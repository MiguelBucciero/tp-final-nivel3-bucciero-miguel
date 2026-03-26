<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarArticulos.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.AgregarArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-agregar {
            border: 2px solid #ff6600 !important;
            color: #ff6600 !important;
            background-color: transparent !important;
            transition: all 0.3s ease;
        }

            .btn-agregar:hover {
                background-color: #ff6600 !important;
                color: #fff !important;
            }

            .btn-agregar:focus {
                box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.4) !important;
            }

            .btn-agregar:active {
                transform: scale(0.98);
            }

        .form-control:focus {
            border-color: #ff6600 !important;
            box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.25) !important;
        }

        .form-select:focus {
            border-color: #ff6600 !important;
            box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.25) !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-12 col-lg-8">

                <div class="card shadow-lg p-4">

                    <h3 id="titulo" runat="server" class="mb-4 text-center fw-bold">Agregar Artículo</h3>

                    <div class="row">

                        <!-- IZQUIERDA -->
                        <div class="col-md-6">

                            <div class="mb-3">
                                <label class="form-label">Código</label>
                                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Marca</label>
                                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" />
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Categoría</label>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" />
                            </div>

                        </div>

                        <!-- DERECHA -->
                        <div class="col-md-6">


                            <div class="mb-3">
                                <label class="form-label">Precio</label>
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">URL Imagen</label>
                                <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" />
                                <img id="imgPreview" class="img-fluid mt-2" style="max-height:150px;" />
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Descripción</label><asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                            </div>

                        </div>

                    </div>

                    <!-- BOTONES -->
                    <div class="d-flex justify-content-center gap-3 mt-4">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-agregar" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" PostBackUrl="ListadoArticulos.aspx" />
                    </div>

                    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block text-center fw-bold"></asp:Label>

                </div>

            </div>
        </div>
    </div>
    <script>
    document.addEventListener("DOMContentLoaded", function () {
        const txtImagen = document.getElementById("<%= txtImagen.ClientID %>");
        const imgPreview = document.getElementById("imgPreview");

        function actualizarImagen() {
            if (txtImagen.value) {
                imgPreview.src = txtImagen.value;
                imgPreview.style.display = "block";
            } else {
                imgPreview.style.display = "none";
            }
        }
        txtImagen.addEventListener("input", actualizarImagen);
        actualizarImagen();
    });
    </script>
</asp:Content>
