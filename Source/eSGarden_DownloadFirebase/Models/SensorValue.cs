using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SensorValue
    {
        public int Id { get; set; }
        public string Condition { get; set; }
        public int Field { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
    }
}
