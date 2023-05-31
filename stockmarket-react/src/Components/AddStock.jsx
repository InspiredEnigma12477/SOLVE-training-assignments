import React, { useState } from 'react';
import './../scss/AddStock.scss'
import api from '../Helpers/api';

function AddStock() {

  const [stock, setStock] = useState({
    stockName: '',
    stockSymbol: '',
  });

  const [errors, setErrors] = useState({
    stockName: '',
    stockSymbol: '',
  });

  const handleChange = (event) => {
    const { name, value } = event.target;

    api.get('/isStocknameExist', { params: { stockName: value } })
      .then((response) => {
        console.log(response);
        if (response.data === true) {
          setErrors((prevErrors) => ({
            ...prevErrors,
            stockName: 'Stock Name already exists',
          }));
        } else {
          setErrors((prevErrors) => ({
            ...prevErrors,
            stockName: '',
          }));
        }
      })
      .catch((error) => {
        console.log(error);
      });

    api.get('/isStockSymbolExist', { params: { stockSymbol: value } })
      .then((response) => {
        console.log(response);
        if (response.data === true) {
          setErrors((prevErrors) => ({
            ...prevErrors,
            stockSymbol: 'Stock Symbol already exists',
          }));
        } else {
          setErrors((prevErrors) => ({
            ...prevErrors,
            stockSymbol: '',
          }));
        }
      })
      .catch((error) => {
        console.log(error);
      });

    setStock((prevStock) => ({
      ...prevStock,
      [name]: value,
    }));
  };

  const handleBlur = (event) => {
    const { name, value } = event.target;
    if (name === 'stockName' && value.length < 1) {
      setErrors((prevErrors) => ({
        ...prevErrors,
        stockName: 'Stock Name is required',
      }));
    } if (name === 'stockName' && value.length > 50) {
      setErrors((prevErrors) => ({
        ...prevErrors,
        stockName: 'Stock Name cannot be more than 50 characters',
      }));
    } if (name === 'stockName' && value.length < 50) {
      setErrors((prevErrors) => ({
        ...prevErrors,
        stockName: '',
      }));
    }
  };

  const handleErrors = (name) => {
    if (errors[name].length > 0) {
      return <div className="error-msg">{errors[name]}</div>;
    }
    return null;
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    console.log(stock);

    api.post('/InsertOneStock', stock)
      .then((response) => {
        console.log(response);
        window.location.href = '/GetAllStocks';
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleCancel = (event) => {
    event.preventDefault();
    window.location.href = '/';
  };


  return (
    <div className='AddStock mainContainer'>
      <h1>Add Stock</h1>
      <p>Use the form below to add a new stock to the watchlist.</p>
      <p>Fields marked with an asterisk (*) are required.</p>
      <p>Stock Name and Stock Symbol must be unique.</p>


      <div className="form-group" onSubmit={handleSubmit}>
        <form action="" className='form'>

          <formgroup className="name-group flex">
            <label htmlFor="">Stock Name</label>
            {handleErrors('stockName')}
            <input
              type="text"
              className="text-input"
              placeholder="Stock Name"
              name="stockName"
              id="stockName"
              value={stock.stockName}
              onChange={(e) => setStock({ ...stock, stockName: e.target.value })}
              onBlur={handleBlur}
              tabIndex={1} />
          </formgroup>

          <formgroup className="symbol-group flex">
            <label htmlFor="">Stock Symbol</label>
            {handleErrors('stockSymbol')}
            <input type="text"
              className="text-input"
              placeholder="Stock Symbol"
              name="stockSymbol"
              id="stockSymbol"
              value={stock.stockSymbol}
              onChange={(e) => setStock({ ...stock, stockSymbol: e.target.value })}  
              onBlur={handleBlur}
              tabIndex={2} />
          </formgroup>
          <div className="flex button-group">
            <input type="button" className="button form-cancel" value="Cancel" onClick={handleCancel} tabIndex={4} />
            <input type="submit" className="button form-submit" value="Add Stock" tabIndex={3} />
          </div>
        </form>
      </div>

    </div>
  )
}

export default AddStock