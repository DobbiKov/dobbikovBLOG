import React, {useState, useEffect} from 'react';
import {Redirect} from 'react-router-dom';
import {useHttp} from '../../hooks/http.hook';

export const AdminCreatePost = () => {
    const {request} = useHttp();
    const [form, setForm] = useState({
        Name: '', Title: '', Text: ''
    })
    const [created, setCreated] = useState(false);
    const changeHandler = event => {
        setForm({...form, [event.target.name]: event.target.value});
    }
    const clickHandler = async () => {
        const response = await request('/api/Posts/Create', 'POST', JSON.stringify({...form}), {"Accept": "application/json", "Content-Type" : "application/json"});
        setCreated(true)
    }
    return(
        <div>
            {created ? <Redirect to="/admin/blog"/> :
            <div>
                <p>Укажите название поста</p>
                <input type="input" id="Name" name="Name" onChange={changeHandler}/>
                <p>Заполните краткое описание поста</p>
                <input type="input" id="Title" name="Title" onChange={changeHandler}/>
                <p>Пишите содержание поста</p>
                <input type="input" id="Text" name="Text" onChange={changeHandler}/>
                <input type="submit" onClick={clickHandler}/>   
            </div>
            }
        </div>
    )
}