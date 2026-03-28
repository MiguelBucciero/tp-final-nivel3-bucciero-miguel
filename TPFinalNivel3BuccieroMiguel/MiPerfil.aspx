<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .perfil-card {
            border-radius: 15px;
        }

        .perfil-img {
            width: 160px;
            height: 160px;
            object-fit: cover;
            border-radius: 50%;
            border: 3px solid #ff6600;
        }

        .btn-editar {
            border: 2px solid #ff6600 !important;
            color: #ff6600 !important;
            background-color: transparent !important;
            transition: all 0.3s ease;
        }

        .btn-editar:hover {
            background-color: #ff6600 !important;
            color: #fff !important;
        }

        .btn-editar:focus {
            box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.4) !important;
        }

        .btn-editar:active {
            transform: scale(0.98);
        }

        .form-control:focus {
            border-color: #ff6600 !important;
            box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.25) !important;
        }

        .is-invalid {
            border-color: #dc3545 !important;
        }

        .is-invalid:focus {
            border-color: #dc3545 !important;
            box-shadow: 0 0 0 0.25rem rgba(220, 53, 69, 0.25) !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-lg-10">

                <div class="card shadow p-4 perfil-card">

                    <h2 class="text-center mb-4">Mi Perfil 👤</h2>
                    <hr />
                    <div class="row">

                        <!-- 🔹 IZQUIERDA: DATOS -->
                        <div class="col-md-6 d-flex flex-column align-items-center">

                            <div class="mb-2 w-75">
                                <label class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="false" />
                            </div>

                            <div class="mb-2 w-75">
                                <label class="form-label">Apellido</label>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Enabled="false" />
                            </div>

                            <div class="mb-2 w-75">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Enabled="false" />
                            </div>
                            <div class="mb-2 mb-2 w-75 text-start">
                                <label class="form-label">Nueva contraseña</label>                     
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Enabled="false" />
                            </div>
                        </div>

                        <!-- 🔹 DERECHA: FOTO  -->
                        <div class="col-md-6 text-center">
                            <asp:Image ID="imgPerfil" runat="server" CssClass="perfil-img mt-4 mb-3" />
                            <br />
                            <div class="mb-2 w-75 mx-auto">
                                <asp:Label ID="lblImagen" Text="Subir imagen" runat="server" class="form-label" />
                                <asp:FileUpload ID="fuImagen" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>

                    <!-- MENSAJE -->
                    <asp:Label ID="lblMensaje" runat="server" CssClass="d-block text-center mt-3" />

                    <!-- BOTÓN -->
                    <div class="d-flex justify-content-center gap-3 mt-4">
                        <asp:Button ID="btnEditar" runat="server" Text="Editar datos" CssClass="btn btn-editar" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnGuardar" Text="Guardar datos" runat="server" OnClick="btnGuardar_Click" CssClass="btn btn-editar" Visible="false" />
                    </div>

                </div>

            </div>
        </div>
    </div>

</asp:Content>
