﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tarefas.aspx.cs" Inherits="MyEconomy.Tarefas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
    

    <div class="container-fluid">

        <div class="row">

            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col p-md-0">
                                <ol class="breadcrumb">
                                    
                                    <li class="breadcrumb-item active"><a href="javascript:void(0)"> Gerenciamento / Tarefas</a></li>
                                </ol>

                            </div> 

                        </div>
                        <div id="accordion-three" class="accordion">



                            <div class="card">
                                <div class="card-header">

                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div class="d-flex align-items-center">

                                                <ul class="mb-0 form-profile__icons">

                                                    <li class="d-inline-block">
                                                        <button type="button" class="btn btn-outline-light" title="Nova tarefa" data-toggle="modal" data-target="#CadastroModal"><i class="fa fa-plus"></i></button>

                                                    </li>
                                                    <li class="d-inline-block">
                                                        <button type="button" class="btn btn-outline-light" title="Pesquisar tarefas" data-toggle="modal" data-target="#basicModal"><i class="fa fa-search"></i></button>
                                                    </li>

                                                    <li class="d-inline-block">
                                                        <button type="button" id="teste1" class="btn btn-outline-light" title="Limpar Pesquisar" runat="server" onserverclick="Button3_Click"><i class="fa fa-eraser"></i></button>
                                                    </li>

                                                      <li class="d-inline-block">
                                                        <button type="button" id="Button6" class="btn btn-outline-light" title="Atualizar" runat="server" onserverclick="Button1_Click"><i class="fa fa-refresh"></i></button>
                                                    </li>
                                                   

                                                </ul>

                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                            <div class="card">
                                <div class="table-responsive">
                                    <asp:UpdatePanel ID="upcontasbancarias" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GrdDados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                                                EmptyDataText="Não Existem infornações" OnRowCommand="GrdDados_RowCommand" PageSize="5" AllowPaging="True" OnPageIndexChanging="GrdDados_PageIndexChanging" OnSelectedIndexChanging="GrdDados_SelectedIndexChanging">
                                                <Columns>

                                                    <asp:BoundField DataField="DescricaoTarefa" HeaderText="Descrição" />
                                                    <asp:BoundField DataField="descricaousuario" HeaderText="Descrição Usuário" />                                                   
                                                    <asp:BoundField DataField="DataTarefa" HeaderText="Data tarefa" DataFormatString="{0:dd/MM/yyyy}"  />
                                                     <asp:BoundField DataField="StatusTarefa" HeaderText="Status Tarefa"  />

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEditar" runat="server" class="btn mb-1  btn-primary btn-sm"
                                                                CommandName="Editar" Text="Editar"
                                                                CommandArgument='<%# DataBinder
                                                                .Eval(Container.DataItem, "Idtarefa")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                               <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                                <PagerStyle HorizontalAlign="Right" Wrap="True" CssClass="page-item" />
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
                        <div class="modal fade bd-example-modal-lg" id="basicModal"   data-keyboard="false" data-backdrop="static" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Pesquisar tarefas</h5>
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
                                                        <asp:Label ID="Label4" runat="server" Text="Label">Status Tarefa: </asp:Label>

                                                        <asp:DropDownList ID="Dropstatustarefapesquisa" runat="server" CssClass="form-control form-control" ValidationGroup="group">
                                                        </asp:DropDownList>


                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                    <div class="form-group col-md-6">
                                                        <asp:Label ID="Label8" runat="server" Text="Label">Descrição: </asp:Label>
                                                        <asp:TextBox ID="Txtdescricaopesquisa" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                    </div>
                                                     <div class="form-group col-md-6">
                                                         <asp:Label ID="Label6" runat="server" Text="Label">Descrição usuário: </asp:Label>
                                                        <asp:DropDownList ID="Dropusuariopesquisa" runat="server" CssClass="form-control form-control-" ValidationGroup="group">
                                                          
                                                         </asp:DropDownList>
                                                        
                                                     </div>
                                                </div>
                                               
                                                <div class="form-row">
                                                     <div class="form-group col-md-6">
                                                         <asp:Label ID="Label10" runat="server" Text="Label" >Data inicial: </asp:Label>
                                                         <asp:TextBox ID="Txtdatainicialpesquisa"  runat="server" CssClass="form-control" TextMode="Date" ></asp:TextBox> 
                                                        
                                                     </div>
                                                   
                                                    
                                                     <div class="form-group col-md-6">
                                                         <asp:Label ID="Label15" runat="server" Text="Label" >Data final: </asp:Label>
                                                         <asp:TextBox ID="Txtdatafinalpesquisa"  runat="server" CssClass="form-control" TextMode="Date" ></asp:TextBox> 
                                                        
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

                     <div class="modal fade bd-example-modal-lg" id="CadastroModal"  data-keyboard="false" data-backdrop="static" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered modal-lg" role="document">


                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">Cadastro de tarefas</h5>
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
                                                         <asp:Label ID="Label3" runat="server" Text="Label">Usuário: </asp:Label>
                                                        <asp:DropDownList ID="Dropusuario" runat="server" CssClass="form-control form-control-" ValidationGroup="group">
                                                          
                                                         </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="group" runat="server" class="text-danger"  InitialValue="1" ErrorMessage="* Campo obrigatório" ControlToValidate="Dropusuario"></asp:RequiredFieldValidator>

                                                        
                                                     </div> 
                                                        <div class="form-group col-md-6">
                                                        <asp:Label ID="Label13" runat="server" Text="Label">Data: </asp:Label>
                                                        <asp:TextBox ID="Txtdata" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="group" runat="server" Display="Dynamic" class="text-danger" ErrorMessage="* Campo obrigatório" ControlToValidate="Txtdata"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="RangeValidator2" Display="Dynamic" Type="Date" class="text-danger"
                                                            MaximumValue="30/12/2050" MinimumValue="1/01/1900" EnableClientScript="true"
                                                            ControlToValidate="Txtdata" runat="server" SetFocusOnError="true" ValidationGroup="group"
                                                            ErrorMessage="* O formato do campo 'Data de Vencimento' está incorreto, selecione a data ao lado"></asp:RangeValidator>
                                                    </div>
                                                    
                                                   
                                                   
                                                </div>
                                                <div class="form-row">
                                                    <div class="form-group col-md-12">
                                                    <asp:Label ID="Label2" runat="server" Text="Label">Obs: </asp:Label>
                                                    <asp:TextBox ID="txtobs"  runat="server"  class="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>

                                                </div>   </div>
                                             
                                             
                                               

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
    
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="bootstrap-modal">
                        <div class="modal fade bd-example-modal-sm" id="CadSucess" tabindex="-1" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-top modal-sm" role="document">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                               <div class="alert alert-success">

                                <strong>Sucesso!</strong> <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>  
                                </div>
                                            <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                                            </ContentTemplate></asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
                

</asp:Content>
