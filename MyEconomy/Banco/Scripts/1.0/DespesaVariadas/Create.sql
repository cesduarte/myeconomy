CREATE TABLE `myeconomy`.`tbl_despesavariada` (
  `IdDespesavariada` INT NOT NULL AUTO_INCREMENT,
  `Descricaodespesavariada` VARCHAR(200) NULL,
  `Idcontasbancarias` int null,
  `Idclassificacao` int null, 
  `ValorDespesaVariada` decimal (10,2), 
  `DataDespesaVariada` datetime,
  
  
  PRIMARY KEY (`IdDespesavariada`),
  UNIQUE INDEX `IdDespesavariada_UNIQUE` (`IdDespesavariada` ASC) VISIBLE);

ALTER TABLE `tbl_despesavariada` ADD CONSTRAINT `fk_IdclassificacaoDespesaVariada` FOREIGN KEY ( `Idclassificacao` ) REFERENCES `tbl_classificacao` ( `Idclassificacao` ) ;
ALTER TABLE `tbl_despesavariada` ADD CONSTRAINT `fk_IdcontasbancariasDespesaVariada` FOREIGN KEY ( `Idcontasbancarias` ) REFERENCES `tbl_contasbancarias` ( `Idcontasbancarias` ) ;
