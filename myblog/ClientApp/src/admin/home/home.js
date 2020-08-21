import React, {useState} from 'react';
import {useHttp} from '../../hooks/http.hook';
export const EditHome = () => {
    const {request} = useHttp();
    const [form, setForm] = useState({
        Id: '00000000-0000-0000-0000-000000000001', Text: '', Title: ''
    })

    const changeHandler = event => {
        setForm({...form, [event.target.name]: event.target.value})
    }

    const clickHandler = async () => {
        const response = await request('/api/MainPages/Update', 'POST', JSON.stringify({...form}), {"Accept": "application/json", "Content-Type" : "application/json"});
        const data = response.json();
    }

    return(
        <div>
            <h1>Редактирование главной страницы</h1>
            <h2>Заголовок:</h2>
            <input type="input" id="Title" name="Title" placeholder="укажите заголовок" onChange={changeHandler}/>
            <h2>Описание:</h2>
            <input type="input" id="Text" name="Text" placeholder="укажите описание" onChange={changeHandler}/>
            <input type="submit" onClick={clickHandler} value="Сохранить"/>
        </div>
    )
}