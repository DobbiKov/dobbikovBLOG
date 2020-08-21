import React, {Component, useCallback, useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';
import {useHttp} from '../hooks/http.hook';

const Post = () => {
    const [post, setPost] = useState({});
    const [loading, setLoading] = useState(true);
    const idx = useParams().id;
    const {request} = useHttp();
    
    const renderPost = useCallback((_post) => {
        return(
            <div>
            <h1>{_post.name}</h1>
            <h2>{_post.title}</h2>
            <p>{_post.text}</p>
        </div>
        );
    }, []);

    useEffect(() => {
        async function fetchData(){
            const response = await request(`api/Posts/${idx}`);
            const data = await response.json();
            setPost(data);
            setLoading(false);  
        }
        fetchData();
    }, []);

    return(
        <div>
        <h1>
            Post
        </h1>
        {loading ? <h2>Loading...</h2> : renderPost(post)}
    </div>
    );
    
}

export default Post;