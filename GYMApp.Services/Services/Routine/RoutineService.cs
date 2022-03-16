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
    public class RoutineService : IRoutineService
    {
        private readonly ContextDB context;
        public RoutineService(ContextDB context)
        {
            this.context = context;
        }


        public void CreateRoutine(RoutineCreateDTO newRoutineDTO)
        {

            context.Routines.Add(new Routine
            {
                Name = newRoutineDTO.Name,
                Description = newRoutineDTO.Description,
                ClientID = newRoutineDTO.ClientID,
            });
            context.SaveChanges();
        }
        public void UpdateRoutine(int RoutineID, RoutineUpdateDTO newRoutineDTO)
        {
            Routine OldRoutine = context.Routines.FirstOrDefault(_ => _.ID == RoutineID);

            if (OldRoutine == null)
            {
                throw new Exception("Программа не найдена");
            }

            OldRoutine.Name = newRoutineDTO.Name;
            OldRoutine.Description = newRoutineDTO.Description;

            context.SaveChanges();
        }

        public void DeleteRoutine(int RoutineID)
        {
            if (context.Routines.FirstOrDefault(_ => _.ID == RoutineID) == null)
            {
                throw new Exception("Программа не найдена");
            }

            context.Routines.Remove(context.Routines.FirstOrDefault(_ => _.ID == RoutineID));

            context.SaveChanges();
        }

        public GetRoutineDTO GetCurrentRoutine(int ClientID)
        {
            Client client = context.Clients.Include(_=>_.Routines)
                .ThenInclude(_ => _.TrainingW).ThenInclude(_ => _.TrainingDays)
                .ThenInclude(_ => _.Exercises).ThenInclude(_=>_.Exercise)
                .FirstOrDefault(_ => _.ID == ClientID);

            Routine routine = client.Routines.Where(_ => _.Current == true).ToList().FirstOrDefault();
            
            return new GetRoutineDTO

            {
                Name = routine?.Name,
                Description = routine?.Description,
                TrainingWeeksDTO = routine?.TrainingW.Select(_ => new TrainingWeekDTO
                {
                    Name = _.Name,
                    ID = _.ID,
                    TrainingDaysDTO = _.TrainingDays.Select(_ => new TrainingDayDTO
                    {
                        Name = _.Name,
                        ID = _.ID,
                        Exercises = _.Exercises.Select(_ => new ExerciseGetDTO
                        {
                            Name = _.Exercise.Name,
                            Description = _.Exercise.Description,
                            ExerciseID = _.Exercise.ID

                        }).ToList()
                    }).ToList()
                }).ToList()
            };
        }
    }
}