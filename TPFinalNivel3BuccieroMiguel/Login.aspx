<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-ingresar {
            margin-top: auto;
            border: 2px solid #ff6600 !important;
            color: #ff6600 !important;
            background-color: transparent !important;
            transition: all 0.3s ease;
        }

            .btn-ingresar:hover {
                background-color: #ff6600 !important;
                color: #fff !important;
            }

            .btn-ingresar:focus {
                box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.4) !important;
            }

            .btn-ingresar:active {
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
    <div class="d-flex justify-content-center align-items-start vh-100">
        <div class="col-10 col-sm-8 col-md-6 col-lg-4">
            <div class="card shadow p-4">
                <h2 class="text-center mb-4">Iniciar sessión</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Password</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
                </div>
                <div class="d-grid gap-2 mb-3">
                    <asp:Button Text="Ingresar" CssClass="btn btn-ingresar" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
                </div>
                <div class="text-center">
                    <a href="Registrar.aspx">Crear cuenta</a>
                </div>
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="mt-3 d-block text-center fw-bold"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
