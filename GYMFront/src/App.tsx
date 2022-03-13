import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Sidebar from './componets/Sidebar/Sidebar';
import ClientsList from './componets/ClientsList/ClientsList';
import Reviews from './componets/Reviews/Reviews';
import ClientProfile from './componets/ClientProfile/ClientProfile';
import MeasurementList from './componets/MeasurementList/MeasurementList';
import Registration from './componets/Registration/Registration';

function App() {

  return (
    <body>
      <div className="appContainer">

        <Sidebar />
        <div className="mainField">
          <Routes>
            <Route path='/' element={<ClientsList />} />
            <Route path='/clients' element={<ClientsList />} />
            <Route path='/clients/:id' element={<ClientProfile />} />
            <Route path='/myreviews' element={<Reviews />} />
            <Route path='/measurement/:id' element={<MeasurementList />} />
            <Route path='/registration' element={<Registration />} />
          </Routes>
        </div>
      </div>
    </body>
  );
}

export default App;
