import React from 'react';
import axios from 'axios';
import { Config } from '../Util/Constants';


type IUserLogin = {
    userName:  string,
    password: string,
    remember: boolean
}


export const useLogin = ( params: IUserLogin ) =>{
    const [ isLoading, setIsLoading] = React.useState(true);
    const [ jwt, setJwt ] = React.useState(null);

    axios.post(Config.APILOGIN, params )
         .then( response => {
            console.log(response);
         })


    return [ jwt, isLoading ] as const;
}

