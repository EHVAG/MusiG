import React from 'react';
import ChannelItem from './ChannelItem';

class ChannelPage extends React.Component {
  render() {
    console.log(this.props);
    let rows = [];
    this.props.channels.forEach((channel) => {
      if (channel.title.indexOf(this.props.filterText) === -1) {
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
