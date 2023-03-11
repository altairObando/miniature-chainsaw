import React from 'react';
import { HomeOutlined } from '@ant-design/icons';
import { Breadcrumb } from 'antd';
const { Item } = Breadcrumb;

const buildItem = ( path : string, display?: string, icon? : React.ReactElement ) => (<Item href={ path } key={ path }> { icon } { display }</Item>)
const getPathItems = (path: string) : string[] =>{
    const items = path.split('/');
    
    if(items.some(i => Number(i) >= 0)){
        const id = items.pop();
        items[items.length - 1] +=`/${ id }`;
    };

    let current = '';
    return items.map((value, index) =>{
        if(index === 0)
            return '/'
        current += `/${value}`;
        return current;
    });
}


export const CustomBreadcrumb: React.FC =()=>{
    const path = window.location.pathname;
    const pathItems = getPathItems(path);

    return <Breadcrumb style={{ marginTop: '1rem' }}>
    {        
        pathItems.map( (item, index ) => {
            const displayName = index === 0 ? '' : item.split('/').pop()
            const icon = index === 0 ? <HomeOutlined /> : <></> ;
            return buildItem(item, displayName , icon );
        })
    }
    </Breadcrumb>
}
