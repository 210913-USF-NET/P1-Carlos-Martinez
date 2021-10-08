using System;
using System.Collections.Generic;
using System.Net.Security;
using Models;

namespace SBL
{
    public interface IBL
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
        public Exercise GetExerciseById(int Id);
        public List<Exercise> GetAllExercises();
        public List<Weight> GetWeightsByClient(int Id);
        public List<Exercise> GetExerciseByWeightByClient(int Id);

        // Password
        public string Hash(string password);
        public bool Verify(string password, string hash);

    }
}