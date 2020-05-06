CREATE TABLE `myeconomy`.`TBL_USUARIOS` (
  `Idusuario` INT NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(200) NULL,
  `Usuario` VARCHAR(200) NULL,
  `Senha` VARCHAR(200) NULL,
  `Email` VARCHAR(200) NULL,
  `Isdelete` boolean,
  `TrocarSenha` boolean,
  PRIMARY KEY (`Idusuario`),
  UNIQUE INDEX `Idusuario_UNIQUE` (`Idusuario` ASC) VISIBLE);
  
  
  
insert INTO `myeconomy`.`tbl_usuarios`
(
`Descricao`,
`Isdelete`
)
VALUES
(

'--',
false
);

CREATE TABLE `myeconomy`.`tbl_contasBancarias` (
  `Idcontasbancarias` INT NOT NULL AUTO_INCREMENT,
  `Idusuario` int null,
  `DescricaoContasBancarias` VARCHAR(200) NULL,
  `Saldo` decimal (10,2), 
  `Isdelete` boolean,
  PRIMARY KEY (`Idcontasbancarias`),
  UNIQUE INDEX `Idcontasbancarias_UNIQUE` (`Idcontasbancarias` ASC) VISIBLE);

ALTER TABLE `tbl_contasBancarias` ADD CONSTRAINT `fk_Idusuario` FOREIGN KEY ( `Idusuario` ) REFERENCES `tbl_usuarios` ( `Idusuario` ) ;

INSERT INTO `myeconomy`.`tbl_contasbancarias`
(
`Idusuario`,
`DescricaoContasBancarias`,
`Saldo`,
`Isdelete`
)
VALUES
(
1,
'--',
0,
false
);

CREATE TABLE `myeconomy`.`tbl_classificacao` (
  `Idclassificacao` INT NOT NULL AUTO_INCREMENT,
 
  `DescricaoClassificacao` VARCHAR(200) NULL,
  
  `Isdelete` boolean,
  PRIMARY KEY (`Idclassificacao`),
  UNIQUE INDEX `Idclassificacao_UNIQUE` (`Idclassificacao` ASC) VISIBLE);



INSERT INTO `myeconomy`.`tbl_classificacao`
(

`DescricaoClassificacao`,
`Isdelete`
)
VALUES
(

'--',
false
);

CREATE TABLE `myeconomy`.`tbl_contas` (
  `Idcontas` INT NOT NULL AUTO_INCREMENT,
  `Descricaocontas` VARCHAR(200) NULL,
  `Idcontasbancarias` int null,
  `Idclassificacao` int null,
  `ValorContas` decimal (10,2), 
  `ValorTotalContas` decimal (10,2), 
  `DataVencimento` datetime,
  `QuantParcelas` int,
  `QuantParcelasAPagar` int,
  `Isdelete` boolean,
  PRIMARY KEY (`Idcontas`),
  UNIQUE INDEX `Idcontas_UNIQUE` (`Idcontas` ASC) VISIBLE);

ALTER TABLE `tbl_contas` ADD CONSTRAINT `fk_Idclassificacao` FOREIGN KEY ( `Idclassificacao` ) REFERENCES `tbl_classificacao` ( `Idclassificacao` ) ;
ALTER TABLE `tbl_contas` ADD CONSTRAINT `fk_Idcontasbancarias` FOREIGN KEY ( `Idcontasbancarias` ) REFERENCES `tbl_contasbancarias` ( `Idcontasbancarias` ) ;
CREATE TABLE `myeconomy`.`tbl_contasapagar` (
 `IdContaAPagar` INT NOT NULL AUTO_INCREMENT,
 `Idcontas` INT,
 `DataVencimentoContaAPagar` datetime,
  `NParcelasContaAPagar` int,
   PRIMARY KEY (`IdContaAPagar`),
  UNIQUE INDEX `IdContaAPagar_UNIQUE` (`IdContaAPagar` ASC) VISIBLE);

ALTER TABLE `tbl_contasapagar` ADD CONSTRAINT `fk_Idcontas` FOREIGN KEY ( `Idcontas` ) REFERENCES `tbl_contas` ( `Idcontas` ) ;
