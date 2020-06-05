CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_alterarExtratoBancarioInvestimento`(
IN _descricaoextrato nvarchar(200), 
IN _idclassificacao INT,
IN _idinvestimento INT,
IN _valorocorrencia decimal(10,2),
IN _dataocorrencia datetime,
IN _statusocorrencia nvarchar(200),
IN _tipoclassificacao VARCHAR(200),
IN _idocorrencia INT
)
BEGIN

UPDATE `myeconomy`.`tbl_extratobancario`
SET
`DescricaoExtratoBancario` =_descricaoextrato, 
`Idinvestimento` =_idinvestimento,
`Idclassificacao` = _idclassificacao,

`ValorOcorrencia` = _valorocorrencia ,

`DataOcorrencia` = _dataocorrencia


WHERE `IdOcorrencia` = _idocorrencia and `StatusOcorrencia` = _statusocorrencia and TipoClassificacao = _tipoclassificacao;
END