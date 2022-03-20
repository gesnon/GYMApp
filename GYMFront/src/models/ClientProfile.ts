import { Routine } from './Routine'

export interface ClientProfile {
    fullName: string,
    trainer: string,
    phoneNumber: string,
    email: string,
    birthDate: string,
    trainerID: number,
    clientRoutine: Routine,
    id: number
};