import React, { Component, PropTypes } from 'react';
import Tile from 'grommet/components/Tile';
import Box from 'grommet/components/Box';
import Heading from 'grommet/components/Heading';
import Label from 'grommet/components/Label';
import Button from 'grommet/components/Button';

class ChannelTile extends Component {
    render() {
        const channel = this.props.item;

        let href;
        let label;

        if (channel.State === 'add') {
            href = `/api/Channel/AddChannel?channelName=${channel.Name}`;
            label = 'Hinzufügen';
        } else {
            href = `/api/Channel/RemoveChannel?channelName=${channel.Name}`;
            label = 'Entfernen';
        }

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
                <i class={channel.FontAwesomeIconClass} />
              </Heading>
              <Label size="medium">
                {channel.Name}
              </Label>
              <Box>
                <Button
                  label={label}
                  primary
                  accent={false}
                  plain={false}
                  href={href}
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
    selected: PropTypes.bool,
};

export default ChannelTile;