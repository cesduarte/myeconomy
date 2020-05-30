CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_RelatorioTotalizadorClassificacao`(
IN _idclassificacao INT, 
IN _datainicial datetime,
IN _datafinal datetime
)
BEGIN


if(_idclassificacao = 1) then
select 
a.DescricaoClassificacao as descricao,
(select COALESCE(sum(ValorOcorrencia),0) from tbl_extratobancario b where StatusOcorrencia = 'Receitas' and b.Idclassificacao= a.Idclassificacao and DataOcorrencia BETWEEN 
_datainicial and _datafinal) as receitas,
(select COALESCE(sum(ValorOcorrencia),0) from tbl_extratobancario b where StatusOcorrencia = 'Despesas Variadas' and b.Idclassificacao= a.Idclassificacao and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as Despesasvariadas,
(select COALESCE(sum(ValorOcorrencia),0) from tbl_extratobancario b where StatusOcorrencia = 'Despesa fixa paga' and b.Idclassificacao= a.Idclassificacao and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as DespesaFixaPaga,
(select COALESCE(sum(ValorDespesa),0) from tbl_despesafixa c, tbl_contasapagar d where StatusContasAPagar = 'Despesa fixa a pagar' and d.Iddespesas = c.IdDespesaFixa and c.Idclassificacao = a.Idclassificacao and d.DataVencimentoContaAPagar BETWEEN 
_datainicial and _datafinal ) as DespesaFixaapagar,
(select COALESCE(sum(ValorOcorrencia),0) from tbl_extratobancario b where StatusOcorrencia = 'Investimento' and b.Idclassificacao= a.Idclassificacao and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as Investimento


from

tbl_classificacao a
where Idclassificacao<>1 order by a.DescricaoClassificacao;

else
select 
a.DescricaoClassificacao as descricao,
(select COALESCE(sum(ValorOcorrencia),0) from tbl_extratobancario b where StatusOcorrencia = 'Receitas' and b.Idclassificacao= a.Idclassificacao and DataOcorrencia BETWEEN 
_datainicial and _datafinal) as receitas,
(select COALESCE(sum(ValorOcorrencia),0) from tbl_extratobancario b where StatusOcorrencia = 'Despesas Variadas' and b.Idclassificacao= a.Idclassificacao and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as Despesasvariadas,
(select COALESCE(sum(ValorOcorrencia),0) from tbl_extratobancario b where StatusOcorrencia = 'Despesa fixa paga' and b.Idclassificacao= a.Idclassificacao and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as DespesaFixaPaga,
(select COALESCE(sum(ValorDespesa),0) from tbl_despesafixa c, tbl_contasapagar d where StatusContasAPagar = 'Despesa fixa a pagar' and d.Iddespesas = c.IdDespesaFixa and c.Idclassificacao = a.Idclassificacao and d.DataVencimentoContaAPagar BETWEEN 
_datainicial and _datafinal ) as DespesaFixaapagar,
(select COALESCE(sum(ValorOcorrencia),0) from tbl_extratobancario b where StatusOcorrencia = 'Investimento' and b.Idclassificacao= a.Idclassificacao and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as Investimento


from

tbl_classificacao a
where Idclassificacao = _idclassificacao order by a.DescricaoClassificacao;

end if;
END