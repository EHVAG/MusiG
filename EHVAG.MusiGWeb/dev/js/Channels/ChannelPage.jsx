import React from 'react';
import ChannelItem from './ChannelItem';

class ChannelPage extends React.Component {
  render() {
    const rows = [];
    this.props.channels.forEach((channel) => {
      if (channel.title.toLowerCase().indexOf(this.props.filterText.toLowerCase()) === -1) {
        return;
      }
      rows.push(<ChannelItem channel={channel} key={channel.title} />);
    });
    return (
      <div class="row">
        {rows}
      </div>
    );
  }
}

export default ChannelPage;
