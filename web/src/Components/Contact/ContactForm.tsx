import React, { useState } from 'react';
import { Button, Col, Form, Input, Radio, Row } from 'antd';
import { CustomDatePicker } from '../Common/CustomDatePicker';
import { SelectCatalog } from '../Common/SelectCatalog';

const options = [
    { label: 'Male', value: 'M' },
    { label: 'Female', value: 'F' },
];

declare global{
    interface Window {
        contactForm : any
    }
}


export const ContactForm: React.FC =()=>{
    const [ form ] = Form.useForm();
    window.contactForm = form;
    const { Item } = Form;
    const onBirthChange =( { year, month, day }: any )=>{
        try {
            const newDate = new Date(year, month, day);
            form.setFieldsValue({ birth: newDate });
        } catch (error) {
            form.setFieldsValue({ birth: null });
        }
    }
    const onGenderChange =(value: string)=>{
        form.setFieldsValue({ gender: value })
    }
    const onSaveChanges=()=>{
        console.log(form.getFieldsValue());
        form.validateFields();
    }
    
    return <>
        <Form
            id='ContactForm'
            name='ContactForm'
            form={ form }
            layout='vertical'
            labelCol={{ span: 12 }}
            wrapperCol={{ span: 22  }}
            initialValues={{ 
                id: 0, 
                nationality:'NI'
            }}>
            <Row>
                <Item name='id'>
                    <Input type='hidden'/>
                </Item>
                <Col span={ 8 }>                    
                    <Item name='nif' label='NIF' rules={[{ required: true, message:'NIF is required' }]}>
                        <Input id='nif'/>
                    </Item>
                    <Item name='name' label='First Name'>
                        <Input id='name' />
                    </Item>
                    <Item name='middleName' label='Middle Name'>
                        <Input id='middleName' />
                    </Item>
                    <Item label='Last Name'>
                        <Input name='surname1' id='surname1'/>
                    </Item>
                    <Item name='surname2' label='Second Last Name' >
                        <Input id='surname2'/>
                    </Item>
                </Col>
                <Col span={ 8 }>
                    <SelectCatalog 
                        catalog='Country'
                        filterValues='active=1'
                        itemName='nationality'
                        itemLabel='Nationality'
                        rules={[{ required: true, message: 'Contact origin is required'}]}
                    />
                    <SelectCatalog 
                        catalog='MaritalStatus'
                        filterValues='active=1 and x-1ss'
                        itemName='maritalStatus'
                        itemLabel='Marital Status'
                    />
                    <Item name='email' label='Email address'>
                        <Input type='email' />
                    </Item>
                    <Item name='gender' label='Gender'>
                        <Radio.Group                             
                            id='gender'
                            buttonStyle='solid'
                            options={ options }
                            onChange={ ({ target: { value }}) => onGenderChange(value) }
                            optionType='button' />
                    </Item>
                    <CustomDatePicker 
                        itemName='birth'
                        itemLabel='Birthday'
                        callBack={ onBirthChange } />  
                </Col>
            </Row>
            <Button onClick={ onSaveChanges }>
                Save Changes
            </Button>
        </Form>
    </>
}