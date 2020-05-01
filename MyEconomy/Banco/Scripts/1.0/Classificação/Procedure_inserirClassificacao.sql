CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirClassificacao`(IN _descricaoclassificacao nvarchar(200),
IN _isdelete bool)
BEGIN
insert into tbl_classificacao(DescricaoClassificacao,Isdelete) values(_descricaoclassificacao, _isdelete);
END