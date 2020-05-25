CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_RelatorioExtratoAnaliticoStatus`(
IN _descricaoocorrencia nvarchar(200), 
IN _idcontasbancarias INT, 
IN _idclassificacao INT,
IN _datainicial datetime,
IN _datafinal datetime,
IN _statusocorrencia nvarchar(200)
)
BEGIN


if(_descricaoocorrencia=''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal and StatusOcorrencia = _statusocorrencia

 order by a.DataOcorrencia;
elseif(_descricaoocorrencia<>''&& _idcontasbancarias = 1 && _idclassificacao =1)then
select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal  and DescricaoExtratoBancario LIKE CONCAT('%',_descricaoocorrencia, '%')
and StatusOcorrencia = _statusocorrencia
order by a.DataOcorrencia;

elseif(_descricaoocorrencia<>''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal  and DescricaoExtratoBancario LIKE CONCAT('%',_descricaoocorrencia, '%') and a.Idcontasbancarias = _idcontasbancarias
and StatusOcorrencia = _statusocorrencia
order by a.DataOcorrencia;

elseif(_descricaoocorrencia<>''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal  and DescricaoExtratoBancario LIKE CONCAT('%',_descricaoocorrencia, '%') and a.Idcontasbancarias = _idcontasbancarias and a.Idclassificacao = _idclassificacao
and StatusOcorrencia = _statusocorrencia
order by a.DataOcorrencia;


elseif(_descricaoocorrencia<>''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal  and DescricaoExtratoBancario LIKE CONCAT('%',_descricaoocorrencia, '%') and a.Idclassificacao = _idclassificacao
and StatusOcorrencia = _statusocorrencia
order by a.DataOcorrencia;


elseif(_descricaoocorrencia=''&& _idcontasbancarias <> 1 && _idclassificacao =1)then
select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal  and a.Idcontasbancarias = _idcontasbancarias
and StatusOcorrencia = _statusocorrencia
order by a.DataOcorrencia;

elseif(_descricaoocorrencia=''&& _idcontasbancarias <> 1 && _idclassificacao <>1)then
select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal  and  a.Idcontasbancarias = _idcontasbancarias and a.Idclassificacao = _idclassificacao
and StatusOcorrencia = _statusocorrencia
order by a.DataOcorrencia;

elseif(_descricaoocorrencia=''&& _idcontasbancarias = 1 && _idclassificacao <>1)then
select a.IdExtratoBancario, a.DescricaoExtratoBancario, a.ValorOcorrencia, a.DataOcorrencia,a.StatusOcorrencia, b.DescricaoContasBancarias, c.DescricaoClassificacao
from
tbl_extratobancario a, tbl_contasbancarias b, tbl_classificacao c
where
a.Idcontasbancarias = b.Idcontasbancarias and a.Idclassificacao = c.Idclassificacao and a.DataOcorrencia BETWEEN 
_datainicial and _datafinal  and   a.Idclassificacao = _idclassificacao
and StatusOcorrencia = _statusocorrencia
order by a.DataOcorrencia;

end if;
END