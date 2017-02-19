import React from 'react';
import ClassNames from 'classnames';

class SearchBar extends React.Component {
  constructor(props) {
    super(props);
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange() {
    this.props.onUserInput(
      this.filterTextInput.value,
    );
  }

  render() {
    const SeachBarStyle = ClassNames('searchbar', 'form-control', 'col-lg-12');

    return (
      <div class="row">
        <div class="form-group has-feedback searchbar-wrapper">
          <input
            type="text"
            placeholder="Search..."
            value={this.props.filterText}
            ref={input => this.filterTextInput = input}
            onChange={this.handleChange}
            class={SeachBarStyle}
          />
          <span class="glyphicon glyphicon-search form-control-feedback" />
        </div>
      </div>
    );
  }
}

export default SearchBar;
