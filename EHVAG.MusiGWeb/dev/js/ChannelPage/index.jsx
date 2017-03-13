import React from 'react';
import { connect } from 'react-redux';
import FilterableChannelPage from './components/filterableChannelPage';

import { fetchChannels } from './actions/channelActions';

class Index extends React.Component {
    componentWillMount() {
        this.props.dispatch(fetchChannels());
    }

    render() {
        const { channels } = this.props;

        if (!channels.length) {
            // TODO: Add this here. Bind won't work
            // return <button onClick={this.fetchTweets.bind(this)}>load tweets</button>
            return <div />;
        }

        return (
          <FilterableChannelPage channels={channels} />
        );
    }
}

function mapStateToProps(store) {
    return {
        channels: store.channels.channels,
    };
}

export default connect(mapStateToProps)(Index);