CREATE TABLE `myeconomy`.`tbl_contasapagar` (
 `IdContaAPagar` INT,
 `Idcontas` INT,
 `DataVencimentoContaAPagar` datetime,
  `NParcelasContaAPagar` int,
   PRIMARY KEY (`IdContaAPagar`),
  UNIQUE INDEX `IdContaAPagar_UNIQUE` (`IdContaAPagar` ASC) VISIBLE);

ALTER TABLE `tbl_contasapagar` ADD CONSTRAINT `fk_Idcontas` FOREIGN KEY ( `Idcontas` ) REFERENCES `tbl_contas` ( `Idcontas` ) ;
