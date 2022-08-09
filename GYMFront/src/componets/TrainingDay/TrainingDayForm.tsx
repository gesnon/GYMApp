import { Tabs, TabList, Tab, TabPanel } from 'react-tabs';
import { TrainingDay } from '../../models/TrainingDay';
import './TrainingDayForm.css';


type IGetTrainingDayProps = {
  trainingDay: TrainingDay;
}

function TrainingDayForm(props: IGetTrainingDayProps) {
  const routineExercise = props.trainingDay.exercises;
  console.log(props);
  return (
    <div className="AllContent">


      <Tabs forceRenderTabPanel>
        <div className="TrainingDay">
        <div className="buttonsContainer">
        <TabList>
            <div className="excersisesTab">
              {routineExercise.map(routineExercise => <Tab>{routineExercise.name}</Tab>)}
            </div>
        </TabList>
        <div >            
            <div className="buttonContainer">
                <a href={`/rourineExercise`}> Add New Exercise</a>
            </div>
        </div>
      </div>
          <div >          
          {routineExercise.map(routineExercise => <TabPanel>
            <div className="tabPanel">
              <p>{routineExercise.description}</p>
              <p>{routineExercise.set}</p>
            </div>
            </TabPanel>)}
          </div>
        </div>
      </Tabs>



    </div>

  )

}

export default TrainingDayForm;