import React, { useEffect, useState } from 'react';
import { IDrawerFilter } from '../../Interfaces/Common/IDrawerFilter';
import { Drawer } from 'antd';
import { FilterForm } from './FilterForm';


export const FilterDrawer : React.FC<IDrawerFilter> = ( props )=>{    
    const filterCallBack = ( response : string) =>{
        props.callback(response);
    }

    const onClose =()=> props.callback(null);


    return <Drawer
        title='Search Contact by'
        placement='right'
        closable={ true }
        open={ props.visible }
        onClose={onClose}
        >
            <FilterForm callBack={ filterCallBack } />
        </Drawer>
}
