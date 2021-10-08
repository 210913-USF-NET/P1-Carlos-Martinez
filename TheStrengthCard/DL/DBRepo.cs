using System;
using System.Collections.Generic;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;

namespace DL
{
    public class DBRepo : IRepo
    {
        private P0TenzinStoreContext _context;

        public DBRepo(P0TenzinStoreContext context)
        {
            _context = context;
        }

        public void AddObject(Object thing)
        {
            /// Adds an object to the appropriate database. 
            /// thing is the object being added
            
            thing = _context.Add(thing).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public void Update(Object thing)
        {
            /// Updates an object in the appropriate database. 
            /// thing is the object being updated

            thing = _context.Client.Update(thing).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public Client GetOneClient(int Id)
        {
            /// Gets one client from all the clients
            /// Id is the ID of the client you want

            return _context.Client
                .Where(i => i.Id = Id)
                .Select(
                c => new Client()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Password = c.Password
                }
                ).ToList();
        }

        public List<Client> GetAllClients()
        {
            /// Gets all the clients in a list
            
            return _context.Client
                .Select(
                c => new Client()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Password = c.Password
                }
            ).ToList();
        }

        public List<Weight> GetAllWeights()
        {
            /// Gets all the weights in a list

            return _context.Weight
                .Select(
                w => new Weight()
                {
                    Id = w.Id,
                    DateTime = w.DateTime,
                    Amount = w.Amount,
                    ClientId = w.ClientId,
                    ExerciseId = w.ExerciseId
                }
            ).ToList();
        }

        public List<Exercise> GetAllExercises()
        {
            /// Gets all the exercises in a list

            return _context.Exercise
                .Select(
                e => new Exercise()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description
                }
            ).ToList();
        }

        public List<Weight> GetWeightsByClient(int Id)
        {
            /// Gets all the weights with respect to a client
            /// Id is the client you want

            return _context.Weight
                .Where(i => i.ClientId = Id)
                .Select(
                w => new Weight()
                {
                    Id = w.Id,
                    DateTime = w.DateTime,
                    Amount = w.Amount,
                    ClientId = w.ClientId,
                    ExerciseId = w.ExerciseId
                }
            ).ToList();
        }

        public List<Exercise> GetExerciseByWeightByClient(int Id)
        {
            /// Gets all the exercises with respect to a client
            /// Id is the client you want
            
            List<Weight> WeightsByClient = GetWeightsByClient(Id);

            List<Exercise> exercisesByWeightsByClients = new List<Exercise>();

            List<Exercise> allExercises = GetAllExercises();

            foreach (Weight wbC in WeightsByClient)
            {
                foreach (Exercise item in allExercises)
                {
                    if (item.Id == wbC.ExerciseId)
                        exercisesByWeightsByClients.Add(item);
                }
            }

            return exercisesByWeightsByClients;
        }
    }
}