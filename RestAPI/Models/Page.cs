﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class Page
    {
        public Guid Id { get; set; }
       
        public string Title { get; set; }
        public string Slug { get; set; }
       
        public string Content { get; set; }
        public int Sorting { get; set; }
    }
}
