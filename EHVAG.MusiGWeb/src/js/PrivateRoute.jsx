import React from "react";
import { Route, Redirect, withRouter } from "react-router-dom";
import { connect } from "react-redux";
import PropTypes from "prop-types";

const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route
    path={rest.path}
    render={props =>
      (rest.isAuthenticated
        ? <Component {...props} />
        : <Redirect
            to={{
              pathname: "/login",
              state: { from: props.location }
            }}
          />)}
  />
);

PrivateRoute.propTypes = {
  isAuthenticated: PropTypes.bool.isRequired,
  location: React.PropTypes.shape({
    pathname: React.PropTypes.string.isRequired
  })
};

PrivateRoute.defaultProps = {
  location: {
    pathname: ""
  }
};

function mapStateToProps(store) {
  return {
    isAuthenticated: store.googleLogin.isAuthenticated
  };
}

export default withRouter(connect(mapStateToProps)(PrivateRoute));
