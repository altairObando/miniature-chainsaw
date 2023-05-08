import React from 'react';
import axios from 'axios';
import { Config } from '../Util/Constants';

type IUserLogin = {
    userName:  string,
    password: string,
    remember: boolean
}
type LoginResponse =  {
    ok : boolean,
    token: string | null
};

export const useLogin = async ( params: IUserLogin ) : Promise<LoginResponse>=>{
    try {
        const response = await  axios.post(Config.APILOGIN, params )
        return {
            ok: response.data.statusCode == 200,
            token : response.data.statusCode == 200 ? response.data.value.accessToken : null
        } satisfies LoginResponse
    } catch (error) {
        console.log(error)
        return {
            ok: false,
            token: null
        }
    }
}

