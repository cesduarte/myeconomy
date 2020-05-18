CREATE DEFINER=`my`@`%` PROCEDURE `Procedure_excluirDespesaVariada`(in _IdDespesaVariada int)
BEGIN
delete from tbl_despesavariada where IdDespesavariada = _IdDespesaVariada;
END