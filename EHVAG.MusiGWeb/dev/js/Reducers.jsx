import { combineReducers } from 'redux';

// Import reducers here
import channels from './ChannelPage/reducers/channelReducer';

const rootReducer = combineReducers({
    channels,
});

export default rootReducer;