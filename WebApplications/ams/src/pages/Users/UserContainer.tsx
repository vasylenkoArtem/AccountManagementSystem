import { Modal } from 'antd';
import React from 'react';
import { User } from './reducer';
import UserForm from './UserForm';

interface PassedProps {
    onCancel: () => void;
    visible: boolean;
    userInfo?: User;
    mode?: 'add' | 'edit';
}

class UserContainer extends React.Component<PassedProps>{


    handleCancel = () => {
        this.props.onCancel();
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
                />

            </Modal>

        </>)
    }

}

export default UserContainer;
