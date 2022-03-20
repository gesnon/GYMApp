import { Exercise } from "./Exercise"

export interface TrainingDay {
    name: string,
    exercises: Exercise[],
    id:string
};