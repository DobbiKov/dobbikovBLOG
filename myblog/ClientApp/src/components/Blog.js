import React, {Component} from 'react'
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

export class Blog extends Component{
    static displayName = Blog.name;
    constructor(props){
        super(props);
        this.state = {posts: [], loading: true};
    }
    componentDidMount() {
        this.populatePosts();
    }

    static renderPosts(posts){
        return(
            <div style = {{display: 'flex'}}>
                {posts.map(post => 
                    <Link to={`/post/${post.id}`} style={styles.renderPostsA}><div key={post.id} style = {styles.renderPostsDiv}>
                        <h3>{post.name}</h3>
                        <p>{post.title}</p>
                    </div></Link>
                    )}
            </div>
        )
    }

    render(){
        let content = this.state.loading ? <h1>Loading...</h1> : Blog.renderPosts(this.state.posts);
        return(
            <div>
                <h1>Blog</h1>
                {content}
            </div>
        )
    }

    async populatePosts() {
        // const token = await authService.getAccessToken();
        const response = await fetch('api/Posts', {
          headers: {}
        });
        const data = await response.json();
        this.setState({ posts: data, loading: false });
      }
}