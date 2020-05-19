CREATE DEFINER=`my`@`%` PROCEDURE `Procedure_excluirReceitasVariada`(in _IdReceitaVariada int)
BEGIN
delete from tbl_receitavariada where Idreceitavariada = _IdReceitaVariada;
END