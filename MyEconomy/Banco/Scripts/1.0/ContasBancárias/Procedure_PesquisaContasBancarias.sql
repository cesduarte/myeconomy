CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaContasBancarias`(in _descricaocontasbancarias varchar(100), in _isdelete bool)
BEGIN
if(_descricaocontasbancarias ='') then
select * from tbl_contasBancarias where Isdelete = _isdelete;
else
select * from tbl_contasbancarias where DescricaoContasBancarias = _descricaocontasbancarias and Isdelete = _isdelete;

end if;
END