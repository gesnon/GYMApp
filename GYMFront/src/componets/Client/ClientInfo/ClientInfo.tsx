import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { ClientProfile as ClientProfileModel } from "../../../models/ClientProfile";
import ClientsService from "../../../services/clients/ClientsService";
import './ClientInfo.css';

type IClientInfoProps = {
    client: ClientProfileModel;
}
function ClientInfo(props: IClientInfoProps) {
    const { client } = props;

    return (
        <div className="profileContainer">
            <div className="clientinfo">
                <div className="clientInfoString">
                    <span>Имя</span>
                </div>
                <div className="clientInfoString">
                    <span className="fieldValue">{client.fullName ?? "test"}</span>
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
            <a href={`/updateClientInfo/${props.client.id}`}> Update Information</a>
        </div>

    );
}

export default ClientInfo;