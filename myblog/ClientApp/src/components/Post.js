import React, {Component} from 'react';

class Post extends Component{
    static displaName = Post.name;
    constructor(props){
        super(props);
        this.state = {post: {}, loading: true};
    }
    componentDidMount(){ this.populatePost(); }

    static renderPost(posts){ return ( 
        <div>
            <h1>{posts.name}</h1>
            <h2>{posts.title}</h2>
            <p>{posts.text}</p>
        </div>
    )}

    render(){
        let content = this.state.loading ? <h2>Loading...</h2> : Post.renderPost(this.state.post);
        return(
            <div>
                <h1>
                    Post
                </h1>
                {content}
            </div>
        )
    }

    async populatePost(){
        const response = await fetch(`api/Posts/${this.props.taskId}`);
        const data = await response.json();
        this.setState({post: data, loading: false});
    }

}

export default Post;