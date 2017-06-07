import { combineReducers } from "redux";
import { routerReducer } from "react-router-redux";
import channelPage from "./ChannelPage/Reducers/ChannelReducer";
import googleLogin from "./GoogleLoginPage/Reducers/GoogleLoginReducer";

const rootReducer = combineReducers({
  channelPage,
  googleLogin,
  router: routerReducer
});

export default rootReducer;
