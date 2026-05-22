import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import "./global.css";
import 'bootstrap/dist/css/bootstrap.min.css';
import HomeScreen from './pages/home-screen/HomeScreen'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <HomeScreen />
  </StrictMode>,
)
