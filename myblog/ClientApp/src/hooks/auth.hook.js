import React, { useState, useCallback, useEffect } from 'react';

const storageName = 'userData';


export const useAuth = () => {
    const [token, setToken] = useState(null);
    const [userId, setUserId] = useState(null);
    const [name, setName] = useState(null);

    const login = useCallback((jwtToken, id, _name) => {
        setToken(jwtToken);
        setUserId(id);
        setName(_name);

        localStorage.setItem(storageName, JSON.stringify({userId: id, token: jwtToken, name: _name}));
    }, [])
    const logout = useCallback(() => {
        setToken(null);
        setUserId(null);
        setName(null);
        localStorage.removeItem(storageName);
    }, [])

    useEffect(() => {
        const data = JSON.parse(localStorage.getItem(storageName));

        if(data && data.token){
            login(data.token, data.userId, data.name);
        }
    }, [login]);

    return {login, logout, token, userId, name};
}