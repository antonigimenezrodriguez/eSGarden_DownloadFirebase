using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vegetable
    {
        public int Id { get; set; }
        public string BigDescr { get; set; }
        public string Descr { get; set; }
        public string Name { get; set; }
        public string continent { get; set; }
        public string img { get; set; }
        public string img1200x900 { get; set; }
        public int temp_max { get; set; }
        public int temp_min { get; set; }
        public int temp_opt { get; set; }
    }
}
