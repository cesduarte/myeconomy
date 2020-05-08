CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirContasAPagar`(
IN _IdDespesa INT, IN _datavencimentocontasapagar date, IN _nparcelacontasapagar int, IN _statuscontaapagar varchar(200))
BEGIN
insert into tbl_contasapagar(
 Iddespesas, DataVencimentoContaAPagar,NParcelasContaAPagar, StatusContasAPagar)
values(
_IdDespesa,_datavencimentocontasapagar, _nparcelacontasapagar, _statuscontaapagar
);
END