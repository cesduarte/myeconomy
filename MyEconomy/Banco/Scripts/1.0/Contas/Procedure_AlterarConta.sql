CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarConta`(
IN _idcontas INT,
IN _descricaoconta nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valorparcela decimal(10,2),
IN _valortotalparcela decimal(10,2),
IN _datavencimento datetime,
IN _quantparcela INT,
IN _isdelete bool)
BEGIN
UPDATE `myeconomy`.`tbl_contas`
SET
`Descricaocontas` =_descricaoconta, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,
`ValorContas` = _valorparcela,
`ValorTotalContas` =_valortotalparcela,
`DataVencimento` = _datavencimento,
`QuantParcelas` =  _quantparcela,
`Isdelete` = _isdelete

WHERE `Idcontas` = _idcontas;
END