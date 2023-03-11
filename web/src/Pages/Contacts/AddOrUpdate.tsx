import React, { useEffect, useState } from "react";
import { PageHeader } from '../../Components/Navigation/PageHeader';
import { UserOutlined, SaveFilled, UndoOutlined, BookOutlined, PaperClipOutlined } from '@ant-design/icons';
import { Button } from 'antd';
import { CustomTabs } from "../../Components/Common/CustomTabs";
import { ContactForm } from "../../Components/Contact/ContactForm";
import { useParams } from "react-router-dom";
import { saveContact, useContact } from "../../hooks/useContact";
import { IContactDto } from "../../Interfaces/Contacts/IContactDto";


export const AddOrUpdate: React.FC =() => {

    const { contactId } = useParams();
    const [ selectedContact ] = useContact({ fields:'*', filter: `id=${ contactId }` });
    const [ initialValues, setInitial ] = useState<IContactDto>()

    const resetFields =()=> window.contactForm.resetFields();
    const saveOrUpdateContact = async()=>{
        const data = window.contactForm.getFieldsValue();
        const response = await saveContact(data);
        const { output:{ results, status, statusDescription } } = response;
        const [ newContact ] = results;
        if(typeof newContact !== 'undefined' && newContact !== null)
            setInitial(newContact);

        if(status === 'Ok')
            window.showSuccess(statusDescription);
        if(status !== 'Ok')
            window.showError(statusDescription, 10);
    }

    useEffect(()=>{
        setInitial(selectedContact[0]);
    },[ selectedContact ])


    return <>
    <PageHeader 
            title={ typeof initialValues !== 'undefined' ? `${initialValues.name} ${ initialValues.surname1}`.toUpperCase() : 'New Contact' }
            icon={ <UserOutlined /> }
            actions={[
                <Button key='resetButton' 
                    onClick={ resetFields } 
                    icon={ <UndoOutlined /> } 
                    type='default' > Reset 
                </Button>,
                <Button 
                    key='addNewButton' 
                    onClick={ saveOrUpdateContact } 
                    icon={ <SaveFilled /> } 
                    type='primary'>
                    Save
                </Button>,
                
            ]}/>
    <CustomTabs 
        active='1'
        childrens={[
        { 
            key : '1',
            label: <span> <BookOutlined /> Basic Information </span>,
            children: <ContactForm { ...selectedContact[0]} />,
        },
        { 
            key : '2',
            label: <span> <PaperClipOutlined /> Addresses </span>,
            children: <h3> Formulario 2</h3>
        },
    ]}  />
    </>
}