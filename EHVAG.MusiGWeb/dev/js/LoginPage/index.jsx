import React from 'react';
import GoogleLogin from 'react-google-login';
import Box from 'grommet/components/Box';
import Button from 'grommet/components/Button';
import Title from 'grommet/components/Title';
import Environment from '../Environment';

class Index extends React.Component {
    constructor(props) {
        console.log(Environment);
        super(props);
        this.onSuccess = this.onSuccess.bind(this);
        this.onError = this.onError.bind(this);
    }

    onSuccess(googleIdToken) {
        const xhr = new XMLHttpRequest();
        xhr.open('POST', 'api/Login/GoogleLogin');
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xhr.onload = function () {
            console.log(`Signed in as: ${xhr.responseText}`);
        };
        const obj = { idtoken: googleIdToken.getAuthResponse().id_token };
        const myJSON = JSON.stringify(obj);
        xhr.send(myJSON);
    }

    onError() {
        console.log('onError');
    }

    render() {
        return (
          <Box appCentered="false">
            <Title responsive={false}>
              <span>Kanäle</span>
            </Title>
            <Button>
              {/*
                  For the style property we just provide a dummy value.
                  So Gromment can overwrite the default style wich this component provides.
              */}
              {/*
                  TODO: scope and clientId should not be static in the code.
                  Move to some config file.
              */}
              <GoogleLogin
                clientId="621236350765-15njpt6aaf05jtmoag5n1igd4oa6idjj.apps.googleusercontent.com"
                scope="https://www.googleapis.com/auth/userinfo.profile"
                onSuccess={this.onSuccess}
                onFailure={this.onError}
                offline={false}
                approvalPrompt="force"
                responseType="id_token"
                style={{ }}
                disabled={false}
              />
            </Button>
          </Box>
        );
    }
}

export default (Index);