export interface Response<T> {
  errorOccurred: boolean;
  errors: Array<any>;
  successResult: Array<T>;
}

export interface SingleResponse<T> {
  errorOccurred: boolean;
  errors: Array<any>;
  successResult: T;
}
