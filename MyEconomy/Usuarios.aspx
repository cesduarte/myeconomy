<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="MyEconomy.Usuarios" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
   <div class="row page-titles mx-0">
        <div class="col p-md-0">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">Dashboard</a></li>
                <li class="breadcrumb-item active"><a href="javascript:void(0)">Usuários</a></li>
            </ol>
        </div>
   </div>
   
            <div class="container-fluid">
                <div class="row">
                    
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-body">
                               
                                <div id="accordion-three" class="accordion">
                                       
                                    <div class="card">
                                        <div class="card-header">
                                            <h5 class="mb-0" data-toggle="collapse" data-target="#collapseOne4" aria-expanded="true" aria-controls="collapseOne4"><i class="fa" aria-hidden="true"></i>Pesquisa avançada</h5>
                                        </div>
                                        <div id="collapseOne4" class="collapse" data-parent="#accordion-three">
                                            <div class="card-body">
                                                 <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
                                                 <ContentTemplate>
                                                <div class="form-row">
                                                    <div class="form-group col-md-12">
                                                        <asp:Label ID="Label1" runat="server" Text="Label">Usuario: </asp:Label>
                                                        <asp:TextBox ID="Txtdescricaopesquisa" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                    <div class="form-group col-md-5">
                                                        <div class="form-check form-check-inline">
                                                             <asp:CheckBox ID="chkinativoPesquisa" class="form-check-input" runat="server"/>
                                                               <asp:Label ID="Label2" runat="server" Text="Label">Inativo</asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="text-right">
                                                    <asp:Button ID="Button1" class="btn btn-outline-primary btn-sm"  runat="server" Text="Pesquisar" OnClick="Button1_Click" />
                                                </div>  
                                                 </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>
                                    </div>
                                       
                                    <div class="card">
                                        <div class="card-header">
                                             <div class="d-flex align-items-center">
                                          <ul class="mb-0 form-profile__icons">
                                            <li class="d-inline-block">
                                                <button class="btn btn-transparent p-0 mr-3"><i class="fa fa-user"></i></button>
                                            </li>
                                            <li class="d-inline-block">
                                                <button class="btn btn-transparent p-0 mr-3"><i class="fa fa-paper-plane"></i></button>
                                            </li>
                                            <li class="d-inline-block">
                                                <button class="btn btn-transparent p-0 mr-3"><i class="fa fa-camera"></i></button>
                                            </li>
                                            <li class="d-inline-block">
                                                <button class="btn btn-transparent p-0 mr-3"><i class="fa fa-smile"></i></button>
                                            </li>
                                        </ul>
                                        <button class="btn btn-primary px-3 ml-4">Novo Usuario</button>
                                            </div>
                                        </div>
                                        
                                    </div>
                                    <div class="card">
                                        <div class="table-responsive">
                                            <asp:UpdatePanel ID="upusuarios" runat="server">
                                            <ContentTemplate>
                                            <asp:GridView ID="GrdDados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                                                 EmptyDataText="Não Existem infornações">
                                                <Columns>
                                                    <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                                                    <asp:BoundField DataField="Email" HeaderText="Email" />

                                                     <asp:TemplateField>
                                                         <ItemTemplate>
                                                             <asp:Button ID="btnEditar" runat="server" class="btn mb-1  btn-primary btn-sm"
                                                                CommandName="Editar" Text="Editar"
                                                                CommandArgument='<%# DataBinder
                                                                .Eval(Container.DataItem, "Idusuario")%>' />
                                                         </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                       </asp:TemplateField>
                                                </Columns>
                                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5"  />
                                                        <PagerStyle HorizontalAlign="Right" Wrap="True"/>
                                            </asp:GridView>

                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>            
</asp:Content>

