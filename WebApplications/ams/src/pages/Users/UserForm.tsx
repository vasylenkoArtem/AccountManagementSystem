
import React from 'react';
import { User } from './reducer';


interface PassedProps {
    userInfo?: User;
    mode?: 'add' | 'edit';
}

class UserForm extends React.Component<PassedProps>{



    render() {

        const { userInfo } = this.props;

        return <>
            {this.props.mode === 'edit' ? <div><span> FirstName:</span>
                <span>{userInfo?.FirstName}</span>

                <span> LastName:</span>
                <span>{userInfo?.LastName}</span>

                <span>RFIDKey:</span>
                <span>{userInfo?.RFIDKey}</span>
                <span> Rooms:</span>
                <span>{userInfo?.RoomNumbers}</span>
            </div> : null}


        </>
    }
}

export default UserForm;