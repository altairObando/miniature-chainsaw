import React from 'react';
import { MenuTheme } from 'antd';
import CustomLayout from './Components/Navigation/CustomLayout';
function App() {
  const [ theme, setTheme] = React.useState<MenuTheme>('light');
  return <>
    <CustomLayout 
      theme={ theme } 
      setTheme={ setTheme} />
  </>
}

export default App
