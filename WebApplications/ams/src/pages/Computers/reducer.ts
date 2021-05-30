import { updateObject } from '../../helpers/updateObject';
import { GET_COMPUTERS } from './actions';

export type Computer = {
    Id: number;
    OperatingSystemId: number;
    RoomId: number;
    OperationSystem: string;
    RoomName: string;
    RoomNumber: string;
}

export type ComputerState = {
    computers?: Computer[];
    isLoading: boolean;
    isLoadingTableData: boolean;
}

const initialState = {
    isLoading: false,
    isLoadingTableData: false
}

export const reducer = (state: ComputerState = initialState, action: any) => {
    switch (action.type) {
        case GET_COMPUTERS.REQUEST:
            return updateObject(state, { computers: undefined, isLoadingTableData: true });
        case GET_COMPUTERS.SUCCESS:
            return updateObject(state, { computers: action.computers, isLoadingTableData: false });

        default:
            return state;
    }
}