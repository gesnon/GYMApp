import { useEffect, useState, useMemo } from "react";
import { useParams } from "react-router-dom";
import { ClientProfile as ClientProfileModel } from "../../models/ClientProfile";
import ClientsService from "../../services/clients/ClientsService";
import './UpdateClient.css';
import { useForm } from "react-hook-form";

function UpdateClient() {
    const { id } = useParams();
    const [client, setClient] = useState({} as ClientProfileModel);
    const {
        register,
        handleSubmit,
        watch,
        reset,
        formState: { errors }
    } = useForm({
        defaultValues: useMemo(() => {
            console.log("defaultValues");
            
            return client;
        }, [client])
    });

    useEffect(() => {
        const clientsService = new ClientsService();
        clientsService.getClient(Number.parseInt(id ?? "")).then(res => {
            setClient(res);
            reset(client);
        });
    }, []);

    return (
        <div className="profileContainer">

            <div className="clientinfo">
                <div className="clientInfoString">
                    <span>Имя</span>
                </div>
                <div className="clientInfoString">
                    <input
                        {...register("fullName", { required: true })}/>
                    {errors?.fullName?.type === "required" && <p>This field is required</p>}
                </div>
            </div>


            <div className="clientinfo">
                <div className="clientInfoString">
                    <span >Тренер</span>
                </div>
                <div className="clientInfoString">
                    <span className="fieldValue">{client.trainer ?? "test"}</span>
                </div>
            </div>
            <div className="clientinfo">
                <div className="clientInfoString">
                    <span >Номер телефона</span>
                </div>
                <div className="clientInfoString">
                    <span className="fieldValue">{client.phoneNumber ?? "test"}</span>
                </div>
            </div>
            <div className="clientinfo">
                <div className="clientInfoString">
                    <span >Почта</span>
                </div>
                <div className="clientInfoString">
                    <span className="fieldValue">{client.email ?? "test"}</span>
                </div>
            </div>
            <div className="clientinfo">
                <div className="clientInfoString">
                    <span >День рождения</span>
                </div>
                <div className="clientInfoString">
                    <span className="fieldValue">{client.birthDate ?? "test"}</span>
                </div>
            </div>
            <a href="/editClientInfo"> Edit information</a>
            <input type="submit" />
        </div>

    );
}

export default UpdateClient;