import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './../scss/Navbar.scss';
import './../scss/responsive.scss';
import SearchResultDiv from './SearchResultDiv';
import api from '../Helpers/api';

function Navbar() {
    const [searchResults, setSearchResults] = useState([]);
    const [stocks, setStocks] = useState([]);

    const stocksData = () => {
        api.get('/GetAllStocks')
            .then((response) => {
                const formattedStocks = response.data.map((stock) => {
                    const formattedDate = new Date(stock.creationDate).toLocaleString();
                    return {
                        ...stock,
                        creationDate: formattedDate,
                    };
                });
                setStocks(formattedStocks);
            })
            .catch((error) => {
                console.log(error);
            });
    };


    const SearchList = (event) => {
        stocksData()

        const searchText = event.target.value;
        const filteredStocks = stocks.filter((stock) => {
            return stock.stockName.toLowerCase().includes(searchText.toLowerCase());
        });
        console.log(filteredStocks);
        setSearchResults(filteredStocks);
    };

    return (
        <div className="navbar-container">


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
        </div>
    )
}

export default Navbar;