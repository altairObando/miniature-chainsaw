import { Button, Form, Input, InputNumber , Radio, Space, DatePicker } from "antd";
import { UndoOutlined, SearchOutlined } from '@ant-design/icons'
import React, { useState } from "react";
import type { RadioChangeEvent } from 'antd';
import { ICallBack } from "../../Interfaces/Common/ISearchable";

const genders = [
    { label: 'None', value: '' },
    { label: 'Male', value: 'M' },
    { label: 'Female', value: 'F' },
]

export const FilterForm : React.FC<ICallBack> = (props) =>{
    const [ form ] = Form.useForm();
    const [ gender, setGender] = useState('');
    const { Item } = Form;

    const onResetClick = () => {
        form.resetFields();
        onSearchClick();
    };
    
    const onChangeGender = ({ target: { value } }: RadioChangeEvent) => {
        setGender(value);
    };

    const onSearchClick = () => {
        props.callBack(buildQuerParams())
    }

    const GetISODate = (date: string) => new Date(date).toISOString().split('T')[0];

    const buildQuerParams = () => {
        let formValues  = form.getFieldsValue();
        formValues['middleName'] = formValues.name;
        let q = Object.keys(formValues)
              .filter( key => typeof formValues[key] !== 'undefined' && formValues[key] )
              .map( key => key === 'birth' ?  `${ key } = '${ GetISODate(formValues[key]) }'` : `${ key } = '${ formValues[key] }'`)
              .join(' OR ');

        return q;
    }


    return <>
        <Space>
            <Button icon={ <UndoOutlined />  } onClick={ onResetClick } > Reset Fields</Button>
        </Space>
        <Form
            style={{ marginTop: '0.5rem'}}
            layout='vertical'
            form={ form }>
            <Item name='id' label='Id'>
                <InputNumber name='id' id='id' />
            </Item>
            <Item name='nif' label='NIF'>
                <Input name='nif' id='nif' />
            </Item>
            <Item name='name' label='Names'>
                <Input name='name' id='name'/>
            </Item>
            <Item name='surname1' label='Last names'>
                <Input name='surname1' id='surname1' />
            </Item>
            <Item name='gender' label='Gender'>
                <Radio.Group options={ genders } optionType='button' onChange={ onChangeGender } value={ gender } />
            </Item>
            <Item name='birth' label='Birth Date'>
                <DatePicker name='birth' id='birth' />
            </Item>
            <Item>
                <Button type='primary' htmlType='button' icon={ <SearchOutlined /> } onClick={ onSearchClick} >
                    Search 
                </Button>
            </Item>
        </Form>
    </>
} 