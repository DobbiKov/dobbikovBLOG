import React, { Component, useState, useCallback, useEffect } from 'react';

export const Contacts = () => {
  const [contacts, setContacts] = useState([]);
  const [loading, setLoading] = useState(true);

  const populateContacts = useCallback(async () => {
    const response = await fetch('api/Contacts', {
      headers: {}
    });
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
    <h1 id="tabelLabel" >Contacts</h1>
    <p>This component demonstrates fetching data from the server.</p>
    {loading ?  <p><em>Loading...</em></p> : renderContactsTable(contacts)}
  </div>
  )
}
