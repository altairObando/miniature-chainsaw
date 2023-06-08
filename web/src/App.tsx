import React from 'react';
import { MenuTheme } from 'antd';
import CustomLayout from './Components/Navigation/CustomLayout';
import { GlobalProvider } from './Context/UserContext';
import 'handsontable/dist/handsontable.full.min.css';

function App() {
  const [ theme, setTheme] = React.useState<MenuTheme>('light');

  return <>
   <GlobalProvider>
    <CustomLayout 
        theme={ theme } 
        setTheme={ setTheme} />
   </GlobalProvider>
  </>
}

export default App
