import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './../scss/Navbar.scss';
import './../scss/responsive.scss';
import SearchResultDiv from './SearchResultDiv';
import api from '../Helpers/api';

function Navbar() {
    const [searchResults, setSearchResults] = useState([]);

    const stocksData = (event) => {
        let searchtext = (encodeURIComponent(event.target.value) === "" ) ? "--null" : encodeURIComponent(event.target.value);
        api.get('/SearchByNameAndSymbol/' + searchtext)
            .then((response) => {
                setSearchResults(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
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
                    <input type="text" id="search-bar" onChange={stocksData} placeholder="Search..." />
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