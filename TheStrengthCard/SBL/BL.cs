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
        
    }
}
