import type { TabsProps } from 'antd';

export interface ITabChildrens{
    type? : TabsProps['type'];
    childrens: TabsProps['items'];
    active: TabsProps['defaultActiveKey'];
    hideAdd?: TabsProps['hideAdd'];
}