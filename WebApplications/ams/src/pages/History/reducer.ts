import { updateObject } from '../../helpers/updateObject';
import { GET_HISTORY } from './actions';

export type HistoryEntry = {
    AuditEntryID: number;
    CreatedBy: string;
    CreatedDate: Date;
    EntitySetName: string;
    EntityTypeName: string;
    Properties: AuditEntryProperty[];
    State: number;
    StateName: string;

}

export type AuditEntryProperty = {
    AuditEntryPropertyID: number;
    AuditEntryID: number;
    PropertyName: string;
    RelationName: string;
    NewValue: string;
    IsValueSet: boolean;
    InternalPropertyName: string;
    NewValueFormatted: string;
    OldValue: string;
    IsKey: boolean;
    OldValueFormatted: string;
}

export type HistoryState = {
    historyEntries?: HistoryEntry[];
    isLoading: boolean;
    isLoadingTableData: boolean;
}

const initialState = {
    isLoading: false,
    isLoadingTableData: false
}

export const reducer = (state: HistoryState = initialState, action: any) => {
    switch (action.type) {
        case GET_HISTORY.REQUEST:
            return updateObject(state, { historyEntries: undefined, isLoadingTableData: true });
        case GET_HISTORY.SUCCESS:
            return updateObject(state, { historyEntries: action.historyEntries, isLoadingTableData: false });

        default:
            return state;
    }
}