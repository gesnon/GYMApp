import { DetailsList, IColumn, IDetailsColumnRenderTooltipProps, IDetailsHeaderProps, IDetailsRowProps, SelectionMode } from "@fluentui/react/lib/DetailsList";
import { useEffect, useState } from "react";
import { Client } from '../../models/Client';
import ClientsService from '../../services/clients/ClientsService';

function ClientsList() {
    const [clients, setClients] = useState([] as Client[])

    useEffect(() => {
        const clientsService = new ClientsService();
        clientsService.getAllClients().then(res => setClients(res));
    }, []);

    const columns: IColumn[] = [
        { key: "fullName", name: "fullName", fieldName: "fullName", minWidth: 100 },
        { key: "lastMeasurementDate", name: "lastMeasurementDate", fieldName: "lastMeasurementDate", minWidth: 100 },
        { key: "trainer", name: "trainer", fieldName: "trainer", minWidth: 100 },
        { key: "phoneNumber", name: "phoneNumber", fieldName: "phoneNumber", minWidth: 100 },
        { key: "email", name: "email", fieldName: "email", minWidth: 100 }
    ];

    return (
        <DetailsList columns={columns} items={clients} />
    )
}

export default ClientsList;