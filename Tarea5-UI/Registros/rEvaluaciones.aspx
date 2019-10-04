﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rEvaluaciones.aspx.cs" Inherits="Tarea5_UI.Registros.rEvaluaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
             <%--ID & Fecha--%>
                <div class="form-group row">
                    <label for="ID" class="col-sm-1 col-form-label">ID</label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:TextBox type="number" ID="IDTextBox" runat="server" min=0 class="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-3 col-sm-2 col-xs-4">
                         <asp:LinkButton ID="BuscarButton" CssClass="btn btn-dark btn-block btn-md" CausesValidation="false" runat="server" Text="Buscar"></asp:LinkButton>
                    </div>    
                    <label for="Fecha" class="col-md-1 col-form-label">Fecha</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="FechaTextBox" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFecha" runat="server" MaxLength="200" ControlToValidate="FechaTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="form-group row">
                    <label for="Estudiante" class="col-md-1 col-form-label">Estudiante</label>
                      <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="EstudianteDropDown" CssClass="form-control"></asp:DropDownList>
                      </div>
                </div>
               <div class="form-group row">
                    <label for="Categoria" class="col-sm-1 col-form-label">Categoria</label>
                      <div class="col-md-3">
                        <asp:DropDownList runat="server" ID="CategoriaDropdown" CssClass="form-control"></asp:DropDownList>
                      </div>
                      <label for="Valor" class="col-xs-1 col-form-label">Valor</label>
                      <div class="col-md-1">
                        <asp:TextBox ID="ValorTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVValor" runat="server" MaxLength="200" ControlToValidate="ValorTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>                      
                      </div>
                    <label for="Logrado" class="col-xs-1 col-form-label">Logrado</label>
                      <div class="col-md-1">
                        <asp:TextBox ID="LogradoTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFLogrado" runat="server" MaxLength="200" ControlToValidate="LogradoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>                                  
                </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                         <asp:LinkButton ID="AddButton" CssClass="btn btn-outline-success btn-block btn-md" CausesValidation="false" runat="server" Text="+"></asp:LinkButton>
                    </div>    
        </div>

            <asp:GridView ID="Grid" runat="server" class="table table-condensed table-responsive" AutoGenerateColumns="true" ShowHeaderWhenEmpty="True" DataKeyNames="Id" CellPadding="4" ForeColor="Black" GridLines="None">
                    <EmptyDataTemplate><div style="text-align:center">No hay datos.</div></EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
             <div class ="form-group row">
                    <label for="TotalPerdido" class="col-sm-1 col-form-label">Total Perdido</label>
                    <div class="col-sm-2">
                        <asp:TextBox runat="server" ID="TotalPerdidoTextBox" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                    </div>
             </div>
    </div>
        <br />
           <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" CausesValidation="false" style="color:#fff" runat="server" ID="NuevoButton" />
                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuardarButton"/>
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" CausesValidation="false" runat="server" ID="EliminarButton"/>

                </div>
            </div>

        </div>
     
  </div>
</asp:Content>