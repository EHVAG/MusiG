import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { Router, BrowserRouter, Route } from 'react-router-dom';
import MusiG from './MusiG/Index';
import LiveFeed from './LiveFeed/LiveFeed';
import ChannelPage from './ChannelPage/ChannelPage';
import LoginPage from './GoogleLoginPage/GoogleLoginPage';
import store from './Store';
import PrivateRoute from './PrivateRoute';
import '../scss/index.scss';

render(
  <Provider store={store}>
    <BrowserRouter>
      <div>
        <MusiG>
          <Route exact path="/" component={LiveFeed} />
          <Route exact path="/channel" component={ChannelPage} />
        </MusiG>
        <Route exact path="/login" component={LoginPage} />
      </div>
    </BrowserRouter>
  </Provider>,
  document.getElementById('content'),
);