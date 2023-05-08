
import { ConfigProvider, message } from 'antd'
import { RouterProvider } from 'react-router-dom';
import { Router } from './router';
import ReactDOM from 'react-dom/client';
import './assets/devStyles.css';


declare global{
  interface Window {
      contactForm : any,
      showSuccess : Function,
      showError   : Function,
      showWarning : Function
  }
}

const RootRender = ()=> {
  const [messageApi, contextHolder] = message.useMessage();
  window.showSuccess = (content: string, duration?: number ) => messageApi.success(content, duration ?? 5 );
  window.showError   = (content: string, duration?: number ) => messageApi.error(content, duration ?? 5 );
  window.showWarning = (content: string, duration?: number ) => messageApi.warning(content, duration ?? 5 );

return <>
  { contextHolder }
  <ConfigProvider>
      <RouterProvider router={ Router }/>
    </ConfigProvider>
  </>
}

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <RootRender />
)
