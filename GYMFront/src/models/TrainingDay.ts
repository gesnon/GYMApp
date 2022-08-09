import { Exercise } from "./Exercise"
import { RoutineExercise } from "./RoutineExercise"
export interface TrainingDay {
    description: string,
    dayOfWeek: number,
    exercises: RoutineExercise[],
    id:string
};