CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaContasBancarias`(
in _descricaocontasbancarias varchar(100), in _isdelete bool)
BEGIN
if(_descricaocontasbancarias ='') then
select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
b. Saldo
from

tbl_usuarios a,
tbl_contasbancarias b
where
b.idusuario = a.idusuario and  b.Isdelete = _isdelete;




else
select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
b. Saldo
from

tbl_usuarios a,
tbl_contasbancarias b
where
b.idusuario = a.idusuario and  DescricaoContasBancarias = _descricaocontasbancarias and b.Isdelete = _isdelete;

end if;
END