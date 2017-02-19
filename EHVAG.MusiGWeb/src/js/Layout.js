import React from 'react';
import SideNav from './SideNav';
import LiveFeedSubs from './LiveFeedSubs';
import FilterableChannelPage from './Channels/FilterableChannelPage';
import ChannelData from '../data/ChannelData';

export default class Layout extends React.Component {
    render() {
        return (
              // <div id="LiveFeedSubs">
              //    <LiveFeedSubs subscriptions={data} />
              // </div>

              <div id="Channels">
                  <FilterableChannelPage channels={ChannelData} />
              </div>
        );
    }
}
