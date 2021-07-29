using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public class FormationMemoryRepository : IFormationRepository
    {
        private List<Formation> _formations = new List<Formation>();
        public FormationMemoryRepository()
        {
            _formations.Add(new Formation { Id = 1, Nom = "Créer votre site web avec ASP.NET Core", NomSeo = "asp-net-core", Description = "Grace à cette formation vous saurez créer votre propre sit web en très peu de temps" });
            _formations.Add(new Formation { Id = 2, Nom = "Créer votre site web avec PHP", NomSeo = "php", Description = "Grace à cette formation vous saurez créer votre propre sit web en très peu de temps" });
            _formations.Add(new Formation { Id = 3, Nom = "Devenez un pro du jardiange", NomSeo = "pro-jardiange", Description = "Apprenez à cultiver des tomates, courgettes, ..." });
            _formations.Add(new Formation { Id = 4, Nom = "Photo Pro", NomSeo = "pro-photo", Description = "Apprenez à prendre de belles photos" });
        }

        public List<Formation> GetFormations(int nombre)
        {
            return _formations.OrderBy(qu => Guid.NewGuid()).Take(nombre).ToList();
        }

        public List<Formation> GetAllFormations()
        {
            return _formations;
        }

        public Formation GetFormationById(int iIdFormation)
        {
            // ancienne méthode
            /*foreach(var f in _formations)
             {
                 if (f.Id == iIdFormation)
                     return f;
             }
             return null;
            */

            // méthode avec le linq, bien mettre la réfférence en haut
            //return _formations.Where(f => f.Id == iIdFormation).FirstOrDefault();

            // autre méthode
            return _formations.FirstOrDefault(f => f.Id == iIdFormation);
        }

        public Formation GetFormationByNomSeo(string NomSeo)
        {
            return null;
        }
    }

}
