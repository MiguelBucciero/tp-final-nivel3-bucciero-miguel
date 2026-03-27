<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LIstadoArticulos.aspx.cs" Inherits="TPFinalNivel3BuccieroMiguel.LIstadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-agregar {
            margin-top: auto;
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

        .table thead {
            background-color: #ff6600;
            color: #fff;
        }

        .table tbody tr:hover {
            background-color: rgba(255, 102, 0, 0.05);
        }

        .search-input:focus {
            border-color: #ff6600 !important;
            box-shadow: 0 0 0 0.25rem rgba(255, 102, 0, 0.25) !important;
        }

        .page-title {
            font-weight: 700;
            color: #333;
            border-left: 4px solid #ff6600;
            padding-left: 0.75rem;
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
    <!-- ENCABEZADO -->
    <div class="mb-3">
        <h2 class="page-title mb-0">Listado de artículos</h2>
    </div>

    <!-- BUSCADOR -->
    <div class="position-relative mb-4">

        <!-- BUSCADOR CENTRADO -->
        <div class="d-flex justify-content-center">
            <div class="d-flex align-items-center gap-2">

                <asp:Label ID="lblTitulo" runat="server" Text="Buscar:" CssClass="fw-semibold mb-0" />

                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control search-input" Style="width: 500px;" placeholder="Nombre, marca..." AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged" />

            </div>
        </div>

        <!-- BOTÓN A LA DERECHA -->
        <div class="position-absolute top-50 end-0 translate-middle-y">
            <asp:Button ID="btnAgregar" runat="server" Text="+ Agregar artículo" CssClass="btn btn-agregar" OnClick="btnAgregar_Click" />
        </div>

    </div>
    <div class="card mb-4 border-0 shadow-sm">
        <div class="card-body">

            <!-- BOTÓN MOSTRAR FILTROS -->
            <asp:Button ID="btnMostrarFiltros" runat="server" Text="Filtros avanzados" CssClass="btn btn-agregar" OnClick="btnMostrarFiltros_Click" />

            <!-- PANEL FILTROS -->
            <asp:Panel ID="pnlFiltros" runat="server" Visible="false">

                <div class="row g-3 align-items-end">

                    <!-- MARCA -->
                    <div class="col-md-2">
                        <asp:Label Text="Marca" runat="server" CssClass="fw-semibold" />
                        <asp:DropDownList ID="ddlFiltroMarca" runat="server" CssClass="form-select" />
                    </div>

                    <!-- CATEGORIA -->
                    <div class="col-md-2">
                        <asp:Label Text="Categoría" runat="server" CssClass="fw-semibold" />
                        <asp:DropDownList ID="ddlFiltroCategoria" runat="server" CssClass="form-select" />
                    </div>

                    <!-- PRECIO -->
                    <div class="col-md-2">
                        <asp:Label Text="Precio mínimo" runat="server" />
                        <asp:TextBox ID="txtPrecioMin" runat="server" CssClass="form-control" placeholder="Mínimo" TextMode="Number" />
                    </div>

                    <div class="col-md-2">
                        <asp:Label Text="Precio máximo" runat="server" />
                        <asp:TextBox ID="txtPrecioMax" runat="server" CssClass="form-control" placeholder="Máximo" TextMode="Number" />
                    </div>

                    <!-- BOTÓN FILTRAR -->
                    <div class="col-md-2 d-grid">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Aplicar filtros" CssClass="btn btn-agregar" OnClick="btnFiltrar_Click" />
                    </div>
                </div>

            </asp:Panel>

        </div>
    </div>
    <!-- TABLA -->
    <div class="card border-0 shadow-sm">
        <div class="card-body p-0">
            <div class="table-responsive">
                <asp:GridView ID="gvListadoArticulos" runat="server" CssClass="table table-hover table-bordered mb-0" AutoGenerateColumns="false" GridLines="None" OnPageIndexChanging="gvListadoArticulos_PageIndexChanging" AllowPaging="true" PageSize="5" OnRowCommand="gvListadoArticulos_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="text-center fw-semibold" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="$ {0:N2}" ItemStyle-CssClass="text-end" HeaderStyle-CssClass="text-end" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoría" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                        <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <div class="d-flex justify-content-center gap-2">
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-agregar btn-sm" />
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-agregar btn-sm" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Panel ID="pnlConfirmar" runat="server" Visible="false" CssClass="alert alert-warning text-center mt-3">

                    <asp:Label ID="lblConfirmar" runat="server" Text="¿Seguro que querés eliminar este artículo?" CssClass="fw-bold d-block mb-2" />

                    <asp:HiddenField ID="hfIdEliminar" runat="server" />

                    <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Sí, eliminar"
                        CssClass="btn btn-agregar me-2"
                        OnClick="btnConfirmarEliminar_Click" />

                    <asp:Button ID="btnCancelarEliminar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar" OnClick="btnCancelarEliminar_Click" />

                </asp:Panel>
            </div>
        </div>
    </div>

    <!-- MENSAJE -->
    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="d-block mt-3 text-center fw-semibold" />
</asp:Content>
