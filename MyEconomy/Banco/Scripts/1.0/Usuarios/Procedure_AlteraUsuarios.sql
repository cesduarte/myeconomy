CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarUsuarios`(IN _idusuarios int, IN _descricao nvarchar(200), In _usuario nvarchar(200),
IN _senha nvarchar(200),
IN _email nvarchar(200),
IN _isdelete bool,
IN _trocarSenha bool)
BEGIN
UPDATE `myeconomy`.`tbl_usuarios`
SET
`Descricao` =_descricao,
`Usuario` = _usuario,
`Senha` = _senha,
`Email` = _email,
`Isdelete` = _isdelete,
`TrocarSenha` = _trocarSenha
WHERE `Idusuario` = _idusuarios;
END