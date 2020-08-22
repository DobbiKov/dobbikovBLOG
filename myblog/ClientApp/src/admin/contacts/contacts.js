import React, { Component, useState, useCallback, useEffect } from 'react';
import {Link} from 'react-router-dom';
import {useHttp} from '../../hooks/http.hook';

export const AdminContacts = () => {
  const [contacts, setContacts] = useState([]);
  const [loading, setLoading] = useState(true);
  const {request} = useHttp();

  const populateContacts = useCallback(async () => {
    const response = await request('api/Contacts');
    const data = await response.json();
    setContacts(data);
    setLoading(false);   
  }, []);

  const renderContactsTable = useCallback((_contacts) => {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Title</th>
            <th>Link</th>
          </tr>
        </thead>
        <tbody>
          {_contacts.map(contact =>
            <tr key={contact.id}>
              <td>{contact.name}</td>
              <td>{contact.title}</td>
              <td><a href={contact.link}>Go from link</a></td>
              <td><Link to={`/admin/contact/edit/${contact.id}`}>Edit</Link></td>
              <td><Link to={`/admin/contact/delete/${contact.id}`}>Delete</Link></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }, []);

  useEffect(() => {
    populateContacts();
  }, []);

  return(
    <div>
    <h1 id="tabelLabel" >Contacts</h1> <Link to="/admin/contact/new">Add new</Link>
    <p>in Admin Panel.</p>
    {loading ?  <p><em>Loading...</em></p> : renderContactsTable(contacts)}
  </div>
  )
}
