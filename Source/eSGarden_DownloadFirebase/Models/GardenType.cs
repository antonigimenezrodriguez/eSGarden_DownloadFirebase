using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GardenType
    {
        public string Id { get; set; }
        public Sensor[] Sensors { get; set; }
    }
}
