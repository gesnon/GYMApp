import { ClientRoutine } from './ClientRoutine'

export interface ClientProfile {
    fullName: string,
    trainer: string,
    phoneNumber: string,
    email: string,
    birthDate: string,
    trainerID: number,
    clientRoutine: ClientRoutine
};