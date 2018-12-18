export interface Response<T> {
  errorOccurred: boolean;
  errors: Array<any>;
  successResult: Array<T>;
}
