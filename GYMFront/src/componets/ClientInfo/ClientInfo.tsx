import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { ClientProfile as ClientProfileModel } from "../../models/ClientProfile";
import ClientsService from "../../services/clients/ClientsService";
import './ClientInfo.css';

type IClientInfoProps = {
    client: ClientProfileModel;
}
function ClientInfo(props: IClientInfoProps) {
    const { client } = props;

    return (
        <div className="profileContainer">
            <div className="row">
                <div className="column">
                    <span className="fieldLabel">Имя</span>
                </div>
                <div className="column">
                    <span className="fieldValue">{client.fullName ?? "test"}</span>
                </div>
            </div>
            <div className="row">
                <div className="column">
                    <span className="fieldLabel">Тренер</span>
                </div>
                <div className="column">
                    <span className="fieldValue">{client.trainer ?? "test"}</span>
                </div>
            </div>
            <div className="row">
                <div className="column">
                    <span className="fieldLabel">Номер телефона</span>
                </div>
                <div className="column">
                    <span className="fieldValue">{client.phoneNumber ?? "test"}</span>
                </div>
            </div>
            <div className="row">
                <div className="column">
                    <span className="fieldLabel">Почта</span>
                </div>
                <div className="column">
                    <span className="fieldValue">{client.email ?? "test"}</span>
                </div>
            </div>
            <div className="row">
                <div className="column">
                    <span className="fieldLabel">День рождения</span>
                </div>
                <div className="column">
                    <span className="fieldValue">{client.birthDate ?? "test"}</span>
                </div>
            </div>
        </div>

    );
}

export default ClientInfo;