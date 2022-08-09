import { useEffect, useState } from "react";
import { Link, Outlet, useParams } from "react-router-dom";
import './CreateRoutineExercise.css';
import RoutineExerciseService from "../../../services/routineExercise/RoutineExerciseService";
import { useForm } from "react-hook-form";
import { CreateRoutineExercise as CreateRoutineExerciseModel } from "../../../models/CreateRoutineExercise";

function CreateRoutineExercise() {
    //const { id } = useParams();

    const [routineExercise, setRoutineExercise] = useState({
        exerciseID: "", trainingDayID: "", set: ""  } as CreateRoutineExerciseModel);

    const saveRoutineExercise = (data: CreateRoutineExerciseModel) => {
        const routineExerciseService = new RoutineExerciseService();
        console.log(data);
        console.log(routineExercise);
        routineExerciseService.createRoutineExercise(data);
    }
    const {
        register,
        handleSubmit,
        watch,
        formState: { errors }
    } = useForm({
        defaultValues: {
            exerciseID: "", trainingDayID: "", set: ""
        } as CreateRoutineExerciseModel
    });


    return (
        
        <form className ="createMeasurement" onSubmit={handleSubmit(saveRoutineExercise)}>
            <div className="measurementContainer">
            <label>Left Arm</label>
            <input {...register("exerciseID", { required: true })} />
            {errors?.exerciseID?.type === "required" && <p>This field is required</p>}
            </div>           
            
            <div className="measurementContainer">
            <label>Right Arm</label>
            <input {...register("trainingDayID", { required: true })} />
            {errors?.trainingDayID?.type === "required" && <p>This field is required</p>}
            </div>            
           
            <div className="measurementContainer">
            <label>Left Leg</label>
            <input {...register("set", { required: true })} />
            {errors?.set?.type === "required" && <p>This field is required</p>}
            </div>                      
               
            <div className="buttonContainer">
            <input type="submit" />
            </div>
        </form>

       
    );
}

export default CreateRoutineExercise;