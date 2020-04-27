CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaUsuarios`(in _descricao varchar(100), in _isdelete bool)
BEGIN
if(_descricao ='') then
select * from tbl_usuarios where Isdelete = _isdelete;
else
select * from tbl_usuarios where Descricao = _descricao and Isdelete = _isdelete;
end if;
END