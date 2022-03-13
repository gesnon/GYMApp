using GYMApp.Services.DTO;
using GYMDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GYMDB.Models;

namespace GYMApp.Services.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly ContextDB context;

        public MeasurementService(ContextDB context)
        {
            this.context = context;
        }

        public void AddNewMeasurement(MeasurementDTO measurementDTO)
        {
            context.Measurements.Add(new Measurement
            {
                LeftArm = measurementDTO.LeftArm,
                RightArm = measurementDTO.RightArm,
                LeftLeg = measurementDTO.LeftLeg,
                RightLeg = measurementDTO.RightLeg,
                Chest = measurementDTO.Chest,
                Weight = measurementDTO.Weight,
                Height = measurementDTO.Height,
                ClientID = measurementDTO.ClientID,

            });
            context.SaveChanges();
        }

        public void UpdateMeasurement(MeasurementUpdateDTO newMeasurementDTO)
        {
            Measurement OldMeasurement = context.Measurements.FirstOrDefault(_ => _.ID == newMeasurementDTO.MeasurementID);

            if (OldMeasurement == null)
            {
                throw new Exception("Замер не найден");
            }

            OldMeasurement.LeftArm = newMeasurementDTO.LeftArm;
            OldMeasurement.RightArm = newMeasurementDTO.RightArm;
            OldMeasurement.LeftLeg = newMeasurementDTO.LeftLeg;
            OldMeasurement.RightLeg = newMeasurementDTO.RightLeg;
            OldMeasurement.Chest = newMeasurementDTO.Chest;
            OldMeasurement.Weight = newMeasurementDTO.Weight;
            OldMeasurement.Height = newMeasurementDTO.Height;
            OldMeasurement.DateOfCreation = DateTime.Now;

            context.SaveChanges();

        }

        public void DeleteMeasurement(int MeasurementID)
        {
            if (context.Measurements.FirstOrDefault(_ => _.ID == MeasurementID) == null)
            {
                throw new Exception("Замер не найден");
            }
            context.Measurements.Remove(context.Measurements.FirstOrDefault(_ => _.ID == MeasurementID));

            context.SaveChanges();
        }

        public List<MeasurementDTO> GetAllClientsMeasurements(int ClientID)
        {
            if (context.Clients.FirstOrDefault(_ => _.ID == ClientID) == null)
            {
                throw new Exception("Клиент не найден");
            }

            List<MeasurementDTO> measurementDTOs = new List<MeasurementDTO>();

            measurementDTOs = context.Measurements.Where(_ => _.ClientID == ClientID).Select(_ => new MeasurementDTO
            {
                LeftArm = _.LeftArm,
                RightArm = _.RightArm,
                Chest = _.Chest,
                LeftLeg = _.LeftLeg,
                RightLeg = _.RightLeg,
                Weight = _.Weight,
                Height = _.Height,
                ClientID = _.ClientID,
                DateOfCreation = _.DateOfCreation
            }).ToList();

            return measurementDTOs;
        }

        public MeasurementDTO GetLastClientMeasurement(int ClientID)
        {
            if (context.Clients.FirstOrDefault(_ => _.ID == ClientID) == null)
            {
                throw new Exception("Клиент не найден");
            }

            Measurement measurement = context.Measurements.Where(_ => _.ClientID == ClientID).OrderByDescending(_ => _.DateOfCreation).FirstOrDefault();

            MeasurementDTO measurementDTO = new MeasurementDTO
            {
                LeftArm = measurement.LeftArm,
                RightArm = measurement.RightArm,
                Chest = measurement.Chest,
                LeftLeg = measurement.LeftLeg,
                RightLeg = measurement.RightLeg,
                Weight = measurement.Weight,
                Height = measurement.Height,
                ClientID = measurement.ClientID,
                DateOfCreation = measurement.DateOfCreation
            };
            return measurementDTO;                             //Выглядит стремно, 100% можно сделать проще
        }

    }
}
