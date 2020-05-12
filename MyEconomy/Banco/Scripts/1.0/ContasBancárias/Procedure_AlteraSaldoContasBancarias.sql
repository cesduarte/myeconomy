CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlteraSaldoContasBancarias`(
IN _Idcontasbancarias int,
IN _saldo decimal(10,2))
BEGIN
UPDATE `myeconomy`.`tbl_contasbancarias`
SET

`Saldo` = `Saldo` + _saldo 

WHERE `Idcontasbancarias` = _Idcontasbancarias;
END