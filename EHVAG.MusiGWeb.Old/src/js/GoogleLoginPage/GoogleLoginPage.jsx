import React from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import GoogleLogin from 'react-google-login';
import Box from 'grommet/components/Box';
import Button from 'grommet/components/Button';
import App from 'grommet/components/App';
import Article from 'grommet/components/Article';
import Title from 'grommet/components/Title';
import Headline from 'grommet/components/Headline';
import { verifyGoogleIdToken, error } from './Actions/GoogleLoginActions';

const GoogleLoginPage = props => (
  <Box pad={{ horizontal: 'medium' }} flex="grow">
    <Box
      appCentered
      alignContent="center"
      justify-content="center"
      justify="center"
    >
      <Headline
        size="small"
        strong={false}
        uppercase={false}
        truncate={false}
        align="center"
      >
        Logge dich ein um die App zu benutzen
      </Headline>

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
        onSuccess={IdToken => props.onSuccess(IdToken)}
        onFailure={props.onError}
        offline={false}
        approvalPrompt="force"
        responseType="id_token"
        style={{}}
        disabled={false}
      />
    </Box>
  </Box>
);

const mapDispatchToProps = {
    onSuccess: verifyGoogleIdToken,
    onError: error,
};

export default withRouter(connect(null, mapDispatchToProps)(GoogleLoginPage));