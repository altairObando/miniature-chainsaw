import React from 'react';
import { PageHeader } from '../../Components/Navigation/PageHeader';
import { UserOutlined, SearchOutlined } from '@ant-design/icons'
import { ListOfContacts } from '../../Components/Contact/ListOfContacts';
import { FilterDrawer } from '../../Components/Contact/FilterDrawer';
import { Button } from 'antd';
export const Index: React.FC = ()=> {
    const [openFilter, setOpenFilter] = React.useState(false);
    const [ filter, setFilter ] = React.useState('');
    const onFilterClick    = () => setOpenFilter(true);
    const onFilterCallback = ( response: string ) =>{
        setFilter(response);
        setOpenFilter(false)
    }

    return <>
        <PageHeader 
            title='Contacts' 
            subTitle='' 
            icon={ <UserOutlined /> }
            actions={[ 
                <Button key='filterButton' onClick={ onFilterClick } icon={ <SearchOutlined /> } type='primary' > Filter </Button> 
            ]}   />
        <ListOfContacts 
            filter={ filter } 
            fields={ `` }/>
        <FilterDrawer 
            callback={ onFilterCallback } 
            visible={ openFilter }/>
    </>
}