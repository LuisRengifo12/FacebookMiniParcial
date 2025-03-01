﻿using FacebookBD.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookMini
{
    public partial class PaginaRegistro : System.Web.UI.Page
    {
        FacebookBD.Modelo.FBUSARIOSEntities1 db = new FacebookBD.Modelo.FBUSARIOSEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            FacebookBD.Modelo.Usuarios usuario = new FacebookBD.Modelo.Usuarios();

            usuario.nombre = TextBox2.Text;
            usuario.email = TextBox3.Text;
            usuario.contraseña = TextBox4.Text;
            usuario.nombreCompleto = TextBox5.Text;
            try
            {
                DateTime fechaNacimiento = DateTime.ParseExact(TextBox6.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                string fechaFormateada = fechaNacimiento.ToString("dd/mm/yyyy");

                usuario.fechaNacimiento = DateTime.ParseExact(fechaFormateada, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            }
            catch (FormatException ex)
            {
                Console.WriteLine("formato de fecha mal: " + ex.Message);
            }
            if (FileUpload1.HasFile)
            {
                try
                {
                    HttpPostedFile archivo = FileUpload1.PostedFile;
                    int longitud = archivo.ContentLength;
                    byte[] bytesImagen = new byte[longitud];
                    archivo.InputStream.Read(bytesImagen, 0, longitud);

                    usuario.fotoPerfil = bytesImagen;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al procesar el archivo cargado: " + ex.Message);
                }
            }


            try
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                Label10.Text = "El usuario se creó satisfactoriamente.";
                Response.Redirect($"Iniciodesesion.aspx");
            }
            catch (Exception ex)
            {
                Label10.Text = "Error al crear el usuario: " + ex.Message;
            }


        }
    }
}