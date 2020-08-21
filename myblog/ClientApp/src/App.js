import React, { Component } from 'react';
import { Container } from 'reactstrap';
import {NavMenu} from './components/NavMenu';
import {AuthContext} from './context/AuthContext';
import {useRoutes} from './routes';
//import {useAuth} from './hooks/auth.hook';

// import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
// import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
// import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'
import { useAuth } from './hooks/auth.hook';

function App(){
  const {login, logout, token} = useAuth();
  const isAuthenticated = !!token;
  const routes = useRoutes(isAuthenticated)
  return (
    <AuthContext.Provider value={{
      login, logout, token, isAuthenticated
    }}>
      <div>
        <NavMenu />
        {routes}
      </div>
    </AuthContext.Provider>
  );
}
export default App;
