﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSözlük.Business.Dtos
{
    public class TitleDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set;}
    }
}
