import { Tabs, TabList, Tab, TabPanel } from 'react-tabs';
import { TrainingDay } from '../../models/TrainingDay';
import './TrainingDayForm.css';


type IGetTrainingDayProps = {
  trainingDay: TrainingDay;
}

function TrainingDayForm(props: IGetTrainingDayProps) {
  const exercises = props.trainingDay.exercises;



  return (
    <div className="AllContent">


      <Tabs forceRenderTabPanel>
        <div className="TrainingDay">
        <TabList>
            <div className="excersisesTab">
              {exercises.map(exercise => <Tab>{exercise.name}</Tab>)}
            </div>
        </TabList>
          <div >
          {exercises.map(exercise => <TabPanel>{exercise.description}</TabPanel>)}
          </div>
        </div>
      </Tabs>




      {/* <Tabs forceRenderTabPanel>
        <TabList>
          <Tab>Exersise 1</Tab>
          <Tab>Exersise 2</Tab>
          <Tab>Exersise 3</Tab>
        </TabList>

        <TabPanel>
               <h1>test 1</h1>  
        </TabPanel>

        <TabPanel>
        <h1>test 2</h1>  
        </TabPanel>
        <TabPanel>
        <h1>test 3</h1>  
            
        </TabPanel>
      </Tabs> */}

    </div>

  )

}

export default TrainingDayForm;