import { DetailsList, IColumn, IDetailsColumnRenderTooltipProps, IDetailsHeaderProps, IDetailsRowProps, SelectionMode } from "@fluentui/react/lib/DetailsList";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Tab, TabList, TabPanel, Tabs } from "react-tabs";
import RoutineService from "../../services/routines/RoutinesService";
import { Routine } from "../../models/Routine";
import GetTrainingWeek from "../TrainingWeek/GetTrainingWeek";

function CurrentRoutine() {
  const [routine, setRoutine] = useState({} as Routine)
  const { id } = useParams();


  useEffect(() => {
    const routineService = new RoutineService();
    console.log('get routine');
    routineService.getCurrentRoutine(Number.parseInt(id ?? "")).then(res => setRoutine(res));    
  }, []);

  return (
    <div className="routineContainer">
      {routine.trainingWeeksDTO && routine.trainingWeeksDTO.map(week =>
        <GetTrainingWeek trainingWeek={week} />
      )}
    </div>

  );
}

export default CurrentRoutine;

