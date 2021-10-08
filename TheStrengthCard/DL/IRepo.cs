using System;
using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {
        public void AddObject(Object thing);
        public void Update(Client thing);
        public void Update(Weight thing);
        public void Update(Exercise thing);
        public void DeleteObject(Client thing);
        public void DeleteObject(Weight thing);
        public void DeleteObject(Exercise thing);
        public Client GetOneClient(int Id);
        public Client GetOneClient(string first, string last);
        public List<Client> GetAllClients();
        public List<Weight> GetAllWeights();
        public List<Exercise> GetAllExercises();
        public List<Weight> GetWeightsByClient(int Id);
        public List<Exercise> GetExerciseByWeightByClient(int Id);

    }
}
