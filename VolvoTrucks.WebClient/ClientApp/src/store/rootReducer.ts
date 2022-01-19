import {combineReducers} from '@reduxjs/toolkit';
import TrucksStore, {TrucksStoreState} from 'src/store/TrucksStore';
import {Action} from 'redux';
import {Reducer} from "react";

export interface RootCombinedState {
  trucks: TrucksStoreState
}

const rootReducer = combineReducers({
  trucks: TrucksStore.slice.reducer
}) as Reducer<RootCombinedState, any>;

export default (state: any, action: Action) =>
  rootReducer(action.type === 'RESET_STATE' ? undefined : state, action);
