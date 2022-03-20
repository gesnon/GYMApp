import axios from 'axios';
import { Exercise } from '../../models/Exercise';
import { CreateExercise } from '../../models/CreateExercise';


class ExerciseService {
    async getExercisesByName(name: string): Promise<Exercise[]> {
        const response = await axios.get(`https://localhost:44361/API/Exercise/GetExercisesByName/${name}`);

        return response.data as Exercise[];
    }

    async getExercise(id: number): Promise<Exercise> {
        const response = await axios.get(`https://localhost:44361/API/Exercise/${id}`);

        return response.data as Exercise;
    }
    async createExercise(exercise: CreateExercise): Promise<void> {
        console.log(exercise);
        const response = await axios.post(`https://localhost:44361/API/Exercise`, exercise);
    }
}

export default ExerciseService;