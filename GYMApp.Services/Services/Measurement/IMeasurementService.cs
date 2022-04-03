using GYMApp.Services.DTO;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.Services
{
    public interface IMeasurementService
    {
        public void CreateMeasurement(MeasurementCreateDTO measurementDTO);

        public void UpdateMeasurement(MeasurementUpdateDTO measurementUpdateDTO);

        public void DeleteMeasurement(int MeasurementID);

        public List<MeasurementDTO> GetAllClientsMeasurements(int ClientID);

        public MeasurementDTO GetLastClientMeasurement(int ClientID);        // этот метод нужен для того, чтобы тренер видел кто халтурит, по факту достаточно получать только дату
    }
}
