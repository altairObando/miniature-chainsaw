import { ColumnSettings } from "handsontable/settings";
export interface ICatalogTableBuilder {
    colHeaders: Array<string>;
    columns: Array<ColumnSettings>
}