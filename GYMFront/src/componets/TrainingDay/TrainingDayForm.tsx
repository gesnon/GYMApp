import './TrainingDayForm.css';

function TrainingDayForm() {
  return (
    <div className="AllContent">
   
      <div className="tab">
        <button className="tablinks">Exersise 1</button>
        <button className="tablinks">Exersise 2</button>
        <button className="tablinks" >Exersise 3</button>
      </div>
      
      <div className="ExersiseInfo">
        <h3>Подъем на бицепс</h3>
        <p>3 подхода по 10 повторений</p>
      </div>     
      
    </div>
            
    )  
    
}

export default TrainingDayForm;