import { Exercise } from "./Exercise"

export interface TrainingDay {
    description: string,
    dayOfWeek: number,
    exercises: Exercise[],
    id:string
};