import React, { useEffect, useState } from 'react'
import api from '../Helpers/api';
import '../scss/Stock.scss'

function Stock() {
    const [stock, setStock] = useState([]);
    const [stockPrice, setStockPrice] = useState([]);
    const [loading, setLoading] = useState(false);
    const [symbol, setSymbol] = useState('');

    useEffect(() => {
        setLoading(true);
        setSymbol(window.location.pathname.split('/')[2])
        
        api.get(`/StockBySymbol/${symbol}`)
            .then((response) => {
                setStock(response.data);
                setLoading(false);
            })
            .catch((error) => {
                console.log(error);
                // window.location.href = "/NotFound";
            });

        api.get(`/StockPriceOnline/${symbol}`)
            .then((response) => {
                console.log(response.data);
                setStockPrice(response.data.stockPrice);
                setLoading(false);
            }
            )
            .catch((error) => {
                console.log(error);
            }
            );

    }, [symbol]);

    const StockPriceh1 = () => {
        setLoading(true);
        api.get(`/StockPriceOnline/${symbol}`)
            .then((response) => {
                console.log(response.data);
                setStockPrice(response.data.stockPrice);
                setLoading(false);
                return (
                    <h1 className='stockprice-h1'> Stock Price :
                        <span id="symbol-h1-price">
                            {stockPrice}
                        </span>
                        <button className='addToDB'> Add to DB </button>
                    </h1>
                )
            }
            )
            .catch((error) => {
                console.log(error);
            }
            );
    }
    const LoadingAnimation = (
        <div className="loading " id='stock-loading' colSpan={6}>
            <div className="spinner">Loading</div>
        </div>
    );



    const DisplayStock = (stock) => {
        
        
        return (
            <>
                <h1 className="stockName">{stock.stockName} </h1>

                <h1><span id="symbol-h1"> {symbol} </span></h1>
                {StockPriceh1}

                <h1 className='stockprice-h1'> Stock Price :
                    <span id="symbol-h1-price">
                        {stockPrice}
                    </span>
                    <button className='addToDB'> Add to DB </button>
                </h1>

            </>
        )
    }



    return (
        <main className="mainContainer stockpage">


            {loading ? LoadingAnimation : DisplayStock(stock)}

        </main>
    )
}

export default Stock