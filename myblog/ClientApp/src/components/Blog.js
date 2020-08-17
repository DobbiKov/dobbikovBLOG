import React, {Component, useState, useCallback, useEffect} from 'react'
import {useHistory} from 'react-router-dom';
import { Link } from 'react-router-dom';

const styles = {
    renderPostsA:{
        textDecoration: 'none',
        color: 'black',
        paddingRight: '5px'
    },
    renderPostsDiv: {
        borderBottom: '3px solid black',
        borderTop: '3px solid black',
        borderRight: '3px solid black',
        width: '200px'
    }
}

export const Blog = () => {
    const [posts, setPosts] = useState([]);
    const [loading, setLoading] = useState(true);

    const populatePosts = useCallback(async () => {
        const response = await fetch('api/Posts', {
            headers: {}
        });
        const data = await response.json();
        setPosts(data);
        setLoading(false);
    }, []);

    const renderPosts = useCallback((_posts) => {
        return(
            <div style = {{display: 'flex'}}>
                {_posts.map(post => 
                    <Link to={`/post/${post.id}`} style={styles.renderPostsA}  key={post.id}><div style = {styles.renderPostsDiv}>
                        <h3>{post.name}</h3>
                        <p>{post.title}</p>
                    </div></Link>
                )}
            </div>
        )       
    }, []);

    useEffect(() => {
        populatePosts();
    }, []);

    return(
        <div>
            <h1>Blog</h1>
            {loading ? <h1>Loading...</h1> : renderPosts(posts)}
        </div>
    )
}