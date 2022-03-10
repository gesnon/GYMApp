import axios from 'axios';
import { Client } from '../../models/Client';
import { ClientProfile } from '../../models/ClientProfile';

class ClientsService {
    async getAllClients(): Promise<Client[]> {
        const response = await axios.get('https://localhost:44361/API/Client');

        return response.data as Client[];
    }

    async getClient(id: number): Promise<ClientProfile> {
        const response = await axios.get(`https://localhost:44361/API/Client/${id}`);

        return response.data as ClientProfile;
    }
}

export default ClientsService;