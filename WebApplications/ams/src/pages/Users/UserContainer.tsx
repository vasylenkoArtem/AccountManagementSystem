import { Modal } from 'antd';
import React from 'react';
import { connect } from 'react-redux';
import { AppState } from '../../reducer';
import { User } from './reducer';
import UserForm from './UserForm';
import { addUser } from './actions'
import { getRooms } from '../Rooms/actions';
import { Room } from '../Rooms/reducer';

interface PassedProps {
    onCancel: () => void;
    visible: boolean;
    userInfo?: User;
    mode?: 'add' | 'edit';
}

interface DispatchFromProps {
    addUser: (user: User) => void;
    getRooms: () => void;
}

interface OwnStateProps {
    userInfo?: User
}

interface StateFromProps {
    isLoading: boolean;
    rooms?: Room[];
}

class UserContainer extends React.Component<StateFromProps & DispatchFromProps & PassedProps, OwnStateProps>{

    state = {
        userInfo: {} as User
    }


    componentDidMount = () => {
        this.props.getRooms();
    }

    handleCancel = () => {
        this.props.onCancel();
    }

    handleSubmit = () => {
        const { mode } = this.props;

        if (mode === 'add') {
            this.props.addUser(this.state.userInfo as User)
        }
        else if (mode === 'edit') {

        }
    }

    handleChange = (fieldName: string, fieldValue: any) => {
        const userInfo = this.state.userInfo as any;
        userInfo[fieldName] = fieldValue;

        this.setState({ userInfo: userInfo });
    }

    render() {
        return (<>

            <Modal
                title={"Add user"}
                visible={this.props.visible}
                onCancel={this.handleCancel}
                destroyOnClose={true}
                footer={null}
                maskClosable={false}
            >
                <UserForm
                    userInfo={this.props.userInfo}
                    mode={this.props.mode}
                    handleSubmit={this.handleSubmit}
                    onChange={this.handleChange}
                    isLoading={this.props.isLoading}
                    handleReset={this.props.onCancel}
                    rooms={this.props.rooms}
                />

            </Modal>

        </>)
    }

}

const mapStateToProps = (state: AppState): StateFromProps => {
    return {
        isLoading: state.user.isLoading,
        rooms: state.room.rooms

    };
};

export default connect<StateFromProps, DispatchFromProps, any, AppState>(mapStateToProps, {
    addUser,
    getRooms
})(UserContainer);