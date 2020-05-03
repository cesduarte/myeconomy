CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirContas`(
IN _descricaoconta nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valorparcela decimal(10,2),
IN _valortotalparcela decimal(10,2),
IN _datavencimento datetime,
IN _quantparcela INT,
IN _isdelete bool)
BEGIN
insert into tbl_contas(
Descricaocontas,
Idcontasbancarias,
Idclassificacao,
ValorContas,
ValorTotalContas,
DataVencimento,
QuantParcelas,
Isdelete)
values(
_descricaoconta, 
_idcontasbancarias,
 _idclassificacao,
_valorparcela,
 _valortotalparcela,
 _datavencimento,
 _quantparcela,
 _isdelete);

END