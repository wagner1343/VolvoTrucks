import Truck from "src/data/Truck";
import {createSlice} from "@reduxjs/toolkit";
import {Dispatch} from "react";
import {trucksApi} from "src/api/TrucksApi";

export interface TrucksStoreState {
  isLoading: boolean;
  isLoaded: boolean;
  errorCode?: string;
  trucks?: Truck[];
}

const truckStoreInitialState : TrucksStoreState = {
  isLoading: false,
  isLoaded: false,
};

const slice = createSlice<TrucksStoreState, any, any>( {
  name: "trucks",
  initialState: truckStoreInitialState,
  reducers: {
    getStarted(state, action) {
      state.isLoading = true; 
    },
    getSuccess(state, action) {
      state.isLoading = false;
      state.isLoaded = true;
      state.trucks = action.payload;
    },
    getFailed(state, action) {
      state.isLoading = false;
      state.errorCode = action.payload
    },
  }
})

export const actions = {
  list: () => async (dispatch: Dispatch<any>) => {
    try {
      dispatch(slice.actions.getStarted());
      const response = await trucksApi.list();
      dispatch(slice.actions.getSuccess(response.data));
    }
    catch (e) {
      dispatch(slice.actions.getFailed(e));
    }
  }
}

export const reducer = slice.reducer; 

export default {
  slice,
  actions
}