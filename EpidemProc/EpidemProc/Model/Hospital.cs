using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemProc
{
    class Hospital
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public int CorruptionLevel { get; set; }
        public int MaxHospitalized { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
