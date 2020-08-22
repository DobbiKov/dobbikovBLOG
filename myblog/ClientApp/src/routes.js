import React, {useContext, useState, useEffect} from 'react';
import { Switch, Route } from 'react-router-dom';
import { Container } from 'reactstrap';
import {useAuth} from './hooks/auth.hook';
import {AuthContext} from './context/AuthContext';
import {useUser} from './hooks/user.hook';

import { Home } from './components/Home';
import { Portfolio } from './components/portfolio';
import { Contacts } from './components/Contacts';
import { Blog } from './components/Blog';
import Post from './components/Post';
import {AuthPage} from './components/AuthPage';
import {User} from './components/User';

import {EditHome} from './admin/home/home';
import {AdminPortfolios} from './admin/portfolio/portfolio';
import {AdminDeletePortfolio} from './admin/portfolio/deletePortfolio';
import {AdminEditPortfolio} from './admin/portfolio/editPortfolio';
import {AdminCreatePortfolio} from './admin/portfolio/createPortfolio';
 
export const AllAuth = () => {
    const auth = useContext(AuthContext);
    const [user, setUser] = useState({});
    const [role, setRole] = useState({});

    const populateUser = async (_token) => {
        const response = await fetch(`/api/Accounts/${_token}`, {headers: {}});
        const data = await response.json();
        setUser(data);
        populateUserRole(data.userRoleId);
    }
    const populateUserRole = async (idx) => {
        const response = await fetch(`/api/Roles/${idx}`, {headers: {}});
        const data = await response.json();
        setRole(data);
    }
    useEffect(() => {
        populateUser(auth.token);
    }, [auth]);
    return(
        <Container>
            <Route path='/user' component={User}/>
            {role.canEditMainPage ? <Route path="/admin/home" component={EditHome}/> : <Container/>}
            {role.canEditMainPage ? <Route path="/admin/portfolios" component={AdminPortfolios}/> : <Container/>}
            {role.canEditMainPage ? <Route path="/admin/portfolio/delete/:id" component={AdminDeletePortfolio}/> : <Container/>}
            {role.canEditMainPage ? <Route path="/admin/portfolio/edit/:id" component={AdminEditPortfolio}/> : <Container/>}
            {role.canEditMainPage ? <Route path="/admin/portfolio/new" component={AdminCreatePortfolio}/> : <Container/>}
        </Container>
    )
}

export const CanCreate = () => {

}
export const CanEdit = () => {

}
export const CanDelete = () => {

}
export const CanBanUsers = () => {

}
export const CanCreateRoles = () => {

}
export const CanEditMainPage = () => {

}



export const useRoutes = isAuthenticated => {
    return(
        <Container>
            <Route exact path='/' component={Home}/>
            <Route path='/post/:id' component={Post} />
            <Route path='/blog' component={Blog} />
            <Route path='/portfolio' component={Portfolio} />
            <Route path='/contact' component={Contacts} />
            <Route path='/auth' component={AuthPage}/>
            <AllAuth/>
        </Container>)
}