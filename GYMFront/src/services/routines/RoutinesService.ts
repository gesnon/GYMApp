import axios from 'axios';
import { Measurement } from '../../models/Measurement';
import { CreateMeasurement } from '../../models/CreateMeasurement';
import { Routine } from '../../models/Routine';

class RoutineService {
    async getCurrentRoutine(id: number): Promise<Routine> {
        const response = await axios.get(`https://localhost:44361/API/Routine/GetCurrentRoutine/${id}`);

        return response.data as Routine;
    }  

}

export default RoutineService;