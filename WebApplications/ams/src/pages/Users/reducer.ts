import { updateObject } from '../../helpers/updateObject';
import { ADD_USER, GET_USERS } from './actions';

export type User = {
    Id: number;
    FirstName: string;
    LastName: string;
    Email: string;
    UserTypeId: number;
    UserType: string;
    IdentityLockUserId: number;
    RoomIds: number[];
    RoomNumbers: string[];
    RFIDKey: string;

}

export type UserState = {
    users: User[];
    isLoadingTable: boolean;
    isLoading: boolean;
}

const initialState = {
    users: [],
    isLoadingTable: false,
    isLoading: false
}

const updateUsersWithUser = (state: UserState, user: User) => {
    return state.users.push(user);
}

export const reducer = (state: UserState = initialState, action: any) => {
    switch (action.type) {
        case GET_USERS.REQUEST:
            return updateObject(state, { users: undefined, isLoadingTable: true });
        case GET_USERS.SUCCESS:
            return updateObject(state, { users: action.users, isLoadingTable: false });
        case ADD_USER.REQUEST:
            return updateObject(state, { isLoading: true });
        case ADD_USER.SUCCESS:
            return updateObject(state, { users: updateUsersWithUser(state, action.user), isLoading: false });


        default:
            return state;
    }
}