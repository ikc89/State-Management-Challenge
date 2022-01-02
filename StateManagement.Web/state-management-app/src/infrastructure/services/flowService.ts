import { Flow, FlowStateTask } from "../../presentation/modules/flow/models";
import http from "../common/http-common";

const getAll = () => {
  return http.get<Array<Flow>>("/flow");
};

const get = (id: any) => {
  return http.get<Flow>(`/flow/${id}`);
};

const getStates = (id: any) => {
  return http.get<Array<FlowStateTask>>(`/flowstate/${id}`);
}

export const FlowService = {
  getAll,
  get,
  getStates
};

export default FlowService;