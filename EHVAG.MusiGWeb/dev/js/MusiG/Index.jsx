import React from 'react';
import App from 'grommet/components/App';
import Split from 'grommet/components/Split';
import Title from 'grommet/components/Title';
import Box from 'grommet/components/Box';
import Sidebar from 'grommet/components/Sidebar';
import Anchor from 'grommet/components/Anchor';
import SidebarNav from '../SidebarNav/Index';


class MusiG extends React.Component {
    render() {
        return (
          <App centered={false}>
            <Split flex="right">
              <SidebarNav />
              {this.props.children}
            </Split>
          </App>
        );
    }
}

export default MusiG;