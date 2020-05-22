CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaContasBancarias`(
in _descricaocontasbancarias varchar(100), in _idusuario int,  in _isdelete bool)
BEGIN
if(_descricaocontasbancarias='' && _idusuario = 1) then
select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
sum(c.ValorOcorrencia)Saldo
from
tbl_usuarios a,
tbl_contasbancarias b,
tbl_extratobancario c


where
b.idusuario = a.idusuario and  b.Isdelete = _isdelete and a.idusuario<>1 and c.Idcontasbancarias and b.idcontasbancarias;
elseif(_descricaocontasbancarias<>'' && _idusuario = 1) then

select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
sum(c.ValorOcorrencia)Saldo
from
tbl_usuarios a,
tbl_contasbancarias b


where
b.idusuario = a.idusuario and  b.Isdelete = false and DescricaoContasBancarias  LIKE CONCAT('%', _descricaocontasbancarias, '%') and a.idusuario<>1 and c.Idcontasbancarias and b.idcontasbancarias;

elseif(_descricaocontasbancarias='' && _idusuario <> 1) then
select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
sum(c.ValorOcorrencia)Saldo
from
tbl_usuarios a,
tbl_contasbancarias b


where
b.idusuario = a.idusuario and  b.Isdelete = _isdelete and  a.idusuario =_idusuario and c.Idcontasbancarias and b.idcontasbancarias ;
else
select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
sum(c.ValorOcorrencia)Saldo
from
tbl_usuarios a,
tbl_contasbancarias b


where
b.idusuario = a.idusuario and  b.Isdelete = _isdelete and  a.idusuario =_idusuario and DescricaoContasBancarias  LIKE CONCAT('%', _descricaocontasbancarias, '%') and c.Idcontasbancarias and b.idcontasbancarias;

end if;

END