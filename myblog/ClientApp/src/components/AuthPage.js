import React, {Component, useContext, useState, useEffect} from 'react';
import {Redirect, Route} from 'react-router-dom';
import {AuthContext} from '../context/AuthContext';
import {useHttp} from '../hooks/http.hook';

export const AuthPage = () => {
    const {request} = useHttp();
    const auth = useContext(AuthContext);
    const [form, setForm] = useState({
        username: '', password: ''
    })

    const changeHandler = event => {
        setForm({...form, [event.target.name]: event.target.value})
    }

    const loginHandler = async () => {

        console.log({...form});
        const response = await request('api/Accounts/token', 'POST', JSON.stringify({...form}), {"Accept": "application/json", "Content-Type" : "application/json"});

        const data = await response.json();
        console.log(`AuthPage == ${data}`)
        if(response.ok === true){
            auth.login(data.token);
        }
    }
    if(auth.isAuthenticated) {return <Redirect to="/user"/>} else{
    return(
        <div style={{display: 'block'}}>
            <h2>Введите Email</h2>
            <input type="input" placeholder="Введите Email" id="inputLoginEmail" name="username" onChange={changeHandler}/>
            <h2>Введите пароль</h2>
            <input type="input" placeholder="Введите пароль" id="inputLoginPass" name="password" onChange={changeHandler}/>
            <input type="submit" value="Авторизоваться" onClick={loginHandler}/>
        </div>
    )
    }
}