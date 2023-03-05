import React, { useState } from 'react';
import { ICatalog } from '../Interfaces/Common/ICatalog';
import { ISearchCatalog } from '../Interfaces/Common/ISearchable';
import { IServerResponse } from "../Interfaces/Server/IServerResponse";
import { Config } from "../Util/Constants";


export const useCatalog =( options: ISearchCatalog )=>{
    const [ data, setData] = useState<Array<ICatalog>>([]);
    const [ isLoading, setIsLoading] = useState(true);

    const config = {
        operation: 'GET',
        command: options.catalog,
        filter: options.filter, 
        fields: options.fields
    }
    const request = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(config)
    }
    React.useEffect( () => {
        setIsLoading( true );
        
        fetch( Config.APISERVER, request )
        .then( res => res.json())
        .then(( data : IServerResponse<ICatalog> ) => {
            setData( data.output.results )
            setIsLoading( false )
        })
    }, [ options.catalog, options.filter ]);

    return [data, isLoading] as const;
}