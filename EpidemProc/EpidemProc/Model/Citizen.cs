using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemProc
{
    class Citizen
    {
        public int Id { get; set; }
        public int Immunity { get; set; }
        public bool WasSick { get; set; }
        public string SocialStatus { get; set; }
        public int ProffesionId { get; set; }
        public int Health { get; set; }
        public int HealthStatus { get; set; }
        public bool HardWorker { get; set; }
        public bool SickLeave { get; set; }
        public bool Hospitalized { get; set; }
        public int FactureId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
