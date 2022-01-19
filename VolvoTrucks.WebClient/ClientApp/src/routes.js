import React, { Fragment, lazy, Suspense } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import SplashScreen from './components/SplashScreen';

export const renderRoutes = (routes = []) => (
  <Suspense fallback={<SplashScreen />}>
    <Switch>
      {routes.map((route) => {
        const Guard = route.guard || Fragment;
        const Layout = route.layout || Fragment;
        const Component = route.component;

        return (
          <Route
            key={`route-${route.path}`}
            path={route.path}
            exact={route.exact}
            render={(props) => (
              <Guard>
                <Layout>
                  {route.routes ? (
                    renderRoutes(route.routes)
                  ) : (
                    <Component {...props} />
                  )}
                </Layout>
              </Guard>
            )}
          />
        );
      })}
    </Switch>
  </Suspense>
);

const routes = [
  {
    exact: true,
    path: '/',
    component: lazy(() => import('src/pages/MainPage'))
  },
  {
    path: '*',
    routes: [
      {
        component: () => <Redirect to="/" />
      }
    ]
  }
];

export default routes;
