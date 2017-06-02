import React, { Component } from 'react';
import { Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

const fakeAuth = { isAuthenticated: true };

const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={props =>
      (fakeAuth.isAuthenticated
        ? <Component {...props} />
        : <Redirect
          to={{
              pathname: '/login',
              state: { from: props.location },
          }}
        />)}
  />
);

function mapStateToProps(store) {
    return {
        isAuthenticated: store.googleLogin,
    };
}

export default connect(mapStateToProps)(PrivateRoute);