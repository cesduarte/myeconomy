select
a.DescricaoContasBancarias,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Receitas' and b.Idcontasbancarias= a.Idcontasbancarias ) as receitas,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Despesas Variadas' and b.Idcontasbancarias= a.Idcontasbancarias ) as Despesasvariadas,
(select sum(ValorOcorrencia) from tbl_extratobancario b where StatusOcorrencia = 'Despesa fixa paga' and b.Idcontasbancarias= a.Idcontasbancarias ) as DespesaFixaPaga,
(select sum(ValorDespesa) from tbl_despesafixa c, tbl_contasapagar d where StatusContasAPagar = 'Despesa fixa a pagar' and d.Iddespesas = c.IdDespesaFixa and c.Idcontasbancarias = a.Idcontasbancarias) as DespesaFixaapagar

from

tbl_contasbancarias a
where Idcontasbancarias<>1