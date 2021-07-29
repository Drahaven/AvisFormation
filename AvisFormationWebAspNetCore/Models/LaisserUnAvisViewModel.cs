﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvisFormationWebAspNetCore.Models
{
    public class LaisserUnAvisViewModel
    {

        [StringLength(500, ErrorMessage ="Le texte du commentaire dépasse la taille maximale autorisée")]
        public string Commentaire { get; set; }

        //[Required]
        //public string Nom { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public string IdFormation { get; set; }
        public string NomFormation { get; set; }
    }
}
