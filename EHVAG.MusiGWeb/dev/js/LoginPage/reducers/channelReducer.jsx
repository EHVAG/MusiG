export default function reducer(state = {
// Set default values
    channels: [],
    fetching: false,
    fetched: false,
    error: null,
}, action) {
    switch (action.type) {
    case 'FETCH_CHANNELS': {
        return { ...state, fetching: true };
    }
    case 'FETCH_CHANNELS_REJECTED': {
        return { ...state, fetching: false, error: action.payload };
    }
    case 'FETCH_CHANNELS_FULFILLED': {
        return {
            ...state,
            fetching: false,
            fetched: true,
            channels: action.payload,
        };
    }
    default: return state;
    }
}