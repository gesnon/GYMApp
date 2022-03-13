import { DetailsList, IColumn, IDetailsColumnRenderTooltipProps, IDetailsHeaderProps, IDetailsRowProps, SelectionMode } from "@fluentui/react/lib/DetailsList";
import { useEffect, useState } from "react";
import { Measurement } from '../../models/Measurement';
import MeasurementService from '../../services/measurements/MeasurementsService';
import { useParams } from "react-router-dom";

function MeasurementList() {
    const [measurements, setMeasurements] = useState([] as Measurement[])
    const { id } = useParams();

    useEffect(() => {
        const measurementService = new MeasurementService();
        measurementService.getAllClientsMeasurements(Number.parseInt(id ?? "")).then(res => setMeasurements(res));
    }, []);

    const columns: IColumn[] = [
        { key: "leftArm", name: "leftArm", fieldName: "leftArm", minWidth: 100 },
        { key: "rightArm", name: "rightArm", fieldName: "rightArm", minWidth: 100 },
        { key: "leftLeg", name: "leftLeg", fieldName: "leftLeg", minWidth: 100 },
        { key: "rightLeg", name: "rightLeg", fieldName: "rightLeg", minWidth: 100 },
        { key: "chest", name: "chest", fieldName: "chest", minWidth: 100 },
        { key: "weight", name: "weight", fieldName: "weight", minWidth: 100 },
        { key: "height", name: "height", fieldName: "height", minWidth: 100 },
        { key: "dateOfCreation", name: "dateOfCreation", fieldName: "dateOfCreation", minWidth: 100 }
    ];

    return (
        <div className="name">
            <DetailsList columns={columns} items={measurements} />
        </div>)
}

export default MeasurementList;

