import React from 'react';
import { HotTable } from '@handsontable/react';
import { registerAllModules } from 'handsontable/registry'  
import { ICatalogConfig } from '../../Interfaces/Common/ICatalogConfig';
import { ICallBack } from '../../Interfaces/Common/ISearchable';

registerAllModules();

interface ICustomGrid {
    config: ICatalogConfig;
    data: Array<any>,
    callback: Function
}


export const GridCatalog: React.FC<ICustomGrid> =( { config, data, callback })=>{
    const hotRef = React.useRef<HotTable>(null);

    React.useEffect(()=>{
        const instance = hotRef?.current?.hotInstance ?? null;
        if(instance === null)
            return;
        instance.loadData(data);
    },[ data ]);

    const handleSave =()=>{
        const instance = hotRef?.current?.hotInstance ?? null;
        if(instance === null)
            return;

        if(typeof callback == 'function')
            callback(instance?.getData()??{});
    }


    return <HotTable 
        ref={ hotRef }
        columns={ config?.config?.columns ?? []}
        colHeaders={ config?.config?.colHeaders ?? []}
        licenseKey='non-commercial-and-evaluation'
        />
}