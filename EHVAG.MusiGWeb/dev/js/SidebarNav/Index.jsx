import React from 'react';
import Sidebar from 'grommet/components/Sidebar';
import Title from 'grommet/components/Title';
import Image from 'grommet/components/Image';
import Header from 'grommet/components/Header';
import Menu from 'grommet/components/Menu';
import Footer from 'grommet/components/Footer';
import Anchor from 'grommet/components/Anchor';
import CloudIcon from 'grommet/components/icons/base/Cloud';

export default class SidebarNav extends React.Component {
    render() {
        return (
          <Sidebar colorIndex="grey-1-a" size="xsmall" fixed="true" align="center">
            <Header size="small" justify="between" pad={{ vertical: 'medium' }}>
              <Title>
                <Image
                  src="../../img/EHVAGLogoWhite.png"
                  size="thumb"
                />
              </Title>
            </Header>
            <Menu fill="true" primary="true">
              <Anchor path="/" label="Live Feed" />
              <Anchor path="/channel" label="Kanäle" />
              <Anchor path="/login" label="Login" />
            </Menu>
            <Footer pad={{ horizontal: 'medium', vertical: 'small' }}>
              <CloudIcon />
            </Footer>
          </Sidebar>
        );
    }
}