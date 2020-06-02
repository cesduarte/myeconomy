CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_RelatorioExtratoAnaliticoStatus`(
IN _descricaoocorrencia nvarchar(200), 
IN _idcontasbancarias INT, 
IN _idclassificacao INT,
IN _datainicial datetime,
IN _datafinal datetime,
IN _statusocorrencia nvarchar(200)
)
BEGIN

select



 a.IdExtratoBancario, 
 a.DescricaoExtratoBancario,
 a.ValorOcorrencia, 
 a.DataOcorrencia,
 a.StatusOcorrencia, 
 (select b.descricaocontasbancarias from tbl_contasbancarias b where b.Idcontasbancarias = a.Idcontasbancarias) as DescricaoContasBancarias , 
(select c.DescricaoClassificacao from tbl_classificacao c where c.Idclassificacao = a.Idclassificacao) as DescricaoClassificacao,
 (select d.Descricaoinvestimento from tbl_investimento d where d.IdInvestimento = a.Idinvestimento) as Descricaoinvestimento
from
tbl_extratobancario a


where
 a.DataOcorrencia BETWEEN 
_datainicial and _datafinal and a.StatusOcorrencia = _statusocorrencia order by a.DataOcorrencia;





END