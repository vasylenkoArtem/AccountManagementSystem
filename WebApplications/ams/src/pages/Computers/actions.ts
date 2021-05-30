
import axios from '../../api/axiosInstance';
import { Computer } from './reducer';

// get computers
export enum GET_COMPUTERS {
    REQUEST = 'GET_COMPUTERS_REQUEST',
    SUCCESS = 'GET_COMPUTERS_SUCCESS',
}

export const getComputersRequest = () => {
    return {
        type: GET_COMPUTERS.REQUEST
    };
};

export const getComputersSuccess = (computers: Computer[]) => {
    return {
        type: GET_COMPUTERS.SUCCESS,
        computers: computers
    };
};

export const getComputers = () => {
    return (dispatch: any) => {
        dispatch(getComputersRequest());
        axios.get(`computers`)
            .then(response => {
                dispatch(getComputersSuccess(response.data));
            })
            .catch((error: any) => {
                console.log('ERROR: ', error.response);  //will be antd alert with good design
            });
    };
};

