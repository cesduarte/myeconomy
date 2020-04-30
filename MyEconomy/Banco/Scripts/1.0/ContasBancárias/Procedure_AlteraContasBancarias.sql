CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlteraContasBancarias`(
IN _Idcontasbancarias int,
IN _descricaocontasbancarias nvarchar(200), 
IN _saldo decimal(10,2),
In _idusuario int,
IN _isdelete bool)
BEGIN
UPDATE `myeconomy`.`tbl_contasbancarias`
SET
`DescricaoContasBancarias` =_descricaocontasbancarias,
`Idusuario` = _idusuario,
`Saldo` = _saldo ,
`Isdelete` = _isdelete


WHERE `Idcontasbancarias` = _Idcontasbancarias;
END