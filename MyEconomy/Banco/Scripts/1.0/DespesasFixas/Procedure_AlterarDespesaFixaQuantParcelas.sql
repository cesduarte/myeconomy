CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarDespesaFixaQuantParcelas`(
IN _IdDespesa INT,
IN _QuantParcela INT
)
BEGIN
UPDATE `myeconomy`.`tbl_despesafixa`
SET

`QuantParcelasAPagar` = `QuantParcelasAPagar`+ _QuantParcela

WHERE `IdDespesaFixa` = _IdDespesa;
END