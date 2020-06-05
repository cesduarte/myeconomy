CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarInvestimentoManual`(
IN _IdinvestimentoManual INT,
IN _descricaoinvestimento nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
in _idinvestimento INT,
IN _valorinvestimento decimal(10,2),
IN _datainvestimento datetime,
IN _statusocorrencia nvarchar(200),
IN _tipoclassificacao nvarchar(200) 

)
BEGIN
UPDATE `myeconomy`.`tbl_investimentoManual`
SET
 `Descricaoinvestimento` =_descricaoinvestimento,
   `ValorInvestimento` =_valorinvestimento,
   `DataInvestimento` =_datainvestimento,
  `Idcontasbancarias` =  _idcontasbancarias,
  `Idclassificacao` = _idclassificacao,
  `IdInvestimento` =_idinvestimento

WHERE `IdInvestimentoManual` = _IdinvestimentoManual;

UPDATE `myeconomy`.`tbl_extratobancario`
SET
`DescricaoExtratoBancario` =_descricaoinvestimento, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,

`ValorOcorrencia` =_valorinvestimento ,

`DataOcorrencia` = _datainvestimento


WHERE `IdOcorrencia` = _IdinvestimentoManual and `StatusOcorrencia` = _statusocorrencia and TipoClassificacao = _tipoclassificacao;

END