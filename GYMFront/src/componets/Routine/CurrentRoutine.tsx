import { DetailsList, IColumn, IDetailsColumnRenderTooltipProps, IDetailsHeaderProps, IDetailsRowProps, SelectionMode } from "@fluentui/react/lib/DetailsList";
import { useEffect, useState } from "react";
import { Measurement } from '../../models/Measurement';
import MeasurementService from '../../services/measurements/MeasurementsService';
import { useParams } from "react-router-dom";
import { Tab, TabList, TabPanel, Tabs } from "react-tabs";
import ClientInfo from "../ClientInfo/ClientInfo";

function CurrentRoutine() {
    const [routine, setRoutine] = useState([] as Measurement[])
    const { id } = useParams();

    useEffect(() => {
        const measurementService = new MeasurementService();
        measurementService.getAllClientsMeasurements(Number.parseInt(id ?? "")).then(res => setRoutine(res));
    }, []);

    <Tabs forceRenderTabPanel>
    <TabList>
      <Tab>Monday</Tab>
      <Tab>Tuesday</Tab>
      <Tab>Wednesday</Tab>
      <Tab>Thursday</Tab>
      <Tab>Friday</Tab>
      <Tab>Saturday</Tab>
      <Tab>Sunday</Tab>
    </TabList>
    <TabPanel>
           
    </TabPanel>
    <TabPanel>
       
    </TabPanel>
  </Tabs>
}

export default CurrentRoutine;

