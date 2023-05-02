
import React, { createContext, ReactNode, useState } from 'react';
import { IGlobalContext, IUser } from '../Interfaces/Common/IUser';

export const UserContext = createContext<IGlobalContext | undefined>({} as IGlobalContext);

export const GlobalProvider =({ children }: { children : ReactNode })=>{
    const [ data, setData ] = useState<IUser>({} as IUser);
    return <UserContext.Provider value={{ User: data, setUser: setData }}>
        { children }
    </UserContext.Provider>
}