import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './components/NavMenu';
import { Route } from 'react-router';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Portfolio } from './components/portfolio';
import { Contacts } from './components/Contacts';
import { Blog } from './components/Blog';
import Post from './components/Post';
import {AuthContext} from './context/AuthContext';
import {AuthPage} from './components/AuthPage';
//import {useAuth} from './hooks/auth.hook';

// import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
// import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
// import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'
import { useAuth } from './hooks/auth.hook';

function App(){
  const {login, logout, token, userId, roleId} = useAuth();
  const isAuthenticated = !!token;
  return (
    <AuthContext.Provider value={{
      login, logout, token, userId, roleId, isAuthenticated
    }}>
      <div>
        <NavMenu />
        <Container>
          <Route exact path='/' component={Home}/>
          <Route path='/post/:id' component={Post} />
          <Route path='/blog' component={Blog} />
          <Route path='/portfolio' component={Portfolio} />
          {/* <AuthorizeRoute path='/fetch-data' component={FetchData} /> */}
          <Route path='/contact' component={Contacts} />
          <Route path='/auth' component={AuthPage}/>
          <Route path='/user' component={AuthPage}/>
          {/* //<Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} /> */}
        </Container>
      </div>
    </AuthContext.Provider>
  );
}
export default App;
