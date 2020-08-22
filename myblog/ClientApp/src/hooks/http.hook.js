import {useCallback, useContext, useState} from 'react';
import {AuthContext} from '../context/AuthContext';
export const useHttp = () => {
    const auth = useContext(AuthContext);
    const [_token, set_token] = useState(auth.token);
    const request = useCallback(async (url, method = 'GET', body = null, headers = {}) => {
        if(auth.isAuthenticated)
        {
            const token = auth.token;
            const response = await fetch('/api/Accounts/updateToken', {method: 'POST', body: JSON.stringify({token}), headers: {"Accept": "application/json", "Content-Type" : "application/json"}});
            const data = await response.json();
            if(!response.ok) auth.logout();
            else{
                auth.login(data.token);
            }
        }
        if(body){
            headers['Content-Types'] = "application/json";
        }
        const response = await fetch(url, {method, body, headers});
        return response;
    }, []);
    return {request}
}