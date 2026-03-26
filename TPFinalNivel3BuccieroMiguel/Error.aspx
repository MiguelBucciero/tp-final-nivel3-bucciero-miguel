<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-error {
            margin-top: auto;
            border-color: #ff6600 !important;
            color: #ff6600 !important;
            transition: all 0.3s ease;
        }

        .btn-error:hover {
            background-color: #ff6600 !important;
            color: #fff !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="card shadow-sm text-center p-5" style="max-width: 500px; width: 100%;">
            <!-- Icono -->
            <div class="mb-3">
                <i class="bi bi-exclamation-triangle-fill text-warning" style="font-size: 3rem;"></i>
            </div>
            <!-- Título -->
            <h2 class="fw-bold mb-3">Oops! Algo salió mal</h2>
            <!-- Mensaje -->
            <p class="text-muted mb-4">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger small"></asp:Label>
            </p>
            <!-- Botones -->
            <div class="d-grid gap-2">
                <a href="Default.aspx" class="btn btn-error fw-semibold">Volver al inicio
                </a>
            </div>
        </div>
    </div>
</asp:Content>
