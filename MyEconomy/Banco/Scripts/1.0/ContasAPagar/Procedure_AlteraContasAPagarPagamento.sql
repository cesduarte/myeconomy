CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlteraContasAPagarPagamento`(
IN _IdContaAPagar INT,
IN _idContaBancariaPagamento INT,
IN _valorpagamento decimal(10,2),
IN _datapagamento datetime,
IN _statuscontaapagar VARCHAR(200)
)
BEGIN
UPDATE `myeconomy`.`tbl_contasapagar`
SET
`IdContaBancariaPagamento` =_idContaBancariaPagamento, 
`ValorPagamento` =_valorpagamento,
`DataPagamento` = _datapagamento,
`StatusContasAPagar` = _statuscontaapagar

WHERE `IdContaAPagar` = _IdContaAPagar;
END