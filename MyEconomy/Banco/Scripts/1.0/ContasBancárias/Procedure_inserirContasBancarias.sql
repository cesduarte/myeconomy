CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirContasBancarias`(
inout _Idcontasbancarias int,
IN _descricaocontasbancarias nvarchar(200), 
IN _saldo decimal(10,2),
In _idusuario int,
IN _isdelete bool)
BEGIN
insert into tbl_contasbancarias(DescricaoContasBancarias, Saldo, idusuario, Isdelete) values(_descricaocontasbancarias, _saldo, _idusuario, _isdelete);
set _Idcontasbancarias  = (SELECT @@IDENTITY);
END