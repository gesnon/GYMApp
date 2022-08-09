import { useEffect, useState } from "react";
import { Link, Outlet, useParams } from "react-router-dom";
import { ClientProfile as ClientProfileModel } from "../../models/ClientProfile";
import ClientsService from "../../services/clients/ClientsService";
import Avatar from "../Avatar/Avatar";
import NavigationBar from "../NavigationBar/NavigationBar";
import './GetExercise.css';

import { BrowserRouter, Route, Routes, useMatch } from 'react-router-dom';
import ExerciseService from "../../services/Exercise/ExerciseService";
import { Exercise } from "../../models/Exercise";

function GetExercise() {
    const { id } = useParams();
    const [exersise, setExercise] = useState({} as Exercise);
    useEffect(() => {
        const exerciseService = new ExerciseService();
        exerciseService.getExercise(Number.parseInt(id ?? "")).then(res => setExercise(res));
    }, []);
   

    return (
        <div className="exerciseContainer">

            <div className="nameConteiner"> 
             {exersise.name}</div>          
            <div className="discriptionConteiner">
            {exersise.description} </div>    

        </div>
    );
}

export default GetExercise;