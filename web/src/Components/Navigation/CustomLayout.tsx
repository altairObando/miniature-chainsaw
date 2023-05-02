import React from 'react'
import { Button, Checkbox, Form, FormInstance, Input, Layout } from 'antd';
import { Outlet } from "react-router-dom";
import { SideBar } from './SideBar';
import { CustomFooter } from './CustomFooter';
import { CustomTopBar } from './TopBar';
import { ITheme } from '../../Interfaces/ITheme';
import { UserOutlined, KeyOutlined, DeploymentUnitOutlined } from '@ant-design/icons';
import { useLogin } from '../../hooks/useLogin';
const { Header, Content } = Layout;

const headerStyle : React.CSSProperties = {
  color: '#fff',
  backgroundColor: '#607d8b',
  height: 64,
  textAlign: 'center'
}

const loginStyle : React.CSSProperties ={
  display:'flex', 
  flexDirection:'row', 
  alignItems:'center', 
  justifyContent:'center', 
  minHeight:'100vh',
  height:'100%',
  backgroundColor:'white'
}

const MAX_MARGIN = '205px',
        MIN_MARGIN = '85px';

const GetToken = (): string | null => sessionStorage.getItem('coreToken') || localStorage.getItem('coreToken');

const CustomLayout: React.FC<ITheme> = ({ theme, setTheme }) => {
  const [ collapsed, setCollapsed ] = React.useState(false);
  const [ contentMargin, setContentMargin ] = React.useState('200px');
  const [ userToken, setUserToken ] = React.useState<string | null>( GetToken() );
  React.useEffect( () => {
    let newMargin = collapsed ? MIN_MARGIN : MAX_MARGIN;
    setContentMargin(newMargin);
  });

  if(typeof userToken === 'undefined' || userToken === null){
    const [ form ]  = Form.useForm();
    const handleLogin =( event: any )=>{
      event.preventDefault();
      const [ jwt, isLoading ] = useLogin( form.getFieldsValue() )
      console.log(jwt);
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
        <Form.Item initialValue={true} valuePropName='checked'>
          <Checkbox> Remember me</Checkbox>
          <a href='#'> Forgot password</a>
        </Form.Item>
        <Button type='primary' htmlType='submit' style={{ width: '100%' }} >
          Log in
        </Button>
      </Form>
    </Layout>
  }

  return <Layout style={{ minHeight: '100vh' }} >
    <Header style={ headerStyle }> 
      <CustomTopBar setTheme={ setTheme }  />
    </Header>
    <Layout>
      <Layout>
        <SideBar 
          collapsed={ collapsed } 
          setCollapsed={ setCollapsed }
          theme={ theme } />
        <Content style={{ marginLeft: contentMargin, minHeight: '80vh'  }}>
          <Outlet />
        </Content>
      </Layout>
      <CustomFooter/>
    </Layout>
  </Layout>
}

export default CustomLayout