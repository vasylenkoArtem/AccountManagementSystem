import axios from '../../api/axiosInstance';
import { User } from './reducer';

// get users
export enum GET_USERS {
    REQUEST = 'GET_USERS_REQUEST',
    SUCCESS = 'GET_USERS_SUCCESS',
}
export const getUsersRequest = () => {
    return {
        type: GET_USERS.REQUEST
    };
};

export const getUsersSuccess = (users: User[]) => {
    return {
        type: GET_USERS.SUCCESS,
        users: users
    };
};

export const getUsers = () => {
    return (dispatch: any) => {
        dispatch(getUsersRequest());
        axios.get(`users`)
            .then(response => {
                dispatch(getUsersSuccess(response.data));
            })
            .catch((error: any) => {
                console.log('ERROR: ', error.response);  //will be antd alert with good design
            });
    };
};
