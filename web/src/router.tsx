import { createBrowserRouter, useParams } from 'react-router-dom';
import App from './App';
import React from 'react';
// Contact import 
import { Index as ContactIndex } from './Pages/Contacts/Index';
import { ContactForm } from './Components/Contact/ContactForm';
import { AddOrUpdate } from './Pages/Contacts/AddOrUpdate';


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
        children: [
            {
                path: 'Contacts',
                element: <ContactIndex />,
            },
            {
                path: 'Contacts/addOrUpdate',
                element: <AddOrUpdate />
            }
        ]
    },
])