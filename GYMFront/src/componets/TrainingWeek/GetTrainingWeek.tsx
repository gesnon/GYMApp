
import './GetTrainingWeek.css';
import TrainingDayForm from '../TrainingDay/TrainingDayForm';
import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { Tabs, TabList, Tab, TabPanel } from 'react-tabs';

import RoutineService from '../../services/routines/RoutinesService';
import { TrainingWeek } from '../../models/TrainingWeek';

type IGetTrainingWeekProps = {
    trainingWeek: TrainingWeek;
}

function GetTrainingWeek(props: IGetTrainingWeekProps) {
    const weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

    const test = weekDays.map((weekDay, index) => {
        const trainingDay = props.trainingWeek.trainingDaysDTO.find(day => day.dayOfWeek === index);
        if (trainingDay) {
            return <TrainingDayForm trainingDay={trainingDay}></TrainingDayForm>;
        }

        return <h1>Отдых</h1>;
    });    
    return (
        <div className="TrainingWeek">
            <Tabs forceRenderTabPanel>
                <TabList>
                    {weekDays.map(day => <Tab>{day}</Tab>)}
                </TabList>

                {weekDays.map((weekDay, index) => {
                    const trainingDay = props.trainingWeek.trainingDaysDTO.find(day => day.dayOfWeek === index);
                    return trainingDay ?
                        (<TabPanel>
                            <TrainingDayForm trainingDay={trainingDay}/>
                        </TabPanel>) : (<TabPanel><h1>Отдых</h1></TabPanel>)
                })}


            </Tabs>


        </div>
    )
}

export default GetTrainingWeek;