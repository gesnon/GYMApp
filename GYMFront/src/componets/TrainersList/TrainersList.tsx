import { DetailsList, IColumn, IDetailsColumnRenderTooltipProps, IDetailsHeaderProps, IDetailsRowProps, SelectionMode } from "@fluentui/react/lib/DetailsList";
import { useEffect, useState } from "react";
import { Client } from '../../models/Client';
import { Trainer } from '../../models/Trainer';
import ClientsService from '../../services/clients/ClientsService';
import TrainersService from '../../services/trainers/TrainersService';
import './Trainers.css';

function TrainersList() {
    const [trainers, setTrainers] = useState([] as Trainer[])
    const [searchQuery, setSearchQuery] = useState("");

    useEffect(() => {
        const trainersService = new TrainersService();
        trainersService.getAllTrainers(searchQuery).then(res => setTrainers(res));
    }, [searchQuery]);

    const columns: IColumn[] = [
        { key: "fullName", name: "fullName", fieldName: "fullName", minWidth: 100, maxWidth: 200 },
        { key: "birthDate", name: "birthDate", fieldName: "birthDate", minWidth: 100, maxWidth: 200 },
        { key: "numberOfClients", name: "numberOfClients", fieldName: "numberOfClients", minWidth: 100, maxWidth: 200 },
    ];

    const renderItemColumn = (item?: any, index?: number, column?: IColumn) => {
        const fieldValue = item[column?.fieldName as keyof any] as string;

        switch (column?.fieldName) {
            case "fullName":
                return <a href={`/trainers/${item.id}`}>{fieldValue}</a>
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

                <DetailsList columns={columns} items={trainers} onRenderItemColumn={renderItemColumn} />
            </div>
        </div>
    )
}

export default TrainersList;