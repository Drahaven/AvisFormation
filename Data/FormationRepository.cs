using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FormationRepository : IFormationRepository
    {
        MonDbContext _context;

        // injection de dépendance
        public FormationRepository(MonDbContext context)
        {
            _context = context;
        }

        // avoir une liste random des formations
        public List<Formation> GetFormations(int nombre)
        {
            return _context.Formations.Include("Avis").OrderBy(qu => Guid.NewGuid()).Take(nombre).ToList(); ;
        }

        // avoir la liste de toutes les formations
        public List<Formation> GetAllFormations()
        {
            return _context.Formations.ToList();
        }

        // avoir une formation particulière grace à l'id
        public Formation GetFormationById(int iIdFormation)
        {
            return _context.Formations.Include("Avis").FirstOrDefault(f => f.Id == iIdFormation);
        }

        public Formation GetFormationByNomSeo(string nomSeo)
        {
            return _context.Formations.Include("Avis").FirstOrDefault(f => f.NomSeo == nomSeo);
        }
    }
}
