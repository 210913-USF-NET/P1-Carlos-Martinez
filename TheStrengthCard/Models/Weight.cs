using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Weight
    {
        //Properties.
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
        public int ClientId { get; set; }
        public int ExercieId { get; set; }

        //Constructor.
        public Weight() { }
    }
}
