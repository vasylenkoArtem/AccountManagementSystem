
import axios from '../../api/axiosInstance';
import { Room } from './reducer';

// get rooms
export enum GET_ROOMS {
    REQUEST = 'GET_ROOMS_REQUEST',
    SUCCESS = 'GET_ROOMS_SUCCESS',
}
export const getRoomsRequest = () => {
    return {
        type: GET_ROOMS.REQUEST
    };
};

export const getRoomsSuccess = (rooms: Room[]) => {
    return {
        type: GET_ROOMS.SUCCESS,
        rooms: rooms
    };
};

export const getRooms = () => {
    return (dispatch: any) => {
        dispatch(getRoomsRequest());
        axios.get(`rooms`)
            .then(response => {
                dispatch(getRoomsSuccess(response.data));
            })
            .catch((error: any) => {
                console.log('ERROR: ', error.response);  //will be antd alert with good design
            });
    };
};

