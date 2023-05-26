import React from 'react'
import '../scss/EditStock.scss'
import api from '../Helpers/api'

function EditStock() {
    const [stock, setStock] = React.useState({
        stockId: window.location.pathname.split('/')[2],
        stockName: '',
        stockSymbol: ''
    })

    const handleSubmit = (e) => {
        e.preventDefault()
        console.log(stock)
        api.put('/UpdateStock', stock)
            .then((response) => {
                console.log(response);
                window.location.href = `/GetAllStocks`
            })
            .catch((error) => {
                console.log(error)
            })
    }

    return (
        <div className='mainContainer edit-div'>
            <h1 className="edit-h1">
                Editing Stock Id : {stock.stockId}
            </h1>

            <form onSubmit={handleSubmit}>
                <formgroup>
                    <label htmlFor="StockName">StockName</label>
                    <input type="text" name="StockName" id="StockName" placeholder='StockName' value={stock.stockName} onChange={(e) => setStock({ ...stock, stockName: e.target.value })} tabIndex={2} />
                </formgroup>
                <formgroup>
                    <label htmlFor="StockSymbol">StockSymbol</label>
                    <input type="text" name="StockSymbol" id="StockSymbol" placeholder='StockSymbol' value={stock.stockSymbol} onChange={(e) => setStock({ ...stock, stockSymbol: e.target.value })} tabIndex={3} />
                </formgroup>
                <input type="submit" value="Submit" onSubmit={handleSubmit} tabIndex={4} />
            </form>


        </div>
    )
}

export default EditStock