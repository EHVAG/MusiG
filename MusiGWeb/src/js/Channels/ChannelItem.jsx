import React from 'react';
import ClassNames from 'classnames';


class ChannelItem extends React.Component {
  render() {
    const channelItemWrapper = ClassNames('channel-item-wrapper', 'text-center', 'col-xs-12 col-sm-6 col-md-3 col-lg-2', 'portfolio-item');
    const channelItemClasses = ClassNames('channel-item-icon', 'text-center', this.props.channel.fontAwesomeIconClass);
    const channelItemHeader = ClassNames('channel-item-header', 'text-center');
    const channelItemHAction = ClassNames('channel-item-action-wrapper', 'text-center');
    let channelActionUrl;
    let channelActionText;

    if (this.props.channel.state === 0) {
      channelActionUrl = `ConnectChannel/Add?channelId=${this.props.channel.id}`;
      channelActionText = 'Verbinden!';
    } else if (this.props.channel.state === 1) {
      channelActionUrl = `ConnectChannel/Remove?channelId=${this.props.channel.id}`;
      channelActionText = 'Entfernen!';
    } else {
      channelActionUrl = '#';
      channelActionText = 'Comming Soon™';
    }

    return (
      <div class={channelItemWrapper}>
        <a href={this.props.channel.url} target="_blank">
          <i class={channelItemClasses} aria-hidden="true" />
        </a>
        <h4 class={channelItemHeader}>{this.props.channel.title}</h4>
        <div class={channelItemHAction}>
          <a class="btn btn-outlined btn-white btn-sm" href={channelActionUrl}>{channelActionText}</a>
        </div>
      </div>
    );
  }
}


export default ChannelItem;
