import MusiG from './MusiG/index';
import VisibleChannelPage from './ChannelPage/VisibleChannelPage';
import LiveFeed from './LiveFeed/LiveFeed';
import LoginPage from './LoginPage/index';
// import TBD from 'grommet/components/TBD';

const routes = [
    {
        path: '/',
        component: MusiG,
        indexRoute: { component: LiveFeed },
        childRoutes: [
      { path: 'channel', component: VisibleChannelPage },
      { path: 'login', component: LoginPage },
        ],
    },
];

export default routes;