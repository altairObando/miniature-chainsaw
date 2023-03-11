import { Select, Form } from 'antd';
import { useCatalog } from '../../hooks/useCatalog';
import { ICatalog } from '../../Interfaces/Common/ICatalog';
import { ISelectCatalog } from '../../Interfaces/Common/ISelectCatalog'

export const SelectCatalog =(props: ISelectCatalog ) => {
    const { Item } = Form;
    const onCatalogChange =(newValue: string | [] )=>{        
        if(typeof props.callBack === 'function')
            props.callBack(newValue);
    }

    const [ options, isLoading ] = useCatalog({ catalog: `${props.catalog}CatalogSrv`, fields:'*', filter: props.filterValues });

  return <Item name={ props.itemName } label={ props.itemLabel } rules={ props.rules }>
    <Select 
      id={ props.catalog } 
      loading={ isLoading }
      onChange={ onCatalogChange }
      options={ options.map((item : ICatalog) => ({ label: item.name, value: item.code })) } 
      showSearch
      filterOption={ (input, option)=> typeof option==='undefined' || option.label.toLowerCase().indexOf(input.toLowerCase()) >= 0 }
      allowClear
      />
  </Item>
}