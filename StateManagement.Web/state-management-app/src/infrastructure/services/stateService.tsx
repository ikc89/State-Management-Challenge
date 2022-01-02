import http from "../common/http-common";

const getAll = () => {
  return http.get<Array<any>>("/state");
};

const get = (id: any) => {
  return http.get<any>(`/state/${id}`);
};

export const StateService = {
  getAll,
  get,
};

export default StateService;