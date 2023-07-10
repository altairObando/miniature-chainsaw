import React  from 'react';
import { Config } from '../Util/Constants';

export const useFetch = ( url : string ) =>{
    const [ data, setData ] = React.useState([]);
    React.useEffect( () => {
        fetch( url)
        .then( res => res.json())
        .then( val => setData(val));
    }, [url]);

    return [data];
}

export const usePostFetch =( params : object ) => {
    const config = {
        method: 'POST',
        headers : {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${ localStorage.getItem('coreToken') || sessionStorage.getItem('coreToken') }`
        },
        body: JSON.stringify(params)
    }
    return new Promise((resolve, reject)=>{
        fetch(Config.APISERVER, config)
        .then(res => res.json())
        .then(res => resolve(res))
        .catch(res => reject(res))  
    })
}