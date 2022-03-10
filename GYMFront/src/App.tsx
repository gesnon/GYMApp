import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Sidebar from './componets/Sidebar/Sidebar';
import ClientsList from './componets/ClientsList/ClientsList';
import Reviews from './componets/Reviews/Reviews';
import ClientProfile from './componets/ClientProfile/ClientProfile';

function App() {

  return (
    <div className="appContainer">
      <Sidebar />
      <div className="container">
        <Routes>
          <Route path='/' element={<ClientsList />} />
          <Route path='/clients' element={<ClientsList />} />
          <Route path='/clients/:id' element={<ClientProfile />} />
          <Route path='/myreviews' element={<Reviews />} />
        </Routes>
      </div>

    </div>
  );
}

export default App;
