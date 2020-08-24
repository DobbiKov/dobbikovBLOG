import React, {Component, useCallback, useState, useEffect, useContext} from 'react';
import {useParams} from 'react-router-dom';
import {useHttp} from '../hooks/http.hook';
import {AuthContext} from '../context/AuthContext';

export const CommentUserName = (userid) => {
    
    const [user, setUser] = useState({});
    const [loadName, setLoadName] = useState(true);
    const populateUser = async (userid) => {
        const response = await fetch(`/api/Accounts/byId/${userid.userid}`, {method: 'GET', headers: {}});
        const data = await response.json();
        setUser(data);
        setLoadName(false);;
    }  
    
    useEffect(() => {
        populateUser(userid);
    }, [userid]);
    return(
        <p>{loadName ? <p>Loading...</p> : <p>{user.login}</p>}</p>
    )
}

const Post = () => {
    const auth = useContext(AuthContext);
    const idx = useParams().id;
    const {request} = useHttp();
    const [post, setPost] = useState({});
    const [comments, setComments] = useState(null);
    const [comms, setComms] = useState({});
    const [loading, setLoading] = useState(true);
    const [loading2, setLoading2] = useState(true);



    const [formComm, setFormComm] = useState({
        PostId: idx, Text: '', Token: auth.token
    })

    // const populateUser = async (userid) => {
    //     const response = await fetch(`/api/Accounts/byId/${userid}`, {method: 'GET', headers: {}});
    //     const data = await response.json();
    //     console.log(`tut: ${data}`);
    //     setLoadName(false);
    //     console.log(`tut: typeof: ${typeof(data.login)}`);
    //     return data.login;
    // }
    const populateUserByToken = async () => {
        console.log(auth);
        const response = await fetch(`/api/Accounts/${auth.token}`, {method: 'GET', headers: {}});
        const data = await response.json();
        return data;
    }

    const changeHandler = event => {
        setFormComm({...formComm, [event.target.name]: event.target.value});
    }
    const clickHandler = async () => {
        const response = await fetch('/api/PostComments/NewComment', {method: 'POST', body: JSON.stringify({...formComm}), headers: {"Accept": "application/json", "Content-Type" : "application/json"}});
        populateComments(idx);
    }
    
    const renderPost = useCallback((_post) => {
        return(
            <div><div>
                <h1>{_post.name}</h1>
                <h2>{_post.title}</h2>
                <p>{_post.text}</p>
            </div>
        </div>
        );
    }, []);
    const renderUserName = (name, _loadName) => {
        return(<div>{_loadName ? <p>Loading</p> : <p>{name}</p>}</div>)
    }
    const renderComments = (_comments, _comms) => {
        if(_comments == null) return (<div>Null</div>);
        return(
            <div>
                {_comments.map(comment => 
                    <div key={comment.id} style={{borderBottom: '2px solid black'}}>
                        {/* {renderUserName(populateUser(comment.userId), _loadName)} */}
                        <CommentUserName userid={comment.userId}/>
                        <h2>{comment.text}</h2>
                    </div>
                    )}
            </div>
        )
    }

    const populateComments = async (_idx) => {
        const response = await fetch(`/api/PostComments/${_idx}`, {method: 'GET', headers: {}});
        const data = await response.json();
        console.log(`comments: ${comments}`);
        setComments(data);
        setComms(data);
        setLoading2(false);
        console.log(`comments: ${comments}`);
    }

    useEffect(() => {
        async function fetchData(){
            const response = await fetch(`api/Posts/${idx}`, {method: 'GET', headers: {}});
            const data = await response.json();
            setPost(data);
            setLoading(false);  
        }
        fetchData();
        populateComments(idx);
    }, [idx]);

    return(
    <div>
        <h1>
            Post
        </h1>
        {loading ? <h2>Loading...</h2> : renderPost(post)}
        <input type="input" placeholder="Оставьте свой комментарий" name="Text" onChange={changeHandler}/> <input type="submit" value="Оставить комментарий" onClick={clickHandler}/>
        {loading2 ? <h2>Loading...</h2> : renderComments(comments, comms)}
    </div>
    );
    
}

export default Post;