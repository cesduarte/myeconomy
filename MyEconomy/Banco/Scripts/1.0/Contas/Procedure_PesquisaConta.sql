CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaConta`(
IN _descricaoconta nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _isdelete bool)
BEGIN
if(_descricaoconta=''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.idcontas, a.Descricaocontas, a.ValorContas, a.ValorTotalContas, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete order by a.Descricaocontas;

elseif(_descricaoconta<>''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.idcontas, a.Descricaocontas, a.ValorContas, a.ValorTotalContas, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Descricaocontas LIKE CONCAT('%',_descricaoconta, '%')
order by a.Descricaocontas;

elseif(_descricaoconta<>''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.idcontas, a.Descricaocontas, a.ValorContas, a.ValorTotalContas, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Descricaocontas LIKE CONCAT('%', _descricaoconta, '%')
and a.Idcontasbancarias = _idcontasbancarias
order by a.Descricaocontas;

elseif(_descricaoconta<>''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.idcontas, a.Descricaocontas, a.ValorContas, a.ValorTotalContas, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Descricaocontas LIKE CONCAT('%', _descricaoconta, '%')
and a.Idclassificacao = _idclassificacao
order by a.Descricaocontas;


elseif(_descricaoconta<>''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.idcontas, a.Descricaocontas, a.ValorContas, a.ValorTotalContas, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Descricaocontas LIKE CONCAT('%', _descricao, '%')
and a.Idcontasbancarias = _idcontasbancarias and a.Idclassificacao = _idclassificacao
order by a.Descricaocontas;

elseif(_descricaoconta=''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.idcontas, a.Descricaocontas, a.ValorContas, a.ValorTotalContas, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete
and a.Idcontasbancarias = _idcontasbancarias 
order by a.Descricaocontas;


elseif(_descricaoconta=''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.idcontas, a.Descricaocontas, a.ValorContas, a.ValorTotalContas, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete
and a.Idcontasbancarias = _idcontasbancarias and a.Idclassificacao = _idclassificacao
order by a.Descricaocontas;

elseif(_descricaoconta=''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.idcontas, a.Descricaocontas, a.ValorContas, a.ValorTotalContas, a.DataVencimento, a.QuantParcelas,a.QuantParcelasAPagar, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_contas a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.Isdelete = _isdelete and a.Idclassificacao = _idclassificacao
order by a.Descricaocontas;
end if;
END