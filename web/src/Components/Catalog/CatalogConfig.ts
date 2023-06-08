import { ICatalogConfig } from '../../Interfaces/Common/ICatalogConfig';


export const CatalogConfig: Array<ICatalogConfig> = [
    { 
        key: 'MaritalStatus',
        label:'Marital Status',
        config: {
            colHeaders: ['Id','Code','Name', 'Active'],
            columns: [
                { data: 1, type: 'numeric', readOnly: true },
                { data: 2, type: 'text' },
                { data: 3, type: 'text' },
                { data: 4, type: 'checkbox' },
            ]
        }
    },
    { 
        key: 'Country',
        label:'Country',
        config: {
            colHeaders: ['Id','Code','Name', 'Active'],
            columns: [
                { data: 1, type: 'numeric', readOnly: true },
                { data: 2, type: 'text' },
                { data: 3, type: 'text' },
                { data: 4, type: 'checkbox' },
            ]
        }
    },
]