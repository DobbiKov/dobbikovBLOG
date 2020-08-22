import React, {useEffect, useState} from 'react';
import {Redirect, useParams} from 'react-router-dom';
import {useHttp} from '../../hooks/http.hook';

export const AdminDeletePost = () => {
    const idx = useParams().id;
    const {request} = useHttp();
    const [loading, setLoading] = useState(true);
    const populatePost = async (_idx) => {
        const response = await request(`/api/Posts/${_idx}`, 'DELETE');
        setLoading(false);
    }
    useEffect(() => {
        populatePost(idx);
    },[idx]);
    return(
        <div>
            {loading ? <h1>Loading...</h1> : <Redirect to="/admin/blog"/>}
        </div>
    )
}