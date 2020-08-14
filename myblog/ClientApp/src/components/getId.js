import React from 'react';
import { useParams } from 'react-router-dom';
import Post from './Post';

function GetId(){
    const idx = useParams().id;
    return(
        <Post taskId={idx}/>
    )
}
export default GetId;