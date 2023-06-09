import React from 'react'
import '../scss/SearchResultDiv.scss'

function SearchResultDiv(props) {
  const { searchResults } = props;
  const limitedResults = searchResults.slice(0, 12);

  const StockPage = () => {
    // event.preventDefault();

    console.log("Clicked");
    window.location.href = `/Stock/`;
  };

  const list = limitedResults.map((stock) => {
    // console.log(stock);
    return (
      <li key={stock.stockSymbol} onClick={() => StockPage()} className="stock-list-item">
        {stock.stockName}
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