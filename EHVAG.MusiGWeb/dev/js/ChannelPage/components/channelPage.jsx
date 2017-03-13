import React from 'react';
import ChannelItem from './channelItem';

class ChannelPage extends React.Component {

    createChannelItems() {
        return this.props.channels.map((channel) => {
            if (channel.Name.toLowerCase().indexOf(this.props.filterText.toLowerCase()) === -1) {
                return false;
            }
            return (<ChannelItem channel={channel} key={channel.id} / >);
        });
    }

    render() {
        return (
          <div class="row">
            {this.createChannelItems()}
          </div>
        );
    }
}

export default ChannelPage;