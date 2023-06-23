import axios from 'axios';

// localStorage.setItem('api', 'primary');
// localStorage.setItem('baseURL', 'https://localhost:7140/Stock/');


var fallbackApi = axios.create({
  baseURL: 'http://localhost:5232/Stock/',
  headers: {
    'Content-Type': 'application/json',
  },
});

var primaryApi = axios.create({
  baseURL: 'https://localhost:7140/Stock/',
  headers: {
    'Content-Type': 'application/json',
  },
});

// var api = axios.create({
//   baseURL: localStorage.getItem('baseURL'),
//   headers: {
//     'Content-Type': 'application/json',
//   },
// });

// localStorage.setItem('aaxios', api);

// var GhostProtocol = () => {
//   console.log('GhostProtocol : ' + localStorage.getItem('api') + ' : ' + localStorage.getItem('baseURL'));


//     api.get('/')
//       .then((response) => {
//         console.log("GhostProtocol Success " + localStorage.getItem('api') + " : " + localStorage.getItem('baseURL'));
//         console.log(response);
//         return;
//       })
//       .catch((error) => {
//         console.log("GhostProtocol Error caught " + localStorage.getItem('api') + " : " + localStorage.getItem('baseURL'));
//         if (localStorage.getItem('api') === 'primary') {
//           console.log("GhostProtocol: Switching to fallback ");
//           localStorage.setItem('api', 'fallback');
//           localStorage.setItem('baseURL', 'http://localhost:5232/Stock/');
//         } else {
//           console.log("GhostProtocol: Switching to primary ");
//           localStorage.setItem('api', 'primary');
//           localStorage.setItem('baseURL', 'https://localhost:7140/Stock/');
//         }
//       });
 
// };

// GhostProtocol();

var api = fallbackApi;

export default api;