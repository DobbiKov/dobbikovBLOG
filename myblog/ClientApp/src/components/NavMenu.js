import React, { Component, useCallback, useState, useContext } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Label } from 'reactstrap';
import { Link } from 'react-router-dom';
import {useAuth} from '../hooks/auth.hook';
import {AuthContext} from '../context/AuthContext';
// import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';

export const  NavMenu = () => {
  const [collapsed, setCollapsed] = useState(true);
  const auth = useContext(AuthContext);
  const isAuthenticated = !!auth.token;

  const toggleNavbar = useCallback(() => {
    setCollapsed(!collapsed);
  }, []);

  const logoutHandler = () => {
    auth.logout();
  }

  return (
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
        <Container>
          <NavbarBrand tag={Link} to="/">DobbiKov</NavbarBrand>
          <NavbarToggler onClick={toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/blog">Blog</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/portfolio">Portfolio</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/contact">Contacts</NavLink>
              </NavItem>
              {/* <LoginMenu>
              </LoginMenu> */}
              {isAuthenticated ? 
              <div style={{display: 'flex'}}>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/user">{auth.name}</NavLink>
                </NavItem> 
                <NavItem>
                  <NavLink tag={Link} className="text-dark" onClick={logoutHandler} to="/">LogOut</NavLink>
                </NavItem></div> :
              <div style={{display: 'flex'}}>
                <NavItem>
                <NavLink tag={Link} className="text-dark" to="/auth">Login</NavLink>
                </NavItem> 
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
                </NavItem>
            </div>
              }
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
}
