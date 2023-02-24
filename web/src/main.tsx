
import { ConfigProvider } from 'antd'
import { RouterProvider } from 'react-router-dom';
import { Router } from './router';
import ReactDOM from 'react-dom/client'

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  //  <React.StrictMode>
      <ConfigProvider>
        <RouterProvider router={ Router } />
        {/* <App /> */}
      </ConfigProvider>    
  // </React.StrictMode>,
)
