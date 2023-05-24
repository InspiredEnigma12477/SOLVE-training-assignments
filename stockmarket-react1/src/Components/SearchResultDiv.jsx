import React from 'react'
import '../scss/SearchResultDiv.scss'

function SearchResultDiv(props) {
  const { searchResults } = props;

  const list = searchResults.map((stock) => {
    return (
      <li key={stock.StockId} className="stock-list-item">
        <a href={`/GetStock/${stock.StockId}`}>{stock.stockName}</a>
      </li>
    );
  });

  return (
    <div id="search-results" >
    <ul id="stock-list" className='selectize-input'>
      {list}
    </ul>
  </div>
  )
}

export default SearchResultDiv