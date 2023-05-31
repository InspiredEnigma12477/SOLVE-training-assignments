import React from 'react'
import '../scss/Home.scss'

function Home() {
  return (
    <div className='mainContainer home'>
      <h1>Home</h1>
      <ul>
        <li><a href='/AddStock'>Add Stock</a></li>
        <li><a href='/GetAllStocks'>Get All Stocks</a></li>
      </ul>

      <dialog id="dialog" className="dialog">
        <div className="dialog__content">

          <h1>Shivam sakore</h1>
          <p>Stock Market App</p>
        </div>
      </dialog>

      <p>
        This is a simple stock management application. It is built using ReactJS and ASP.NET.
        <br/>
        Developed by <a href='https://github.com/InspiredEnigma12477'>InspiredEnigma12477</a>.
        

      </p>

    </div>
  )
}

export default Home