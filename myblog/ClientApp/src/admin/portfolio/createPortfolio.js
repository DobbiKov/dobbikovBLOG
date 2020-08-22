import React, {useState, useEffect} from 'react';
import {Redirect, useParams} from 'react-router-dom';
import {useHttp} from '../../hooks/http.hook';

export const AdminCreatePortfolio = () => {
    const {request} = useHttp();
    const [form, setForm] = useState({
        Name: '', Title: '', Image: 'n', Link: ''
    })
    const [created, setCreated] = useState(false) //for redirect

    const changeHandler = event => {
        setForm({...form, [event.target.name]: event.target.value});
    }
    const clickHandler = async () => {
        const response = await request('/api/Portfolios/Create', 'POST', JSON.stringify({...form}), {"Accept": "application/json", "Content-Type" : "application/json"});
        const data = response.json();
        setCreated(true);
    }
    return(
        <div>
            {created == true ? <Redirect to="/admin/portfolios"/> :
            <div>
                <p>Укажите название портфолио</p>
                <input type="input" id="Name" name="Name" onChange={changeHandler}/>
                <p>Заполните текст портфолио</p>
                <input type="input" id="Title" name="Title" onChange={changeHandler}/>
                <p>Укажите ссылку портфолио</p>
                <input type="input" id="Link" name="Link" onChange={changeHandler}/>
                <input type="submit" onClick={clickHandler}/>                
            </div>
            }
        </div>
    )
}