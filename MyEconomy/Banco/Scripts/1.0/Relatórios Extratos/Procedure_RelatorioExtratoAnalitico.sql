CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_RelatorioExtratoAnalitico`(
IN _descricaoocorrencia nvarchar(200), 
IN _idcontasbancarias INT, 
IN _idclassificacao INT,
IN _datainicial datetime,
IN _datafinal datetime,
IN _statusocorrencia nvarchar(200)
)
BEGIN

select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal  order by a.DataOcorrencia;

END