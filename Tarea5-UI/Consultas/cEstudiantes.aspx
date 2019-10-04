<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cEstudiantes.aspx.cs" Inherits="Tarea5_UI.Consultas.cEstudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="panel-body">
         <div class="form-group row">
                <div class="col-md-2">
                   <asp:Label ID="Desde" runat="server" Text="Desde">
                    <asp:TextBox type="date" runat="server" ID="DesdeFecha" Class="form-control input-sm"></asp:TextBox></asp:Label>
                    <asp:Label ID="Hasta" runat="server" Text="Hasta">
                    <asp:TextBox type="date" runat="server" ID="HastaFecha" Class="form-control input-sm"></asp:TextBox></asp:Label>
                </div>
         </div>
        <div class="form-group row">
            <div class="col-md-2">
                <asp:Label ID="LabelFiltro" runat="server" Text="FILTRO"></asp:Label>
                    <asp:DropDownList ID="FiltroDropDown" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>Id</asp:ListItem>
                        <asp:ListItem>Estudiante</asp:ListItem>
                        <asp:ListItem>Puntos Perdidos</asp:ListItem>
                        <asp:ListItem>Todo</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <label for="CheckBox" class="col-sm-1 col-form-label">Fecha?</label>
                <div class="col-xs-1">
                    <asp:CheckBox runat="server" CssClass="form-control" ID="CheckBoxFecha" />
                </div>
        </div>
                <div class="form-group row">
                <div class="col-md-6">
                    <asp:Label ID="LabelCriterio" runat="server" Text="CRITERIO"></asp:Label>
                    <asp:TextBox ID="CriterioTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-md-4">
                    <asp:Button ID="BuscarButton" runat="server" Class="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click"/>
                </div>
            </div>
          <asp:GridView ID="Grid" runat="server" class="table table-condensed table-responsive" AutoGenerateColumns="true" ShowHeaderWhenEmpty="True" DataKeyNames="EstudianteId" CellPadding="4" ForeColor="Black" GridLines="None">
                    <EmptyDataTemplate><div style="text-align:center">No hay datos.</div></EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
    </div>
</asp:Content>
