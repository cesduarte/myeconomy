CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirClassificacao`(inout _Idclassificacao int, IN _descricaoclassificacao nvarchar(200), IN  _tipoclassificacao nvarchar(200),
IN _isdelete bool)
BEGIN
insert into tbl_classificacao(DescricaoClassificacao,TipoClassificacao, Isdelete) values(_descricaoclassificacao,_tipoclassificacao, _isdelete);
set _Idclassificacao  = (SELECT @@IDENTITY);
END