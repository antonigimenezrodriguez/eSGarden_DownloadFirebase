﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DataSlot
    {
        public string Id { get; set; }
        public int Type { get; set; }
        public int[] Value { get; set; }
    }
}
