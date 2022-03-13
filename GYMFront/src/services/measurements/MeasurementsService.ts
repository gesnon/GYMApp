import axios from 'axios';
import { Measurement } from '../../models/Measurement';

class MeasurementService {
    async getAllClientsMeasurements(id: number): Promise<Measurement[]> {
        const response = await axios.get(`https://localhost:44361/API/Measurement/${id}`);

        return response.data as Measurement[];
    }


}

export default MeasurementService;