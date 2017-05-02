import React from 'react';
import { connect } from 'react-redux';
import Header from 'grommet/components/Header';
import Title from 'grommet/components/Title';
import Search from 'grommet/components/Search';
import Box from 'grommet/components/Box';
import Tiles from 'grommet/components/Tiles';
import ChannelTile from './Components/ChannelTile';
import { fetchChannels } from './Actions/ChannelActions';
import Button from 'grommet/components/Button';

class Index extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            searchText: '',
        };

        this.onSearch = this.onSearch.bind(this);
    }

    componentWillMount() {
        this.props.dispatch(fetchChannels());
    }

    onSearch(text) {
        this.setState({
            searchText: text,
        });
    }

    render() {
        const { channels } = this.props;

        let items,
            onMore;
        if (channels) {
            items = channels.map(item => (
              <ChannelTile key={item.id} item={item} />
          ));
            if (channels.count > 0 && channels.count < channels.total) {
                onMore = this.onMore;
            }
        }

        return (
          <Box appCentered="false">
            <Header size="large" pad={{ horizontal: 'medium' }}>
              <Title responsive={false}>
                <span>Kanäle</span>
              </Title>
              <Search
                inline fill size="medium" placeHolder="Suche"
                value={this.state.searchText} onDOMChange={this.onSearch}
              />
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

export default connect(mapStateToProps)(Index);