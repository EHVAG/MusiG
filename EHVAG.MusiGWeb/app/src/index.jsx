import React from 'react';
import { render } from 'react-dom';
// import '../styles/styles.scss';
import { history } from './store';
import RouterApp, { routes } from './routes';

const NewRouterApp = require('./routes').default;

render(<NewRouterApp />, document.getElementById('app'));