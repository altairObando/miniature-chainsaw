import React from 'react';
import { Tabs, Card } from 'antd';
import { ITabChildrens } from '../../Interfaces/Common/ITabChildrens';

export const CustomTabs: React.FC<ITabChildrens> = (props)=> (<Card>
    <Tabs 
        defaultActiveKey={ props.active} 
        items={ props.childrens }
        hideAdd={ props.hideAdd }
        type={ props.type }
    />
</Card>
)