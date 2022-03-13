import axios from 'axios';
import { Client } from '../../models/Client';
import { ClientProfile } from '../../models/ClientProfile';

class ClientsService {
    async getClient(id: number): Promise<ClientProfile> {
        const response = await axios.get(`https://localhost:44361/API/Client/${id}`);

        return response.data as ClientProfile;
    }

    async getAllClients(name: string): Promise<Client[]> {
        const response = await axios.get(`https://localhost:44361/API/Client/GetClientsByName/${name}`);

        return response.data as Client[];
    }
}

export default ClientsService;