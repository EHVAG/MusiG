import axios from 'axios';
import * as types from './GoogleLoginActionTypes';

export function verifyGoogleIdToken(idToken) {
    return function (dispatch) {
        axios({
            method: 'post',
            url: 'api/Login/GoogleLogin',
            data: {
                idtoken: idToken.getAuthResponse().id_token,
            },
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        })
      .then((response) => {
          dispatch({
              type: types.GOOGLE_LOGIN_SUCCESSFULL,
              payload: response.data,
          });
      })
      .catch((err) => {
          dispatch({ type: types.GOOGLE_LOGIN_REJECTED, payload: err });
      });
    };
}

export function error() {
    return function (dispatch) {};
}