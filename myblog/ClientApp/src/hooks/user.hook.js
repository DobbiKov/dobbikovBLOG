import {useCallback, useContext, useState} from 'react';
import {AuthContext} from '../context/AuthContext';
export const useUser = () => {
    const auth = useContext(AuthContext);

    const populateUser = async () => {
        const response = await fetch(`/api/Accounts/${auth.token}`, {headers: {}});
        const data = await response.json();
        const user = data;
        const role = populateUserRole(data.userRoleId);
        return {user, role}
    }
    const populateUserRole = async (idx) => {
        const response = await fetch(`/api/Roles/${idx}`, {headers: {}});
        const data = await response.json();
        return data;
    }
    const getRole = async (_token) => {
        const response = await fetch(`/api/Accounts/${_token}`, {headers: {}});
        const data = await response.json();
        const role = populateUserRole(data.userRoleId);    
        return role;
    }
    return {populateUser, populateUserRole, getRole}
}