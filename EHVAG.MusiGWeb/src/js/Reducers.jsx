import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';
import channels from './ChannelPage/Reducers/ChannelReducer';
import googleLogin from './GoogleLoginPage/Reducers/GoogleLoginReducer';

const rootReducer = combineReducers({
    channels,
    googleLogin,
    router: routerReducer,
});

export default rootReducer;