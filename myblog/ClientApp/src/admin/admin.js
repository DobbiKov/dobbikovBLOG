import React from 'react';
import {Link} from 'react-router-dom';

const styles = {
    link:{
        padding: '5px 5px 5px 5px', 
        display: 'block',
        fontSize: '30px'
    }
}

export const Admin = () => {
    return(<div style={{display: 'flex', justifyContent: 'center'}}>
        <Link to="/admin/portfolios" style={styles.link}>Portfolio</Link>
        <Link style={styles.link} to="/admin/contacts">Contacts</Link>
        <Link style={styles.link} to="/admin/blog">Blog</Link>
        <Link style={styles.link} to="/admin/home">Edit Main Page</Link>
    </div>)
}