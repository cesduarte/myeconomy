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