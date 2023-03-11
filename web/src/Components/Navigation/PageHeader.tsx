import { Avatar, Card, Row, Col, Space, Button } from 'antd';
import { AntDesignOutlined } from '@ant-design/icons'
import { IPageHeader } from '../../Interfaces/Pages/IPageHeader';
import { CustomBreadcrumb } from './CustomBreadcrumb';


const styles = {
    container:{
        height: '7rem'
    }
}

export const PageHeader: React.FC<IPageHeader> = (props) =>{
    return <Card style={ styles.container }>
        <Row>
            <Col span={ 4 }>
                <Space>
                    <Avatar icon={  props.icon ||  <AntDesignOutlined /> } size="large"  />
                    <span className='titulo'><strong> { props.title } </strong> </span>
                </Space>
            </Col>
            <Col span={5}>
                <span className='titulo'><strong> { props.subTitle } </strong> </span>
            </Col>
            <Col span={8}>
                {
                    props.bpmActions
                }
            </Col>
            <Col span={7} className='crudActions'>
                <Space>
                    {
                        props.actions
                    }
                </Space>
            </Col>
        </Row>
        <Row>
            <CustomBreadcrumb />
        </Row>
    </Card>
}