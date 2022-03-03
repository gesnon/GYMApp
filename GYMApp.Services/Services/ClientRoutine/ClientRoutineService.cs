using GYMApp.Services.DTO;
using GYMDB;
using GYMDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GYMApp.Services.Services
{
    public class ClientRoutineService : IClientRoutineService
    {
        private readonly ContextDB context;
        public ClientRoutineService(ContextDB context)
        {
            this.context = context;
        }


        public void CreateClientRoutine(ClientRoutineCreateDTO newClientRoutineDTO)
        {

            context.ClientRoutines.Add(new ClientRoutine
            {
                ClientID = newClientRoutineDTO.ClientID,
                RoutineID = newClientRoutineDTO.RoutineID,
                RoutineDate = DateTime.Now

            });
            context.SaveChanges();
        }


        public void DeleteClientRoutine(int ClientRoutineID)
        {
            if (context.ClientRoutines.FirstOrDefault(_ => _.ClientRoutineID == ClientRoutineID) == null)
            {
                throw new Exception("Программа не найдена");
            }

            context.ClientRoutines.Remove(context.ClientRoutines.FirstOrDefault(_ => _.ClientRoutineID == ClientRoutineID));

            context.SaveChanges();
        }

        public List<ClientRoutineDTO> GetAllClientRoutine(int ClientID)
        {
            List<ClientRoutine> clientRoutines = context.ClientRoutines.Include(_=>_.Routine).ThenInclude(_ => _.RoutineExercises).ThenInclude(_ => _.Exercise).Where(_ => _.ClientID == ClientID).ToList();

            List<ClientRoutineDTO> result = clientRoutines
                .Select(r => new ClientRoutineDTO
                {
                    RoutineName = r.Routine.Name,
                    Exercises = r.Routine.RoutineExercises.Select(_ => _.Exercise.Name).ToList(),
                    RoutineDate = r.RoutineDate
                }).ToList();

            return result;
        }

    }
}