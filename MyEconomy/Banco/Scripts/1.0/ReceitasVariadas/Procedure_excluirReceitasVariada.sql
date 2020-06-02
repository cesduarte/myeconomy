CREATE DEFINER=`my`@`%` PROCEDURE `Procedure_excluirReceitasVariada`(in _IdReceitaVariada int, in _statusocorrencia varchar(200), in _tipoclassificacao varchar(200))
BEGIN
delete from tbl_receitavariada where Idreceitavariada = _IdReceitaVariada;
delete from tbl_extratobancario where IdOcorrencia = _IdReceitaVariada and StatusOcorrencia = _statusocorrencia and TipoClassificacao = _tipoclassificacao;

END