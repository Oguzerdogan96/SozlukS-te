using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSözlük.Business.Dtos
{
    public class AddEntryDto
    {
        
        public int TitleId { get; set; }
        public int UserId { get; set; }
        public string? Entry { get; set; }
    }
}
