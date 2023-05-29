export class PagedResult<TEntity>{
    success?:boolean;
    currentPage?:number;
    totalCountOfRecords?:number;
    recordsCountOfPerPage?:number;
    pageOfStart?:number;
    pageOfEnd?:number;
    nextPageUrl?:string;
    items?:Array<TEntity>;
    totalCountOfPages?:number;
}