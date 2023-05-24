import React, { useState, useEffect } from 'react'
import '../scss/AllStocks.scss'
import api from '../Helpers/api'
import { CSSTransition, TransitionGroup } from 'react-transition-group';

function AllStocks() {
  const [stocks, setStocks] = useState([]);
  const [sortOrder, setSortOrder] = useState({
    id: 'asc',
    name: 'asc',
    symbol: 'asc',
    creationDate: 'asc',
  });

  const Edit = (event) => {
    const id = event.target.closest('tr').querySelector('td').innerText
    window.location.href = `/Edit/${id}`
  }
  function Delete() {
    if (!window.confirm("Are you sure you want to Delete this stock?")) return;
    window.location.href = "/Delete/2";
  }

  const sortByColumn = (column) => {
    console.log(`Sorting by ${column}`);
    const sortedStocks = [...stocks].sort((a, b) => {
      if (column === 'stockId') {
        const valueA = Number(a[column]);
        const valueB = Number(b[column]);
        if (sortOrder[column] === 'asc') {
          return valueA - valueB;
        } else {
          return valueB - valueA;
        }
      } else {
        const valueA = a[column].toLowerCase();
        const valueB = b[column].toLowerCase();
        if (sortOrder[column] === 'asc') {
          return valueA.localeCompare(valueB);
        } else {
          return valueB.localeCompare(valueA);
        }
      }
    });
    setStocks(sortedStocks);
    setSortOrder((prevSortOrder) => ({
      ...prevSortOrder,
      [column]: prevSortOrder[column] === 'asc' ? 'desc' : 'asc',
    }));
  };

  const fetchStocks = () => {
    console.log('fetching stocks');
    api.get('/GetAllStocks')
      .then((response) => {
        const formattedStocks = response.data.map(stock => {
          const formattedDate = new Date(stock.creationDate).toLocaleString();
          return {
            ...stock,
            creationDate: formattedDate
          };
        });
        setStocks(formattedStocks);
      })
      .catch((error) => {
        console.log(error)
      })
  }

  useEffect(() => {
    fetchStocks();
  }, []);


  const stockRows = stocks.map((stock) => {
    return (
      <CSSTransition key={stock.stockId} className="stock-item" timeout={500} >
        <tr key={stock.stockId} className="stock-item">
          <td>{stock.stockId}</td>
          <td>
            <a href={`https://www.nseindia.com/get-quotes/equity?symbol=${stock.stockSymbol}`}>
              {stock.stockName}
            </a>
          </td>
          <td>{stock.stockSymbol}</td>
          <td>{stock.creationDate}</td>
          <td className='editButton' onClick={Edit}>Edit</td>
          <td className='deleteButton' onClick={Delete}>Delete</td>
        </tr>
      </CSSTransition>
    )
  })

  const anchorButton = (event) => {
    event.preventDefault();
    if (event.target.innerText === '👇') {
      window.location.href = "#bottom";
      event.target.innerText = '👆';
    }else if (event.target.innerText === '👆') {
      window.location.href = "#top";
      event.target.innerText = '👇';
    }
  }


  return (
    <div className="mainContainer">
      <div id="top"></div>
      <div id="button">
        <a href="#bottom" className='up-arrow' onClick={anchorButton}>👇</a>
      </div>
  

      <h1 className='allStocks'>All Stocks</h1>

      <div className="stocktable">
        <table>
          <thead>
            <tr>
              <th onClick={() => sortByColumn('stockId')}>Id</th>
              <th onClick={() => sortByColumn('stockName')}>Name</th>
              <th onClick={() => sortByColumn('stockSymbol')}>Symbol</th>
              <th onClick={() => sortByColumn('creationDate')}>CreationDate</th>
              <th colSpan={2} className="operations">Operation</th>
            </tr>
          </thead>
          <tbody>
            <TransitionGroup component={null}>
              {stockRows}
            </TransitionGroup>
          </tbody>
        </table>
      </div>
      <div id="bottom"></div>
    </div>
  )
}

export default AllStocks