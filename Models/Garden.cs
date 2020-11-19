using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Garden
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Img { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public List<sensorData> sensorData { get; set; }
    }
}
