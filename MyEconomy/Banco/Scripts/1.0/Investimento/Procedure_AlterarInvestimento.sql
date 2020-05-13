CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarInvestimento`(
IN _Idinvestimento INT,
IN _descricaoinvestimento nvarchar(200), 
IN _idcontasbancarias INT,
IN _saldoinvestimento decimal(10,2),
IN _isdelete bool)
BEGIN
UPDATE `myeconomy`.`tbl_investimento`
SET
`Descricaoinvestimento` = _descricaoinvestimento,
   `SaldoInvestimento` = _saldoinvestimento,
  `Idcontasbancarias` = _idcontasbancarias,
`Isdelete` = _isdelete

WHERE `IdInvestimento` = _Idinvestimento;
END