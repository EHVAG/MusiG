// (C) Copyright 2014-2015 Hewlett Packard Enterprise Development LP

import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import Tile from 'grommet/components/Tile';
import Box from 'grommet/components/Box';
import Heading from 'grommet/components/Heading';
import Label from 'grommet/components/Label';
import Button from 'grommet/components/Button';

class ChannelTile extends Component {

    render() {
        return (
          <Tile
            align="center" separator="all" pad="small" justify="between"
            size="small"
            onClick={this.props.onClick} selected={this.props.selected}
          >
            <Box align="center">
              <Heading tag="h3" align="center" strong>
                <i class={this.props.item.fontAwesomeIconClass} />
              </Heading>
              <Label size="medium">
                {this.props.item.name}
              </Label>
              <Box>
                <Button
                  label={this.props.item.name}
                  href="#"
                  primary
                  accent={false}
                  plain={false}
                  path={''}
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
    onClick: PropTypes.func,
    selected: PropTypes.bool,
};

ChannelTile.defaultProps = {
    editable: true,
};

// const select = state => ({
//     role: state.session.role,
// });

// Using export default doesn't seem to pull in the defaultProps correctly
export default ChannelTile;