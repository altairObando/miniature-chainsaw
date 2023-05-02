import React from 'react';
import { MenuTheme, message } from 'antd';
import CustomLayout from './Components/Navigation/CustomLayout';
import { GlobalProvider } from './Context/UserContext';

declare global{
  interface Window {
      contactForm : any,
      showSuccess : Function,
      showError   : Function,
      showWarning : Function
  }
}


function App() {
  const [ theme, setTheme] = React.useState<MenuTheme>('light');
  const [messageApi, contextHolder] = message.useMessage();
  window.showSuccess = (content: string, duration?: number ) => messageApi.success(content, duration ?? 5 );
  window.showError   = (content: string, duration?: number ) => messageApi.error(content, duration ?? 5 );
  window.showWarning = (content: string, duration?: number ) => messageApi.warning(content, duration ?? 5 );

  return <>
  { contextHolder }
   <GlobalProvider>
    <CustomLayout 
        theme={ theme } 
        setTheme={ setTheme} />
   </GlobalProvider>
  </>
}

export default App
