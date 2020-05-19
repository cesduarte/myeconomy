CREATE DEFINER=`my`@`%` PROCEDURE `Procedure_excluirReceitasVariada`(in _IdReceitasVariada int)
BEGIN
delete from tbl_receitavariada where Idreceitavariada = _IdReceitasVariada;
END