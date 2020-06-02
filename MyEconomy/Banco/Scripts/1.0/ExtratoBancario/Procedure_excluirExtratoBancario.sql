CREATE DEFINER=`my`@`%` PROCEDURE `Procedure_excluirExtratoBancario`(in _IdOcorrencia int, in _tipoclassificacao varchar(200), in _statusocorrencia varchar(200))
BEGIN
delete from tbl_extratobancario where IdOcorrencia = _IdOcorrencia and TipoClassificacao = _tipoclassificacao and StatusOcorrencia = _statusocorrencia ;

END