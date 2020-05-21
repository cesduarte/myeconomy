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
`TipoClassificacao`,
`Isdelete`
)
VALUES
(

'--',
'--',

false
);



INSERT INTO `myeconomy`.`tbl_classificacao`
(

`DescricaoClassificacao`,
`TipoClassificacao`,
`Isdelete`
)
VALUES
(

'Investimento',
'Investimento',

false
);

INSERT INTO `myeconomy`.`tbl_classificacao`
(

`DescricaoClassificacao`,
`TipoClassificacao`,
`Isdelete`
)
VALUES
(

'Salário',
'Receitas',

false
);

INSERT INTO `myeconomy`.`tbl_classificacao`
(

`DescricaoClassificacao`,
`TipoClassificacao`,
`Isdelete`
)
VALUES
(

'Cartão de crédito',
'Despesas',

false
);