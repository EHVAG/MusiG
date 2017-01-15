import React from 'react';
import ChannelPage from './ChannelPage';
import SearchBar from '../SearchBar';

class FilterableChannelPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      filterText: '',
    };

    this.handleUserInput = this.handleUserInput.bind(this);
  }

  handleUserInput(filterText) {
    this.setState({
      filterText: filterText
    });
  }

  render() {
    return (
      <div class="container">
        <ChannelPage
          channels={this.props.channels.items}
          filterText={this.state.filterText}
        />
      </div>
    );
  }
}

export default FilterableChannelPage;
