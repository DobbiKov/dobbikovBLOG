import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Portfolio } from './components/portfolio';
import { Contacts } from './components/Contacts';
import { Blog } from './components/Blog';
import { Post } from './components/Post';
import GetId from './components/getId';
import AuthContext from './context/AuthContext';
//import {useAuth} from './hooks/auth.hook';

// import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
// import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
// import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'

function App(){
  /*
  _authData = useAuth();
  _token = this._authData.token;
  _isAuthenticated = !!this._token;
  _userId = this._authData.userId;*/

  /*
    const __token = this._token;
    const __userId = this._userId;
    const __isAuthenticated = !!this._isAuthenticated;*/
  return (
    <Layout>
      <Route exact path='/' component={Home}/>
      <Route path='/post/:id' component={GetId} />
      <Route path='/blog' component={Blog} />
      <Route path='/portfolio' component={Portfolio} />
      {/* <AuthorizeRoute path='/fetch-data' component={FetchData} /> */}
      <Route path='/contact' component={Contacts} />
      {/* //<Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} /> */}
    </Layout>
  );
}
export default App;
