import React, {useEffect, useState} from 'react';
import {useAuth} from '../hooks/auth.hook';
import {Redirect} from 'react-router-dom';

export const User = () => {
    const {login, logout, token, userId, roleId} = useAuth();
    const isAuth = !!token;
    const [user, setUser] = useState({});
    const [loading, setLoading] = useState(true);
    const populateUser = async () => {
        const response = await fetch(`/api/Accounts/${userId}`, {headers: {}});
        const data = await response.json();
        setUser(data);
        setLoading(false);
    }
    useEffect(() => {
        if(isAuth) populateUser();
    }, []);
    if(!isAuth) {return(<Redirect to="/auth"/>)}
    return(
        <div>
        {loading ? <p>loading</p> :
        <div>
            <h1>{user.login}</h1>
            <h2>{user.role}</h2>
        </div>}</div>
    )
}