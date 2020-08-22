import React, {useState, useEffect} from 'react';
import {Redirect, useParams} from 'react-router-dom';
import {useHttp} from '../../hooks/http.hook';

export const AdminDeletePortfolio = () => {
    const {request} = useHttp();
    const idx = useParams().id;
    const [loading, setLoading] = useState(true);
    const populateDelete = async (idx) => {
        const response = await request(`/api/Portfolios/${idx}`, 'DELETE');
        const data = await response.json();
        setLoading(false);
    }
    useEffect(() => {
        populateDelete(idx);
    }, [idx])
    return(
        <div>
            {loading ? <h1>loading...</h1> : <Redirect to="/admin/portfolios"/>}
        </div>
    )
}