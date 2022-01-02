import State from './state'
import Task from './task'

export interface FlowStateTask {
  id: number;
  order: number;
  state: State;
  tasks: Array<Task>;
}

export default FlowStateTask;