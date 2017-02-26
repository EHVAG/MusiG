import React from 'react';
import { render } from 'react-dom';
import { Router, Route, IndexRoute, IndexLink, Link, hashHistory } from 'react-router';
import App from './App';
import Home from './Home'
import ChannelsPageIndex from './Channels/ChannelPageIndex'

render(
  <Router history={hashHistory}>
    <Route path="/" component={App}>
      <IndexRoute component={Home} />
    </Route>
    <Route path="/channel" component={App} >
      <IndexRoute component={ChannelsPageIndex} />
    </Route>
  </Router>
  , document.getElementById('app'));
