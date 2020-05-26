CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_RelatorioTotalizadorContasBancarias`(
IN _idcontasbancarias INT, 
IN _datainicial datetime,
IN _datafinal datetime
)
BEGIN


if(_idcontasbancarias = 1) then
select 
a.DescricaoContasBancarias as descricao,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Receitas' and b.Idcontasbancarias= a.Idcontasbancarias and DataOcorrencia BETWEEN 
_datainicial and _datafinal) as receitas,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Despesas Variadas' and b.Idcontasbancarias= a.Idcontasbancarias and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as Despesasvariadas,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Despesa fixa paga' and b.Idcontasbancarias= a.Idcontasbancarias and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as DespesaFixaPaga,
(select sum(ValorDespesa) from tbl_despesafixa c, tbl_contasapagar d where StatusContasAPagar = 'Despesa fixa a pagar' and d.Iddespesas = c.IdDespesaFixa and c.Idcontasbancarias = a.Idcontasbancarias and d.DataVencimentoContaAPagar BETWEEN 
_datainicial and _datafinal ) as DespesaFixaapagar


from

tbl_contasbancarias a
where Idcontasbancarias<>1 order by a.DescricaoContasBancarias;

elseif(_idcontasbancarias <> 1 ) then

select 
a.DescricaoContasBancarias,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Receitas' and b.Idcontasbancarias= a.Idcontasbancarias and DataOcorrencia BETWEEN 
_datainicial and _datafinal) as receitas,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Despesas Variadas' and b.Idcontasbancarias= a.Idcontasbancarias and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as Despesasvariadas,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Despesa fixa paga' and b.Idcontasbancarias= a.Idcontasbancarias and DataOcorrencia BETWEEN 
_datainicial and _datafinal ) as DespesaFixaPaga,
(select sum(ValorDespesa) from tbl_despesafixa c, tbl_contasapagar d where StatusContasAPagar = 'Despesa fixa a pagar' and d.Iddespesas = c.IdDespesaFixa and c.Idcontasbancarias = a.Idcontasbancarias and d.DataVencimentoContaAPagar BETWEEN 
_datainicial and _datafinal ) as DespesaFixaapagar


from

tbl_contasbancarias a
where Idcontasbancarias = _idcontasbancarias order by a.DescricaoContasBancarias;

end if;
END