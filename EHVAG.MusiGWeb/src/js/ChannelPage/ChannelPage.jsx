import React from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import Header from 'grommet/components/Header';
import Title from 'grommet/components/Title';
import Search from 'grommet/components/Search';
import Box from 'grommet/components/Box';
import Tiles from 'grommet/components/Tiles';
import ChannelTile from './Components/ChannelTile';
import { fetchChannels } from './Actions/ChannelActions';

class ChannelPage extends React.Component {
    componentWillMount() {
        this.props.onFetchChannels();
    }

    render() {
        const { channels } = this.props;

        let items,
            onMore;
        if (channels) {
            items = channels.map(item => <ChannelTile key={item.Id} item={item} />);
            if (channels.count > 0 && channels.count < channels.total) {
                onMore = this.onMore;
            }
        }

        return (
          <Box appCentered={false}>
            <Header size="large" pad={{ horizontal: 'medium' }}>
              <Title responsive={false}>
                <span>Kanäle</span>
              </Title>
              <Search inline fill size="medium" placeHolder="Suche" />
            </Header>
            <Tiles flush={false} fill={false}>
              {items}
            </Tiles>
            {this.props.children}
          </Box>
        );
    }
}

function mapStateToProps(store) {
    return {
        channels: store.channels.channels,
    };
}

const mapDispatchToProps = {
    onFetchChannels: fetchChannels,
};

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(ChannelPage));