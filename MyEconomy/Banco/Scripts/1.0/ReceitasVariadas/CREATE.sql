CREATE TABLE `myeconomy`.`tbl_receitavariada` (
  `Idreceitavariada` INT NOT NULL AUTO_INCREMENT,
  `Descricaoreceitavariada` VARCHAR(200) NULL,
  `Idcontasbancarias` int null,
  `Idclassificacao` int null, 
  `ValorreceitaVariada` decimal (10,2), 
  `DatareceitaVariada` datetime,
  
  
  PRIMARY KEY (`Idreceitavariada`),
  UNIQUE INDEX `Idreceitavariada_UNIQUE` (`Idreceitavariada` ASC) VISIBLE);

ALTER TABLE `tbl_receitavariada` ADD CONSTRAINT `fk_IdclassificacaoreceitaVariada` FOREIGN KEY ( `Idclassificacao` ) REFERENCES `tbl_classificacao` ( `Idclassificacao` ) ;
ALTER TABLE `tbl_receitavariada` ADD CONSTRAINT `fk_IdcontasbancariasreceitaVariada` FOREIGN KEY ( `Idcontasbancarias` ) REFERENCES `tbl_contasbancarias` ( `Idcontasbancarias` ) ;
