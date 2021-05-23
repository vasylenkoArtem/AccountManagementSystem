
import { Button, Table } from 'antd';
import React from 'react';
import { connect } from 'react-redux';
import MainLayout from '../../components/MainLayout/MainLayout';
import { AppState } from '../../reducer';
import { User } from './reducer';
import { getUsers } from './actions'
import { ColumnProps } from 'antd/lib/table';
import { ColumnSetting, getFilterValuesByPropertyName, sortAlphabeticaly } from '../../helpers/tableHelper';
import { PlusOutlined } from '@ant-design/icons';
import UserContainer from './UserContainer';


interface PassedProps {

}

interface OwnStateProps {
    columnSettings: any[]
    modalVisible: boolean;
    selectedUserInfo?: User;
    mode?: 'add' | 'edit'
}

interface StateFromProps {
    users: User[];
    isLoadingTable: boolean;
}

interface DispatchFromProps {
    getUsers: () => void;
}

class UsersList extends React.Component<StateFromProps & DispatchFromProps & PassedProps, OwnStateProps>{

    state = {
        columnSettings: [
            { Key: 'Id', Visible: true, Title: "Id" },
            { Key: 'FirstName', Visible: true, Title: "First Name" },
            { Key: 'LastName', Visible: true, Title: "Last Name" },
            { Key: 'Email', Visible: true, Title: "Email" },
            { Key: 'UserTypeId', Visible: true, Title: "User Type" },
            { Key: 'RFIDKey', Visible: true, Title: "RFID Key" },
            { Key: 'RoomIds', Visible: true, Title: "Room Ids" },
            { Key: 'RoomNumbers', Visible: true, Title: "Room Numbers" },
            { Key: 'actions', Visible: true, width: 50 },
        ],
        modalVisible: false,
        selectedUserInfo: undefined,
        mode: undefined
    }

    componentDidMount = () => {
        this.props.getUsers();
    }

    getUserType = (userTypeId: number) => {
        if (userTypeId == 1) {
            return "Guest"
        }
        else if (userTypeId == 2) {
            return "Student"
        }
        else if (userTypeId == 3) {
            return "Engineer"
        }
    }

    getFilterValues = (columnKey: string) => {
        return () => this.props.users ? getFilterValuesByPropertyName(this.props.users, columnKey) : null;
    }

    showAddUsertModal = () => {
        this.setState({ modalVisible: true, mode: 'add' });
    }

    onEditUser = (row: User) => {
        this.setState({ modalVisible: true, selectedUserInfo: row, mode: 'edit' });
    }

    render() {

        const columns: ColumnProps<any>[] = [];
        let { columnSettings } = this.state;
        columnSettings.forEach((element: ColumnSetting | any) => {
            const columnKey = element.Key;
            var index = columns.find((column: any) => { return column.key === columnKey; });
            if (!index) {
                columns.push({
                    title: element.Title,
                    dataIndex: columnKey,
                    width: element.Width,
                    key: columnKey,
                    align: (element.IsDate || element.IsDateTime) ? 'right' : undefined,
                    sorter: (a: any, b: any) => sortAlphabeticaly(a[columnKey], b[columnKey]),
                    filters: this.getFilterValues(columnKey)() as any,
                    onFilter: (value: any, record: any) => {
                        return record[columnKey] === value;
                    },
                    render: (text: string, row: User) => {
                        switch (columnKey) {
                            case 'UserTypeId':
                                return this.getUserType(row.UserTypeId);
                            case 'actions':

                                return <Button
                                    size="small"
                                    className="tr-action-item"
                                    onClick={() => this.onEditUser(row)}>
                                    Edit
                                </Button>;
                        }

                        if (element.IsDate || element.IsDateTime) {
                            return null; //formatDateString(text, element.IsDateTime);
                        }

                        return text;
                    }
                });
            }
        });


        return (<>
            <MainLayout>

                <Button onClick={this.showAddUsertModal} type="primary" icon={<PlusOutlined />}>
                    Add new
                </Button>

                <UserContainer
                    onCancel={() => this.setState({ modalVisible: false })}
                    visible={this.state.modalVisible}
                    userInfo={this.state.selectedUserInfo}
                    mode={this.state.mode}
                />


                <Table
                    rowKey="Id"
                    columns={columns}
                    dataSource={this.props.users}
                    loading={this.props.isLoadingTable}
                />


            </MainLayout>

        </>)
    }
}


const mapStateToProps = (state: AppState): StateFromProps => {
    return {
        users: state.user.users,
        isLoadingTable: state.user.isLoadingTable

    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {
    getUsers
})(UsersList);