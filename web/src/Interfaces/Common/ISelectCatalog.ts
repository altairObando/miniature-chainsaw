import { ICallBack } from '../../Interfaces/Common/ISearchable';
import { type FormInstance } from 'antd';
import { type Rule } from 'antd/es/form';
export interface ISelectCatalog extends ICallBack {
    catalog: string;
    filterValues: string;
    itemName: string;
    itemLabel?: string | undefined;
    rules?: Array<Rule> | undefined
}