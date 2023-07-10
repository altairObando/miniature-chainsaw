import React, { useState, useEffect, useRef } from 'react';
import Handsontable from 'handsontable';
import { Config } from '../../Util/Constants';
import { CatalogConfig } from './CatalogConfig';
import { Button, Form, Select } from 'antd';
import { ICatalogConfig } from '../../Interfaces/Common/ICatalogConfig';
import { HotTable } from '@handsontable/react';
import AxiosInstance from '../../Util/AxiosInstance';
import { usePostFetch } from '../../hooks/useFetch';

interface RowData {
    [field: string]: string | number;
}

interface Schema {
    field: string;
    type: string;
}

export const GridCatalog: React.FC = () => {
    const [ catalog, setCatalog ] = useState<ICatalogConfig | null>();
    const hotInstance = useRef<Handsontable | null>(null);
    const onSelectCatalogChange =( newValue : string )=>{
        let item = CatalogConfig.find( item => item.key == newValue);
        setCatalog(item);
    }
    
    const onSaveChanges=()=>{
        
    }

    const loadCatalog =()=>{
        const request = {
            operation: 'GET',
            command: catalog?.key,
            filter: '1=1', 
            fields: ''
        };
        usePostFetch(request).then( response => console.log(response))
    }

    useEffect(()=>{
        if(catalog === null || !catalog?.key)
            return;
        loadCatalog();
    },[ catalog ])

    return <>
        <Form layout='inline'>
            <Form.Item name='catalog' label='Select catalog' id='catalog'>
                <Select
                    options={ CatalogConfig.map( item => ({ label: item.label, value: item.key })) }
                    onChange={ onSelectCatalogChange } 
                    showSearch
                    style={{ width: 400 }}
                />            
            </Form.Item>
            <Form.Item>
                <Button type='primary' onClick={ onSaveChanges }> Save Changes</Button>
            </Form.Item>
        </Form>
        <HotTable
         dataSchema={ catalog?.config?.schema }
         colHeaders={ catalog?.config?.colHeaders }
         columns={ catalog?.config?.columns }
         height={ 'auto' }
         width={ 'auto' }
         dropdownMenu={ true }
         licenseKey='non-commercial-and-evaluation'
        />
        
    </>
}