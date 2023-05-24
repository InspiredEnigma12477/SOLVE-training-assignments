import { Routes } from 'react-router-dom';
import { BrowserRouter, Route } from 'react-router-dom';
import './App.css';
import Home from './Components/Home';
import Navbar from './Components/Navbar';
import AddStock from './Components/AddStock';
import NotFound from './Components/NotFound';
import AllStocks from './Components/AllStocks';
import Footer from './Components/Footer';

function App() {
  return (
    <BrowserRouter>

      <div className="App">
        <Navbar />
      </div>

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path='\' exact element={<Home/>}/>
        <Route path="/AddStock" element={<AddStock />} />
        <Route path="/GetAllStocks" element={<AllStocks/>} />
        <Route path="*" element={<NotFound/>} />
      </Routes>

      <Footer/>
    </BrowserRouter>
  );
}

export default App;
