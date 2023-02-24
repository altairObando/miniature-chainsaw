import { Avatar, Card, Row, Col } from 'antd';
import { AntDesignOutlined } from '@ant-design/icons'
import { IPageHeader } from '../../Interfaces/Pages/IPageHeader';



const styles = {
    container:{
        margin: '1rem', 
        height: '6rem'
    },
    titulo: {
        fontSize : '1.2rem'
    },
    subTitulo: {
        fontSize: '1rem'
    },
    crudActions: {
        display:'flex', 
        justifyContent: 'flex-end'
    }
}

export const PageHeader: React.FC<IPageHeader> = (props) =>{
    return <Card style={ styles.container }>
        <Row>
            <Col span={ 1 }>
                <Avatar icon={  props.icon ||  <AntDesignOutlined /> } size="large"  />
            </Col>
            <Col span={8}>
                <Row> <span style={styles.titulo}><strong> { props.title } </strong> </span> </Row>
                <Row><span style={styles.subTitulo}> { props.subTitle } </span></Row>
            </Col>
            <Col span={8}>
                {
                    props.bpmActions
                }
            </Col>
            <Col span={7} style={ styles.crudActions }>
                {
                    props.actions
                }
            </Col>
        </Row>
    </Card>
}