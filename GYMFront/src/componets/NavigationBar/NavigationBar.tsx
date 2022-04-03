import './NavigationBar.css';
import { BrowserRouter, Route, Routes, useParams } from 'react-router-dom';
import ClientInfo from '../Client/ClientInfo/ClientInfo';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css'; 
import { ClientProfile as ClientProfileModel } from "../../models/ClientProfile";
import MeasurementList from '../Measurement/MeasurementList/MeasurementList';
import CurrentRoutine from '../Routine/CurrentRoutine';

type INavigationBarProps = {
    client: ClientProfileModel;
}
function NavigationBar(props: INavigationBarProps) {
    const { client } = props;

    return (
        <Tabs forceRenderTabPanel>
        <TabList>
          <Tab>About</Tab>
          <Tab>Measurements</Tab>
          <Tab>Routine</Tab>
        </TabList>
        <TabPanel>
            <ClientInfo client={client} />     
        </TabPanel>
        <TabPanel>
            <MeasurementList></MeasurementList>
        </TabPanel>
        <TabPanel>
            <CurrentRoutine></CurrentRoutine>
        </TabPanel>
      </Tabs>
    )
}

export default NavigationBar;