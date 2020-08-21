import React, {Component} from 'react';
import { Switch, Route } from 'react-router-dom';
import { Container } from 'reactstrap';
import {useAuth} from './hooks/auth.hook';

import { Home } from './components/Home';
import { Portfolio } from './components/portfolio';
import { Contacts } from './components/Contacts';
import { Blog } from './components/Blog';
import Post from './components/Post';
import {AuthPage} from './components/AuthPage';
import {User} from './components/User';

import {EditHome} from './admin/blog/home';

export const useRoutes = isAuthenticated => {
    if(isAuthenticated){
        return(
            <Container>
                <Route exact path='/' component={Home}/>
                <Route path='/post/:id' component={Post} />
                <Route path='/blog' component={Blog} />
                <Route path='/portfolio' component={Portfolio} />
                <Route path='/contact' component={Contacts} />
                <Route path='/auth' component={AuthPage}/>
                <Route path='/user' component={User}/>
                <Route path='/admin/blog' component={EditHome}/>
            </Container>
        )
    }
    else{
        return(
            <Container>
                <Route exact path='/' component={Home}/>
                <Route path='/post/:id' component={Post} />
                <Route path='/blog' component={Blog} />
                <Route path='/portfolio' component={Portfolio} />
                <Route path='/contact' component={Contacts} />
                <Route path='/auth' component={AuthPage}/>
            </Container>)
    }
}