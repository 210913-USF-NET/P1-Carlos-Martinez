using System;
using System.Collections.Generic;
using Models;
using DL;
using System.Text.RegularExpressions;


namespace StoreBL
{
    public class BL : IBL

    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public void AddObject(object thing)
        {
            _repo.AddObject(thing);
        }

        public List<Client> GetAllClients()
        {
            return _repo.GetAllClients();
        }

        public List<Exercise> GetAllExercises()
        {
            return _repo.GetAllExercises();
        }

        public List<Weight> GetAllWeights()
        {
            return _repo.GetAllWeights();
        }

        public List<Exercise> GetExerciseByWeightByClient(int Id)
        {
            return _repo.GetExerciseByWeightByClient(Id);
        }

        public Client GetOneClient(int Id)
        {
            return _repo.GetOneClient(Id);
        }

        public List<Weight> GetWeightsByClient(int Id)
        {
            return _repo.GetWeightsByClient(Id);
        }

        public void Update(Client thing)
        {
            _repo.Update(thing);
        }

        public void Update(Weight thing)
        {
            _repo.Update(thing);
        }

        public void Update(Exercise thing)
        {
            _repo.Update(thing);
        }
    }
}
