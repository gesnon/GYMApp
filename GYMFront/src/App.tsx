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
import TrainersList from './componets/TrainersList/TrainersList';
import GetExercise from './componets/Exercise/GetExercise';
import ExerciseService from './services/Exercise/ExerciseService';
import ExerciseList from './componets/ExerciseList/ExerciseList';
import CreateExercise from './componets/CreateExercise/CreateExercise';
import UpdateClient from './componets/UpdateClient/UpdateClient';

function App() {

  return (
    <body>
      <div className="appContainer">

        <Sidebar />
        <div className="mainField">
          <Routes>
            <Route path='/' element={<ClientsList />} />
            <Route path='/clients' element={<ClientsList />} />
            <Route path='/trainers' element={<TrainersList />} />
            <Route path='/clients/:id' element={<ClientProfile />} />
            <Route path='/myreviews' element={<Reviews />} />
            <Route path='/measurement/:id' element={<MeasurementList />} />
            <Route path='/registration' element={<Registration />} />
            <Route path='/exercises' element={<ExerciseList />} />
            <Route path='/exercise' element={<CreateExercise />} />
            <Route path='/exercise/:id' element={<GetExercise />} />
            <Route path='/editClientInfo/:id' element={<UpdateClient />} />
          </Routes>
          
        </div>
      </div>
    </body>
  );
}

export default App;
