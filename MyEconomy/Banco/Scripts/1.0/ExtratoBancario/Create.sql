CREATE TABLE `myeconomy`.`tbl_extratobancario` (
  `IdExtratoBancario` INT NOT NULL AUTO_INCREMENT,
  `DescricaoExtratoBancario` VARCHAR(200) NULL,
  `Idcontasbancarias` int null,
  `Idclassificacao` int null,
  `Idinvestimento` int null,
  `TipoClassificacao` VARCHAR(200),
  `ValorOcorrencia` decimal (10,2),   
  `DataOcorrencia` datetime,
  `StatusOcorrencia` VARCHAR(200) NULL,
  `Idocorrencia` int null,
  
  PRIMARY KEY (`IdExtratoBancario`),
  UNIQUE INDEX `IdExtratoBancario_UNIQUE` (`IdExtratoBancario` ASC) VISIBLE);


