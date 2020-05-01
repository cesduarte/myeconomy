CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaClassificacao`(in _descricaoclassificacao varchar(100), in _isdelete bool)
BEGIN
if(_descricaoclassificacao = '') then
select * from tbl_classificacao where Isdelete = _isdelete and Idclassificacao<>1 order by DescricaoClassificacao;
else
select * from tbl_classificacao where Isdelete = _isdelete and Idclassificacao<>1 and DescricaoClassificacao LIKE CONCAT('%', _descricaoclassificacao, '%')  order by DescricaoClassificacao;
end if;
END