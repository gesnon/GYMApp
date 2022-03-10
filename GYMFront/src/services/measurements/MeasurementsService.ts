import axios from 'axios';
import { Client } from '../../models/Client';

class ClientsService {
    async getAllClients(): Promise<Client[]> {
        const response = await axios.get('https://localhost:44361/API/Client');
        
        return response.data as Client[];
    }
}

export default ClientsService;