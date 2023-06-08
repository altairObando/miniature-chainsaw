import React from 'react';
import { GridCatalog } from '../../Components/Catalog/GridCatalog';
import { SelectCatalog } from '../../Components/Catalog/SelectCatalog';
import { ICatalogConfig } from '../../Interfaces/Common/ICatalogConfig';
import { CatalogConfig } from '../../Components/Catalog/CatalogConfig';

export const Index:React.FC =()=>{
  const [ catalog, setCatalog ] = React.useState<ICatalogConfig>(CatalogConfig[0]);
  const [ data, setData ] = React.useState([]);
  const onSelectChange =( newKey: string )=>{
    const [ config ] =  CatalogConfig.filter( item => item.key == newKey);
    setCatalog(config);
  }
  const onSaveChanges =( response: any )=>{
    console.log(response);
  }

  return <>
    <SelectCatalog callBack={ onSelectChange } />
    <GridCatalog config={ catalog } data={ data } callback={ onSaveChanges }/>
  </>
}