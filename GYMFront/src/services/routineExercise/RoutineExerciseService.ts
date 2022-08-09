import axios from 'axios';
import { CreateRoutineExercise } from '../../models/CreateRoutineExercise';
import { Routine } from '../../models/Routine';

class RoutineExerciseService {
    async createRoutineExercise(routineExercise: CreateRoutineExercise): Promise<void> {
        console.log(routineExercise);
        const response = await axios.post(`https://localhost:44361/API/RoutineExercise`, routineExercise);
    } 
}

export default RoutineExerciseService;