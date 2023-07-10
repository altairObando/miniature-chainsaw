import React from 'react';
import { GridCatalog } from '../../Components/Catalog/GridCatalog';
export const Index:React.FC =()=>{
  
  const onSaveChanges =( response: any )=>{
    console.log(response);
  }

  return <>
    <GridCatalog />
  </>
}