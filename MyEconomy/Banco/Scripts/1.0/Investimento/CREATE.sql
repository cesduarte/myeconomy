CREATE TABLE `myeconomy`.`tbl_investimento` (
  `IdInvestimento` INT NOT NULL AUTO_INCREMENT,
  `Descricaoinvestimento` VARCHAR(200) NULL,
   `SaldoInvestimento` decimal (10,2), 
  `Idcontasbancarias` int null,  
  `Isdelete` boolean,
  PRIMARY KEY (`IdInvestimento`),
  UNIQUE INDEX `Idcontas_UNIQUE` (`IdInvestimento` ASC) VISIBLE);


ALTER TABLE `tbl_investimento` ADD CONSTRAINT `fk_Idcontasbancariasinvestimento` FOREIGN KEY ( `Idcontasbancarias` ) REFERENCES `tbl_contasbancarias` ( `Idcontasbancarias` ) ;
