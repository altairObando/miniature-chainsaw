import { ICatalogConfig } from '../../Interfaces/Common/ICatalogConfig';


export const CatalogConfig: Array<ICatalogConfig> = [
    { 
        key: 'MaritalStatusSrvCatalog',
        label:'Marital Status',
        config: {
            colHeaders: ['Id','Code','Name', 'Active'],
            columns: [
                { data: 'Id', type: 'text', readOnly: true },
                { data: 'Code', type: 'text' },
                { data: 'Name', type: 'text' },
                { data: 'Active', type: 'text' },
            ],
            schema: {
                Id: null,
                Code: null,
                Name: null,
                Active: null
            }
        }
    },
    { 
        key: 'CountrySrvCatalog',
        label:'Country',
        config: {
            colHeaders: ['Id','Code','Nombre', 'Active'],
            columns: [
                { data: 1, type: 'text', readOnly: true },
                { data: 2, type: 'text' },
                { data: 3, type: 'text' },
                { data: 4, type: 'text' },
            ],
            schema: ['Id','Code','Name', 'Active']
        }
    },
]