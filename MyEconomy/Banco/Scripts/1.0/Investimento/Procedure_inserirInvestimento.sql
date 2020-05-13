CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirInvestimento`(
INOUT _Idinvestimento INT,
IN _descricaoinvestimento nvarchar(200), 
IN _idcontasbancarias INT,
IN _saldoinvestimento decimal(10,2),
IN _isdelete bool)
BEGIN
insert into tbl_investimento(
Descricaoinvestimento,
Idcontasbancarias,
SaldoInvestimento,
Isdelete)
values(
_descricaoinvestimento,
_idcontasbancarias,
_saldoinvestimento,
_isdelete
);

set _Idinvestimento   = (SELECT @@IDENTITY);
END