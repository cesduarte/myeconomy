CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirReceitasVariadas`(
INOUT _IdReceitavariada INT,
IN _descricaoreceitasvariadas nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valorreceitavariada decimal(10,2),
IN _datareceitavariada datetime,
IN _statusocorrencia nvarchar(200),
IN _tipoclassificacao nvarchar(200) 
)
BEGIN
insert into tbl_receitavariada(
Descricaoreceitavariada,
Idcontasbancarias,
Idclassificacao,
ValorreceitaVariada,
DatareceitaVariada
)
values(
_descricaoreceitasvariadas,
_idcontasbancarias,
_idclassificacao,
_valorreceitavariada,
_datareceitavariada
);


set _IdreceitaVariada   = (SELECT @@IDENTITY);

insert into tbl_extratobancario(
DescricaoExtratoBancario,
Idcontasbancarias,
Idclassificacao,
TipoClassificacao,
IdOcorrencia,
ValorOcorrencia,
DataOcorrencia,
StatusOcorrencia
)
values(
_descricaoreceitasvariadas,
_idcontasbancarias,
_idclassificacao,
_tipoclassificacao,
_IdreceitaVariada,
_valorreceitavariada,
_datareceitavariada,
_statusocorrencia
);

END