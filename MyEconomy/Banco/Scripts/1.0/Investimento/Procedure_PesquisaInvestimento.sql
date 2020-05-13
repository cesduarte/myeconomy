CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaInvestimento`(
IN _descricaoinvestimento nvarchar(200), 
IN _idcontasbancarias INT,
IN _isdelete bool)
BEGIN
IF(_descricaoinvestimento='' && _idcontasbancarias = 1)then
select a.IdInvestimento, a.Descricaoinvestimento, a.SaldoInvestimento, b.DescricaoContasBancarias
from
tbl_investimento a, tbl_contasbancarias b
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Isdelete = _isdelete order by a.Descricaoinvestimento;
elseif(_descricaoinvestimento<>''&& _idcontasbancarias = 1)then

select a.IdInvestimento, a.Descricaoinvestimento, a.SaldoInvestimento, b.DescricaoContasBancarias
from
tbl_investimento a, tbl_contasbancarias b
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Isdelete = _isdelete and a.Descricaoinvestimento LIKE CONCAT('%',_descricaoinvestimento, '%')  order by a.Descricaoinvestimento;


elseif(_descricaoinvestimento<>''&& _idcontasbancarias <> 1)then

select a.IdInvestimento, a.Descricaoinvestimento, a.SaldoInvestimento, b.DescricaoContasBancarias
from
tbl_investimento a, tbl_contasbancarias b
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Isdelete = _isdelete and a.Descricaoinvestimento LIKE CONCAT('%',_descricaoinvestimento, '%') and a.Idcontasbancarias = _idcontasbancarias order by a.Descricaoinvestimento;

elseif(_descricaoinvestimento =''&& _idcontasbancarias <> 1)then
select a.IdInvestimento, a.Descricaoinvestimento, a.SaldoInvestimento, b.DescricaoContasBancarias
from
tbl_investimento a, tbl_contasbancarias b
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Isdelete = _isdelete and a.Idcontasbancarias = _idcontasbancarias order by a.Descricaoinvestimento;

end if;
END