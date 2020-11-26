using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewPeliculas.Models
{
    public class Moderador
    {
        public int idModerador { get; set; }

        public int idAdministrador { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public int edad { get; set; }

        public string genero { get; set; }

        public string email { get; set; }
    }
}
