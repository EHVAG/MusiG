import React from 'react';
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';
import App from 'grommet/components/App';
import Split from 'grommet/components/Split';
import SidebarNav from '../SidebarNav/Index';

const MusiG = props => (
  <App centered={false}>
    <Split flex="right">
      <SidebarNav />
      {props.children}
    </Split>
  </App>
);

export default withRouter(MusiG);