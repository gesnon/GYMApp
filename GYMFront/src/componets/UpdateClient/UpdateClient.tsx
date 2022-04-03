import { useEffect, useState, useMemo } from "react";
import { useParams } from "react-router-dom";
import ClientsService from "../../services/clients/ClientsService";
import { UpdateClient as UpdateClientModel } from "../../models/UpdateClient";
import './UpdateClient.css';
import { Controller, useForm } from "react-hook-form";
import Select from "react-select";
function UpdateClient() {

    const { id } = useParams();
    const [client, setClient] = useState({clientID: id } as UpdateClientModel);

    const updateClient = (data: UpdateClientModel) => {
        const clientsService = new ClientsService();
        clientsService.updateClient(data);
    }
    
    const {
        control,
        register,
        handleSubmit,
        watch,
        reset,
        formState: { errors }
    } = useForm({
        defaultValues: useMemo(() => {
            return client;
        }, [client])
    });

    useEffect(() => {
        const clientsService = new ClientsService();
        clientsService.getClient(Number.parseInt(id ?? "")).then(res => {
            if (id) {
                setClient({ clientID: id, email: res.email, fullName: res.fullName, phoneNumber: res.phoneNumber });
            }
        });
    }, []);

    useEffect(() => {
        reset(client);
    }, [client]);


    return (
        <form className="createExercise" onSubmit={handleSubmit(updateClient)}>
            <div className="container" >
                <label>FullName</label>
                <input {...register("fullName", { required: true })} />
                {errors?.fullName?.type === "required" && <p>This field is required</p>}
            </div>

            <div className="container" >
                <label>Telephone Number</label>
                <input {...register("phoneNumber", { required: true })} />
                {errors?.phoneNumber?.type === "required" && <p>This field is required</p>}
            </div>

            <div className="container" >
                <label>Email</label>
                <input {...register("email", { required: true })} />
                {errors?.email?.type === "required" && <p>This field is required</p>}
            </div>         

            <div className="buttonContainer">
                <input type="submit" />
            </div>
        </form>

    );
}

export default UpdateClient;