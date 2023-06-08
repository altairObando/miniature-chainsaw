export interface IColumnBuilder {
    data: number,
    type: String,
    allowInvalid?: boolean,
    className?: string,
    readOnly?: boolean,
    renderer?: Function
}