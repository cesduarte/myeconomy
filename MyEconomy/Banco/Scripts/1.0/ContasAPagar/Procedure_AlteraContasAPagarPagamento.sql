CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlteraContasAPagarPagamento`(
IN _IdContaAPagar INT,
IN _idContaBancariaPagamento INT,
IN _idclassificacao INT,
IN _valorpagamento decimal(10,2),
IN _datapagamento datetime,
IN _statuscontaapagar VARCHAR(200),
IN _descricaodespesa VARCHAR(200),
IN _statusocorrencia VARCHAR(200)
)
BEGIN
UPDATE `myeconomy`.`tbl_contasapagar`
SET
`IdContaBancariaPagamento` =_idContaBancariaPagamento, 
`ValorPagamento` =_valorpagamento,
`DataPagamento` = _datapagamento,
`StatusContasAPagar` = _statuscontaapagar

WHERE `IdContaAPagar` = _IdContaAPagar;
if(_statuscontaapagar = 'Conta paga')then
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
_descricaodespesa,
_idContaBancariaPagamento,
_idclassificacao,
_IdContaAPagar,
(-_valorpagamento),
_datapagamento,
_statusocorrencia
);
else
delete from tbl_extratobancario where IdOcorrencia = _IdContaAPagar and StatusOcorrencia = _statusocorrencia;

END IF;


END