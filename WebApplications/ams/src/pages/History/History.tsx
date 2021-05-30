
import { Button, Table } from 'antd';
import React from 'react';
import { connect } from 'react-redux';
import MainLayout from '../../components/MainLayout/MainLayout';
import { AppState } from '../../reducer';
import { HistoryEntry } from './reducer';
import { getHistory } from './actions'
import { ColumnProps } from 'antd/lib/table';
import { ColumnSetting, formatDateString, getFilterValuesByPropertyName, sortAlphabeticaly } from '../../helpers/tableHelper';
import { PlusOutlined } from '@ant-design/icons';
//import UserContainer from './UserContainer';


interface PassedProps {

}

interface OwnStateProps {
    columnSettings: any[]
    modalVisible: boolean;
    selectedHistoryInfo?: HistoryEntry;
    mode?: 'add' | 'edit'
}

interface StateFromProps {
    historyEntries?: HistoryEntry[];
    isLoadingTable: boolean;
    isSaved: boolean;
}

interface DispatchFromProps {
    getHistory: () => void;
}

class HistoryList extends React.Component<StateFromProps & DispatchFromProps & PassedProps, OwnStateProps>{

    state = {
        columnSettings: [
            { Key: 'AuditEntryID', Visible: true, Title: "Entry ID" },
            { Key: 'CreatedBy', Visible: true, Title: "Created By" },
            { Key: 'CreatedDate', Visible: true, Title: "Created Date", IsDateTime: true },
            { Key: 'EntitySetName', Visible: true, Title: "Entity Set Name" },
            { Key: 'StateName', Visible: true, Title: "State" },



            //props
            { Key: 'PropertyName', Visible: true, Title: "PropertyName" },
            { Key: 'OldValue', Visible: true, Title: "Old Value" },
            { Key: 'NewValue', Visible: true, Title: "Old Value" },


            { Key: 'actions', Visible: true, width: 50 },
        ],
        modalVisible: false,
        selectedHistoryInfo: undefined,
        mode: undefined
    }

    componentDidMount = () => {
        this.props.getHistory();
    }

    componentDidUpdate(prevProps: StateFromProps & PassedProps, prevState: OwnStateProps) {

    }

    getFilterValues = (columnKey: string) => {
        return () => this.props.historyEntries ? getFilterValuesByPropertyName(this.props.historyEntries, columnKey) : null;
    }

    showAddUsertModal = () => {
        this.setState({ modalVisible: true, mode: 'add' });
    }

    onEditUser = (row: HistoryEntry) => {
        this.setState({ modalVisible: true, selectedHistoryInfo: row, mode: 'edit' });
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
                    render: (text: string, row: HistoryEntry) => {
                        switch (columnKey) {

                            case 'actions':
                                if(!(row.Properties?.length > 0)){
                                    return null;
                                }
                                
                                return <Button
                                    size="small"
                                    className="tr-action-item"
                                    onClick={() => this.onEditUser(row)}>
                                    Details
                                </Button>;
                        }

                        if (element.IsDate || element.IsDateTime) {
                            return formatDateString(text, element.IsDateTime);
                        }

                       
                        return text;
                    }
                });
            }
        });


        return (<>
            <MainLayout>

                {/* <Button onClick={this.showAddUsertModal} type="primary" icon={<PlusOutlined />}>
                    Add new
                </Button> */}

                {/* <UserContainer
                    onCancel={() => this.setState({ modalVisible: false })}
                    visible={this.state.modalVisible}
                    userInfo={this.state.selectedUserInfo}
                    mode={this.state.mode}
                /> */}


                <Table
                    rowKey="AuditEntryID"
                    columns={columns}
                    dataSource={this.props.historyEntries}
                    loading={this.props.isLoadingTable}
                    childrenColumnName={"Properties"}
                />


            </MainLayout>

        </>)
    }
}


const mapStateToProps = (state: AppState): StateFromProps => {
    return {
        historyEntries: state.history.historyEntries,
        isLoadingTable: state.room.isLoadingTableData,
        isSaved: state.user.isSaved

    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {
    getHistory
})(HistoryList);