import React, {Component, useContext} from 'react';
import {AuthContext} from '../context/AuthContext';

export const AuthPage = () => {
        const auth = useContext(AuthContext);
        return(
            <div>
                <h2>Введите Email</h2>
                <input type="input" placeholder="Введите Email" id="inputLoginEmail"/>
                <h2>Введите пароль</h2>
                <input type="input" placeholder="Введите пароль" id="inputLoginPass"/>
                <input type="submit" value="Авторизоваться" onClick={loginHandler}/>
            </div>
        )
}