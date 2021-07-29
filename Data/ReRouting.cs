using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
    public class ReRouting
    {
        [Key]
        public string OldUrl { get; set; }
        public string NewUrl { get; set; }
    }
}
