using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewPeliculas.Models
{
    public class Pelicula
    {
        public int idPelicula { get; set; }

        public int idModerador { get; set; }

        public string titulo { get; set; }

        public string sinopsis { get; set; }

        public string director { get; set; }

        public string actorPrincipal { get; set; }

        public string categoria { get; set; }

        public string idioma { get; set; }

        public int idReview { get; set; }
    }
}
