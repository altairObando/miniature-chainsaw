import React from 'react';
import { PageHeader } from '../../Components/Navigation/PageHeader';
import { UserOutlined } from '@ant-design/icons'
import { ListOfContacts } from '../../Components/Contact/ListOfContacts';
export const Index: React.FC = ()=> {
    return <>
        <PageHeader title='Contacts' subTitle='' icon={ <UserOutlined /> }  />
        <ListOfContacts 
            filter={ `` } 
            fields={ `` }/>
    </>
}