import { createBrowserRouter, useParams } from 'react-router-dom';
import App from './App';
import React from 'react';
// Contact import 
import { Index as ContactIndex } from './Pages/Contacts/Index';
import { AddOrUpdate } from './Pages/Contacts/AddOrUpdate';
import { Login } from './Pages/Auth/Login';
import { LoginLoader } from './Components/Common/LoginLoader';
import { Index as CatalogIndex } from './Pages/Catalogs/Index';


const TestPage : React.FC = ()=>{
    const { pageName } = useParams();
    return <div>
        Valor del parametro { pageName }
</div>
}


export const Router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        loader: LoginLoader,
        children: [
            {
                path: 'Contacts',
                element: <ContactIndex />,
            },
            {
                path: 'Contacts/addOrUpdate/:contactId',
                element: <AddOrUpdate />
            },
            {
                path: 'Config',
                element: <CatalogIndex />
            }
        ],
    },{
        path: '/Login',
        element: <Login />
    }
])