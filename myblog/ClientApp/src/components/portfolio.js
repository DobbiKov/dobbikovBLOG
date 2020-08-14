import React, { Component } from 'react';

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
      textAlign: 'center'
    }
};

export class Portfolio extends Component {
  static displayName = Portfolio.name;

  constructor(props) {
    super(props);
    this.state = { portfolios: [], loading: true };
  }
  componentDidMount(){
    this.populatePortfolio();
  }

  static renderTable(portfolios){
      return(
        <div style={{display: 'flex', marginTop: '15px'}}>
          { portfolios.map((portfolio) => 
              <div key={portfolio.id} style={styles.div}>
                <h3 style={styles.mz}>{portfolio.name}</h3>
                <p style={styles.mz}>{portfolio.title}</p>
                <a href={portfolio.link} style = {{textDecoration: 'none'}}>See a project</a>
              </div>
          ) }
          </div>
      )
  }

  render() {
    let content = this.state.loading ? <p><em>Loading...</em></p> : Portfolio.renderTable(this.state.portfolios);
    return (
      <div>
        <h1>My Portfolios</h1>
        <div style={{display: 'flex', justifyContent: 'center'}}>
        {content}
        </div>
      </div>
    );
  }
  async populatePortfolio()
  {
    const response = await fetch('api/Portfolios', {headers: {}});
    const data = await response.json();
    this.setState({portfolios: data, loading: false});
  }
}
