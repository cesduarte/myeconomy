CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaContasBancarias`(
in _descricaocontasbancarias varchar(100), in _idusuario int,  in _isdelete bool)
BEGIN
if(_descricaocontasbancarias='' && _idusuario = 1) then
select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
(select sum(c.ValorOcorrencia)from tbl_extratobancario c where c.Idcontasbancarias = b.Idcontasbancarias) as Saldo
from
tbl_usuarios a,
tbl_contasbancarias b



where
b.idusuario = a.idusuario and  b.Isdelete = _isdelete and a.idusuario<>1;
elseif(_descricaocontasbancarias<>'' && _idusuario = 1) then

select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
(select sum(c.ValorOcorrencia)from tbl_extratobancario c where c.Idcontasbancarias = b.Idcontasbancarias) as Saldo
from
tbl_usuarios a,
tbl_contasbancarias b


where
b.idusuario = a.idusuario and  b.Isdelete = false and DescricaoContasBancarias  LIKE CONCAT('%', _descricaocontasbancarias, '%') and a.idusuario<>1;

elseif(_descricaocontasbancarias='' && _idusuario <> 1) then
select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
(select sum(c.ValorOcorrencia)from tbl_extratobancario c where c.Idcontasbancarias = b.Idcontasbancarias) as Saldo
from
tbl_usuarios a,
tbl_contasbancarias b


where
b.idusuario = a.idusuario and  b.Isdelete = _isdelete and  a.idusuario =_idusuario ;
else
select
b.idcontasbancarias,
b.DescricaoContasBancarias,
a.descricao as descricaousuario,
(select sum(c.ValorOcorrencia)from tbl_extratobancario c where c.Idcontasbancarias = b.Idcontasbancarias) as Saldo
from
tbl_usuarios a,
tbl_contasbancarias b


where
b.idusuario = a.idusuario and  b.Isdelete = _isdelete and  a.idusuario =_idusuario and DescricaoContasBancarias  LIKE CONCAT('%', _descricaocontasbancarias, '%');

end if;

END