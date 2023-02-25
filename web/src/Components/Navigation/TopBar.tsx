import React from 'react';
import { Col, Row, Switch, Space, Avatar } from 'antd';
import { IChangeTheme } from '../../Interfaces/ICollapseEvent';
import logo from '../../assets/react.svg';
import { Link } from 'react-router-dom'
export const CustomTopBar : React.FC<IChangeTheme> = ( props )=>{
    
    const onSwitchChange = ( checked : boolean )=> {
        props.setTheme( checked ? 'dark' : 'light')
    }

    return <Row>
        <Col span={ 18 } style={{ justifyContent:'start', alignItems: 'center', display: "flex"}}>
            <Space>
                <Link to='/'>                
                    <Avatar src={ logo } />
                </Link>
                <span>Web Core </span>
            </Space>

        </Col>
        <Col span={ 6 } style={{ justifyContent: 'end', alignItems: 'center', display: 'flex' }}>
            <Space>
                <span> Set theme </span>
                <Switch  
                    checkedChildren="Dark"
                    unCheckedChildren="Light"
                    onChange={ onSwitchChange }/>
            </Space>
        </Col>
    </Row>
}