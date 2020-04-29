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