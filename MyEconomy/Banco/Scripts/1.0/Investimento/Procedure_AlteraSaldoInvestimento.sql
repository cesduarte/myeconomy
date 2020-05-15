CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlteraSaldoInvestimento`(
IN _Idcontasinvestimento int,
IN _saldo decimal(10,2))
BEGIN
UPDATE `myeconomy`.`tbl_investimento`
SET

`SaldoInvestimento` = `SaldoInvestimento` + _saldo 

WHERE `IdInvestimento` = _Idcontasinvestimento;
END