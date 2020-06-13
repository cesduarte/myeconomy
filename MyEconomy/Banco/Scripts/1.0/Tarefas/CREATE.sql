CREATE TABLE `myeconomy`.`tbl_tarefas` (
  `Idtarefa` INT NOT NULL AUTO_INCREMENT,
  `Idusuario` INT NOT NULL,
  `DescricaoTarefa` VARCHAR(200) NULL,
  `StatusTarefa` VARCHAR(200),
  `DataTarefa` datetime,
   `Obs` VARCHAR(200),
  PRIMARY KEY (`Idtarefa`),
  UNIQUE INDEX `Idtarefa_UNIQUE` (`Idtarefa` ASC) VISIBLE);
  
  
  ALTER TABLE `tbl_tarefas` ADD CONSTRAINT `fk_Idusuariotarefa` FOREIGN KEY ( `Idusuario` ) REFERENCES `tbl_usuarios` ( `Idusuario` ) ;
  
  
  
