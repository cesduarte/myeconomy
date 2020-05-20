CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaDespesasVariadas`(
IN _descricaodespesavariadas nvarchar(200), 
IN _idcontasbancarias INT, IN _datainicial datetime, in _datafinal datetime,
IN _idclassificacao INT)
BEGIN
if(_descricaodespesavariadas=''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataDespesaVariada BETWEEN 
_datainicial and _datafinal  order by a.DataDespesaVariada;

elseif(_descricaodespesavariadas<>''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaodespesavariada LIKE CONCAT('%',_descricaodespesavariadas, '%')
and a.DataDespesaVariada BETWEEN 
_datainicial and _datafinal  order by a.DataDespesaVariada;




elseif(_descricaodespesavariadas<>''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaodespesavariada LIKE CONCAT('%',_descricaodespesavariadas, '%') and a.Idcontasbancarias = _idcontasbancarias
and a.DataDespesaVariada BETWEEN 
_datainicial and _datafinal  order by a.DataDespesaVariada;



elseif(_descricaodespesavariadas<>''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaodespesavariada LIKE CONCAT('%',_descricaodespesavariadas, '%') and a.Idcontasbancarias = _idcontasbancarias
and a.Idclassificacao = _idclassificacao
and a.DataDespesaVariada BETWEEN 
_datainicial and _datafinal  order by a.DataDespesaVariada;

elseif(_descricaodespesavariadas<>''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaodespesavariada LIKE CONCAT('%',_descricaodespesavariadas, '%') 
and a.Idclassificacao = _idclassificacao
and a.DataDespesaVariada BETWEEN 
_datainicial and _datafinal  order by a.DataDespesaVariada;

elseif(_descricaodespesavariadas=''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and
a.Idcontasbancarias = _idcontasbancarias
and a.DataDespesaVariada BETWEEN 
_datainicial and _datafinal  order by a.DataDespesaVariada;


elseif(_descricaodespesavariadas=''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and
a.Idcontasbancarias = _idcontasbancarias
and a.Idclassificacao = _idclassificacao
and a.DataDespesaVariada BETWEEN 
_datainicial and _datafinal  order by a.DataDespesaVariada;

elseif(_descricaodespesavariadas=''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Idclassificacao = _idclassificacao
and a.DataDespesaVariada BETWEEN 
_datainicial and _datafinal  order by a.DataDespesaVariada;

end if;
END