CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaContaAPagar`(
IN _descricaoconta nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _datainicial datetime, in _datafinal datetime)
BEGIN

select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, b.DescricaoContasBancarias, c.DescricaoClassificacao, d.DataVencimentoContaAPagar, a.ValorDespesa
from
tbl_despesafixa a, tbl_contasbancarias b, tbl_classificacao c, tbl_contasapagar d
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = false and d.Iddespesas = a.IdDespesaFixa and d.DataVencimentoContaAPagar BETWEEN 
_datainicial and _datafinal
order by d.DataVencimentoContaAPagar;



END