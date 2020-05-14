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
CREATE TABLE `myeconomy`.`tbl_classificacao` (
  `Idclassificacao` INT NOT NULL AUTO_INCREMENT,
 
  `DescricaoClassificacao` VARCHAR(200) NULL,
  `TipoClassificacao` VARCHAR(200) NULL,
  
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

CREATE TABLE `myeconomy`.`tbl_despesafixa` (
  `IdDespesaFixa` INT NOT NULL AUTO_INCREMENT,
  `Descricaodespesa` VARCHAR(200) NULL,
  `Idcontasbancarias` int null,
  `Idclassificacao` int null,
  `Idinvestimento` int null,
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


CREATE TABLE `myeconomy`.`tbl_investimento` (
  `IdInvestimento` INT NOT NULL AUTO_INCREMENT,
  `Descricaoinvestimento` VARCHAR(200) NULL,
   `SaldoInvestimento` decimal (10,2), 
  `Idcontasbancarias` int null,  
  `Isdelete` boolean,
  PRIMARY KEY (`IdInvestimento`),
  UNIQUE INDEX `Idcontas_UNIQUE` (`IdInvestimento` ASC) VISIBLE);


ALTER TABLE `tbl_investimento` ADD CONSTRAINT `fk_Idcontasbancariasinvestimento` FOREIGN KEY ( `Idcontasbancarias` ) REFERENCES `tbl_contasbancarias` ( `Idcontasbancarias` ) ;


CREATE TABLE `myeconomy`.`tbl_contasapagar` (
 `IdContaAPagar` INT NOT NULL AUTO_INCREMENT,
 `Iddespesas` INT,
 `DataVencimentoContaAPagar` datetime,
 `NParcelasContaAPagar` varchar(200),
 `StatusContasAPagar` varchar(200),
 `IdContaBancariaPagamento` int,
 `ValorPagamento` decimal (10,2),
  `DataPagamento` datetime,
 PRIMARY KEY (`IdContaAPagar`),
UNIQUE INDEX `IdContaAPagar_UNIQUE` (`IdContaAPagar` ASC) VISIBLE);

ALTER TABLE `tbl_contasapagar` ADD CONSTRAINT `fk_Iddespesas` FOREIGN KEY ( `Iddespesas` ) REFERENCES `tbl_despesafixa` ( `IdDespesaFixa` ) ;