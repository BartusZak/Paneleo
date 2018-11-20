export interface GenericList<T> {
  totalCount: number;
  rows: Row<T>[];
}

export interface Row<T> {
  row: T;
  canRemove: boolean;
  canEdit: boolean;
}
