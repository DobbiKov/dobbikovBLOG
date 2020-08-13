import React, { Component } from 'react';
// import authService from './api-authorization/AuthorizeService'

export class Contacts extends Component {
  static displayName = Contacts.name;

  constructor(props) {
    super(props);
    this.state = { contacts: [], loading: true };
  }

  componentDidMount() {
    this.populateContacts();
  }

  static renderContactsTable(contacts) {
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
          {contacts.map(contact =>
            <tr key={contact.id}>
              <td>{contact.name}</td>
              <td>{contact.title}</td>
              <td><a href={contact.link}>Go</a></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Contacts.renderContactsTable(this.state.contacts);

    return (
      <div>
        <h1 id="tabelLabel" >Contacts</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateContacts() {
    // const token = await authService.getAccessToken();
    const response = await fetch('Contacts', {
      headers: {}
    });
    const data = await response.json();
    this.setState({ contacts: data, loading: false });
  }
}
