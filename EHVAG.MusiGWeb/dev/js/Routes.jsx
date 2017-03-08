import React from 'react';
import { createStore } from 'redux';
import { Provider } from 'react-redux';
import { Router, Route, IndexRoute, IndexLink, Link, hashHistory } from 'react-router';
import App from './Shared/App';
import Home from './Home/Home';
import ChannelPageIndex from './Channels/ChannelPageIndex';
import rootReducer from './Reducers';

const store = createStore(rootReducer);
const routes =
  (<Provider store={store}>
    <Router history={hashHistory}>
      <Route path="/" component={App}>
        <IndexRoute component={Home} />
      </Route>
      <Route path="/channel" component={App} >
        <IndexRoute component={ChannelPageIndex} />
      </Route>
    </Router>
  </Provider>
);

export default routes;