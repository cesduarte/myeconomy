CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirDespesaVariada`(
INOUT _IdDespesaVariada INT,
IN _descricaodespesavariadas nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valordespesavariada decimal(10,2),
IN _datadespesavariada datetime
)
BEGIN
insert into tbl_despesavariada(
Descricaodespesavariada,
Idcontasbancarias,
Idclassificacao,
ValorDespesaVariada,
DataDespesaVariada
)
values(
_descricaodespesavariadas,
_idcontasbancarias,
_idclassificacao,
_valordespesavariada,
_datadespesavariada
);


set _IdDespesaVariada   = (SELECT @@IDENTITY);
END