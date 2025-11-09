<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-start vh-100">
        <div class="col-10 col-sm-8 col-md-6 col-lg-4">
            <div class="card shadow p-4">
                <h2 class="text-center mb-4">Pantalla Login</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
                </div>
                <div class="d-grid gap-2 mb-3">
                    <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnLogin" runat="server" />
                </div>
                <div class="text-center">
                    <a href="Registrar.aspx">Crear cuenta</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
