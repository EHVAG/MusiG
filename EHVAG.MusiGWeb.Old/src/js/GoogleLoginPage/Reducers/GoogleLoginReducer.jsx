import * as types from '../Actions/GoogleLoginActionTypes';

export default function reducer(
  state = {
    // Set default values
      isAuthenticated: false,
      error: false,
  },
  action,
) {
    switch (action.type) {
    case types.GOOGLE_LOGIN_SUCCESSFULL: {
        return { isAuthenticated: true, error: false };
    }

    case types.GOOGLE_LOGIN_REJECTED: {
        return { isAuthenticated: false, error: action.payload };
    }

    default:
        return state;
    }
}