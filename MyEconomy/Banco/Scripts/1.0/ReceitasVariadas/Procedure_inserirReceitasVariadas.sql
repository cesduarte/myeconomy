CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirReceitasVariadas`(
INOUT _IdReceitavariada INT,
IN _descricaoreceitasvariadas nvarchar(200), 
IN _idcontasbancarias INT,
IN _idclassificacao INT,
IN _valorreceitavariada decimal(10,2),
IN _datareceitavariada datetime
)
BEGIN
insert into tbl_receitavariada(
Descricaoreceitavariada,
Idcontasbancarias,
Idclassificacao,
ValorreceitaVariada,
DatareceitaVariada
)
values(
_descricaoreceitasvariadas,
_idcontasbancarias,
_idclassificacao,
_valorreceitavariada,
_datareceitavariada
);


set _IdreceitaVariada   = (SELECT @@IDENTITY);
END