CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaUsuarios`(in _descricao varchar(100), in _usuario varchar(200), in _isdelete bool)
BEGIN
if(_descricao ='' && _usuario = '') then
select * from tbl_usuarios where Isdelete = _isdelete and Idusuario<>1 order by Descricao;
elseif(_descricao<>'' && _usuario='')then
select * from tbl_usuarios where Descricao LIKE CONCAT('%', _descricao, '%') and Isdelete = _isdelete and Idusuario<>1 order by Descricao;
elseif(_descricao<>'' && _usuario<>'')then
select * from tbl_usuarios where Usuario = _usuario  and Descricao LIKE CONCAT('%', _descricao, '%') and Isdelete = _isdelete and Idusuario<>1 order by Descricao;
else
select * from tbl_usuarios where Usuario = _usuario and Isdelete = _isdelete and Idusuario<>1 order by Descricao;
end if;
END