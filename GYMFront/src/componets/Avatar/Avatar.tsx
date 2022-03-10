import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { ClientProfile as ClientProfileModel } from "../../models/ClientProfile";
import ClientsService from "../../services/clients/ClientsService";
import ClientInfo from "../ClientInfo/ClientInfo";
import "./Avatar.css";

type IAvatarProps = {
    photoSrc: string;
    name: string;
}

function Avatar(props: IAvatarProps) {
    return (
        <div className="avatarContainer">
            <img className="avatar" src={`data:image/jpeg;base64, ${props.photoSrc}`} />
            <h3>{props.name ?? "test"}</h3>
        </div>
    );
}

export default Avatar;