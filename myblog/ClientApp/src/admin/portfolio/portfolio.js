import React, { useState, useCallback, useEffect, useContext } from 'react';
import {AuthContext} from '../../context/AuthContext';
import {useHttp} from '../../hooks/http.hook';
import {Link} from 'react-router-dom';

const styles = {
    mz:{
      margin: '0',
      padding: '0'
    },
    div:{
      borderBottom: '1px solid black', 
      borderRight: '2px solid black',
      width: '300px', 
      paddingBottom: '5px',
      marginLeft: '10px',
      textAlign: 'center'
    },
    links:{
        // display: 'block',
        marginRight: '5px'
    }
};

export const AdminPortfolios = () => {
    const auth = useContext(AuthContext);
    const {request} = useHttp();
    const [portfolios, setPortfolios] = useState([]);
    const [user, setUser] = useState({});
    const [role, setRole] = useState({});
    const [loading2, setLoading2] = useState(true);
    const [loading, setLoading] = useState(true);
  
    const renderTable = useCallback((_portfolios, _role) => {
      return(
        <div style={{display: 'flex', marginTop: '15px'}}>
          { _portfolios.map((portfolio) => 
              <div key={portfolio.id} style={styles.div}>
                <h3 style={styles.mz}>{portfolio.name}</h3>
                <p style={styles.mz}>{portfolio.title}</p>
                <a href={portfolio.link} style = {styles.links}>See a project</a>
                <Link to={`/admin/portfolio/edit/${portfolio.id}`} style = {styles.links}>Edit</Link>
                <Link to={`/admin/portfolio/delete/${portfolio.id}`} style = {styles.links}>Delete</Link>
              </div>
          ) }
          </div>
      )
    }, []);
    
    const populatePortfolio = useCallback(async () =>
    {
      const response = await request('api/Portfolios');
      const data = await response.json();
      setPortfolios(data);
      setLoading(false);
  
  
    }, []);
  
    useEffect(() => {
      populatePortfolio();
      //renderTable(portfolios);
    }, []);
  
    return (
      <div>
        <h1>My Portfolios</h1> <Link to="/admin/portfolio/new">Add new</Link>
        <div style={{display: 'flex', justifyContent: 'center'}}>
        {loading ? <p><em>Loading...</em></p> : renderTable(portfolios, role)}
        </div>
      </div>
    );  
}