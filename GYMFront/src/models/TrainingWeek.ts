import { TrainingDay } from "./TrainingDay";

export interface TrainingWeek {
    name: string,
    trainingDaysDTO: TrainingDay[],
    id:string
};