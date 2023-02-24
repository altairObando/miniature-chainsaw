import React from 'react'
import { Layout } from 'antd';
export const CustomFooter = () => <Layout.Footer style={{ textAlign: 'center' }}>
 © { new Date().getFullYear() }
</Layout.Footer>