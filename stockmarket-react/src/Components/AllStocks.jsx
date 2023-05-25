import React, { useState, useEffect } from 'react'
import '../scss/AllStocks.scss'
import api from '../Helpers/api'
import { CSSTransition, TransitionGroup } from 'react-transition-group';

function AllStocks() {
  const [heading, setHeading] = useState('All Stocks');
  const [stocks, setStocks] = useState([]);
  const [searchResults, setSearchResults] = useState([]);
  const [loading, setLoading] = useState(false);
  const [priceFlag, setPriceFlag] = useState(false);
  const [sortOrder, setSortOrder] = useState({
    id: 'asc',
    name: 'asc',
    symbol: 'asc',
    price: 'asc',
    creationDate: 'asc',
  });

  const StockPage = (event) => {
    const symbol = event.target.closest('tr').querySelector('#symbol').innerText
    window.location.href = `/Stock/${symbol}`
  }
  const Edit = (event) => {
    const id = event.target.closest('tr').querySelector('td').innerText
    window.location.href = `/Edit/${id}`
  }
  function Delete(event) {
    if (!window.confirm("Are you sure you want to Delete this stock?")) return;
    const id = event.target.closest('tr').querySelector('td').innerText;
    api.delete(`/DeleteStock/${id}`)
      .then((response) => {
        console.log(response);
        fetchStocks();
      })
      .catch((error) => {
        console.log(error);
      });
  }

  const sortByColumn = (column) => {
    console.log(`Sorting by ${column}`);
    const sortedStocks = [...searchResults].sort((a, b) => {
      if (column === 'stockId' || column === 'stockPrice') {
        const valueA = Number(a[column]);
        const valueB = Number(b[column]);
        if (sortOrder[column] === 'asc') {
          return valueA - valueB;
        } else {
          return valueB - valueA;
        }
      }
      else {
        const valueA = a[column].toLowerCase();
        const valueB = b[column].toLowerCase();
        if (sortOrder[column] === 'asc') {
          return valueA.localeCompare(valueB);
        } else {
          return valueB.localeCompare(valueA);
        }
      }
    });
    setSearchResults(sortedStocks);
    setSortOrder((prevSortOrder) => ({
      ...prevSortOrder,
      [column]: prevSortOrder[column] === 'asc' ? 'desc' : 'asc',
    }));
  };

  const fetchStocks = () => {
    setHeading('All Stocks');
    setSearchResults([]);
    console.log('fetching stocks');
    setLoading(true);
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
        setSearchResults(formattedStocks);
        setLoading(false);
      })
      .catch((error) => {
        console.log(error)
        setLoading(false);
      })
  }

  const fetchStocksWithPrice = () => {
    setHeading('All Stocks With Price');
    setSearchResults([]);
    setPriceFlag(true);
    console.log('fetching stocks with price');
    setLoading(true);
    api.get('/GetAllStocksWithPrice')
      .then((response) => {
        const formattedStocks = response.data.map(stock => {
          const formattedDate = new Date(stock.creationDate).toLocaleString();
          return {
            ...stock,
            creationDate: formattedDate
          };
        });
        setStocks(formattedStocks);
        setSearchResults(formattedStocks);
        setLoading(false);
      })
      .catch((error) => {
        console.log(error)
        setLoading(false);
      })
  }

  const fetchStocksWithoutPrice = () => {
    setHeading('All Stocks Without Price');
    setSearchResults([]);
    setPriceFlag(false);
    console.log('fetching stocks without price');
    setLoading(true);
    api.get('/GetAllStocksWithoutPrice')
      .then((response) => {
        const formattedStocks = response.data.map(stock => {
          const formattedDate = new Date(stock.creationDate).toLocaleString();
          return {
            ...stock,
            creationDate: formattedDate
          };
        });
        setStocks(formattedStocks);
        setSearchResults(formattedStocks);
        setLoading(false);
      })
      .catch((error) => {
        console.log(error)
        setLoading(false);
      })
  }

  useEffect(() => {
    fetchStocks();
  }, []);

  const stockRows = searchResults.map((stock) => {
    return (
      <CSSTransition key={stock.stockId} className="stock-item" timeout={500} >
        <tr key={stock.stockId} className="stock-item">
          <td id='id'>{stock.stockId}</td>
          <td id='name' onClick={StockPage}>
            {stock.stockName}
          </td>
          <td id='symbol'>{stock.stockSymbol}</td>
          {priceFlag ? <td>{stock.stockPrice}</td> : null}
          <td id='date'>{stock.creationDate}</td>
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
    } else if (event.target.innerText === '👆') {
      window.location.href = "#top";
      event.target.innerText = '👇';
    }
  }

  const SearchTable = (event) => {
    const searchValue = event.target.value.toLowerCase();
    const searchResults = stocks.filter((stock) => {
      return (
        stock.stockName.toLowerCase().includes(searchValue) ||
        stock.stockSymbol.toLowerCase().includes(searchValue)
      );
    });
    setSearchResults(searchResults);
  }

  const loadingSpinner = (
    <td colSpan={6} className='loading-td'>
      <div className="loading" colSpan={6}>
        <div className="spinner">Loading</div>
      </div>
    </td>
  );

  return (
    <div className="mainContainer-allstocks" >
      <div id="top"></div>
      <div id="button">
        <a href="#bottom" className='up-arrow' onClick={anchorButton}>👇</a>
      </div>

      <h1 className='allStocks'>{heading}</h1>
      <div className="header">
        <div className="search-table">
          <input type="text" id="search" onChange={SearchTable} placeholder="Search Table..." />
          <p>Search is based on Name and Symbol</p>
        </div>

        <div className="filters">
          <input type="submit" id="button2" onClick={fetchStocks} value="All Stocks" />
          <input type="submit" id="button1" onClick={fetchStocksWithoutPrice} value="Stock Without Price" />
          <input type="submit" id="button2" onClick={fetchStocksWithPrice} value="Stock With Price" />
        </div>
      </div>


      <div className="stocktable">
        <table>
          <thead>
            <tr>
              <th onClick={() => sortByColumn('stockId')}>Id</th>
              <th onClick={() => sortByColumn('stockName')}>Name</th>
              <th onClick={() => sortByColumn('stockSymbol')}>Symbol</th>
              {priceFlag ? <th onClick={() => sortByColumn('stockPrice')}>Price</th> : null}
              <th onClick={() => sortByColumn('creationDate')}>CreationDate</th>
              <th colSpan={2} className="operations">Operation</th>
            </tr>
          </thead>
          <tbody>
            <TransitionGroup component={null}>
              {false ? loadingSpinner : false ? <tr><td colSpan={6} className='noStocks'>No Stocks Found</td></tr> : stockRows}
            </TransitionGroup>
          </tbody>
        </table>
      </div>
      <div id="bottom"></div>
    </div>
  )
}

export default AllStocks