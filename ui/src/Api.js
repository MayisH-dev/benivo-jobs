import axios from 'axios'

const api = axios.create({
  baseURL: 'http://localhost:57679/',
  headers: { 'Access-Control-Allow-Origin': '*' },
})

export default api
