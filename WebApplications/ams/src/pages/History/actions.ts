
import axios from '../../api/axiosInstance';
import { HistoryEntry } from './reducer';

// get history
export enum GET_HISTORY {
    REQUEST = 'GET_HISTORY_REQUEST',
    SUCCESS = 'GET_HISTORY_SUCCESS',
}

export const getHisotryRequest = () => {
    return {
        type: GET_HISTORY.REQUEST
    };
};

export const getHisotrySuccess = (historyEntries: HistoryEntry[]) => {
    return {
        type: GET_HISTORY.SUCCESS,
        historyEntries: historyEntries
    };
};

export const getHistory = () => {
    return (dispatch: any) => {
        dispatch(getHisotryRequest());
        axios.get(`history`)
            .then(response => {
                dispatch(getHisotrySuccess(response.data));
            })
            .catch((error: any) => {
                console.log('ERROR: ', error.response);  //will be antd alert with good design
            });
    };
};

