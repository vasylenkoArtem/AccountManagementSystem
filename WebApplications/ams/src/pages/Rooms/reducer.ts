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
}

const initialState = {
    isLoading: false
}

export const reducer = (state: RoomState = initialState, action: any) => {
    switch (action.type) {
        case GET_ROOMS.REQUEST:
            return updateObject(state, { rooms: undefined, isLoading: true });
        case GET_ROOMS.SUCCESS:
            return updateObject(state, { rooms: action.rooms, isLoading: false });

        default:
            return state;
    }
}