CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_InserirUsuarios`(
INOUT _Idusuarios INT,
IN _descricao nvarchar(200), In _usuario nvarchar(200),
IN _senha nvarchar(200),
IN _email nvarchar(200),
IN _isdelete bool,
IN _trocarSenha bool)
BEGIN
insert into tbl_usuarios(Descricao,Usuario, Senha,Email,Isdelete, TrocarSenha) values(_descricao,_usuario, _senha, _email, _isdelete, _trocarSenha);
set _Idusuarios  = (SELECT @@IDENTITY);
END