import React, {Component, useCallback, useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';

const Post = () => {
    const [post, setPost] = useState({});
    const [loading, setLoading] = useState(true);
    const idx = useParams().id;
    
    const renderPost = useCallback((_post) => {
        return(
            <div>
            <h1>{_post.name}</h1>
            <h2>{_post.title}</h2>
            <p>{_post.text}</p>
        </div>
        );
    }, []);

    useEffect(async () => {
        try{
            const response = await fetch(`api/Posts/${idx}`);
            const data = await response.json();
            setPost(data);
            setLoading(false);  
        }catch(e) {}
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