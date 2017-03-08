import { combineReducers } from 'redux';
import channelReducer from './Channels/ChannelReducer';

const rootReducer = combineReducers({
    channels: channelReducer,
});

export default rootReducer;