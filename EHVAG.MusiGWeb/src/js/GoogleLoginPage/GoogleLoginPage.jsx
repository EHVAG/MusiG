import React from 'react';
import { connect, dispatch } from 'react-redux';
import GoogleLogin from 'react-google-login';
import Box from 'grommet/components/Box';
import Button from 'grommet/components/Button';
import Title from 'grommet/components/Title';
import { verifyGoogleIdToken, error } from './Actions/GoogleLoginActions';

class GoogleLoginPage extends React.Component {
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
                onSuccess={IdToken => this.props.onSuccess(IdToken)}
                onFailure={this.props.onError}
                offline={false}
                approvalPrompt="force"
                responseType="id_token"
                style={{}}
                disabled={false}
              />
            </Button>
          </Box>
        );
    }
}

const mapDispatchToProps = {
    onSuccess: verifyGoogleIdToken,
    onError: error,
};

export default connect(null, mapDispatchToProps)(GoogleLoginPage);