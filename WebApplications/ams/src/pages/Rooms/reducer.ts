import { updateObject } from '../../helpers/updateObject';

export type RoomState = {

}

const initialState = {

}

export const reducer = (state: RoomState = initialState, action: any) => {
    switch (action.type) {
        case '':
            return updateObject(state, { student: undefined });


        default:
            return state;
    }
}