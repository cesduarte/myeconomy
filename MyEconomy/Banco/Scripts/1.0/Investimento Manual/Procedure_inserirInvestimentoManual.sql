CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirInvestimentoManual`(
INOUT _IdinvestimentoManual INT,
IN _descricaoinvestimento nvarchar(200), 
IN _idcontasbancarias INT,
in _idinvestimento INT,
IN _valorinvestimento decimal(10,2),
IN _datainvestimento datetime)
BEGIN
insert into tbl_investimentoManual(
 Descricaoinvestimento,
   ValorInvestimento ,
   DataInvestimento,
  Idcontasbancarias,
  IdInvestimento)
values(
_descricaoinvestimento,
_valorinvestimento,
_datainvestimento,
_idcontasbancarias,
_idinvestimento
);

set _IdinvestimentoManual   = (SELECT @@IDENTITY);
END