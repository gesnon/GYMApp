import { useEffect, useState } from "react";
import { Link, Outlet, useParams } from "react-router-dom";
import './CreateMeasurement.css';
import MeasurementService from "../../../services/measurements/MeasurementsService";
import { CreateMeasurement as CreateMeasurementModel } from "../../../models/CreateMeasurement";
import { useForm } from "react-hook-form";

function CreateMeasurement() {
    const { id } = useParams();

    const [measurement, setMeasurement] = useState({
         leftArm: "", rightArm: "", leftLeg: "", rightLeg: "", chest: "",weight: "",height: "", clientId:id } as CreateMeasurementModel);

    const saveMeasurement = (data: CreateMeasurementModel) => {
        const measurementService = new MeasurementService();
        console.log(data);
        console.log(measurement);
        measurementService.createMeasurement(data);
    }
    const {
        register,
        handleSubmit,
        watch,
        formState: { errors }
    } = useForm({
        defaultValues: {
            leftArm: "", rightArm: "", leftLeg: "", rightLeg: "", chest: "", weight: "", height: "",clientId:id
        } as CreateMeasurementModel
    });



    return (
        
        <form className ="createMeasurement" onSubmit={handleSubmit(saveMeasurement)}>
            <div className="measurementContainer">
            <label>Left Arm</label>
            <input {...register("leftArm", { required: true })} />
            {errors?.leftArm?.type === "required" && <p>This field is required</p>}
            </div>           
            
            <div className="measurementContainer">
            <label>Right Arm</label>
            <input {...register("rightArm", { required: true })} />
            {errors?.rightArm?.type === "required" && <p>This field is required</p>}
            </div>            
           
            <div className="measurementContainer">
            <label>Left Leg</label>
            <input {...register("leftLeg", { required: true })} />
            {errors?.leftLeg?.type === "required" && <p>This field is required</p>}
            </div>            
            
            <div className="measurementContainer">
            <label>Right Leg</label>
            <input {...register("rightLeg", { required: true })} />
            {errors?.rightLeg?.type === "required" && <p>This field is required</p>}
            </div>            
            
            <div className="measurementContainer">
            <label>Chest</label>
            <input {...register("chest", { required: true })} />
            {errors?.chest?.type === "required" && <p>This field is required</p>}
            </div>            
            
            <div className="measurementContainer">
            <label>Weight</label>
            <input {...register("weight", { required: true })} />
            {errors?.weight?.type === "required" && <p>This field is required</p>}
            </div>
            
            <div className="measurementContainer">
            <label>Height</label>
            <input {...register("height", { required: true })} />
            {errors?.height?.type === "required" && <p>This field is required</p>}
            </div>    

            <div className="buttonContainer">
            <input type="submit" />
            </div>
        </form>

       
    );
}

export default CreateMeasurement;