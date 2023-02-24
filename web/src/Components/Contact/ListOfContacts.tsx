import { Empty, Space } from 'antd';
import Table, { ColumnsType } from 'antd/es/table';
import React from 'react';
import { Link } from 'react-router-dom';
import { useContact } from '../../hooks/useContact';
import { ISearch } from '../../Interfaces/Common/ISearchable';
import { IContactDto } from '../../Interfaces/Contacts/IContactDto';


const listColumns : ColumnsType<IContactDto> = [
    {
        key: 'id',
        title: 'Id',
        dataIndex: 'id',
        render: (id) => <a> { id }</a>
    },
    {
        key: 'name',
        title: 'Name',
        dataIndex: 'name'
    },
    {
        key: 'middleName',
        title: 'Middle Name',
        dataIndex: 'middleName'
    },
    {
        key: 'middleName',
        title: 'Last Name ',
        dataIndex: 'surname1',
        render: (_, { surname1, surname2,  }) => {
            return ` ${ surname1} ${ surname2} `.trim()
        } 
    },
    {
        key: 'gender',
        title: 'Gender',
        dataIndex: 'gender',
        render : gender => (gender || 'M').toLocaleUpperCase()
    },
    {
        key: 'phone',
        title: 'Phone number',
        dataIndex: 'phone'
    },
    {
        key: 'birth',
        title: 'Birthday',
        dataIndex: 'birth',
        render: birth => new Date(birth).toISOString().split('T')[0]
    },
    {
        key: 'actions',
        title: 'Actions',
        render: (_, record) => {
            return <Space>
                <Link to={ `AddOrUpdate/${ record.id }` }>
                    View 
                </Link>
                <Link to={ `Delete/${ record.id }` }>
                    Remove
                </Link>
            </Space>
        }
    }
]



export const ListOfContacts : React.FC<ISearch> = (props)=>{
    const [ contacts, isLoading ] = useContact(props);
    return contacts.length == 0 ?
    <Empty />: 
    <Table 
        columns={ listColumns } 
        dataSource={ contacts  } 
        loading={ isLoading }
    />
    
}