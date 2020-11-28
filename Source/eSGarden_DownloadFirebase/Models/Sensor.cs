using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sensor
    {
        public string Id { get; set; }
        public SensorValue[] SensorValues { get; set; }
    }
}
