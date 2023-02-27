import React from "react";
import { PageHeader } from '../../Components/Navigation/PageHeader';
import { UserOutlined, SaveFilled, UndoOutlined, BookOutlined, PaperClipOutlined } from '@ant-design/icons';
import { Button } from 'antd';
import { CustomTabs } from "../../Components/Common/CustomTabs";
export const AddOrUpdate: React.FC = ()=> {
    return <>
    <PageHeader 
            title='Contacts' 
            subTitle='' 
            icon={ <UserOutlined /> }
            actions={[
                <Button key='filterButton' 
                    // onClick={ onFilterClick } 
                    icon={ <UndoOutlined /> } 
                    type='default' > Reset 
                </Button>,
                <Button 
                    key='addNewButton' 
                    // onClick={ onNewContactClick } 
                    icon={ <SaveFilled /> } 
                    type='primary'>
                    Save
                </Button>,
                
            ]}/>
    <CustomTabs 
        active="1"
        childrens={[
        { 
            key : '1',
            label: <span> <BookOutlined /> Basic Information </span>,
            children: <h1> Formulario 1</h1>,
        },
        { 
            key : '2',
            label: <span> <PaperClipOutlined /> Addresses </span>,
            children: <h3> Formulario 2</h3>
        },
    ]}  />
    </>
}