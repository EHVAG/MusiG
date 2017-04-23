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
            channelActionUrl = `Channel/Add?channelname=${this.props.channel.name}`;
            channelActionText = 'Verbinden!';
        } else if (this.props.channel.state === 1) {
            channelActionUrl = `Channel/Remove?channelname=${this.props.channel.name}`;
            channelActionText = 'Entfernen!';
        } else {
            channelActionUrl = '#/channel';
            channelActionText = 'Comming Soon™';
        }

        return (
          <div class={channelItemWrapper}>
            <a href={this.props.channel.url} target="_blank">
              <i class={channelItemClasses} aria-hidden="true" />
            </a>
            <h4 class={channelItemHeader}>{this.props.channel.name}</h4>
            <div class={channelItemHAction}>
              <a class="btn btn-outlined btn-white btn-sm" href={channelActionUrl}>{channelActionText}</a>
            </div>
          </div>
        );
    }
}


export default ChannelItem;