using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSözlük.Business.Dtos
{
    public class EntryDto
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public string Entry { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TitleName { get; set; }
    }
}
