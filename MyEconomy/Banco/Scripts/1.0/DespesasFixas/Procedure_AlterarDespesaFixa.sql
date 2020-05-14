CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarDespesaFixa`(
IN _IdDespesa INT,
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
UPDATE `myeconomy`.`tbl_despesafixa`
SET
`Descricaodespesa` =_descricaodespesa, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,
`Idinvestimento` = _idinvestimento,
`ValorDespesa` = _valorparceladespesa,
`ValorTotalDespesa` =_valortotalparceladespesa,
`DataVencimento` = _datavencimento,
`QuantParcelas` =  _quantparcela,
`Isdelete` = _isdelete

WHERE `IdDespesaFixa` = _IdDespesa;
END