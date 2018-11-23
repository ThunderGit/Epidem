using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemProc
{
    class Troop
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public int HospitalId { get; set; }
        public bool Initiative { get; set; }
        public int Quality { get; set; }
    }
}
