import React from 'react';
import { connect } from 'react-redux';
import Header from 'grommet/components/Header';
import Title from 'grommet/components/Title';
import Search from 'grommet/components/Search';
import Box from 'grommet/components/Box';
import Tiles from 'grommet/components/Tiles';
import ChannelTile from './Components/ChannelTile';
import { fetchChannels, addChannel } from './Actions/ChannelActions';
import Button from 'grommet/components/Button';
import Notification from 'grommet/components/Notification';

class VisibleChannelPage extends React.Component {
    componentWillMount() {
        this.props.onFetchChannels();
    }

    render() {
        const { channels } = this.props;

        let items,
            onMore;
        if (channels) {
            items = channels.map(item => (
              <ChannelTile
                key={item.id}
                item={item}
                onClick={this.props.onAddChannelClick}
              />
      ));
            if (channels.count > 0 && channels.count < channels.total) {
                onMore = this.onMore;
            }
        }

        return (
          <Box appCentered="false">
            <Notification message="Sample message" status="critical" />
            <Header size="large" pad={{ horizontal: 'medium' }}>
              <Title responsive={false}>
                <span>Kanäle</span>
              </Title>
              <Search inline fill size="medium" placeHolder="Suche" />
            </Header>
            <Tiles flush={false} fill={false}>
              {items}
            </Tiles>
          </Box>
        );
    }
}

function mapStateToProps(store) {
    return {
        channels: store.channels.channels,
    };
}

function mapStateToProps(store) {
    return {
        channels: store.channels.channels,
    };
}

const mapDispatchToProps = {
    onAddChannelClick: addChannel,
    onFetchChannels: fetchChannels,
};

export default connect(mapStateToProps, mapDispatchToProps)(VisibleChannelPage);