﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListApp.Models
{
    public class ListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int ListId { get; set; }
        public List List { get; set; }
    }
}
