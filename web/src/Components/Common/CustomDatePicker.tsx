import { Select, Space, Form } from 'antd';
import React, { useState, useEffect } from 'react'
import { ICustomDatePicker } from '../../Interfaces/Common/ICustomDatePicker';

const getMonthOptions = () => Array.from({ length: 12  }, (_, i) : ISelectRecord => ({ value: i, label: (i + 1).toString().padStart(2,'0') }));
const getYearsOptions = () => Array.from({ length: 100 }, (_, i) : ISelectRecord => ({ value: new Date().getFullYear() - i, label: (new Date().getFullYear() - i).toString() }));

interface ISelectRecord {
    value: number,
    label: string
}

const styles={
  spaceContainer : {
    width: '100%', 
    display:'flex'
  },
  selectChild: {
    minWidth:'6rem', 
    width:'auto'
  }
}


export const CustomDatePicker: React.FC<ICustomDatePicker> = ({ callBack, itemLabel, itemName }) => {
    const [ year , setYear  ] = useState<number | undefined>();
    const [ month, setMonth ] = useState<number | undefined>();
    const [ day  , setDay   ] = useState<number | undefined>();    
    const [ dayOptions, setOptions] = useState<Array<ISelectRecord>>([]);
    const form = Form.useFormInstance();
    const customValue = Form.useWatch(itemName, form);

    useEffect(()=> {
        const date = new Date(year?? 0,(month ?? 0) + 1, 0 );
        const newOptions = Array.from({ length: date.getDate() }, (_, i) : ISelectRecord => ({ value: i + 1, label: (i + 1).toString().padStart(2,'0') }));
        setOptions( newOptions );
        if(day && day > date.getDate())
          setDay(date.getDate());
    }, [ month ]);


    useEffect(()=>{
      try{
        if(typeof customValue === 'undefined')
          return;
        const fecha = new Date(customValue);
        setYear(fecha.getFullYear());
        setMonth(fecha.getMonth())
        setDay(fecha.getDate());
        console.log('changed birth')
      }catch(error){
        console.log(error)
      }     
    },[ customValue ])

    const filterOption = (input: any, option: any): boolean => typeof option==='undefined' || option.label.toLowerCase().indexOf(input.toLowerCase()) >= 0;
    
  return <Form.Item name={ itemName } label={ itemLabel }>
    <Space style={ styles.spaceContainer }>
      <Select 
        id='yearSelect' 
        allowClear 
        style={ styles.selectChild }
        options={ getYearsOptions() } 
        value={ year  } 
        onChange={ (value: number) => setYear ( value )} 
        filterOption={ filterOption } 
        />
      <Select 
        showSearch 
        id='monthSelect'
        allowClear 
        style={ styles.selectChild }
        options={ getMonthOptions() } 
        value={ month } 
        onChange={ (value: number) => setMonth( value )}
        filterOption={ filterOption } 
        />
      <Select 
        showSearch 
        id='daySelect'  
        allowClear 
        style={ styles.selectChild }
        options={ dayOptions        } 
        value={ day } 
        onChange={ (value: number) => {
          setDay  ( value );
          const fecha = new Date(Number(year), Number(month), Number(value));
          form.setFieldsValue({[itemName]: fecha });
        }} 
        filterOption={ filterOption } 
        />
    </Space>
  </Form.Item> 
}