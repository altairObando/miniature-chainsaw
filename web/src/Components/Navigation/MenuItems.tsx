import React from 'react';
import type { MenuProps  } from 'antd';
import { Link } from 'react-router-dom';
import { AppstoreOutlined, UserOutlined, UserAddOutlined, SearchOutlined } from '@ant-design/icons';
type MenuItem = Required<MenuProps>['items'][number];



const buildItem = ( label: React.ReactNode, key?: React.Key | null, icon?: React.ReactNode, children?: MenuItem[], type?: 'group' ): MenuItem =>{
    const id = key;
    return { key, icon, children, label, type, id } as MenuItem
}

export const MenuItems : MenuItem[] = [
    buildItem('Contacts', 'contactsMenu', <UserOutlined />, [
        buildItem(<Link to='Contacts'> Contact List </Link>, 'menuContactsIndex', <SearchOutlined /> ),
        buildItem(<Link to='Contacts/addOrUpdate/0'> New Contact </Link>, 'menuContactsForm', <UserAddOutlined/>)
    ]),
    buildItem('Navigation Two', 'sub2', <AppstoreOutlined />, [
        buildItem('Option5', '5'),
        buildItem('Option6', '6'),
        buildItem('Option7', '7'),
        buildItem('Option8', '8'),
        buildItem('Option9', '9'),
    ]),
    buildItem('Navigation Tree', 'sub3', <AppstoreOutlined />, [
        buildItem('Option10', '10'),
        buildItem('Option11', '11'),
        buildItem('Option12', '12'),
    ])
]