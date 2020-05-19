CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaReceitasVariadas`(
IN _descricaoreceitavariadas nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT)
BEGIN
if(_descricaoreceitavariadas=''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.Idreceitavariada, a.Descricaoreceitavariada, a.ValorreceitaVariada,DatareceitaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_receitavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao  order by a.Descricaoreceitavariada;

elseif(_descricaoreceitavariadas<>''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.Idreceitavariada, a.Descricaoreceitavariada, a.ValorreceitaVariada,DatareceitaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_receitavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaoreceitavariada LIKE CONCAT('%',_descricaoreceitavariadas, '%')
 order by a.Descricaoreceitavariada;




elseif(_descricaoreceitavariadas<>''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.Idreceitavariada, a.Descricaoreceitavariada, a.ValorreceitaVariada,DatareceitaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_receitavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaoreceitavariada LIKE CONCAT('%',_descricaoreceitavariadas, '%') and a.Idcontasbancarias = _idcontasbancarias
 order by a.Descricaoreceitavariada;



elseif(_descricaoreceitavariadas<>''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.Idreceitavariada, a.Descricaoreceitavariada, a.ValorreceitaVariada,DatareceitaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_receitavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaoreceitavariada LIKE CONCAT('%',_descricaoreceitavariadas, '%') and a.Idcontasbancarias = _idcontasbancarias
and a.Idclassificacao = _idclassificacao
order by a.Descricaoreceitavariada;

elseif(_descricaoreceitavariadas<>''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.Idreceitavariada, a.Descricaoreceitavariada, a.ValorreceitaVariada,DatareceitaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_receitavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Descricaoreceitavariada LIKE CONCAT('%',_descricaoreceitavariadas, '%') 
and a.Idclassificacao = _idclassificacao
order by a.Descricaoreceitavariada;

elseif(_descricaoreceitavariadas=''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.Idreceitavariada, a.Descricaoreceitavariada, a.ValorreceitaVariada,DatareceitaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_receitavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and
a.Idcontasbancarias = _idcontasbancarias
order by a.Descricaoreceitavariada;


elseif(_descricaoreceitavariadas=''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.Idreceitavariada, a.Descricaoreceitavariada, a.ValorreceitaVariada,DatareceitaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_receitavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and
a.Idcontasbancarias = _idcontasbancarias
and a.Idclassificacao = _idclassificacao
order by a.Descricaoreceitavariada;

elseif(_descricaoreceitavariadas=''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.Idreceitavariada, a.Descricaoreceitavariada, a.ValorreceitaVariada,DatareceitaVariada, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_receitavariada a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao 
and a.Idclassificacao = _idclassificacao
order by a.Descricaoreceitavariada;

end if;
END