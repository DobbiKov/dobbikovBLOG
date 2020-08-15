import React, {Component} from 'react';

export class AuthPage extends Component{
    render(){
        return(
            <div>
                <h2>Введите Email</h2>
                <input type="input" placeholder="Введите Email" id="inputEmail"/>
                <h2>Введите пароль</h2>
                <input type="input" placeholder="Введите пароль" id="inputPass"/>
                <input type="submit" value="Авторизоваться" onClick={}/>
            </div>
        )
    }
}