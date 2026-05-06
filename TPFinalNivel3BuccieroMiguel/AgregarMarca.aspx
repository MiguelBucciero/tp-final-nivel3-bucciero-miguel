<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.AgregarMarca" %>

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

        .btn-cancelar {
            margin-top: auto;
            border: 2px solid #ff6600 !important;
            color: #ff6600 !important;
            background-color: #333 !important;
            transition: all 0.3s ease;
        }

            .btn-cancelar:hover {
                background-color: #ff6600 !important;
                color: #fff !important;
            }

            .btn-cancelar:focus {
                box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.4) !important;
            }

            .btn-cancelar:active {
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

        .is-invalid:focus {
            border-color: #dc3545 !important;
            box-shadow: 0 0 0 0.25rem rgba(220, 53, 69, 0.25) !important;
        }

        .is-invalid::placeholder {
            color: #dc3545;
            opacity: 0.7;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-12 col-lg-8">
                <div class="card shadow-lg p-4">
                    <h3 id="titulo" runat="server" class="mb-4 text-center fw-bold">Agregar Marca</h3>
                    <div class="row">
                        <div class="mb-3">
                            <label class="form-label">Proximo ID</label>
                            <asp:TextBox ID="txtProximoID" runat="server" CssClass="form-control" Enabled="false" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Nombre de la marca</label>
                            <asp:TextBox ID="txtNombreMarca" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <!-- BOTONES -->
                    <div class="d-flex justify-content-center gap-3 mt-4">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-agregar" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar" PostBackUrl="ListadoArticulos.aspx" />
                    </div>
                    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block text-center fw-bold"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
