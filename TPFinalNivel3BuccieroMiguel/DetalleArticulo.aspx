<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-warning {
            background-color: #ff6600;
            border: none;
            color: white;
        }

        .btn-warning:hover {
            background-color: #e55a00;
        }

        .text-warning {
            color: #ff6600 !important;
        }

        .text-Color {
            border-color: #ff6600 !important;
            color: #ff6600 !important;
        }

        .btn-favorito {
            margin-top: auto;
            border: 2px solid #ff6600 !important;
            color: #ff6600 !important;
            background-color: transparent !important;
            transition: all 0.3s ease;
        }

        .btn-favorito:hover {
            background-color: #ff6600 !important;
            color: #fff !important;
        }

        .btn-favorito:focus {
            box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.4) !important;
        }

        .btn-favorito:active {
            transform: scale(0.98);
        }

        .img-container {
            height: 400px;
            padding: 1rem;
        }

        .producto-img {
            max-height: 100%;
            max-width: 100%;
            object-fit: contain;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <!-- Volver atras -->
        <div class="mb-3">
            <a href="Default.aspx" class="text-decoration-none text-Color">Inicio</a> >
        <span class="text-muted">Detalle del producto</span>
        </div>
        <div class="row g-4">
            <!-- Imagen -->
            <div class="col-md-6">
                <div class="card shadow-sm h-100">
                    <div class="img-container d-flex align-items-center justify-content-center">
                        <asp:Image ID="imgProducto" runat="server" CssClass="img-fluid producto-img" />
                    </div>
                </div>
            </div>
            <!-- Info -->
            <div class="col-md-6">
                <div class="card p-4 shadow-sm h-100">
                    <!-- Nombre -->
                    <h2 class="fw-semibold mb-2">
                        <asp:Label ID="lblNombre" runat="server" />
                    </h2>
                    <!-- Código -->
                    <p class="text-muted mb-1">
                        <strong>Código:</strong>
                        <asp:Label ID="lblCodigo" runat="server" />
                    </p>
                    <!-- Marca -->
                    <p class="text-muted mb-3">
                        <strong>Marca:</strong>
                        <span class="badge bg-secondary">
                            <asp:Label ID="lblMarca" runat="server" />
                        </span>
                    </p>
                    <!-- Stock -->
                    <div class="alert alert-success py-2">
                        ✓ Stock disponible
                    </div>
                    <!-- Precio -->
                    <div class="bg-light p-3 rounded mb-3">
                        <small class="text-muted">Precio</small>
                        <h3 class="fw-bold text-warning mb-0">$
                        <asp:Label ID="lblPrecio" runat="server" />
                        </h3>
                    </div>
                    <!-- Descripción -->
                    <div class="mb-3">
                        <h6 class="fw-semibold">Descripción</h6>
                        <p class="text-muted mb-0">
                            <asp:Label ID="lblDescripcion" runat="server" />
                        </p>
                    </div>
                    <!-- Botón -->
                    <asp:Button ID="btnAgregarFavoritos" runat="server" Text="Agregar a favoritos" CssClass="btn btn-favorito" OnClick="btnAgregarFavoritos_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
