import http from "../common/http-common";

const getAll = () => {
  return http.get<Array<any>>("/task");
};

const get = (id: any) => {
  return http.get<any>(`/task/${id}`);
};

const moveNext = (id: any) => {
  return http.post<any>(`/task/${id}/next`);
};

const movePrevious = (id: any) => {
  return http.post<any>(`/task/${id}/previous`);
};

const undo = (id: any) => {
  return http.post<any>("/task/undo");
};

export const TaskService = {
  getAll,
  get,
  moveNext,
  movePrevious,
  undo
};

export default TaskService;