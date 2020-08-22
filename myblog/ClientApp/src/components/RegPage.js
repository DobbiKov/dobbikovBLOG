import React, {useState} from 'react';
import {Redirect} from 'react-router-dom';
import {useHttp} from '../hooks/http.hook';

export const RegPage = () => {
    const {request} = useHttp()
    const [error, setError] = useState('');
    const [created, setCreated] = useState(false);
    const [form, setForm] = useState({
        Login: '', Password: ''
    })
    const changeHandler = event => {
        setForm({...form, [event.target.name]: event.target.value});
    }
    const clickHandler = async () => {
        const response = await request('/api/Accounts/Register', 'POST', JSON.stringify({...form}), {"Accept": "application/json", "Content-Type" : "application/json"});
        const data = await response.json();
        if(response.ok){
            setCreated(true);
        }else{
            setError(data.errorText);
        }
    }
    return(
        <div>
            {created == true ? <Redirect to="/"/> :
            <div>
                <h2 style={{color: 'red'}}>{error}</h2>
                <p>Укажите ваш E-Mail</p>
                <input type="input" id="Login" name="Login" onChange={changeHandler}/>
                <p>Укажите пароль</p>
                <input type="text" id="Password" name="Password" onChange={changeHandler}/>
                <input type="submit" onClick={clickHandler}/>                
            </div>
            }
        </div>
    )    
}