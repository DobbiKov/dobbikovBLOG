import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Portfolio } from './components/portfolio';
import {Contacts} from './components/Contacts';
import {Blog} from './components/Blog';
// import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
// import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
// import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home}/>
        <Route path='/blog' component={Blog} />
        <Route path='/portfolio' component={Portfolio} />
        {/* <AuthorizeRoute path='/fetch-data' component={FetchData} /> */}
        <Route path='/contact' component={Contacts} />
        {/* //<Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} /> */}
      </Layout>
    );
  }
}
