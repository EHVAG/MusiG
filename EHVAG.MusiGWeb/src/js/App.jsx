import React from 'react';
import SidebarNav from './SidebarNavigation/SidebarNav'

export default class App extends React.Component {
    render() {
        return (
          <div>
            <div class="sidenav">
              <SidebarNav />
            </div>
            <div className="content">
              {this.props.children}
            </div>
          </div>
        );
    }
}
