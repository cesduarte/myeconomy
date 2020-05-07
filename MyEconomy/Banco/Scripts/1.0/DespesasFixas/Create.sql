CREATE TABLE `myeconomy`.`tbl_despesafixa` (
  `IdDespesaFixa` INT NOT NULL AUTO_INCREMENT,
  `Descricaodespesa` VARCHAR(200) NULL,
  `Idcontasbancarias` int null,
  `Idclassificacao` int null,
  `ValorDespesa` decimal (10,2), 
  `ValorTotalDespesa` decimal (10,2), 
  `DataVencimento` datetime,
  `QuantParcelas` int,
  `QuantParcelasAPagar` int,
  `Isdelete` boolean,
  PRIMARY KEY (`IdDespesaFixa`),
  UNIQUE INDEX `IdDespesaFixa_UNIQUE` (`IdDespesaFixa` ASC) VISIBLE);

ALTER TABLE `tbl_despesafixa` ADD CONSTRAINT `fk_Idclassificacao` FOREIGN KEY ( `Idclassificacao` ) REFERENCES `tbl_classificacao` ( `Idclassificacao` ) ;
ALTER TABLE `tbl_despesafixa` ADD CONSTRAINT `fk_Idcontasbancarias` FOREIGN KEY ( `Idcontasbancarias` ) REFERENCES `tbl_contasbancarias` ( `Idcontasbancarias` ) ;
