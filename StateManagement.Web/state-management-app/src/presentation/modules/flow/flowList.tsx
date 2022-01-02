
import React, { FC, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { FlowService } from '../../../infrastructure/services';
import { Flow } from './models';

interface FlowListProps {

}

export const FlowList: FC<FlowListProps> = () => {
  const [flows, setFlows] = useState(new Array<Flow>());

  useEffect(() => {
    FlowService.getAll()
      .then((response: any) => {
        if (response && response.data && response.data.length > 0)
          setFlows(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }, []);

  return (
    <>
      <div>
        <h1>Flows</h1>
        {flows && flows.length > 0 && flows.map((f: Flow) =>
          <div key={f.id}>
            <h3>Flow Name: {f.name}</h3>
            <Link to={`/flows/${f.id}`}>Click to view flow detail</Link>
          </div>
        )}
      </div>
    </>
  );
};

export default FlowList;