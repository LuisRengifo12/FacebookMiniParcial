using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookMini
{
    public partial class Login : System.Web.UI.Page

    {
        FacebookBD.Modelo.FBUSARIOSEntities1 db = new FacebookBD.Modelo.FBUSARIOSEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            string credencial = TextBox1.Text;
            string contraseña = TextBox2.Text;

            int idUsuario = ObtenerIdUsuario(credencial);

            if (idUsuario != -1 && ValidarCredenciales(credencial, contraseña))
            {
                Session["UserId"] = "idUsuario";

                Response.Redirect($"PaginaInicio.aspx?userId={idUsuario}");
            }
            else
            {
            Label1.Text = "Credenciales Incorrectas";
            }
        }

        public int ObtenerIdUsuario(string credencialNombreEmail)
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.nombre == credencialNombreEmail || u.email == credencialNombreEmail);

            if (usuario != null)
            {
                return usuario.IdUsuario;
            }
            else
            {
                return -1;
            }
        }

        public bool ValidarCredenciales(string credencialNombreEmail, string contraseña)
        {
            var usuario = db.Usuarios.FirstOrDefault(u => (u.nombre == credencialNombreEmail || u.email == credencialNombreEmail) && u.contraseña == contraseña);

            return usuario != null;
        }

        public void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect($"PaginaRegistro.aspx");
        }
    }
}
