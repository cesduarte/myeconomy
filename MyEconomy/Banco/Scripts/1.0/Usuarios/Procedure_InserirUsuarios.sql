CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_InserirUsuarios`(IN Descricao nvarchar(200), In Usuario nvarchar(200),
IN Senha nvarchar(200),
IN Email nvarchar(200),
IN Isdelete bool,
IN TrocarSenha bool)
BEGIN
insert into tbl_usuarios(Descricao,Senha,Email,Isdelete, TrocarSenha) values(Descricao, Senha, Email, Isdelete, TrocarSenha);
END