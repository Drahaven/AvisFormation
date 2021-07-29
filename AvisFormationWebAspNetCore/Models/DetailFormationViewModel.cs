using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace AvisFormationWebAspNetCore.Models
{
    public class DetailFormationViewModel
    {
        public Formation Formation { get; set; }
        public double NoteMoyenne { get; set; }
    }
}
