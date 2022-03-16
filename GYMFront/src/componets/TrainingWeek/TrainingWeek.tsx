
import './TrainingWeek.css';
import TrainingDayForm from '../TrainingDay/TrainingDayForm';
function TrainingWeek() {
    return (
        <div className="TrainingWeek">
        
            <div className="tabWeek">  
                <button className="tablink">Monday</button>
                <button className="tablink">Tuesday</button>
                <button className="tablink">Wednesday</button>
                <button className="tablink">Thursday</button>
                <button className="tablink">Friday</button>
                <button className="tablink">Saturday</button>
                <button className="tablink">Sunday</button>
            </div> 
            
            <div className="Weekcontent">
            <TrainingDayForm></TrainingDayForm>
            </div>

            
        </div>
    )
}

export default TrainingWeek;