import React, {Component, useState, useCallback, useEffect} from 'react'
import { Link } from 'react-router-dom';
import {useHttp} from '../../hooks/http.hook';

const styles = {
    renderPostsA:{
        display: 'inline-block',
        textDecoration: 'none',
        color: 'black',
        paddingRight: '5px',
        marginTop: '5px'
    },
    renderPostsDiv: {
        display: 'inline-block',
        borderBottom: '3px solid black',
        borderTop: '3px solid black',
        borderRight: '3px solid black',
        width: '200px'
    }
}

export const AdminBlog = () => {
    const [posts, setPosts] = useState([]);
    const [loading, setLoading] = useState(true);
    const {request} = useHttp();

    const populatePosts = useCallback(async () => {
        const response = await request('api/Posts');
        const data = await response.json();
        setPosts(data);
        setLoading(false);
    }, []);

    const renderPosts = useCallback((_posts) => {
        return(
            <div style = {{display: 'block'}}>
                {_posts.map(post => 
                    <Link to={`/post/${post.id}`} style={styles.renderPostsA}  key={post.id}><div style = {styles.renderPostsDiv}>
                        <h3>{post.name}</h3>
                        <p>{post.title}</p>
                        <Link to={`/admin/post/edit/${post.id}`}>Edit</Link>
                        <Link to={`/admin/post/delete/${post.id}`}>Delete</Link>
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
            <Link to="/admin/post/new">Add new</Link>
            {loading ? <h1>Loading...</h1> : renderPosts(posts)}
        </div>
    )
}