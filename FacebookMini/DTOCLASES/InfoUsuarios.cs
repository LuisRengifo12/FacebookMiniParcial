using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookMini.DTOCLASES
{
    public class InfoUsuarios
    {

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string FotoPerfilBase64 { get; set; }
    }
}