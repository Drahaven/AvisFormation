using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
    public class Avis
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(2000)]
        public string Commentaire { get; set; }
        [Required]
        public double Note { get; set; }

        [Required]
        public string NomUtilisateur { get; set; }

        public int FormationId { get; set; }
        [ForeignKey("FormationId")]
        public Formation Formation { get; set; }
    }
}
