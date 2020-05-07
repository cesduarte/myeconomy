CREATE TABLE `myeconomy`.`tbl_contasapagar` (
 `IdContaAPagar` INT NOT NULL AUTO_INCREMENT,
 `Iddespesas` INT,
 `DataVencimentoContaAPagar` datetime,
 `NParcelasContaAPagar` int,
 `StatusContasAPagar` int,
 PRIMARY KEY (`IdContaAPagar`),
UNIQUE INDEX `IdContaAPagar_UNIQUE` (`IdContaAPagar` ASC) VISIBLE);

ALTER TABLE `tbl_contasapagar` ADD CONSTRAINT `fk_Iddespesas` FOREIGN KEY ( `Iddespesas` ) REFERENCES `tbl_despesafixa` ( `IdDespesaFixa` ) ;