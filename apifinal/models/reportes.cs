using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinal.models
{
    public class reportes
    {
        public int id { get; set; }
        public string catedraticos_activos { get; set; }
        public string catedraticos_inactivos { get; set; }
        public string catedraticos_reprobados { get; set; }
    }
}
