const Environments = {
    production: { BASE_URL: '', API_KEY: '', API_ENDPOINT: 'http://localhost' },
    staging: { BASE_URL: '', API_KEY: '', API_ENDPOINT: 'http://localhost' },
    development: { BASE_URL: '', API_KEY: '', API_ENDPOINT: 'http://localhost:1337' },
};

function getEnvironment() {
    // Insert logic here to get the current platform (e.g. staging, production, etc)
    const currentEnviorment = 'development';

    // ...now return the correct environment
    return Environments[currentEnviorment];
}

const Environment = getEnvironment();
export default Environment;