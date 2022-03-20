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
        <form onSubmit={handleSubmit(saveExercise)}>
            <label>Name</label>
            <input {...register("name", { required: true })} />
            {errors?.name?.type === "required" && <p>This field is required</p>}

            <label>Description</label>
            <input {...register("description", { required: true })} />
            {errors?.description?.type === "required" && (<p>This field is required</p>)}

            <input type="submit" />
        </form>
    );
}

export default CreateExercise;