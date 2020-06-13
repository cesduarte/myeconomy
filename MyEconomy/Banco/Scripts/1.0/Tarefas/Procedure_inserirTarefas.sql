CREATE DEFINER=`root`@`localhost` PROCEDURE `Procedure_inserirTarefas`(
inout _IdTarefa int,
In _idusuario int,
IN _descricaotarefa nvarchar(200), 
IN _obstarefa nvarchar(500),
IN _datatarefa datetime,
IN _statustarefa nvarchar(200))
BEGIN
insert into tbl_tarefas(DescricaoTarefa,Idusuario,Obs,DataTarefa,StatusTarefa) values(_descricaotarefa,_idusuario,_obstarefa, _datatarefa, _statustarefa );
set _IdTarefa  = (SELECT @@IDENTITY);
END