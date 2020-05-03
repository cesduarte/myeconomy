CREATE TABLE `myeconomy`.`tbl_contas` (
  `Idcontas` INT NOT NULL AUTO_INCREMENT,
  `Descricaocontas` VARCHAR(200) NULL,
  `Idcontasbancarias` int null,
  `Idclassificacao` int null,
  `ValorContas` decimal (10,2), 
  `ValorTotalContas` decimal (10,2), 
  `DataVencimento` datetime,
  `QuantParcelas` int,
  `Isdelete` boolean,
  PRIMARY KEY (`Idcontas`),
  UNIQUE INDEX `Idcontas_UNIQUE` (`Idcontas` ASC) VISIBLE);

ALTER TABLE `tbl_contas` ADD CONSTRAINT `fk_Idclassificacao` FOREIGN KEY ( `Idclassificacao` ) REFERENCES `tbl_classificacao` ( `Idclassificacao` ) ;
ALTER TABLE `tbl_contas` ADD CONSTRAINT `fk_Idcontasbancarias` FOREIGN KEY ( `Idcontasbancarias` ) REFERENCES `tbl_contasbancarias` ( `Idcontasbancarias` ) ;
