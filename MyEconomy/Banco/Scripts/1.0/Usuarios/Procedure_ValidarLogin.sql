CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_ValidarLogin`(in _usuario varchar(100), in _senha varchar(100))
BEGIN

select * from 
tbl_usuarios
where 
`Usuario` = _usuario and `Senha` = _senha;




END