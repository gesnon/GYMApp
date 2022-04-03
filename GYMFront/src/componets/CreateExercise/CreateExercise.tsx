import { useEffect, useState } from "react";
import { Link, Outlet, useParams } from "react-router-dom";
import './CreateExercise.css';
import ExerciseService from "../../services/Exercise/ExerciseService";
import { CreateExercise as CreateExerciseModel } from "../../models/CreateExercise";
import { useForm } from "react-hook-form";

function CreateExercise() {
    const [exersise, setExercise] = useState({ description: "", name: "" } as CreateExerciseModel);

    const saveExercise = (data: CreateExerciseModel) => {
        const exerciseService = new ExerciseService();
        console.log(data);
        console.log(exersise);
        exerciseService.createExercise(data).then(() => goBack());
    }
    const {
        register,
        handleSubmit,
        watch,
        formState: { errors }
    } = useForm({
        defaultValues: {
            name: "",
            description: ""
        } as CreateExerciseModel
    });

    const goBack = () => {
        window.location.href = "/exercises"
    }

    return (
        <form className="createExercise" onSubmit={handleSubmit(saveExercise)}>
            <div className="container" >
            <label>Name</label>
            <input {...register("name", { required: true })} />
            {errors?.name?.type === "required" && <p>This field is required</p>}
            </div>
            <div className="container" >
            <label>Description</label>           
            <textarea {...register("description", { required: true })} />       
            {errors?.description?.type === "required" && (<p>This field is required</p>)}
            </div>
            <div className="buttonContainer">
            <input type="submit" />
            </div>
        </form>
    );
}

export default CreateExercise;