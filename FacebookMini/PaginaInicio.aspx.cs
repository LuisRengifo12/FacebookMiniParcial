using FacebookBD.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace FacebookMini
{
    public partial class PaginaInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarPublicaciones();
                if (Request.QueryString["userId"] != null)
                {
                    int userId = Convert.ToInt32(Request.QueryString["userId"]);

                    CargarInformacionUsuario(userId);
                }
            }
        }

        private void MostrarPublicaciones()
        {
            int userId = Convert.ToInt32(Request.QueryString["userId"]);

            // Aquí obtienes las publicaciones del usuario utilizando Entity Framework
            using (FacebookBD.Modelo.FBUSARIOSEntities1 contexto = new FacebookBD.Modelo.FBUSARIOSEntities1())
            {
                var publicaciones = contexto.Publicaciones.ToList();

                // Iterar sobre las publicaciones y crear elementos HTML para mostrarlas
                foreach (var publicacion in publicaciones)
                {
                    // Crear un div para cada publicación con sus detalles
                    var divPublicacion = new HtmlGenericControl("div");
                    divPublicacion.Attributes.Add("class", "card mb-3 publicard");

                    // Obtener información del usuario específico de la publicación
                    var usuario = contexto.Usuarios.FirstOrDefault(u => u.IdUsuario == publicacion.IdUsuario);

                    // Crear un div para contener la foto de perfil y el nombre de usuario
                    var divUsuario = new HtmlGenericControl("div");
                    divUsuario.Attributes.Add("class", "usuario divusuario");

                    // Crear una imagen para la foto de perfil del usuario
                    var fotoPerfilUsuario = new HtmlGenericControl("img");
                    fotoPerfilUsuario.Attributes.Add("class", "foto-perfil-usuario fotoperfilpubli");
                    fotoPerfilUsuario.Attributes.Add("src", "data:image/jpeg;base64," + Convert.ToBase64String(usuario.fotoPerfil));

                    // Crear un párrafo para el nombre de usuario
                    var nombreUsuario = new HtmlGenericControl("p");
                    nombreUsuario.Attributes.Add("class", "nombre-usuario nombreusuario");
                    nombreUsuario.InnerText = usuario.nombre;

                    // Agregar la foto de perfil y el nombre de usuario al div del usuario
                    divUsuario.Controls.Add(fotoPerfilUsuario);
                    divUsuario.Controls.Add(nombreUsuario);

                    // Agregar el div del usuario al div de la publicación
                    divPublicacion.Controls.Add(divUsuario);

                    // Crear una imagen para la foto de la publicación
                    var fotoPublicacion = new HtmlGenericControl("img");
                    fotoPublicacion.Attributes.Add("class", "foto-publicacion imagenpubli");
                    fotoPublicacion.Attributes.Add("src", "data:image/jpeg;base64," + Convert.ToBase64String(publicacion.Imagen));

                    // Crear un párrafo para el contenido de la publicación
                    var contenido = new HtmlGenericControl("p");
                    contenido.Attributes.Add("class", "card-text");
                    contenido.InnerText = publicacion.Contenido;

                    // Crear un párrafo para la fecha de publicación
                    var fecha = new HtmlGenericControl("p");
                    fecha.Attributes.Add("class", "card-text nombreusuario");
                    fecha.InnerHtml = "<small class='text-muted'>" + publicacion.FechaPublicacion.ToString() + "</small>";

                    // Agregar la foto de la publicación, el contenido y la fecha al div de la publicación
                    divPublicacion.Controls.Add(fotoPublicacion);
                    divPublicacion.Controls.Add(contenido);
                    divPublicacion.Controls.Add(fecha);

                    // Agregar el div de la publicación al contenedor de publicaciones
                    contenedorPublicaciones.Controls.Add(divPublicacion);
                }
            }
        }

        private void CargarInformacionUsuario(int userId)
        {
            using (FBUSARIOSEntities1 db = new FBUSARIOSEntities1())
            {
                Usuarios usuario = db.Usuarios.Find(userId);

                if (usuario != null)
                {
                    Page.Title = $"{usuario.nombre}'s Pagina de Inicio";

                    if (usuario.fotoPerfil != null)
                    {
                        string base64String = Convert.ToBase64String(usuario.fotoPerfil);
                        string imageUrl = $"data:image/jpeg;base64,{base64String}";

                        navUsuarioFoto.Src = imageUrl;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"InfoUsuario.aspx?userId={Request.QueryString["userId"]}");
        }

        protected void btnCrearPublicacion_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            HttpPostedFile archivo = FileUploadPubli.PostedFile;
            if (archivo != null && archivo.ContentLength > 0)
            {
                int longitud = archivo.ContentLength;
                byte[] bytesImagenPubli = new byte[longitud];
                archivo.InputStream.Read(bytesImagenPubli, 0, longitud);

                int userId;
                if (Request.QueryString["userId"] != null && int.TryParse(Request.QueryString["userId"], out userId))
                {
                    using (var db = new FBUSARIOSEntities1())
                    {
                        Publicaciones nuevaPublicacion = new Publicaciones
                        {
                            IdUsuario = userId,
                            Contenido = descripcion,
                            Imagen = bytesImagenPubli,
                            FechaPublicacion = DateTime.Now
                        };

                        db.Publicaciones.Add(nuevaPublicacion);
                        db.SaveChanges();
                    }
                }
                else
                {
                    Response.Write("ID de usuario no válido");
                }
            }
            txtDescripcion.Text = "";
            Response.Redirect(Request.RawUrl);
        }
    }
}