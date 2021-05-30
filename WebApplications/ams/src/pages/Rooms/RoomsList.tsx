
import { Button, Table } from 'antd';
import React from 'react';
import { connect } from 'react-redux';
import MainLayout from '../../components/MainLayout/MainLayout';
import { AppState } from '../../reducer';
import { Room } from './reducer';
import { getRooms } from './actions'
import { ColumnProps } from 'antd/lib/table';
import { ColumnSetting, getFilterValuesByPropertyName, sortAlphabeticaly } from '../../helpers/tableHelper';
import { PlusOutlined } from '@ant-design/icons';
//import UserContainer from './UserContainer';


interface PassedProps {

}

interface OwnStateProps {
    columnSettings: any[]
    modalVisible: boolean;
    selectedRoomInfo?: Room;
    mode?: 'add' | 'edit'
}

interface StateFromProps {
    rooms?: Room[];
    isLoadingTable: boolean;
    isSaved: boolean;
}

interface DispatchFromProps {
    getRooms: () => void;
}

class RoomsList extends React.Component<StateFromProps & DispatchFromProps & PassedProps, OwnStateProps>{

    state = {
        columnSettings: [
            { Key: 'Id', Visible: true, Title: "Id" },
            { Key: 'Number', Visible: true, Title: "Number" },
            { Key: 'Name', Visible: true, Title: "Name" },
            
            { Key: 'actions', Visible: true, width: 50 },
        ],
        modalVisible: false,
        selectedUserInfo: undefined,
        mode: undefined
    }

    componentDidMount = () => {
        this.props.getRooms();
    }

    componentDidUpdate(prevProps: StateFromProps & PassedProps, prevState: OwnStateProps) {
        if (this.props.isSaved && prevState.modalVisible) {
            this.setState({ modalVisible: false });
        }
    }

    getFilterValues = (columnKey: string) => {
        return () => this.props.rooms ? getFilterValuesByPropertyName(this.props.rooms, columnKey) : null;
    }

    showAddUsertModal = () => {
        this.setState({ modalVisible: true, mode: 'add' });
    }

    onEditUser = (row: Room) => {
        this.setState({ modalVisible: true, selectedRoomInfo: row, mode: 'edit' });
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
                    render: (text: string, row: Room) => {
                        switch (columnKey) {
                            
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

                {/* <UserContainer
                    onCancel={() => this.setState({ modalVisible: false })}
                    visible={this.state.modalVisible}
                    userInfo={this.state.selectedUserInfo}
                    mode={this.state.mode}
                /> */}


                <Table
                    rowKey="Id"
                    columns={columns}
                    dataSource={this.props.rooms}
                    loading={this.props.isLoadingTable}
                />


            </MainLayout>

        </>)
    }
}


const mapStateToProps = (state: AppState): StateFromProps => {
    return {
        rooms: state.room.rooms,
        isLoadingTable: state.room.isLoadingTableData,
        isSaved: state.user.isSaved

    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {
    getRooms
})(RoomsList);