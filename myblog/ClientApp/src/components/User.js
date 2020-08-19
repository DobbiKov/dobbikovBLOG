import React, {useEffect, useState, useContext} from 'react';
import {AuthContext} from '../context/AuthContext';
import {Redirect} from 'react-router-dom';

export const User = () => {
    const auth = useContext(AuthContext);
    const [user, setUser] = useState({});
    const [role, setRole] = useState({});
    const [loading2, setLoading2] = useState(true);
    const [loading, setLoading] = useState(true);
    const populateUser = async (_userId) => {
        if(_userId == null) { setTimeout(() => { populateUser(); }, 2000); console.log("userId == null таймер"); }else{
            const response = await fetch(`/api/Accounts/${_userId}`, {headers: {}});
            const data = await response.json();
            setUser(data);
            setLoading(false);
        }
    }
    const populateUserRole = async (idx) => {
        const response = await fetch(`/api/Roles/${idx}`, {headers: {}});
        const data = await response.json();
        setRole(data);
        setLoading2(false);
    }
    useEffect(() => {
        populateUser(auth.userId);
        populateUserRole(auth.userId);
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