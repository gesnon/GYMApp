import { DetailsList, IColumn, IDetailsColumnRenderTooltipProps, IDetailsHeaderProps, IDetailsRowProps, SelectionMode } from "@fluentui/react/lib/DetailsList";
import { useEffect, useState } from "react";
import { Client } from '../../../models/Client';
import ClientsService from '../../../services/clients/ClientsService';
import './Clients.css';
function ClientsList() {
    const [clients, setClients] = useState([] as Client[])
    const [searchQuery, setSearchQuery] = useState("");

    useEffect(() => {
        const clientsService = new ClientsService();
        clientsService.getAllClients(searchQuery).then(res => setClients(res));
    }, [searchQuery]);

    const columns: IColumn[] = [
        { key: "fullName", name: "fullName", fieldName: "fullName", minWidth: 100 },
        { key: "lastMeasurementDate", name: "lastMeasurementDate", fieldName: "lastMeasurementDate", minWidth: 100 },
        { key: "trainer", name: "trainer", fieldName: "trainer", minWidth: 100 },
        { key: "phoneNumber", name: "phoneNumber", fieldName: "phoneNumber", minWidth: 100 },
        { key: "email", name: "email", fieldName: "email", minWidth: 100 }
    ];

    const renderItemColumn = (item?: any, index?: number, column?: IColumn) => {
        const fieldValue = item[column?.fieldName as keyof any] as string;

        switch (column?.fieldName) {
            case "fullName":
                return <a href={`/clients/${item.id}`}>{fieldValue}</a>
            default:
                return <span>{fieldValue}</span>
        }
    }

    return (
        <div>
            <div className="d1">
                <form>
                    <input type="text" placeholder="Поиск..." value={searchQuery} onChange={(e) => setSearchQuery((e.target as HTMLInputElement).value)} />
                    <button> Accept</button>
                </form>
            </div>

            <div className="table">

                <DetailsList columns={columns} items={clients} onRenderItemColumn={renderItemColumn} />
            </div>
        </div>
    )
}

export default ClientsList;