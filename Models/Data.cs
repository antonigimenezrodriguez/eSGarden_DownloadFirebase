using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Data
    {
        public string Id { get; set; }
        public int ID_Node { get; set; }
        public long timestamp { get; set; }
        public DataSlot DATASLOT_0 { get; set; }
        public DataSlot DATASLOT_1 { get; set; }
        public DataSlot DATASLOT_2 { get; set; }
        public DataSlot DATASLOT_3 { get; set; }
    }
}
