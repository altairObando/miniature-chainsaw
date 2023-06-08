import React from 'react';
import { Select } from 'antd';
import { CatalogConfig } from './CatalogConfig';
import { ICallBack } from '../../Interfaces/Common/ISearchable';


export const SelectCatalog:React.FC<ICallBack> =( props )=>{
    const onCatalogChange=( newValue: string | [])=>{
        if(typeof props.callBack === 'function')
            props.callBack(newValue);
    }

    return <Select 
        id='selectCatalog'
        options={ CatalogConfig.map( item => ({ label: item.label, value: item.key }))}
        onChange={ onCatalogChange }
        showSearch
        />
}