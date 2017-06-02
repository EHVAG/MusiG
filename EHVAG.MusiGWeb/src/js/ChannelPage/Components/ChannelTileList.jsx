import React from 'react';
import Header from 'grommet/components/Header';
import Title from 'grommet/components/Title';
import Search from 'grommet/components/Search';
import Box from 'grommet/components/Box';
import Tiles from 'grommet/components/Tiles';
import ChannelTile from './ChannelTile';
import Button from 'grommet/components/Button';

class ChannelTileList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            searchText: '',
        };
    }

    comonentWillMount() {
        this.props.onFetchChannels();
    }

    render() {
        let items,
            onMore;
        if (this.props.channels) {
            items = this.props.channels.map(item => (
              <ChannelTile
                key={item.id}
                channel={item}
                onClick={() => this.props.onChannelAddClick()}
              />
      ));
            if (
        this.props.channels.count > 0 &&
        this.props.channels.count < this.props.channels.total
      ) {
                onMore = this.onMore;
            }
        }

        return (
          <Box appCentered="false">
            <Header size="large" pad={{ horizontal: 'medium' }}>
              <Title responsive={false}>
                <span>Kanäle</span>
              </Title>
            </Header>
            <Tiles flush={false} fill={false}>
              {items}
            </Tiles>
          </Box>
        );
    }
}

export default ChannelTileList;