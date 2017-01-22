import React from 'react';
import ClassNames from 'classnames';


class ChannelItem extends React.Component {
  render() {
    const channelItemWrapper = ClassNames('channel-item-wrapper', 'text-center', 'col-xs-12 col-sm-6 col-md-3 col-lg-2', 'portfolio-item');
    const channelItemClasses = ClassNames('channel-item-icon', 'text-center', this.props.channel.fontAwesomeIconClass);
    const channelItemHeader = ClassNames('channel-item-header', 'text-center');
    const channelItemHAction = ClassNames('channel-item-action-wrapper', 'text-center');

    return (
      <div class={channelItemWrapper}>
        <a href={this.props.channel.url} target="_blank">
          <i class={channelItemClasses} aria-hidden="true" />
        </a>
        <h4 class={channelItemHeader}>{this.props.channel.title}</h4>
        <div class={channelItemHAction}>
          <button class="btn btn-outlined btn-white btn-sm">Connect!</button>
        </div>
      </div>
    );
  }
}

export default ChannelItem;
