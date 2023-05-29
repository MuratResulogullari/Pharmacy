import { CriteriaObject } from "./criteria-object";

export class PagedCriteriaObject extends CriteriaObject{
    currentPage?:number;
    totalCountOfPages?:number;
    totalCountOfRecords?:number;
    recordsCountOfPerPage?:number;
    pageOfStart?:number;
    pageOfEnd?:number;
    searchKey?:string;
    where?:number;
    parameter?:object;
}