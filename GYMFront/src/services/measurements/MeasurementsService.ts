import axios from 'axios';
import { Measurement } from '../../models/Measurement';
import { CreateMeasurement } from '../../models/CreateMeasurement';

class MeasurementService {
    async getAllClientsMeasurements(id: number): Promise<Measurement[]> {
        const response = await axios.get(`https://localhost:44361/API/Measurement/${id}`);

        return response.data as Measurement[];
    }

    async createMeasurement(measurement: CreateMeasurement): Promise<void> {
        console.log(measurement);
        const response = await axios.post(`https://localhost:44361/API/Measurement`, measurement);
    }   

}

export default MeasurementService;