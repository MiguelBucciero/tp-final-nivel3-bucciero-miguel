<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            height: 100%;
            transition: transform 0.3s ease;
        }

            .card:hover {
                transform: translateY(-5px);
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            }

        .card-img-top {
            height: 250px;
            object-fit: contain;
            padding: 1rem;
            background: #f8f9fa;
        }

        .card-body {
            display: flex;
            flex-direction: column;
        }

        .card-text {
            flex-grow: 1;
        }

        .card-img-link {
            display: block;
            text-decoration: none;
            cursor: pointer;
            transition: opacity 0.3s ease;
        }

            .card-img-link:hover {
                opacity: 0.85;
            }

            .card-img-link img {
                pointer-events: none;
            }

        .card h5 {
            font-weight: 600;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-4 text-center fw-bold">Mis Favoritos ❤️</h2>
    <hr />

    <div class="row justify-content-center">
        <div class="col-12 col-md-10 col-lg-8">

            <div class="row">
                <asp:Repeater ID="repFavoritos" runat="server">
                    <ItemTemplate>
                        <div class="col-12 col-sm-6 col-md-4 mb-4">
                            <div class="card">
                                <asp:LinkButton ID="lnkImagen" runat="server" CommandArgument='<%#Eval("Id") %>' OnClick="lnkImagen_Click" CssClass="card-img-link">
                                    <img src="<%#Eval("Imagen") %>" class="card-img-top" />
                                </asp:LinkButton>
                                <div class="card-body">
                                    <h5><%#Eval("Nombre") %></h5>
                                    <p><%#Eval("Precio") %> $</p>
                                    <asp:Button
                                        ID="btnEliminar"
                                        runat="server"
                                        Text="❌ Quitar"
                                        CssClass="btn btn-favorito mt-2"
                                        CommandArgument='<%#Eval("Id") %>'
                                        OnClick="btnEliminar_Click" />
                                </div>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </div>
</asp:Content>
