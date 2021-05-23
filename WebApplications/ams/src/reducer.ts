import { combineReducers } from 'redux';

import { reducer as userReducer, UserState } from './pages/Users/reducer';
import { reducer as roomReducer, RoomState } from './pages/Rooms/reducer';


export type Dictionary = {
    Id: number;
    Name: string;
};

export interface AppState {
    user: UserState;
    room: RoomState;
}


const rootReducer = combineReducers<AppState>({
    user: userReducer,
    room: roomReducer,
});

export default rootReducer;