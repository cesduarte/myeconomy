CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_AlterarDespesaVariada`(
IN _IdDespesaVariada INT,
IN _descricaodespesavariadas nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valordespesavariada decimal(10,2),
IN _datadespesavariada datetime)
BEGIN
UPDATE `myeconomy`.`tbl_despesavariada`
SET
`Descricaodespesavariada` =_descricaodespesa, 
`Idcontasbancarias` =_idcontasbancarias,
`Idclassificacao` = _idclassificacao,

`ValorDespesaVariada` = _valordespesavariada ,

`DataDespesaVariada` = _datadespesavariada


WHERE `IdDespesavariada` = _IdDespesaVariada;
END