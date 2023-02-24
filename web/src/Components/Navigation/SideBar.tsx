import React, { useState } from 'react';
import type { MenuProps  } from 'antd';
import { Menu, Layout } from 'antd';
import { ICollapseEvent } from '../../Interfaces/ICollapseEvent';
import { MenuItems } from './MenuItems';

export const SideBar : React.FC<ICollapseEvent> =( props )=> {
    const [current, setCurrent] = useState('1');

    const onCLick: MenuProps['onClick'] =({ key })=> setCurrent(key);

    return <Layout.Sider collapsible collapsed={ props.collapsed } onCollapse={ (value) => props.setCollapsed(value) }
    style={{
        overflow: 'auto',
        position: 'fixed',
        height: '100vh',
        left: 0,
        top: 64,
        bottom: 0,
        backgroundColor: '#fff'
    }}>
        <Menu
        defaultOpenKeys={['sub1']}
        selectedKeys={[current]}
        mode="inline"
        items={ MenuItems }
        onClick={ onCLick }
        theme={ props.theme }
        style={{ height: '100vh', }} />
    </Layout.Sider>
}