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