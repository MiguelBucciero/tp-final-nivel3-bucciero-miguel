<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.Default" %>

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

        .form-check {
            margin-bottom: 5px;
        }

        .form-control:focus {
            border-color: #ff6600 !important;
            box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.25) !important;
        }

        .dropdown-toggle {
            border-color: #ff6600 !important;
            color: #ff6600 !important;
        }

        .dropdown-toggle:hover {
            background-color: #ff6600 !important;
            color: #fff !important;
        }

        .dropdown-menu {
            border-radius: 8px;
        }

        .dropdown-item:hover {
            background-color: #ff6600 !important;
            color: #fff !important;
        }

        .accordion-button {
            color: #ff6600 !important;
            font-weight: 600 !important;
        }

        .accordion-button:not(.collapsed) {
            background-color: rgba(255, 102, 0, 0.1) !important;
            color: #ff6600 !important;
            box-shadow: none !important;
        }

        .accordion-button:focus {
            box-shadow: none !important;
            border-color: #ff6600 !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1 class="mt-4">Bienvenido a CompraTecno</h1>
        <p>Explorá nuestros productos destacados y armá tu PC ideal.</p>
    </div>
    <div class="row">
        <!-- FILTROS -->
        <div class="col-md-3">
            <div class="accordion mb-3" id="accordionFiltros">

                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingFiltros">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFiltros"><h5>Filtros</h5></button>
                    </h2>
                    <div id="collapseFiltros"
                        class="accordion-collapse collapse"
                        data-bs-parent="#accordionFiltros">

                        <div class="accordion-body">
                            <h5>Categoría</h5>
                            <asp:RadioButtonList ID="rbCategoria" runat="server" CssClass="form-check"></asp:RadioButtonList>
                            <hr />
                            <h5>Marca</h5>
                            <asp:RadioButtonList ID="rbMarca" runat="server" CssClass="form-check"></asp:RadioButtonList>
                            <hr />
                            <h5>Precio</h5>
                            <asp:TextBox ID="txtPrecioMin" runat="server" CssClass="form-control mb-2" placeholder="Mínimo" TextMode="Number"  ></asp:TextBox>
                            <asp:TextBox ID="txtPrecioMax" runat="server" CssClass="form-control mb-2" placeholder="Máximo" TextMode="Number" ></asp:TextBox>
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-favorito w-100 mt-2" OnClick="btnFiltrar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- PRODUCTOS -->
        <div class="col-md-9">
            <!-- ORDENAR -->
            <div class="d-flex justify-content-end align-items-center mb-3">

                <div class="dropdown">
                    <button class="btn btn-outline-secondary dropdown-toggle"
                        type="button"
                        data-bs-toggle="dropdown">
                        Ordenar por
                    </button>

                    <ul class="dropdown-menu dropdown-menu-end">
                        <li><a class="dropdown-item" href="Default.aspx?orden=precio_desc">Mayor precio</a></li>
                        <li><a class="dropdown-item" href="Default.aspx?orden=asc">Menor precio</a></li>
                    </ul>
                </div>

            </div>
            <div class="row">
                <asp:Repeater ID="repRepetidor" runat="server" OnItemDataBound="repRepetidor_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-12 col-sm-6 col-md-4 mb-4">
                            <div class="card">
                                <asp:LinkButton ID="lnkImagen" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="lnkImagen_Click" CssClass="card-img-link">
                                <img src="<%#Eval("Imagen") %>" class="card-img-top" alt="<%#Eval("Nombre") %>">
                                </asp:LinkButton>
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Precio") %> $</p>
                                    <asp:Button Text="Agregar a favoritos" runat="server" ID="agregarFavoritos" CssClass="btn btn-favorito" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="agregarFavoritos_Click" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
