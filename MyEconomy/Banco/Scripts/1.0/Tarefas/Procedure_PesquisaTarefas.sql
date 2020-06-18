CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_PesquisaTarefas`(
in _descricaotarefa varchar(100), in _idusuario int, in _datainicial datetime, _datafinal datetime, _statustarefa varchar(100))
BEGIN
select

b.Idtarefa,
b.DescricaoTarefa,
b.DataTarefa,
a.descricao as descricaousuario,
b.StatusTarefa

from
tbl_usuarios a,
tbl_tarefas b



where
b.idusuario = a.idusuario  and a.idusuario<>1;


END