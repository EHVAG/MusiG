import React from "react";
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import Header from "grommet/components/Header";
import Title from "grommet/components/Title";
import Search from "grommet/components/Search";
import Box from "grommet/components/Box";
import Tiles from "grommet/components/Tiles";
import ChannelTile from "./Components/ChannelTile";
import { fetchChannels, filterChannels } from "./Actions/ChannelActions";

class ChannelPage extends React.Component {
  componentWillMount() {
    this.props.onFetchChannels();
  }

  render() {
    const { channels } = this.props;

    let items, onMore;
    if (channels) {
      items = channels.map(item => <ChannelTile key={item.Id} item={item} />);
      if (channels.count > 0 && channels.count < channels.total) {
        onMore = this.onMore;
      }
    }

    return (
      <Box appCentered={false}>
        <Header size="large" pad={{ horizontal: "medium" }}>
          <Title responsive={false}>
            <span>Kanäle</span>
          </Title>
          <Search
            inline
            fill
            size="medium"
            placeHolder="Suche"
            onDOMChange={event => this.props.onSearchChange(event.target.value)}
          />
        </Header>
        <Tiles flush={false} fill={false}>
          {items}
        </Tiles>
        {this.props.children}
      </Box>
    );
  }
}

const getVisibileChannels = (channels, filter) => {
  if (filter !== "") {
    const patt = new RegExp("^" + filter + ".*", "i");
    return channels.filter(c => patt.test(c.Name));
  }
  return channels;
};

function mapStateToProps(store) {
  return {
    channels: getVisibileChannels(
      store.channelPage.channels,
      store.channelPage.channelFilter
    )
  };
}

const mapDispatchToProps = {
  onFetchChannels: fetchChannels,
  onSearchChange: filterChannels
};

export default withRouter(
  connect(mapStateToProps, mapDispatchToProps)(ChannelPage)
);
