﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}