CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirDespesaFixa`(
INOUT _IdDespesa INT,
IN _descricaodespesa nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _idinvestimento INT,
IN _valorparceladespesa decimal(10,2),
IN _valortotalparceladespesa decimal(10,2),
IN _datavencimento datetime,
IN _quantparcela INT,
IN _quantparcelaapagar INT,
IN _isdelete bool)
BEGIN
insert into tbl_despesafixa(
Descricaodespesa,
Idcontasbancarias,
Idclassificacao,
Idinvestimento,
ValorDespesa,
ValorTotalDespesa,
DataVencimento,
QuantParcelas,
QuantParcelasAPagar,
Isdelete)
values(
_descricaodespesa, 
_idcontasbancarias,
_idclassificacao,
_idinvestimento,
_valorparceladespesa,
_valortotalparceladespesa,
_datavencimento,
_quantparcela,
_quantparcelaapagar,
_isdelete);


set _IdDespesa   = (SELECT @@IDENTITY);
END