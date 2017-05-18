import axios from 'axios';

export function fetchChannels() {
    return function (dispatch) {
        axios
      .get('api/Channel/GetChannels')
      .then((response) => {
          dispatch({ type: 'FETCH_CHANNELS_FULFILLED', payload: response.data });
      })
      .catch((err) => {
          dispatch({ type: 'FETCH_CHANNELS_REJECTED', payload: err });
      });
    };
}

export function addChannel(name) {
    return function (dispatch) {
        axios
      .get(`api/Channel/AddChannel?channelName=${name}`)
      .then((response) => {
          dispatch({ type: 'ADD_CHANNEL_FULFILLED', payload: response.data });
      })
      .catch((err) => {
          dispatch({ type: 'ADD_CHANNEL_REJECTED', payload: err });
      });
    };
}