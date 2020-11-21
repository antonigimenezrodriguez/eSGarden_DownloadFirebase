using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TFM
    {
        public Alert[] Alerts { get; set; }
        public Vegetable[] Vegetables { get; set; }
        public ICollection<Garden> Gardens { get; set; }
    }
}
