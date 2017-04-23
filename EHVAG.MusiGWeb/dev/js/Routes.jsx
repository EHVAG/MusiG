import MusiG from './MusiG/index';
import ChannelPage from './ChannelPage/index';
import LiveFeed from './LiveFeed/LiveFeed';
import LoginPage from './LoginPage/index';
// import TBD from 'grommet/components/TBD';

const routes = [
    { path: '/',
        component: MusiG,
        indexRoute: { component: LiveFeed },
        childRoutes: [
            { path: 'channel', component: ChannelPage },
            { path: 'login', component: LoginPage },
        ],
    },
];

export default routes;