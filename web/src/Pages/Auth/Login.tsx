import React from 'react';
import { Button, Checkbox, Form, Input, Layout, Spin } from 'antd';
import { UserOutlined, KeyOutlined, DeploymentUnitOutlined } from '@ant-design/icons';
import { useLogin } from '../../hooks/useLogin';
const loginStyle : React.CSSProperties ={
    display:'flex', 
    flexDirection:'row', 
    alignItems:'center', 
    justifyContent:'center', 
    minHeight:'100vh',
    height:'100%',
    backgroundColor:'white'
}

export const Login =()=>{
    const [ form ]  = Form.useForm();
    const [ isLoading, setIsLoading ] = React.useState(false);
    // Clear previous token
    //sessionStorage.clear();
    //localStorage.clear();
    const handleLogin = async ( event: any )=>{
      setIsLoading(true)
      event.preventDefault();
      const { ok, token } = await useLogin( form.getFieldsValue() )
      if(!ok){
        window.showError('User/password didnt match');
        setIsLoading(false);
        return;
      }
      // Store Values
      if(form.getFieldValue('remember')){
        sessionStorage.setItem('coreToken', token??'')
      }else
       localStorage.setItem('coreToken', token??'');
      window.location.href = window.location.href.replace('Login','')
      setIsLoading(false)
    }

    return <Layout style={ loginStyle } >      
      <Form onSubmitCapture={ handleLogin } style={{ maxWidth: 500, }} form={ form }>
        <Form.Item style={{ textAlign:'center'}}>
            <DeploymentUnitOutlined />
            <span> Core demo log in</span>
        </Form.Item>
        <Form.Item label='Username' name='userName'>
          <Input prefix={ <UserOutlined /> } placeholder='Username'/>
        </Form.Item>
        <Form.Item label='Password' name='password'>
          <Input type='password' prefix={ <KeyOutlined /> } placeholder='Password'/>
        </Form.Item>
        <Form.Item initialValue={true} valuePropName='checked' name='remember'>
          <Checkbox checked={ true }> Remember me</Checkbox>
          <a href='#'> Forgot password</a>
        </Form.Item>
        <Button type='primary' htmlType='submit' style={{ width: '100%' }} disabled={ isLoading } >
          { isLoading && <Spin spinning={true} />} 
          {' '}
          Log in
        </Button>
      </Form>
    </Layout>
}