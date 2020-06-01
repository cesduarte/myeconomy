CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarInvestimentoManual`(
IN _IdinvestimentoManual INT,
IN _descricaoinvestimento nvarchar(200), 
IN _idcontasbancarias INT,
in _idinvestimento INT,
IN _valorinvestimento decimal(10,2),
IN _datainvestimento datetime)
BEGIN
UPDATE `myeconomy`.`tbl_investimentoManual`
SET
 `Descricaoinvestimento` =_descricaoinvestimento,
   `ValorInvestimento` =_valorinvestimento,
   `DataInvestimento` =_datainvestimento,
  `Idcontasbancarias` =  _idcontasbancarias,
  `IdInvestimento` =_idinvestimento

WHERE `IdInvestimentoManual` = _IdinvestimentoManual;
END