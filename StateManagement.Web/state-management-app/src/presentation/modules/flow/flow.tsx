
import React, { FC, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { FlowStateTask, Task } from './models';
import { FlowService, TaskService } from '../../../infrastructure/services';
import { Button } from 'react-bootstrap';

interface FlowProps {
}

export const Flow: FC<FlowProps> = () => {
  const [flowStates, setFlowStates] = useState(new Array<FlowStateTask>());

  const { id } = useParams();

  useEffect(() => {
    FlowService.getStates(id)
      .then((response: any) => {
        if (response && response.data && response.data.length > 0) {
          setFlowStates(response.data);
        }
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }, [id]);

  const moveNextState = (taskId: number) => {
    TaskService.moveNext(id)
      .then((response: any) => {
        FlowService.getStates(id)
          .then((response: any) => {
            if (response && response.data && response.data.length > 0) {
              setFlowStates(response.data);
            }
          })
          .catch((e: Error) => {
            console.log(e);
          });
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }

  const movePreviousState = (taskId: number) => {
    TaskService.movePrevious(id)
      .then((response: any) => {
        FlowService.getStates(id)
          .then((response: any) => {
            if (response && response.data && response.data.length > 0) {
              setFlowStates(response.data);
            }
          })
          .catch((e: Error) => {
            console.log(e);
          });
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }

  return (
    <>
      <h1>Flow Detail</h1>
      {flowStates && flowStates.length > 0 && flowStates.map((fst: FlowStateTask) =>
        <div key={fst.id}>
          <h3 style={{ color: "red" }}>State Name: {fst.state.name}</h3>
          <h3>State Order: {fst.order}</h3>
          {fst.tasks && fst.tasks.length > 0 && fst.tasks.map((t: Task) =>
            <div className="row">
              <h4 style={{ color: "green" }}>Task Name: {t.name}</h4>
              <Button onClick={() => { movePreviousState(t.id) }}>Move Previous State</Button>
              <Button onClick={() => { moveNextState(t.id) }}>Move Next State</Button>
            </div>
          )}
        </div>
      )
      }
    </>
  );
};

export default Flow;