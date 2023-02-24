import { ReactElement } from 'react'

export interface IPageHeader{
    title : string,
    subTitle: string,
    bpmActions?: ReactElement[] | undefined,
    actions? : ReactElement[] | undefined,
    icon?: ReactElement

}