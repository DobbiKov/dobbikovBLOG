import React, {Component, useContext, useState, useEffect} from 'react';
import {AuthContext} from '../context/AuthContext';

export const AuthPage = () => {
        const auth = useContext(AuthContext);
        const [form, setForm] = useState({
            username: '', password: ''
        })

        const changeHandler = event => {
            setForm({...form, [event.target.name]: event.target.value})
        }

        const loginHandler = async () => {

            console.log({...form});
            const response = await fetch('api/Accounts/token', {
                method: 'POST',
                headers: {"Accept": "application/json"},
                body: JSON.stringify({...form})
            });

            const data = await response.json();

            if(response.ok === true){
                auth.login(data.token, data.userId);
                console.log(data);
            }
        }

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