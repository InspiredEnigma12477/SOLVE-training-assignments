import { useState, useEffect } from 'react';
import api from './api';

const GetAllStocks = () => {
  const [data, setData] = useState([]);

    const fetchData = async () => {
      try {
        const response = await api.get('/GetAllStocks');
        const formattedStocks = response.data.map((stock) => {
          const formattedDate = new Date(stock.creationDate).toLocaleString();
          return {
            ...stock,
            creationDate: formattedDate,
          };
        });
        setData(formattedStocks);
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();

  return data;
};

export default GetAllStocks;
