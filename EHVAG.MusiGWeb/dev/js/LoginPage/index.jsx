import React from 'react';
import { connect } from 'react-redux';
import Box from 'grommet/components/Box';
import Title from 'grommet/components/Title';

class Index extends React.Component {
    constructor(props) {
        super(props);
        this.onSignIn = this.onSignIn.bind(this);
        this.onClick = this.onClick.bind(this);

 // This binding is necessary to make `this` work in the callback
        this.handleClick = this.handleClick.bind(this);
    }

    componentDidMount() {
        gapi.signin2.render('g-signin2', {
            scope: 'https://www.googleapis.com/auth/plus.login',
            width: 200,
            height: 50,
            longtitle: true,
            theme: 'dark',
            onsuccess: this.onSignIn,
        });
    }

    onClick() {
        console.log('test');
    }
    onSignIn(googleIdToken) {
        console.log('test');
        const xhr = new XMLHttpRequest();
        xhr.open('POST', 'http://localhost/Login/GoogleLogin');
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xhr.onload = function () {
            console.log(`Signed in as: ${xhr.responseText}`);
        };
        const obj = { idtoken: googleIdToken };
        const myJSON = JSON.stringify(obj);
        xhr.send(myJSON);
    }

    handleClick() {
        console.log('test');
    }

    render() {
        return (
          <Box appCentered="false">
            <Title responsive={false}>
              <span>Kanäle</span>
            </Title>
            <div class="g-signin2" data-onsuccess={this.handleClick} onClick={this.onClick} />
          </Box>
        );
    }
}

function mapStateToProps(store) {
    return {
        channels: store.channels.channels,
    };
}

export default connect(mapStateToProps)(Index);