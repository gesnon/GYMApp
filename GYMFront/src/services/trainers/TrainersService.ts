import axios from 'axios';
import { Client } from '../../models/Client';
import { ClientProfile } from '../../models/ClientProfile';
import { Trainer } from '../../models/Trainer';

class TrainersService {
    async getClient(id: number): Promise<ClientProfile> {
        const response = await axios.get(`https://localhost:44361/API/Client/${id}`);

        return response.data as ClientProfile;
    }

    async getAllTrainers(name: string): Promise<Trainer[]> {
        const response = await axios.get(`https://localhost:44361/API/Trainer/GetTrainersByName/${name}`);

        return response.data as Trainer[];
    }
}

export default TrainersService;