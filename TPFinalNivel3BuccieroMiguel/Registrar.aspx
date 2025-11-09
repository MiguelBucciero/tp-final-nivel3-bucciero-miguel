<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="d-flex justify-content-center align-items-start vh-100">
            <div class="col-10 col-sm-8 col-md-6 col-lg-5">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Registrarse</h2>

                    <div class="row mb-3">
                        <div class="col-md-6 mb-3 mb-md-0">
                            <label class="form-label">Nombre</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Apellido</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                        </div>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Email</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
                    </div>

                    <div class="mb-4">
                        <label class="form-label">Repetir Contraseña</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword2" TextMode="Password" />
                    </div>

                    <div class="d-grid gap-2 mb-3">
                        <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnRegistrarse" runat="server" />
                    </div>

                    <div class="text-center">
                        <p class="mb-0">¿Ya tenés cuenta? <a href="Login.aspx">Iniciá sesión acá</a></p>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
