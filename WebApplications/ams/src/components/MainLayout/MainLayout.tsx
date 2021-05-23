import React from 'react'
import { Layout, Menu, Breadcrumb } from 'antd';
import './MainLayout.css'
import { Link, Switch, Route } from 'react-router-dom'
import Home from '../../pages/Home/Home';
import ComputersList from '../../pages/Computers/ComputersList';
import IoTSetList from '../../pages/IoTSets/IoTSetsList';
import RoomsList from '../../pages/Rooms/RoomsList';
import UsersList from '../../pages/Users/UsersList';
import History from '../../pages/History/History';


// import Dashboard from '../Dashboard/Dashboard'
// import Regions from '../Regions/Regions'
// import RegionsDetails from '../Regions/Region Details/RegionDetails'
// import Schools from '../Schools/School'
// import SchoolDetails from '../Schools/School Details/SchoolsDetails'

interface OwnStateProps {
    selectedKeys: string[];
}

interface PassedProps {

}

class MainLayout extends React.Component<PassedProps, OwnStateProps>{

    state = {
        selectedKeys: []
    };


    render() {
        const { SubMenu } = Menu;
        const { Header, Content, Footer, Sider } = Layout;
        return (
            <>
                <Layout style={{ minHeight: '100vh' }}>
                    <Sider collapsible>

                        <div className="logo" style={{ marginBottom: 30 }}>

                            <img src="" alt="logo" width={150} />

                        </div>

                        <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline" selectedKeys={this.state.selectedKeys}>
                            <Menu.Item key="1">
                                <Link to="/">Home</Link>
                            </Menu.Item>
                            <Menu.Item key="2">
                                <Link to="/users">Users</Link>
                            </Menu.Item>
                            <Menu.Item key="3">
                                <Link to="/rooms">Rooms</Link>
                            </Menu.Item>
                            <Menu.Item key="4">
                                <Link to="/iot-sets">IoT Sets</Link>
                            </Menu.Item>
                            <Menu.Item key="4">
                                <Link to="/computers">Computers</Link>
                            </Menu.Item>
                            <Menu.Item key="4">
                                <Link to="/history">History</Link>
                            </Menu.Item>

                            {/* <SubMenu
                                key="sub1"
                                title={
                                    <span>
                                        <span>.</span>
                                    </span>
                                }
                            >
                                <Menu.Item key="4">.</Menu.Item>
                                <Menu.Item key="5">.</Menu.Item>
                                <Menu.Item key="6">.</Menu.Item>
                            </SubMenu>
                            <SubMenu
                                key="sub2"
                                title={
                                    <span>
                                        <span>.</span>
                                    </span>
                                }
                            >
                                <Menu.Item key="7">.</Menu.Item>
                                <Menu.Item key="8">.</Menu.Item>
                            </SubMenu>
                            <Menu.Item key="9">
                                <span>File</span>
                            </Menu.Item> */}

                        </Menu>
                    </Sider>
                    <Layout>
                        <Header style={{ background: '#fff', padding: 10, marginLeft: 16, marginTop : 15, marginRight : 15 }} >

                            <Breadcrumb style={{ margin: '16px 0', marginLeft: 5 }}>
                                <Breadcrumb.Item>Page</Breadcrumb.Item>
                                <Breadcrumb.Item>Nested page</Breadcrumb.Item>

                                {/* <Switch>

                                    <Route path="/" exact={true} component={Home} />
                                    <Route path="/users" exact={true} component={UsersList} />
                                    <Route path="/rooms" exact={true} component={RoomsList} />
                                    <Route path="/iot-sets" exact={true} component={IoTSetList} />
                                    <Route path="/computers" exact={true} component={ComputersList} />
                                    <Route path="/history" exact={true} component={History} />

                                </Switch> */}

                            </Breadcrumb>

                        </Header>


                        <Content style={{ margin: '0 15px' }}>
                            <div style={{ padding: 24, background: '#fff', minHeight: 860, marginTop: 15 }}>
                                {this.props.children}
                            </div>
                        </Content>
                        <Footer style={{ textAlign: 'center' }}>ONAT ©2021 Created by Artem Vasylenko</Footer>
                    </Layout>
                </Layout>

            </>
        );

    }
}

export default MainLayout;