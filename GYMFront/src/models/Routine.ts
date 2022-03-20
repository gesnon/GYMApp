import { TrainingWeek } from "./TrainingWeek";

export interface Routine {
    name: string,
    trainingWeek: TrainingWeek[],
    id:string 
};