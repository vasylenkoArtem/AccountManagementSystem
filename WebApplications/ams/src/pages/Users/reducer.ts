import { updateObject } from '../../helpers/updateObject';
import { GET_USERS } from './actions';

export type User = {
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;
    UserTypeId: number;
    IdentityLockUserId: number;
    RoomIds: number[];
    RoomNumbers: string[];
    RFIDKey: string;

}

export type UserState = {
    users: User[];
    isLoadingTable: boolean;
}

const initialState = {
    users: [],
    isLoadingTable: false
}

export const reducer = (state: UserState = initialState, action: any) => {
    switch (action.type) {
        case GET_USERS.REQUEST:
            return updateObject(state, { users: undefined, isLoadingTable: true });
        case GET_USERS.SUCCESS:
            return updateObject(state, { users: action.users, isLoadingTable: false });


        default:
            return state;
    }
}