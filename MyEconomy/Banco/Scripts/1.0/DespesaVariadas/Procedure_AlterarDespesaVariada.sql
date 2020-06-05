CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarDespesaVariada`(
IN _IdDespesaVariada INT,
IN _descricaodespesavariadas nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valordespesavariada decimal(10,2),
IN _datadespesavariada datetime,
IN _statusocorrencia VARCHAR(200),
IN _tipoclassificacao VARCHAR(200))
BEGIN
UPDATE `myeconomy`.`tbl_despesavariada`
SET
`Descricaodespesavariada` =_descricaodespesavariadas, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,

`ValorDespesaVariada` = _valordespesavariada ,

`DataDespesaVariada` = _datadespesavariada


WHERE `IdDespesavariada` = _IdDespesaVariada;

UPDATE `myeconomy`.`tbl_extratobancario`
SET
`DescricaoExtratoBancario` =_descricaodespesavariadas, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,

`ValorOcorrencia` = (-_valordespesavariada) ,

`DataOcorrencia` = _datadespesavariada


WHERE `IdOcorrencia` = _IdDespesaVariada AND `StatusOcorrencia` = _statusocorrencia AND TipoClassificacao = _tipoclassificacao;






UPDATE `myeconomy`.`tbl_extratobancario`
SET
`DescricaoExtratoBancario` =_descricaodespesavariadas, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,

`ValorOcorrencia` = (-_valordespesavariada) ,

`DataOcorrencia` = _datadespesavariada


WHERE `IdOcorrencia` = _IdDespesaVariada and `StatusOcorrencia` = _statusocorrencia and TipoClassificacao = _tipoclassificacao;
END