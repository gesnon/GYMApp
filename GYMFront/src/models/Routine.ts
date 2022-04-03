import { TrainingWeek } from "./TrainingWeek";

export interface Routine {
    name: string,
    trainingWeeksDTO: TrainingWeek[],
    id:string 
};