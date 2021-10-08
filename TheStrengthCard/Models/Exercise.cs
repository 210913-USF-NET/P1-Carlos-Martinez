﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Exercise
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Weight> weightList { get; set; }

        //Constructors.
        public Exercise() { }
    }
}
