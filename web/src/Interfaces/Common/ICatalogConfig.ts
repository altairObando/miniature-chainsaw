import { ICatalogTableBuilder } from '../../Interfaces/Common/ICatalogTableBuilder';

export interface ICatalogConfig {
    key?: string,
    label?: string,
    config?: ICatalogTableBuilder
}