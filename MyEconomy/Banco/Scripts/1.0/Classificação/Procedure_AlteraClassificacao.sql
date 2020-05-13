CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlteraClassificacao`(IN _Idclassificacao int,  IN _descricaoclassificacao nvarchar(200), IN  _tipoclassificacao nvarchar(200),
IN _isdelete bool)
BEGIN
UPDATE `myeconomy`.`tbl_classificacao`
SET
`DescricaoClassificacao` = _descricaoclassificacao,
`TipoClassificacao` = _tipoclassificacao,

`Isdelete` = _isdelete

WHERE `Idclassificacao` = _Idclassificacao;
END