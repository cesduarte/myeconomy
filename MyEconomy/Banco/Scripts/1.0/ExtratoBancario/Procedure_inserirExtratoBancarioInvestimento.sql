CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirExtratoBancarioInvestimento`(
IN _Idextratobancario INT,
IN _descricaoextrato nvarchar(200), 
IN _idinvestimento INT,
IN _idclassificacao INT,
IN _idocorrencia INT,
IN _valorocorrencia decimal(10,2),
IN _dataocorrencia datetime,
IN _statusocorrencia nvarchar(200),
IN _tipoclassificacao VARCHAR(200)
)
BEGIN

insert into tbl_extratobancario(
DescricaoExtratoBancario,
Idinvestimento,
Idclassificacao,
TipoClassificacao,
ValorOcorrencia,
DataOcorrencia,
StatusOcorrencia,
Idocorrencia
)
values(
_descricaoextrato,
_idinvestimento,
_idclassificacao,
_tipoclassificacao,
_valorocorrencia,
_dataocorrencia,
_statusocorrencia,
_idocorrencia
);

END