select



 a.IdExtratoBancario, 
 a.DescricaoExtratoBancario,
 a.ValorOcorrencia, 
 a.DataOcorrencia,
 a.StatusOcorrencia, 
 (select b.descricaocontasbancarias from tbl_contasbancarias b where b.Idcontasbancarias = a.Idcontasbancarias) as banco , 

 (select d.Descricaoinvestimento from tbl_investimento d where d.IdInvestimento = a.Idinvestimento) as investimento
from
tbl_extratobancario a
