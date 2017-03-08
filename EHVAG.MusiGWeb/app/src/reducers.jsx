import { combineReducers } from 'redux';

/* Import all  reducers */
import channel from './containers/LandingContainer/reducer';
// import landing from './containers/LandingContainer/reducer';
// import app from './containers/AppContainer/reducer';

const rootReducer = combineReducers({
    app,
  /* GENERATOR: Compile all of your reducers */
    landing,
});

export default rootReducer;