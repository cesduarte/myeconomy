CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirExtratoBancario`(
IN _Idextratobancario INT,
IN _descricaoextrato nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valorocorrencia decimal(10,2),
IN _dataocorrencia datetime,
IN _statusocorrencia nvarchar(200),
IN _idOcorrencia int
)
BEGIN

insert into tbl_extratobancario(
DescricaoExtratoBancario,
Idcontasbancarias,
Idclassificacao,
IdOcorrencia,
ValorOcorrencia,
DataOcorrencia,
StatusOcorrencia
)
values(
_descricaoextrato,
_idcontasbancarias,
_idclassificacao,
_idOcorrencia,
_valorocorrencia,
_dataocorrencia,
_statusocorrencia
);

END