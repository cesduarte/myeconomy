CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirInvestimentoManual`(
INOUT _IdinvestimentoManual INT,
IN _descricaoinvestimento nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
in _idinvestimento INT,
IN _valorinvestimento decimal(10,2),
IN _datainvestimento datetime,
IN _statusocorrencia nvarchar(200) )
BEGIN
insert into tbl_investimentoManual(
 Descricaoinvestimento,
   ValorInvestimento ,
   DataInvestimento,
  Idcontasbancarias,
  Idclassificacao,
  IdInvestimento)
values(
_descricaoinvestimento,
_valorinvestimento,
_datainvestimento,
_idcontasbancarias,
_idclassificacao,
_idinvestimento
);

set _IdinvestimentoManual   = (SELECT @@IDENTITY);


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
_descricaoinvestimento,
_idcontasbancarias,
_idclassificacao,
_IdinvestimentoManual,
(-_valorinvestimento),
_datainvestimento,
_statusocorrencia
);

END