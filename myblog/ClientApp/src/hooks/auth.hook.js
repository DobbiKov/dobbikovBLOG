import React, { useState, useCallback, useEffect } from 'react';

const storageName = 'userData';

// export class AuthHook{
//     token = null;
//     userId = null;

//     static login = useCallback((jwtToken, id) => {
//         this.token = jwtToken; 
//         this.userId = id;
//         localStorage.setItem(storageName, JSON.stringify({jwtToken, id}));
//     }, [])

//     static logout = useCallback(() => {
//         this.token = null; this.userId = null;
//         localStorage.removeItem(storageName);
//     }, [])

//     componentDidMount() 
//     {    
//         const data = JSON.parse(localStorage.getItem(storageName));

//         if(data && data.token){
//             AuthHook.login(data.token, data.userId);
//         }       
//     }  
//     componentDidUpdate() 
//     {    
//         const data = JSON.parse(localStorage.getItem(storageName));

//         if(data && data.token){
//             AuthHook.login(data.token, data.userId);
//         }  
//     }

//     static Get(){
//         const _token = this.token;
//         const _userId = this.userId;
//         const _login = AuthHook.login;
//         const _logout = AuthHook.logout;
//         return {_login, _logout, _token, _userId};
//     }

//     static get instance() { return authHook }
// }

// const authHook = new AuthHook();

// export default authHook;


export const useAuth = () => {
    const [token, setToken] = useState(null);
    const [userId, setUserId] = useState(null);
    const [roleId, setRoleId] = useState(null);

    const login = useCallback((jwtToken, id, _roleid) => {
        setToken(jwtToken);
        setUserId(id);
        setRoleId(_roleid);

        localStorage.setItem(storageName, JSON.stringify({userId: id, token: jwtToken, roleId: _roleid}));
    }, [])
    const logout = useCallback(() => {
        setToken(null);
        setUserId(null);
        setRoleId(null);
        localStorage.removeItem(storageName);
    }, [])

    useEffect(() => {
        const data = JSON.parse(localStorage.getItem(storageName));

        if(data && data.token){
            login(data.token, data.userId, data.roleId);
        }
    }, [login]);

    return {login, logout, token, userId, roleId};
}