import axios from 'axios';
import { Client } from '../../models/Client';
import { ClientProfile } from '../../models/ClientProfile';
import { UpdateClient } from '../../models/UpdateClient';

class ClientsService {
    async getClient(id: number): Promise<ClientProfile> {
        const response = await axios.get(`https://localhost:44361/API/Client/${id}`);

        return response.data as ClientProfile;
    }

    async getAllClients(name: string): Promise<Client[]> {
        const response = await axios.get(`https://localhost:44361/API/Client/GetClientsByName/${name}`);

        return response.data as Client[];
    }

    async updateClient(client: UpdateClient): Promise<void> {
        const response = await axios.put(`https://localhost:44361/API/Client/UpdateClient`, client);      
    }
}

export default ClientsService;