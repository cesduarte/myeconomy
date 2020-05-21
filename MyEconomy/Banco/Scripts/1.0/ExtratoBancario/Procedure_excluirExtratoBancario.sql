CREATE DEFINER=`my`@`%` PROCEDURE `Procedure_excluirExtratoBancario`(in _IdOcorrencia int, in _statusocorrencia varchar(200))
BEGIN
delete from tbl_extratobancario where IdOcorrencia = _IdOcorrencia and StatusOcorrencia = _statusocorrencia;

END