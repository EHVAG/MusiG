import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { HashRouter, Route } from 'react-router-dom';
import PrivateRoute from './PrivateRoute';
import store from './Store';
import '../scss/index.scss';
import MusiG from './MusiG/Index';
import LiveFeed from './LiveFeed/LiveFeed';
import ChannelPage from './ChannelPage/ChannelPage';
import LoginPage from './GoogleLoginPage/GoogleLoginPage';

render(
  <Provider store={store}>
    <HashRouter>
      <div>
        <MusiG>
          <PrivateRoute exact path="/" component={LiveFeed} />
          <PrivateRoute exact path="/channel" component={ChannelPage} />
          <Route exact path="/login" component={LoginPage} />
        </MusiG>
      </div>
    </HashRouter>
  </Provider>,
  document.getElementById('content'),
);