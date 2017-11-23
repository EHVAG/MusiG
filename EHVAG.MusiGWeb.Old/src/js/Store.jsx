import { applyMiddleware, createStore } from 'redux';
import logger from 'redux-logger';
import thunk from 'redux-thunk';
import promise from 'redux-promise-middleware';
import rootReducer from './Reducers';

export default createStore(
  rootReducer,
  applyMiddleware(promise(), thunk, logger()),
);