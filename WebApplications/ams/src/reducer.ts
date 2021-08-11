import { combineReducers } from 'redux';

import { reducer as userReducer, UserState } from './pages/Users/reducer';
import { reducer as roomReducer, RoomState } from './pages/Rooms/reducer';
import { reducer as computerReducer, ComputerState } from './pages/Computers/reducer';
import { reducer as historyReducer, HistoryState } from './pages/History/reducer';


export type Dictionary = {
    Id: number;
    Name: string;
};

export interface AppState {
    user: UserState;
    room: RoomState;
    computer: ComputerState;
    history: HistoryState;
}


const rootReducer = combineReducers<AppState>({
    user: userReducer,
    room: roomReducer,
    computer: computerReducer,
    history: historyReducer
});

export default rootReducer;