import React, {useState, useEffect} from 'react';
import {Redirect, useParams} from 'react-router-dom';
import {useHttp} from '../../hooks/http.hook';

export const AdminEditContacts = () => {
    const idx = useParams().id;
    const {request} = useHttp();
    const [loading, setLoading] = useState(true);
    const [obj, setObj] = useState({}) //contacts (1)
    const [form, setForm] = useState({
        Id: idx, Name: '', Title: '', Image: 'n', Link: ''
    })
    const populateProtfolio = async (idx) => {
        const response = await fetch(`/api/Contacts/${idx}`, {method: 'GET', body: null, headers: {}});
        const data = await response.json();
        setObj(data);
        setLoading(false);
    }
    useEffect(() => {
        populateProtfolio(idx);
    }, [idx])
    const changeHandler = event => {
        setForm({...form, [event.target.name]: event.target.value});
    }
    const clickHandler = async () => {
        const response = await request('/api/Contacts/Update', 'POST', JSON.stringify({...form}), {"Accept": "application/json", "Content-Type" : "application/json"});
        const data = response.json();
        setObj(data);
    }
    return(
        <div>
            {loading ? <h2>Loading...</h2> : 

            <div key={obj.id}>
                <p>Укажите название контакта, в данный момент: {obj.name}</p>
                <input type="input" id="Name" name="Name" onChange={changeHandler}/>
                <p>Заполните описание контакта, в данный момент: {obj.title}</p>
                <input type="input" id="Title" name="Title" onChange={changeHandler}/>
                <p>Укажите ссылку контакта, в данный момент: {obj.link}</p>
                <input type="input" id="Link" name="Link" onChange={changeHandler}/>
                <input type="submit" onClick={clickHandler}/>
            </div>
                
                }
        </div>
    )
}