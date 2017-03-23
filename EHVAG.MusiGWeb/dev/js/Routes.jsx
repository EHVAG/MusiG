import MusiG from './MusiG/index';
import ChannelPage from './ChannelPage/index';
import LiveFeed from './LiveFeed/LiveFeed';
// import TBD from 'grommet/components/TBD';

const routes = [
    { path: '/',
        component: MusiG,
        indexRoute: { component: LiveFeed },
        childRoutes: [
            { path: 'channel', component: ChannelPage },
        ],
    },
];

export default routes;