<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="MyEconomy.Usuarios" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row page-titles mx-0">
        <div class="col p-md-0">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">Dashboard</a></li>
                <li class="breadcrumb-item active"><a href="javascript:void(0)">Usuários</a></li>
            </ol>
        </div>
    </div>
    <!-- row -->

    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        
                        

                       <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
                        <ContentTemplate>
                 <div class="form-row">
                                            <div class="form-group col-md-12">
                                                <label>Descrição</label>
                                               
                                                <asp:TextBox ID="TxtdescricaoPesquisa" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            
                       </div>
                                  <div class="form-row">      
                                        <div class="form-group col-md-6"">
                                            <div class="form-check">
                                                
                                                <asp:CheckBox ID="chkinativoPesquisa" class="form-check-input" runat="server" />
                                                <label class="form-check-label">Inativo</label>
                                            </div>
                        
                                            </div>
                   </div>

                                          
              
  <div class ="text-right">
       <asp:Button ID="Button3" class="btn mb-1  btn-outline-primary" runat="server" Text="Pesquisar" OnClick="Button1_Click1" />
       <asp:Button ID="Button2" class="btn mb-1  btn-outline-primary" runat="server" Text="Novo" data-toggle="modal" data-target="#loginModal" />
 </div>
               
                 <div class="table-responsive">
                        <asp:GridView ID="GrdDados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                            RowCommand="grdDados_RowCommand" AllowPaging="True" OnPageIndexChanging="GrdDados_PageIndexChanging" PageSize="5" EmptyDataText="Não Existem infornações">
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
                     </div>

                  </ContentTemplate> 
</asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
     
         
    <div class="container">
       
        <div class="modal fade" tabindex="-1" id="loginModal" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <label class="text-left">Cadastro de Usuários</label>
                        <button type="button" class="close text-right" data-dismiss="modal">&times;</button>
                       
                    </div>
                    <div class="modal-body">
                       
                      
                        <form>
                             <div class="form-group">
                                <label for="inputUsuario">ID</label>
                                   <asp:TextBox ID="Txtid" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="inputUsuario">Usuário</label>
                                  <asp:TextBox ID="Txtdescricao" class="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                            
                            <div class="form-group">
                                <label for="inputSenha">Senha</label>
                                  <asp:TextBox ID="Txtsenha" class="form-control" runat="server"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                <label for="inputUsuario">E-mail</label>
                                   <asp:TextBox ID="txtemail" class="form-control" runat="server"></asp:TextBox>
                            </div>
                           <div class="checkbox">
                               

                               <asp:CheckBox ID="chkinativo"  runat="server" />
                                                <label class="form-check-label">Inativo</label>
                            </div>
                        </form>
                           

                    </div>
                    <div class="modal-footer">
                   <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
                        <ContentTemplate>
             <asp:Button ID="btnsalvar"  class="btn mb-1  btn-primary"  runat="server" Text="Salvar" OnClick="btnsalvar_Click"/>
                       
        

                        </ContentTemplate>
                          </asp:UpdatePanel>
                     
                      
                    </div>
                 
                </div>
            </div>
        </div>
               
    </div>
                  
</asp:Content>

