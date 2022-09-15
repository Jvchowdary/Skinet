import { Iproduct } from "./product";

export interface IPagination
{
    pageIndex:number;
    pagesize:number;
    count:number;
    data:Iproduct[];
}