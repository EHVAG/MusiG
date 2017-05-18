import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import Tile from 'grommet/components/Tile';
import Box from 'grommet/components/Box';
import Heading from 'grommet/components/Heading';
import Label from 'grommet/components/Label';
import Button from 'grommet/components/Button';

class ChannelTile extends Component {
    render() {
        const channel = this.props.item;

        return (
          <Tile
            align="center"
            separator="all"
            pad="small"
            justify="between"
            size="small"
          >
            <Box align="center">
              <Heading tag="h3" align="center" strong>
                <i class={channel.fontAwesomeIconClass} />
              </Heading>
              <Label size="medium">
                {channel.name}
              </Label>
              <Box>
                <Button
                  label={channel.name}
                  primary
                  accent={false}
                  plain={false}
                  href={`/api/Channel/AddChannel?channelName=${this.props.item.name}`}
                />
              </Box>
            </Box>
          </Tile>
        );
    }
}

ChannelTile.propTypes = {
    editable: PropTypes.bool,
    item: PropTypes.object.isRequired,
    onClick: PropTypes.func.isRequired,
    selected: PropTypes.bool,
};

export default ChannelTile;