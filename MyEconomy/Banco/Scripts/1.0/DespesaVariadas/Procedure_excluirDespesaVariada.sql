CREATE DEFINER=`my`@`%` PROCEDURE `Procedure_excluirDespesaVariada`(in _IdDespesaVariada int, in _statusocorrencia varchar(200), in _tipoclassificacao varchar(200))
BEGIN
delete from tbl_despesavariada where IdDespesavariada = _IdDespesaVariada;
delete from tbl_extratobancario where IdOcorrencia = _IdDespesaVariada and StatusOcorrencia = _statusocorrencia and TipoClassificacao = _tipoclassificacao ;

END