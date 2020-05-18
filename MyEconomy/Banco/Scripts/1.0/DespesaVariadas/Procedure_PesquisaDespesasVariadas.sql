CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaDespesasVariadas`(
IN _descricaodespesavariadas nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT)
BEGIN
if(_descricaodespesavariadas=''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao  order by a.Descricaodespesavariada;

elseif(_descricaodespesavariadas<>''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaodespesavariada LIKE CONCAT('%',_descricaodespesavariadas, '%')
 order by a.Descricaodespesavariada;




elseif(_descricaodespesavariadas<>''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaodespesavariada LIKE CONCAT('%',_descricaodespesavariadas, '%') and a.Idcontasbancarias = _idcontasbancarias
 order by a.Descricaodespesavariada;



elseif(_descricaodespesavariadas<>''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaodespesavariada LIKE CONCAT('%',_descricaodespesavariadas, '%') and a.Idcontasbancarias = _idcontasbancarias
and a.Idclassificacao = _idclassificacao
order by a.Descricaodespesavariada;

elseif(_descricaodespesavariadas<>''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaodespesavariada LIKE CONCAT('%',_descricaodespesavariadas, '%') 
and a.Idclassificacao = _idclassificacao
order by a.Descricaodespesavariada;

elseif(_descricaodespesavariadas=''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and
a.Idcontasbancarias = _idcontasbancarias
order by a.Descricaodespesavariada;


elseif(_descricaodespesavariadas=''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and
a.Idcontasbancarias = _idcontasbancarias
and a.Idclassificacao = _idclassificacao
order by a.Descricaodespesavariada;

elseif(_descricaodespesavariadas=''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.IdDespesavariada, a.Descricaodespesavariada, a.ValorDespesaVariada,DataDespesaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_despesavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Idclassificacao = _idclassificacao
order by a.Descricaodespesavariada;

end if;
END