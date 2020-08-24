//react
import React, {useContext, useState, useEffect} from 'react';
import { Switch, Route } from 'react-router-dom';
import { Container } from 'reactstrap';

//hooks + contexts
import {useAuth} from './hooks/auth.hook';
import {AuthContext} from './context/AuthContext';
import {useUser} from './hooks/user.hook';

//components
import { Home } from './components/Home';
import { Portfolio } from './components/portfolio';
import { Contacts } from './components/Contacts';
import { Blog } from './components/Blog';
import Post from './components/Post';
import {AuthPage} from './components/AuthPage';
import {RegPage} from './components/RegPage';
import {User} from './components/User';

//admin components
import {Admin} from './admin/admin';
import {EditHome} from './admin/home/home';
//admin components portfolio
import {AdminPortfolios} from './admin/portfolio/portfolio';
import {AdminDeletePortfolio} from './admin/portfolio/deletePortfolio';
import {AdminEditPortfolio} from './admin/portfolio/editPortfolio';
import {AdminCreatePortfolio} from './admin/portfolio/createPortfolio';
//admin components contacts
import {AdminContacts} from './admin/contacts/contacts';
import {AdminEditContacts} from './admin/contacts/editContact';
import {AdminDeleteContact} from './admin/contacts/deleteContact';
import {AdminCreateContact} from './admin/contacts/createContact';
//admin components posts
import {AdminBlog} from './admin/blog/blog';
import {AdminCreatePost} from './admin/blog/createPost';
import {AdminDeletePost} from './admin/blog/deletePost';
import {AdminUpdatePost} from './admin/blog/editPost';

 
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
    if(auth.isAuthenticated){
    return(
        <Container>
            <Route path='/user' component={User}/>
            {role.canEditMainPage === "True" ? <Route path="/admin/home" component={EditHome}/> : <Container/>}

            {role.canEditMainPage === true ? <Route path="/admin/portfolios" component={AdminPortfolios}/> : <Container/>}
            {role.canEditMainPage === true ? <Route path="/admin/portfolio/delete/:id" component={AdminDeletePortfolio}/> : <Container/>}
            {role.canEditMainPage === true ? <Route path="/admin/portfolio/edit/:id" component={AdminEditPortfolio}/> : <Container/>}
            {role.canEditMainPage === true ? <Route path="/admin/portfolio/new" component={AdminCreatePortfolio}/> : <Container/>}

            {role.canEditMainPage === true ? <Route path="/admin/contacts" component={AdminContacts}/> : <Container/>}
            {role.canEditMainPage === true ? <Route path="/admin/contact/edit/:id" component={AdminEditContacts}/> : <Container/>}
            {role.canEditMainPage === true ? <Route path="/admin/contact/delete/:id" component={AdminDeleteContact}/> : <Container/>}
            {role.canEditMainPage === true ? <Route path="/admin/contact/new" component={AdminCreateContact}/> : <Container/>}

            {role.canCreate === true ? <Route path="/admin/blog" component={AdminBlog}/> : <Container/>}
            {role.canCreate === true ? <Route path="/admin/post/new" component={AdminCreatePost}/> : <Container/>}
            {role.canDelete === true ? <Route path="/admin/post/delete/:id" component={AdminDeletePost}/> : <Container/>}
            {role.canEdit === true ? <Route path="/admin/post/edit/:id" component={AdminUpdatePost}/> : <Container/>}
            {role.canCreate === true ? <Route path="/admins" component={Admin}/> : <Container/>}
        </Container>
    )
    }
    else{
        return(
            <Container/>
        )
    }
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
            <Route path='/register' component={RegPage}/>
            <AllAuth/>
        </Container>)
}