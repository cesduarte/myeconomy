CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirContasAPagar`(
IN _idcontas INT, IN _datavencimentocontasapagar date, IN _nparcelacontasapagar int)
BEGIN
insert into tbl_contasapagar(
 Idcontas, DataVencimentoContaAPagar,NParcelasContaAPagar)
values(
_idcontas,_datavencimentocontasapagar, _nparcelacontasapagar
);
END