import React from 'react'
import { Layout } from 'antd';
import { Outlet, redirect } from "react-router-dom";
import { SideBar } from './SideBar';
import { CustomFooter } from './CustomFooter';
import { CustomTopBar } from './TopBar';
import { ITheme } from '../../Interfaces/ITheme';

const { Header, Content } = Layout;

const headerStyle : React.CSSProperties = {
  color: '#fff',
  backgroundColor: '#607d8b',
  height: 64,
  textAlign: 'center'
}
const MAX_MARGIN = '205px',
        MIN_MARGIN = '85px';
const CustomLayout: React.FC<ITheme> = ({ theme, setTheme }) => {
  const [ collapsed, setCollapsed ] = React.useState(false);
  const [ contentMargin, setContentMargin ] = React.useState('200px');
  
  React.useEffect( () => {
    let newMargin = collapsed ? MIN_MARGIN : MAX_MARGIN;
    setContentMargin(newMargin);
  });

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