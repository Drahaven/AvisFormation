using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvisFormationWebAspNetCore.Models
{
    public class EnvoiEmailViewModel
    {
        [Required]
        public string Nom { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(500, ErrorMessage = "Le texte du commentaire dépasse la taille maximale autorisée")]
        public string Message { get; set; }
    }
}
