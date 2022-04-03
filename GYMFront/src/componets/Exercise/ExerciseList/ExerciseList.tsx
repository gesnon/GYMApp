import { DetailsList, IColumn, IDetailsColumnRenderTooltipProps, IDetailsHeaderProps, IDetailsRowProps, SelectionMode } from "@fluentui/react/lib/DetailsList";
import { useEffect, useState } from "react";
import { Exercise } from "../../../models/Exercise";
import './ExerciseList.css';
import ExerciseService from "../../../services/Exercise/ExerciseService";
function ExerciseList() {
    const [exercises, setExercise] = useState([] as Exercise[])
    const [searchQuery, setSearchQuery] = useState("");

    useEffect(() => {
        const exerciseService = new ExerciseService();
        exerciseService.getExercisesByName(searchQuery).then(res => setExercise(res));
    }, [searchQuery]);

    const columns: IColumn[] = [
        { key: "name", name: "name", fieldName: "name", minWidth: 100 },
        { key: "description", name: "description", fieldName: "description", minWidth: 100 }
    ];

    const renderItemColumn = (item?: Exercise, index?: number, column?: IColumn) => {
        if (!item) { return; }
        const fieldValue = item[column?.fieldName as keyof Exercise] as string;

        switch (column?.fieldName) {
            case "name":
                return <a href={`/exercise/${item.exerciseID}`}>{fieldValue}</a>
            default:
                return <span>{fieldValue}</span>
        }
    }

    return (
        <div>
            <div className="d1">
                <form>
                    <input type="text" placeholder="Поиск..." value={searchQuery} onChange={(e) => setSearchQuery((e.target as HTMLInputElement).value)} />
                    <a href="/exercise"> Add New Exercise</a>
                </form>
            </div>

            <div className="table">

                <DetailsList columns={columns} items={exercises} onRenderItemColumn={renderItemColumn} />
            </div>
        </div>
    )
}

export default ExerciseList;