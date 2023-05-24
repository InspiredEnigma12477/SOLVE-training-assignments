import React from 'react'
import './../scss/NotFound.scss'

function Error() {
  return (
    <div className='error'>

      <h1 >Error 404 - Page Not Found</h1>
      <p>The page you are looking for could not be found. Please check the URL or go back to the <a href="/">homepage</a>.</p>
    
      {/* <img src="https://media0.giphy.com/media/8L0Pky6C83SzkzU55a/giphy.gif?cid=ecf05e4741ymrlyelbfjypainm3uaibaoo5b4pi0cbzw8xdb&ep=v1_gifs_search&rid=giphy.gif&ct=g" alt="" /> */}
      {/* <img src="https://media3.giphy.com/media/C21GGDOpKT6Z4VuXyn/giphy.gif?cid=ecf05e47ltobkefkcex64rbrue2vjxritshp4t3hr8eu4ob7&ep=v1_gifs_search&rid=giphy.gif&ct=g" alt="" /> */}
      <img src="https://media2.giphy.com/media/xTiN0L7EW5trfOvEk0/giphy.gif?cid=ecf05e47xgfg1qlxsxabpzqhuj8xl2pejmbbe9jwlw7zzyso&ep=v1_gifs_search&rid=giphy.gif&ct=g" alt="" />
    
    </div>
  )
}

export default Error