import React, {useState, useEffect} from 'react';
import {Redirect, useParams} from 'react-router-dom';
import {useHttp} from '../../hooks/http.hook';

export const AdminUpdatePost = () => {
    const idx = useParams().id;
    const {request} = useHttp();
    const [loading, setLoading] = useState(true);
    const [obj, setObj] = useState({}) //post (1)
    const [form, setForm] = useState({
        Id: idx, Name: '', Title: '', Text: 'n', Link: ''
    })
    const changeHandler = event => {
        setForm({...form, [event.target.name]: event.target.value});
    }
    const clickHandler = async () => {
        const response = await request('/api/Posts/Update', 'POST', JSON.stringify({...form}), {"Accept": "application/json", "Content-Type" : "application/json"});
        const data = await response.json();
        setObj(data);
        
    }
    const populatePost = async (idx) => {
        const response = await fetch(`/api/Posts/${idx}`, {method: 'GET', body: null, headers: {}});
        const data = await response.json();
        setObj(data);
        setLoading(false);
    }
    useEffect(() => {
        populatePost(idx);
    },[idx])
    return(
        <div>
            {loading ? <h1>Loading...</h1> :
            <div>
                <p>Укажите название поста, в данный момент: {obj.name}</p>
                <input type="input" id="Name" name="Name" onChange={changeHandler}/>
                <p>Заполните краткое описание поста, в данный момент: {obj.title}</p>
                <input type="input" id="Title" name="Title" onChange={changeHandler}/>
                <p>Пишите содержание поста, в данный момент: {obj.text}</p>
                <input type="input" id="Text" name="Text" onChange={changeHandler}/>
                <input type="submit" onClick={clickHandler}/>   
            </div>
            }
        </div>
    )
}