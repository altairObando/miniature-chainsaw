export interface IServerResponse<T> {
    input: IServiceRequest,
    output: IOutputResponse<T>,
}

export interface IServiceRequest{
    command: string,
    operation: string,
    entity: string,
    fields: string,
    filter: string
}
export interface IOutputResponse<T> {
    status : string,
    statusDescription : string,
    results : Array<T>
}