import axios from 'axios';
import { Config } from './Constants';

const AxiosInstance = axios.create({
    baseURL: Config.APISERVER,
});

AxiosInstance.interceptors.request.use( async config =>{
    const updatedToken = `Bearer ${ localStorage.getItem('coreToken') || sessionStorage.getItem('coreToken') }`;
    config.headers ={
        'Accept': 'application/json',
        'Authorization': updatedToken
    }
    return config
})

export default AxiosInstance;