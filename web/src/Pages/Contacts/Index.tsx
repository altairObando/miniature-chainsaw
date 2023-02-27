import React from 'react';
import { PageHeader } from '../../Components/Navigation/PageHeader';
import { UserOutlined, SearchOutlined, UserAddOutlined } from '@ant-design/icons'
import { ListOfContacts } from '../../Components/Contact/ListOfContacts';
import { FilterDrawer } from '../../Components/Contact/FilterDrawer';
import { Button } from 'antd';
import { Link } from 'react-router-dom';
export const Index: React.FC = ()=> {
    const [ openFilter, setOpenFilter ] = React.useState(false);
    const [ filter, setFilter ] = React.useState('');
    const onFilterClick    = () => setOpenFilter(true);
    const onFilterCallback = ( response: string ) =>{
        setFilter(response || filter);
        setOpenFilter(false)
    }

    const onNewContactClick = ()=>{
        document.getElementById('goToNewContact')?.click();        
    }

    return <>
        <PageHeader 
            title='Contacts' 
            subTitle='' 
            icon={ <UserOutlined /> }
            actions={[ 
                <Link to='/Contacts/addOrUpdate' className='ant-btn' id='goToNewContact' key='goToNewContact'/>,
                <Button key='addNewButton' onClick={ onNewContactClick } icon={ <UserAddOutlined /> } type='default' >
                    Add new Contact
                </Button>,
                <Button key='filterButton' onClick={ onFilterClick } icon={ <SearchOutlined /> } type='primary' > Filter </Button>,
            ]}/>
        <ListOfContacts 
            filter={ filter } 
            fields={ `` }/>
        <FilterDrawer 
            callback={ onFilterCallback } 
            visible={ openFilter }/>
    </>
}