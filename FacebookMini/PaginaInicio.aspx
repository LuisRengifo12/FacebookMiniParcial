<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaInicio.aspx.cs" Inherits="FacebookMini.PaginaInicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" href="../Media/LogoFriendSync.png" type="image/x-icon" />
    <link rel="stylesheet" href="../CSS/Inicio.css" />
    <link rel="stylesheet" href="../CSS/Site.css" />
    <title>Inicio de MiniFacebook</title>
</head>
<body>
    <form id="form2" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light barranav">
            <div class="container">
                
                <a class="navbar-brand  tituloNavInicio" href="">MiniFacebook</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                    aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="listanav navbar-nav ml-auto">
                        <li class="libarranav">
                            <a class="nav-link" href="">
                                
                                <svg xmlns="http://www.w3.org/2000/svg" width="20"style="color: #dc3545" height="20" fill="currentColor" class="bi bi-house-lock" viewBox="0 0 16 16">
                                  <path d="M7.293 1.5a1 1 0 0 1 1.414 0L11 3.793V2.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v3.293l2.354 2.353a.5.5 0 0 1-.708.708L8 2.207l-5 5V13.5a.5.5 0 0 0 .5.5h4a.5.5 0 0 1 0 1h-4A1.5 1.5 0 0 1 2 13.5V8.207l-.646.647a.5.5 0 1 1-.708-.708z"/>
                                  <path d="M10 13a1 1 0 0 1 1-1v-1a2 2 0 0 1 4 0v1a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-4a1 1 0 0 1-1-1zm3-3a1 1 0 0 0-1 1v1h2v-1a1 1 0 0 0-1-1"/>
                                </svg>
                            </a>
                        </li>
                        <li class="libarranav">
                            <a class="nav-link" href="">
                                <svg xmlns="http://www.w3.org/2000/svg" style="color: #dc3545" width="20" height="20" fill="currentColor" class="bi bi-people-fill" viewBox="0 0 16 16">
                                  <path d="M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6m-5.784 6A2.24 2.24 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.3 6.3 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1zM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5"/>
                                </svg>
                                
                            </a>
                        </li>
                        <li class="libarranav">
                            <button id="Button1" runat="server" class="botonfoto" onserverclick="Button1_Click">
                                <img id="navUsuarioFoto" runat="server" class="foto-usuario" />
                            </button>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="divcards">
            <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false"
                tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="staticBackdropLabel">Crear Publicación</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="input-group flex-nowrap">
                                <span class="input-group-text" id="addon-wrapping">Descripción</span>
                                <asp:TextBox ID="txtDescripcion" type="text" runat="server" class="form-control" aria-label="Descripcion"
                                    aria-describedby="addon-wrapping"></asp:TextBox>
                            </div>
                            <div class="form-group camposRegistro detail">
                                <asp:FileUpload ID="FileUploadPubli" runat="server" accept="image/*" CssClass="form-control" />
                                <div class="divImagenPubli">
                                    <img id="imagenPerfil" src="#" alt="Vista previa de la imagen" style="max-width: 100%;
                                        display: none; margin: auto; padding-top: 5%;" />
                                </div>
                            </div>
                            <script>
                                document.getElementById('<%= FileUploadPubli.ClientID %>').addEventListener('change', function () {
                                    var archivo = this.files[0];
                                    if (archivo) {
                                        var reader = new FileReader();
                                        reader.onload = function (e) {
                                            var imagenPerfil = document.getElementById('imagenPerfil');
                                            imagenPerfil.src = e.target.result;
                                            imagenPerfil.style.display = 'inline-block';
                                        }
                                        reader.readAsDataURL(archivo);
                                    }
                                });
                            </script>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                            <asp:Button ID="btnCrearPublicacion" runat="server" Text="Crear Publicación" CssClass="btn btn-success" OnClick="btnCrearPublicacion_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="card mb-3 divbotoncrearpu">
                <button type="button" class="btn botoncreapu botonmodal" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                    Crear nueva publicación
                </button>
            </div>
            
            <div id="contenedorPublicaciones" runat="server" class="container mb-3">
                
            </div>
            
        </div>
    </form>
</body>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
    rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH"
    crossorigin="anonymous" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz"
    crossorigin="anonymous"></script>
</html>