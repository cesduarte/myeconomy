CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaInvestimentoManual`(
IN _descricaoinvestimento nvarchar(200), 
IN _idcontasbancarias INT,
IN _idinvestimento INT, IN _datainicial datetime, in _datafinal datetime

)
BEGIN
IF(_descricaoinvestimento='' && _idcontasbancarias = 1 && _idinvestimento = 1)then
select a.DescricaoContasBancarias, b.Descricaoinvestimento, c.Descricaoinvestimento as investimentomanual, c.ValorInvestimento, c.DataInvestimento, c.IdInvestimentoManual

from tbl_contasbancarias  a, tbl_investimento b, tbl_investimentomanual c


where c.Idcontasbancarias = a.Idcontasbancarias and c.IdInvestimento = b.IdInvestimento
and c.DataInvestimento BETWEEN 
_datainicial and _datafinal
order by c.DataInvestimento
;



elseif(_descricaoinvestimento<>'' && _idcontasbancarias = 1 && _idinvestimento = 1)then
select a.DescricaoContasBancarias, b.Descricaoinvestimento, c.Descricaoinvestimento as investimentomanual, c.ValorInvestimento, c.DataInvestimento, c.IdInvestimentoManual

from tbl_contasbancarias  a, tbl_investimento b, tbl_investimentomanual c


where c.Idcontasbancarias = a.Idcontasbancarias and c.IdInvestimento = b.IdInvestimento and c.Descricaoinvestimento LIKE CONCAT('%',_descricaoinvestimento, '%')
and c.DataInvestimento BETWEEN 
_datainicial and _datafinal
order by c.DataInvestimento
;

elseif(_descricaoinvestimento<>'' && _idcontasbancarias <> 1 && _idinvestimento = 1)then
select a.DescricaoContasBancarias, b.Descricaoinvestimento, c.Descricaoinvestimento as investimentomanual, c.ValorInvestimento, c.DataInvestimento, c.IdInvestimentoManual

from tbl_contasbancarias  a, tbl_investimento b, tbl_investimentomanual c


where c.Idcontasbancarias = a.Idcontasbancarias and c.IdInvestimento = b.IdInvestimento and c.Descricaoinvestimento LIKE CONCAT('%',_descricaoinvestimento, '%') and c.Idcontasbancarias = _idcontasbancarias
and c.DataInvestimento BETWEEN 
_datainicial and _datafinal
order by c.DataInvestimento
;


elseif(_descricaoinvestimento<>'' && _idcontasbancarias <> 1 && _idinvestimento <> 1)then
select a.DescricaoContasBancarias, b.Descricaoinvestimento, c.Descricaoinvestimento as investimentomanual, c.ValorInvestimento, c.DataInvestimento, c.IdInvestimentoManual

from tbl_contasbancarias  a, tbl_investimento b, tbl_investimentomanual c


where c.Idcontasbancarias = a.Idcontasbancarias and c.IdInvestimento = b.IdInvestimento and c.Descricaoinvestimento LIKE CONCAT('%',_descricaoinvestimento, '%') and c.Idcontasbancarias = _idcontasbancarias and c.IdInvestimento = _idinvestimento
and c.DataInvestimento BETWEEN 
_datainicial and _datafinal
order by c.DataInvestimento
;

elseif(_descricaoinvestimento<>'' && _idcontasbancarias = 1 && _idinvestimento <> 1)then
select a.DescricaoContasBancarias, b.Descricaoinvestimento, c.Descricaoinvestimento as investimentomanual, c.ValorInvestimento, c.DataInvestimento, c.IdInvestimentoManual

from tbl_contasbancarias  a, tbl_investimento b, tbl_investimentomanual c


where c.Idcontasbancarias = a.Idcontasbancarias and c.IdInvestimento = b.IdInvestimento and c.Descricaoinvestimento LIKE CONCAT('%',_descricaoinvestimento, '%')  and c.IdInvestimento = _idinvestimento
and c.DataInvestimento BETWEEN 
_datainicial and _datafinal
order by c.DataInvestimento
;
elseif(_descricaoinvestimento='' && _idcontasbancarias <> 1 && _idinvestimento = 1)then
select a.DescricaoContasBancarias, b.Descricaoinvestimento, c.Descricaoinvestimento as investimentomanual, c.ValorInvestimento, c.DataInvestimento, c.IdInvestimentoManual

from tbl_contasbancarias  a, tbl_investimento b, tbl_investimentomanual c


where c.Idcontasbancarias = a.Idcontasbancarias and c.IdInvestimento = b.IdInvestimento and  c.Idcontasbancarias = _idcontasbancarias
and c.DataInvestimento BETWEEN 
_datainicial and _datafinal
order by c.DataInvestimento
;

elseif(_descricaoinvestimento='' && _idcontasbancarias <> 1 && _idinvestimento <> 1)then

select a.DescricaoContasBancarias, b.Descricaoinvestimento, c.Descricaoinvestimento as investimentomanual, c.ValorInvestimento, c.DataInvestimento, c.IdInvestimentoManual

from tbl_contasbancarias  a, tbl_investimento b, tbl_investimentomanual c


where c.Idcontasbancarias = a.Idcontasbancariasa and c.IdInvestimento = b.IdInvestimento and c.Idcontasbancarias = _idcontasbancarias and c.IdInvestimento = _idinvestimento
and c.DataInvestimento BETWEEN 
_datainicial and _datafinal
order by c.DataInvestimento
;
elseif(_descricaoinvestimento='' && _idcontasbancarias = 1 && _idinvestimento <> 1)then

select a.DescricaoContasBancarias, b.Descricaoinvestimento, c.Descricaoinvestimento as investimentomanual, c.ValorInvestimento, c.DataInvestimento, c.IdInvestimentoManual

from tbl_contasbancarias  a, tbl_investimento b, tbl_investimentomanual c


where c.Idcontasbancarias = a.Idcontasbancariasa and c.IdInvestimento = b.IdInvestimento  and c.IdInvestimento = _idinvestimento
and c.DataInvestimento BETWEEN 
_datainicial and _datafinal
order by c.DataInvestimento
;

end if;
END