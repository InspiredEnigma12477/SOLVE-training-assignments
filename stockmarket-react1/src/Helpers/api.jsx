import axios from 'axios';
const api = axios.create({
  baseURL: 'https://localhost:7140/Stock/',
  headers: {
    'Content-Type': 'application/json',
  },
});


export default api;