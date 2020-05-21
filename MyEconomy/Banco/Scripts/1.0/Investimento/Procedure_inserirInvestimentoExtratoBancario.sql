CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirInvestimentoExtratoBancario`(
IN _descricaoinvestimento nvarchar(200), 
IN _idInvestimento INT,
IN _idclassificacao INT,
IN _saldoinvestimento decimal(10,2),
IN _datainvestimento datetime,
IN _statusocorrencia nvarchar(200) 
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
(select Descricaoinvestimento from tbl_investimento where IdInvestimento = _idInvestimento),
_idInvestimento,
_idclassificacao,
_idInvestimento,
_saldoinvestimento,
_datainvestimento,
_statusocorrencia
);

END