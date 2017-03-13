import React from 'react';
import ChannelPage from './channelPage';
import SearchBar from '../../Shared/SearchBar';

class FilterableChannelPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            filterText: '',
        };

        this.handleUserInput = this.handleUserInput.bind(this);
    }

    handleUserInput(filter) {
        this.setState({
            filterText: filter,
        });
    }

    render() {
        return (
          <div class="container">
            <SearchBar
              filterText={this.state.filterText}
              onUserInput={this.handleUserInput}
            />

            <ChannelPage
              channels={this.props.channels}
              filterText={this.state.filterText}
            />
          </div>
        );
    }
}

export default FilterableChannelPage;