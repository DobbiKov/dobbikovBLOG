import React, { useEffect, useState } from 'react';
import {useHttp} from '../hooks/http.hook';

export const Home = () => {
  const {request} = useHttp();
  const [page, setPage] = useState({});
  const [loading, setLoading] = useState(true);
  const populateMainPage = async () => {
    const response = await request('/api/MainPages');
    const data = await response.json();
    setPage(data);
    setLoading(false);
  }
  useEffect(() => {
    populateMainPage();
  }, [])

  return (
    <div>
      {
      loading ? <h1>Loading...</h1> : 
      <div>
      {page.map(_page => 
        <div key={_page.id}>
          <h1>{_page.title}</h1>
          <p>{_page.text}</p>
        </div>
        )}  
      </div>
      }
    </div>
  );
}
