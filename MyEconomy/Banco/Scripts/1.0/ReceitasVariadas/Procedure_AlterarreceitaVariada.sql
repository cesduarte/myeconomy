CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarreceitaVariada`(
IN _IdreceitaVariada INT,
IN _descricaoreceitavariadas nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valorreceitavariada decimal(10,2),
IN _datareceitavariada datetime,
IN _statusocorrencia VARCHAR(200),
IN _tipoclassificacao VARCHAR(200))
BEGIN
UPDATE `myeconomy`.`tbl_receitavariada`
SET
`Descricaoreceitavariada` =_descricaoreceitavariadas, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,

`ValorreceitaVariada` = _valorreceitavariada ,

`DatareceitaVariada` = _datareceitavariada


WHERE `Idreceitavariada` = _IdreceitaVariada;


UPDATE `myeconomy`.`tbl_extratobancario`
SET
`DescricaoExtratoBancario` =_descricaoreceitavariadas, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,

`ValorOcorrencia` = _valorreceitavariada ,

`DataOcorrencia` = _datareceitavariada


WHERE `IdOcorrencia` = _IdreceitaVariada and `StatusOcorrencia` = _statusocorrencia and TipoClassificacao = _statusocorrencia;
END