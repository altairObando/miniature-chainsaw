import { MenuTheme } from "antd"

export interface ICollapseEvent {
    collapsed : boolean,
    theme : MenuTheme,
    setCollapsed: Function
}

export interface IChangeTheme {
    setTheme : Function
}