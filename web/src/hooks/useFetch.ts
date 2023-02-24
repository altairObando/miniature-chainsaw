import React  from 'react';

export const useFetch = ( url : string ) =>{
    const [ data, setData ] = React.useState([]);
    React.useEffect( () => {
        fetch( url)
        .then( res => res.json())
        .then( val => setData(val));
    }, [url]);

    return [data];
}