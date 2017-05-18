import React from 'react';
import { Provider } from 'react-redux';
import { Router, hashHistory } from 'react-router';
import routes from './Routes';
import store from './Store';

export default () => (
  <Provider store={store}>
    <Router routes={routes} history={hashHistory} />
  </Provider>
);