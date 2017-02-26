import React from 'react';
import { Link } from 'react-router';

export default class SidebarNav extends React.Component {
    render() {
        const sidenavStyle = {
            height: '100%',
            width: 90,
            position: 'fixed',
            zIndex: 1,
            top: 0,
            left: 0,
            backgroundColor: '#111',
            overflowX: 'hidden',
            overflow: 'hidden',
            paddingTop: 15,
        };

        const sidenavIconStyle = {
            textDecoration: 'none',
            color: '#818181',
            display: 'block',
            padding: '36px 10px 0px 10px',
        };

        const bottomLeftStyle = {
            position: 'absolute',
            color: '#818181',
            bottom: 0,
            width: '100%',
            marginBottom: 5,
        };

        return (
          <div style={sidenavStyle}>
            <Link to="/" class="text-center">
              <img
                src="../../img/EHVAGLogoWhiteResize.png"
                class="img-responsive" role="presentation"
              />
            </Link>
            <Link to="/" style={sidenavIconStyle} class="text-center">
              <i class="fa fa-podcast fa-3x" aria-hidden="true" />
            </Link>
            <Link to="/channel" style={sidenavIconStyle} class="text-center">
              <i class="fa fa-reddit fa-3x" aria-hidden="true" />
            </Link>
            <Link to="/" style={bottomLeftStyle} class="text-center">
              <i class="fa fa-user fa-3x" aria-hidden="true" />
            </Link>
          </div>
        );
    }
}
