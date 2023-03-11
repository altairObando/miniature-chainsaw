import React, { useState } from "react";
import { ISearch } from "../Interfaces/Common/ISearchable";
import { IContactDto } from "../Interfaces/Contacts/IContactDto";
import { IServerResponse } from "../Interfaces/Server/IServerResponse";
import { Config } from "../Util/Constants";

const CONTACTS = 'ContactSrv';

export const useContact = ( optionProps : ISearch )  => {
    const [ contact, setContact ] = React.useState<Array<IContactDto>>( [] );
    const [ isLoading, setIsLoading] = React.useState(true);
    const request = {
        operation: 'GET',
        command: CONTACTS,
        filter: optionProps.filter, 
        fields: optionProps.fields
    }

    const options = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    }
    

    React.useEffect( () => {
        setIsLoading( true );
        
        fetch( Config.APISERVER, options )
        .then( res => res.json())
        .then(( data : IServerResponse<IContactDto> ) => {
            setContact( data.output.results )
            setIsLoading( false )
        })
    }, [ optionProps.filter, optionProps.fields ])
    return [ contact, isLoading ] as const;
}

export const saveContact = async(data: IContactDto ) =>{
    const operation = data.id > 0 ? 'UPDATE' : 'ADD';
    const request = {
        operation,
        command: CONTACTS,
        Entity: JSON.stringify(data)
    }
    const options = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    }

    try {
        const response = await fetch( Config.APISERVER, options );
        const result   = await response.json();
        return result; 
    } catch (error) {
        return error;
    }
}