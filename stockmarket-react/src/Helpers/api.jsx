import axios from 'axios';
const authToken = localStorage.getItem('token');
const api = axios.create({
  baseURL: 'https://jamapi.kandysh.xyz/api/v1/',
  headers: {
    'Content-Type': 'application/json',
  },
});


export default api;