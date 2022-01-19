/* eslint-disable no-unused-vars */
import {
  useDispatch as useReduxDispatch,
  useSelector as useReduxSelector
} from 'react-redux';
import { configureStore } from '@reduxjs/toolkit';
import rootReducer from 'src/store/rootReducer';

const store = configureStore({
  reducer: rootReducer,
  devTools: true
});

export type RootState = ReturnType<typeof rootReducer>;
export type Selector = <TSelected = any>(
  selector: (state: RootState) => TSelected,
  equalityFn?: (left: TSelected, right: TSelected) => boolean
) => TSelected;
export const useSelector = <TSelected = unknown>(
  selector: (state: RootState) => TSelected,
  equalityFn?: (left: TSelected, right: TSelected) => boolean
): TSelected => useReduxSelector(selector, equalityFn);

export const useDispatch = () => useReduxDispatch();

export default store;
