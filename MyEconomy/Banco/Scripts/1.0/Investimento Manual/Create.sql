CREATE TABLE `myeconomy`.`tbl_investimentoManual` (
  `IdInvestimentoManual` INT NOT NULL AUTO_INCREMENT,
  `Descricaoinvestimento` VARCHAR(200) NULL,
   `ValorInvestimento` decimal (10,2), 
   `DataInvestimento` datetime, 
  `Idcontasbancarias` int null,  
 `Idclassificacao` int null, 
  `IdInvestimento` int null,
  
  PRIMARY KEY (`IdInvestimentoManual`),
  UNIQUE INDEX `Idcontas_UNIQUE` (`IdInvestimentoManual` ASC) VISIBLE);


ALTER TABLE `tbl_investimentoManual` ADD CONSTRAINT `fk_IdcontasbancariasinvestimentoManual` FOREIGN KEY ( `Idcontasbancarias` ) REFERENCES `tbl_contasbancarias` ( `Idcontasbancarias` ) ;
ALTER TABLE `tbl_investimentoManual` ADD CONSTRAINT `fk_Idinvestimento` FOREIGN KEY ( `IdInvestimento` ) REFERENCES `tbl_investimento` ( `IdInvestimento` ) ;
ALTER TABLE `tbl_investimentoManual` ADD CONSTRAINT `fk_Idclassificacaorinvestimentomanual` FOREIGN KEY ( `Idclassificacao` ) REFERENCES `tbl_classificacao` ( `Idclassificacao` ) ;