import { updateObject } from '../../helpers/updateObject';
import { GET_ROOMS } from './actions';

export type Room = {
    Id: number;
    Number: string;
    Name: string;
}

export type RoomState = {
    rooms?: Room[];
    isLoading: boolean;
    isLoadingTableData: boolean;
}

const initialState = {
    isLoading: false,
    isLoadingTableData: false
}

export const reducer = (state: RoomState = initialState, action: any) => {
    switch (action.type) {
        case GET_ROOMS.REQUEST:
            return updateObject(state, { rooms: undefined, isLoadingTableData: true });
        case GET_ROOMS.SUCCESS:
            return updateObject(state, { rooms: action.rooms, isLoadingTableData: false });

        default:
            return state;
    }
}