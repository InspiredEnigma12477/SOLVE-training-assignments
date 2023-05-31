import React, { useState, useEffect } from 'react';
import { Scrollbars } from 'react-custom-scrollbars';
import '../scss/AllStocks.scss';
import api from '../Helpers/api';

function AllStocks() {
  const [heading, setHeading] = useState('All Stocks');
  const [stocks, setStocks] = useState([]);
  const [stockPerPage, setStockPerPage] = useState(100);
  const [searchResults, setSearchResults] = useState([]);
  const [loading, setLoading] = useState(false);
  const [priceFlag, setPriceFlag] = useState(false);
  const [pagination, setPagination] = useState(false);
  const [date, setDate] = useState(new Date());
  const [currentPage, setCurrentPage] = useState(0);
  const [stockCount, setStockCount] = useState(0);
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
    const id = event.target.closest('tr').querySelector('td').innerText;
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
    setPagination(false);
    setSearchResults([]);
    setLoading(true);
    setPriceFlag(false);
    api.get('/GetAllStocks')
      .then((response) => {
        const formattedStocks = response.data.map(stock => {
          const formattedDate = new Date(stock.creationDate).toDateString();
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
      .finally(() => {
        window.location.href = "#top";
        setLoading(false);
      })

  }

  const fetchStocksByPage = () => {
    setHeading('All Stocks By Page');
    setSearchResults([]);
    setLoading(true);
    setPagination(true);
    setPriceFlag(false);
    api.get(`/GetStockPage/${currentPage}`)
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
      .finally(() => {
        window.location.href = "#top";
        setLoading(false);
        fetchStocksCount();
      })
  }

  const fetchStocksWithPrice = () => {
    setHeading('All Stocks With Price');
    setPagination(false);
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
      .finally(() => {
        window.location.href = "#top";
        setLoading(false);
      })
  }

  const fetchStocksWithoutPrice = () => {
    setHeading('All Stocks Without Price');
    setPagination(false);
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
      .finally(() => {
        window.location.href = "#top";
        setLoading(false);
      })
  }
  const fetchStocksCount = () => {
    api.get('/GetStocksCount')
      .then((response) => {
        console.log(response);
        setStockCount(response.data.stocksCount);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  useEffect(() => {
    fetchStocks();
  }, []);

  useEffect(() => {
    fetchStocksByPage();
  }, [currentPage]);

  const stockRows = searchResults.map((stock, index) => {

    return (
      // <CSSTransition key={index} className="stock-item" timeout={500} >
      // </CSSTransition>
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


  const SearchByDate = () => {

    const searchResults = stocks.filter((stock) => {
      const stockDate = new Date(stock.creationDate).setHours(0, 0, 0, 0);
      const searchDate = new Date(date).setHours(0, 0, 0, 0);
      return stockDate === searchDate;
    });
    setSearchResults(searchResults);
  }

  const PageNoList = () => {
    const pageNumbers = [];
  
    const totalPages = Math.floor(stockCount / stockPerPage) + 1;
    const maxPageNumbersToShow = 3; // Number of page numbers to show between the first and last pages
  
    // Calculate the range of page numbers to display
    let startRange = Math.max(0, currentPage - Math.floor(maxPageNumbersToShow / 2));
    let endRange = Math.min(totalPages - 1, startRange + maxPageNumbersToShow - 1);
  
    // Adjust the range if it is at the start or end
    if (startRange === 0) {
      endRange = Math.min(endRange + (Math.floor(maxPageNumbersToShow / 2) - currentPage), totalPages - 1);
    }
    if (endRange === totalPages - 1) {
      startRange = Math.max(startRange - (Math.floor(maxPageNumbersToShow / 2) - (totalPages - currentPage - 1)), 0);
    }
  
    // Add first page number if it's not in the visible range
    if (startRange > 0) {
      pageNumbers.push(0);
    }
  
    // Add ellipsis if there are page numbers between the first page and the start of the visible range
    if (startRange > 1) {
      pageNumbers.push('...');
    }
  
    for (let i = startRange; i <= endRange; i++) {
      pageNumbers.push(i);
    }
  
    // Add ellipsis if there are page numbers between the end of the visible range and the last page
    if (endRange < totalPages - 2) {
      pageNumbers.push('...');
    }
  
    // Add last page number if it's not in the visible range
    if (endRange < totalPages - 1) {
      pageNumbers.push(totalPages - 1);
    }
  
    return (
      pageNumbers.map((number) => {
        if (number === currentPage) {
          return (
            <li className='li-item' key={number} onClick={() => setCurrentPage(number)}><b>{number + 1}</b></li>
          );
        }
        if (number === '...') {
          return (
            <li className='li-item' key={number}>{number}</li>
          );
        }
        return (
          <li className='li-item' key={number} onClick={() => setCurrentPage(number)}>{number + 1}</li>
        );
      })
    );
  };
  

  const Pagination = (
    <div className="pagination">
      <ul>
        <li className='li-button' onClick={() => LoadPage("prev")}>Prev</li>
        {/* <li>{currentPage + 1} of {Math.floor(stockCount / stockPerPage) + 1}</li>  */}
        {PageNoList()}
        <li className='li-button' onClick={() => LoadPage("next")}>Next</li>
      </ul>
    </div>
  );

  const LoadPage = (page) => {
    if (loading) {
      return; // Do nothing if still loading
    }

    if (currentPage => 0 && currentPage < Math.floor(stockCount / stockPerPage)) {
      if (page === "prev") {
        if (currentPage === 0) {
        } else
          setCurrentPage(currentPage - 1);
      }
      else if (page === "next") {
        if (currentPage === Math.floor(stockCount / stockPerPage)) {
        } else
          setCurrentPage(currentPage + 1);
      }
    }
  }

  const loadingSpinner = (
    <tr>
      <td colSpan={6} className='loading-td'>
        <div className="loading" colSpan={6}>
          <div className="spinner">Loading</div>
        </div>
      </td>
    </tr>
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

          <input type="date" id="button1" onChange={(e) => (setDate(e.target.value))} placeholder="Search Date..." />
          <input type="submit" id="button2" onClick={SearchByDate} value="Search" />

        </div>

        <div className="filters">
          <input type="submit" id="button2" onClick={fetchStocks} value="All Stocks" />
          <input type="submit" id="button2" onClick={fetchStocksByPage} value="All Stocks By Page" />
          <input type="submit" id="button1" onClick={fetchStocksWithoutPrice} value="Stock Without Price" />
          <input type="submit" id="button2" onClick={fetchStocksWithPrice} value="Stock With Price" />
        </div>
      </div>
      {/* <p>Search is based on Name and Symbol</p> */}

      {
        pagination ? Pagination : null
      }
      <div className="stocktable">
        <Scrollbars style={{ height: "80vh" }}>
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
              {/* <TransitionGroup component={null}>
            </TransitionGroup> */}
              {loading ? loadingSpinner : stockRows.length === 0 ? <tr><td colSpan={6} className='noStocks'>No Stocks Found</td></tr> : stockRows}
            </tbody>
          </table>
        </Scrollbars>
      </div>
      {
        pagination ? Pagination : null
      }
      <div id="bottom"></div>
    </div>
  )
}

export default AllStocks