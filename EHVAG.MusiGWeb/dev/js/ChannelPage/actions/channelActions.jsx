import axios from 'axios';

export function fetchChannels() {
    return function (dispatch) {
        axios.get(`${window.location.protocol}//${window.location.hostname}/Channel/GetChannels`)
          .then((response) => {
              dispatch({ type: 'FETCH_CHANNELS_FULFILLED', payload: response.data });
          })
          .catch((err) => {
              dispatch({ type: 'FETCH_CHANNELS_REJECTED', payload: err });
          });
    };
}