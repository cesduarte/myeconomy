CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlteraContasAPagarPagamento`(
IN _IdContaAPagar INT,
IN _idContaBancariaPagamento INT,
IN _idclassificacao INT,
IN _valorpagamento decimal(10,2),
IN _datapagamento datetime,
IN _statuscontaapagar VARCHAR(200),
IN _descricaodespesa VARCHAR(200),
IN _statusocorrencia VARCHAR(200),
IN _tipoclassificacao VARCHAR(200)
)
BEGIN
UPDATE `myeconomy`.`tbl_contasapagar`
SET
`IdContaBancariaPagamento` =_idContaBancariaPagamento, 
`ValorPagamento` =_valorpagamento,
`DataPagamento` = _datapagamento,
`StatusContasAPagar` = _statuscontaapagar

WHERE `IdContaAPagar` = _IdContaAPagar;
if(_statuscontaapagar = 'Despesa fixa paga')then
insert into tbl_extratobancario(
DescricaoExtratoBancario,
Idcontasbancarias,
Idclassificacao,
TipoClassificacao,
ValorOcorrencia,
DataOcorrencia,
StatusOcorrencia,
Idocorrencia

)
values(
_descricaodespesa,
_idContaBancariaPagamento,
_idclassificacao,
_tipoclassificacao,
(-_valorpagamento),
_datapagamento,
_statusocorrencia,
_IdContaAPagar 
);
else
delete from tbl_extratobancario where _tipoclassificacao = _tipoclassificacao and 
Idocorrencia = _IdContaAPagar and  StatusOcorrencia = _statusocorrencia;


END IF;


END