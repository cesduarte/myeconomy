CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaDespesaFixa`(
IN _descricaodespesa nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _isdelete bool)
BEGIN
if(_descricaodespesa=''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, a.ValorTotalDespesa, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesafixa a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete order by a.Descricaodespesa;

elseif(_descricaodespesa<>''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, a.ValorTotalDespesa, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Descricaodespesa LIKE CONCAT('%',_descricaodespesa, '%')
order by a.Descricaodespesa;

elseif(_descricaodespesa<>''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, a.ValorTotalDespesa, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Descricaodespesa LIKE CONCAT('%', _descricaodespesa, '%')
and a.Idcontasbancarias = _idcontasbancarias
order by a.Descricaodespesa;

elseif(_descricaodespesa<>''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, a.ValorTotalDespesa, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Descricaodespesa LIKE CONCAT('%', _descricaodespesa, '%')
and a.Idclassificacao = _idclassificacao
order by a.Descricaodespesa;


elseif(_descricaodespesa<>''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, a.ValorTotalDespesa, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Descricaodespesa LIKE CONCAT('%', _descricao, '%')
and a.Idcontasbancarias = _idcontasbancarias and a.Idclassificacao = _idclassificacao
order by a.Descricaodespesa;

elseif(_descricaodespesa=''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, a.ValorTotalDespesa, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete
and a.Idcontasbancarias = _idcontasbancarias 
order by a.Descricaodespesa;


elseif(_descricaodespesa=''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, a.ValorTotalDespesa, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete
and a.Idcontasbancarias = _idcontasbancarias and a.Idclassificacao = _idclassificacao
order by a.Descricaodespesa;

elseif(_descricaodespesa=''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.IdDespesaFixa, a.Descricaodespesa, a.ValorDespesa, a.ValorTotalDespesa, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Idclassificacao = _idclassificacao
order by a.Descricaodespesa;
end if;
END