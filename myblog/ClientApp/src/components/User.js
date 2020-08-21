import React, {useEffect, useState, useContext} from 'react';
import {AuthContext} from '../context/AuthContext';
import {Redirect} from 'react-router-dom';
import {useHttp} from '../hooks/http.hook';

export const User = () => {
    const auth = useContext(AuthContext);
    const [user, setUser] = useState({});
    const [role, setRole] = useState({});
    const [loading2, setLoading2] = useState(true);
    const [loading, setLoading] = useState(true);
    const {request} = useHttp();
    const populateUser = async () => {
        const response = await fetch(`/api/Accounts/${auth.token}`, {headers: {}});
        const data = await response.json();
        setUser(data);
        setLoading(false);
        populateUserRole(data.userRoleId);
    }
    const populateUserRole = async (idx) => {
        const response = await fetch(`/api/Roles/${idx}`, {headers: {}});
        const data = await response.json();
        setRole(data);
        setLoading2(false);
    }
    useEffect(() => {
        populateUser();
    }, []);
    return(
        <div>
            <h1>Your account</h1>
            {loading ? <p>loading</p> :
            <div>
                <h1>{user.login}</h1>
                <h2>{role.name}</h2>
            </div>}
        </div>
    )
}