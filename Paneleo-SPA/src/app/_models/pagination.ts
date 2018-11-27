export interface Pagination {
  PageNumber: number;
  PageLimit: number;
}

export class PaginatedResult<T> {
  results: T;
  currentPage: number;
  totalPageCount: number;
  totalItemsCount: number;
}
