export interface ISearch{
    filter : string | undefined,
    fields : string | undefined
}
export interface ISearchCatalog extends ISearch {
    catalog: string
}
export interface ICallBack {
    callBack? : Function
}