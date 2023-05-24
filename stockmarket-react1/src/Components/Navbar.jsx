import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import './../scss/Navbar.scss';
import SearchResultDiv from './SearchResultDiv';
import GetAllstocks from '../Helpers/GetAllStocks';

function Navbar() {

    const [searchResults, setSearchResults] = useState([]);
    const [stocks, setStocks] = useState([]);


    const GetAllstock = () => {
        const stocks = GetAllstocks();
        setStocks(stocks);
    };

    const SearchList = (event) => {
        GetAllstock();

            const searchText = event.target.value;
            const filteredStocks = stocks.filter((stock) => {
                return stock.stockName.toLowerCase().includes(searchText.toLowerCase());
            });
            console.log(filteredStocks);
            setSearchResults(filteredStocks);
        };

        return (
            <nav className="navbar">
                <a href="/" className="logo">
                    <h1>
                        Stock Market
                    </h1>
                </a>
                <div className="search-container">
                    <input type="text" id="search-bar" onChange={SearchList} placeholder="Search..." />
                    <SearchResultDiv searchResults={searchResults} />
                </div>
                <div className="links">
                    <ul>
                        <li><Link to="/">Home</Link></li>
                        <li><Link to="/AddStock">Add Stock</Link></li>
                        <li><Link to="/GetAllStocks">All Stocks</Link></li>
                    </ul>
                </div>
            </nav>
        )
    }

    export default Navbar;