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
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div class="d-flex align-items-center">
                                                <ul class="mb-0 form-profile__icons">

                                                    <li class="d-inline-block">
                                                        <button type="button" class="btn btn-transparent p-0 mr-3" title="Novo Usuário" data-toggle="modal" data-target="#CadastroModal"><i class="fa fa-plus"></i></button>

                                                    </li>
                                                    <li class="d-inline-block">
                                                        <button type="button" class="btn btn-transparent p-0 mr-3" title="Pesquisar Usuário" data-toggle="modal" data-target="#basicModal"><i class="fa fa-search"></i></button>
                                                    </li>

                                                    <li class="d-inline-block">
                                                        <button type="button" id="teste1" class="btn btn-transparent p-0 mr-3" title="Limpar Pesquisar" runat="server" onserverclick="Button3_Click"><i class="fa fa-eraser"></i></button>
                                                    </li>

                                                </ul>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                            <div class="card">
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="upusuarios" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GrdDados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                                                EmptyDataText="Não Existem infornações" OnRowCommand="GrdDados_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                                                    <asp:BoundField DataField="usuario" HeaderText="Usuario" />
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
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                                <PagerStyle HorizontalAlign="Right" Wrap="True" />
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
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="bootstrap-modal">
                        <div class="modal fade bd-example-modal-lg" id="basicModal" tabindex="-1" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Pesquisar Usuários</h5>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <button type="button" id="teste" class="close" runat="server" onserverclick="Button1_Click" usesubmitbehavior="false" data-dismiss="modal">
                                                    <span>&times;</span>
                                                </button>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>


                                    </div>
                                    <div class="modal-body">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <div class="form-row">
                                                    <div class="form-group col-md-12">
                                                        <asp:Label ID="Label8" runat="server" Text="Label">Descrição: </asp:Label>
                                                        <asp:TextBox ID="Txtdescricaopesquisa" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                    <div class="form-group col-md-12">
                                                        <asp:Label ID="Label3" runat="server" Text="Label">Usuario: </asp:Label>
                                                        <asp:TextBox ID="Txtusuariopesquisa" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="form-row">
                                                    <div class="form-group col-md-5">
                                                        <div class="form-check form-check-inline">
                                                            <asp:CheckBox ID="chkinativoPesquisa" class="form-check-input" runat="server" />
                                                            <asp:Label ID="Label4" runat="server" Text="Label">Inativo</asp:Label>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Pesquisar" OnClick="Button1_Click" UseSubmitBehavior="false" data-dismiss="modal" />
                                                <asp:Button ID="Button3" class="btn btn-outline-primary" runat="server" Text="Limpar" OnClick="Button3_Click" />
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
    </div>


    <div class="container-fluid">
        <!-- row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="card">


                    <div class="bootstrap-modal">
                        <!-- Button trigger modal -->
                        <!-- Modal -->

                        <div class="modal fade bd-example-modal-lg" id="CadastroModal" tabindex="-1" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">


                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Cadastro de Usuários</h5>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            
                                         <button type="button" id="Button4" class="close" runat="server" onserverclick="Button5_Click"   UseSubmitBehavior="false" data-dismiss="modal"><span>&times;</span>
                                                        
                                          </button>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="modal-body">
                                         <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                           <ContentTemplate>
                                                <div class="form-row">
                                                    <div class="form-group col-md-12">
                                                        <asp:TextBox ID="Txtid"  runat="server"  class="form-control form-control-sm" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                     <div class="form-group col-md-12">
                                                         <asp:Label ID="Label1" runat="server" Text="Label">Descrição: </asp:Label>
                                                          <asp:TextBox ID="Txtdescricao"  runat="server"  class="form-control form-control-sm"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="group" runat="server" class="text-danger" ErrorMessage="* Campo obrigatório" ControlToValidate="Txtdescricao"></asp:RequiredFieldValidator>

                                                     </div>
                                                </div>
                                                <div class="form-row">
                                                     <div class="form-group col-md-6">
                                                          <asp:Label ID="Label2" runat="server" Text="Label">Usuario: </asp:Label>
                                                          <asp:TextBox ID="Txtusuario"  runat="server"  class="form-control form-control-sm"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" class="text-danger" ValidationGroup="group" ErrorMessage="* Campo obrigatório" ControlToValidate="Txtusuario"></asp:RequiredFieldValidator>
                                                     </div>
                                                     <div class="form-group col-md-6">
                                                         <asp:Label ID="Label6" runat="server" Text="Label">Senha: </asp:Label>
                                                         <asp:TextBox ID="Txtsenha"  runat="server"  class="form-control form-control-sm" TextMode="Password"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="group" runat="server" class="text-danger" ErrorMessage="* Campo obrigatório" ControlToValidate="Txtsenha"></asp:RequiredFieldValidator>
                                                     </div>
                                                </div>
                                               <div class="form-row">
                                                    <div class="form-group col-md-12">
                                                        <asp:Label ID="Label7" runat="server" Text="Label">E-mail: </asp:Label>
                                                        <asp:TextBox ID="Txtemail"  runat="server"  class="form-control form-control-sm" TextMode="Email"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                                                                            class="text-danger" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                                            Display = "Dynamic" ErrorMessage = "E-mail Invalido" ValidationGroup="group"/>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemail"
                                                       class="text-danger" Display = "Dynamic" ValidationGroup="group"  ErrorMessage = "* Campo obrigatório" />
                                                    </div>
                                               </div>
                                               <div class="form-row">
                                                    <div class="form-group col-md-5">
                                                         <div class="form-check form-check-inline">
                                                              <asp:CheckBox ID="Chkinativo" class="form-check-input" runat="server"/>
                                                               <asp:Label ID="Label5" runat="server" Text="Label">Inativo</asp:Label>
                                                         </div>
                                                    </div>
                                               </div>

                                           </ContentTemplate>
                                         </asp:UpdatePanel>
                                    </div>
                                     <div class="modal-footer">
                                         
                                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                         <asp:Button ID="Button2" class="btn btn-outline-primary" runat="server" Text="Salvar" UseSubmitBehavior="false"  OnClick="Button2_Click" ValidationGroup="group" />
                                                        <asp:Button ID="Button5" class="btn btn-outline-primary" runat="server" Text="Limpar"  OnClick="Button5_Click" />
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
    </div>


</asp:Content>

