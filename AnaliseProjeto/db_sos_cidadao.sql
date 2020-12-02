-- MySQL Workbench Synchronization
-- Generated: 2020-11-23 23:34
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: MAGAZINE

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbOcorrencia` (
  `idOcorrencia` INT(11) NOT NULL AUTO_INCREMENT,
  `dataOcorrencia` DATETIME NOT NULL,
  `descOcorrencia` TEXT NULL DEFAULT NULL,
  `fkIdStatusOcorrencia` INT(11) NOT NULL,
  `fkIdLocal` INT(11) NOT NULL,
  `fkIdPessoaSolicitante` INT(11) NOT NULL,
  PRIMARY KEY (`idOcorrencia`),
  INDEX `fk_tbOcorrencia_tbStatusOcorrencia1_idx` (`fkIdStatusOcorrencia` ASC) VISIBLE,
  INDEX `fk_tbOcorrencia_tbLocal1_idx` (`fkIdLocal` ASC) VISIBLE,
  INDEX `fk_tbOcorrencia_tbPessoa1_idx` (`fkIdPessoaSolicitante` ASC) VISIBLE,
  CONSTRAINT `fk_tbOcorrencia_tbStatusOcorrencia1`
    FOREIGN KEY (`fkIdStatusOcorrencia`)
    REFERENCES `db_sos_cidadao`.`tbStatusOcorrencia` (`idStatusOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbOcorrencia_tbLocal1`
    FOREIGN KEY (`fkIdLocal`)
    REFERENCES `db_sos_cidadao`.`tbLocal` (`idLocal`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbOcorrencia_tbPessoa1`
    FOREIGN KEY (`fkIdPessoaSolicitante`)
    REFERENCES `db_sos_cidadao`.`tbPessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbStatusOcorrencia` (
  `idStatusOcorrencia` INT(11) NOT NULL AUTO_INCREMENT,
  `nmStatusOcorrencia` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idStatusOcorrencia`),
  UNIQUE INDEX `nmStatusOcorrencia_UNIQUE` (`nmStatusOcorrencia` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbTipoOcorrencia` (
  `idTipoOcorrencia` INT(11) NOT NULL AUTO_INCREMENT,
  `nmTipoOcorrencia` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idTipoOcorrencia`),
  UNIQUE INDEX `nmTipoOcorrencia_UNIQUE` (`nmTipoOcorrencia` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbLocal` (
  `idLocal` INT(11) NOT NULL AUTO_INCREMENT,
  `nmLocal` VARCHAR(45) NOT NULL,
  `latitudeLocal` DECIMAL NULL DEFAULT NULL,
  `longitudeLocal` DECIMAL NULL DEFAULT NULL,
  PRIMARY KEY (`idLocal`),
  UNIQUE INDEX `nm_Local_UNIQUE` (`nmLocal` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbLocalAgregado` (
  `idLocalAgregado` INT(11) NOT NULL AUTO_INCREMENT,
  `fkIdLocalPrincipal` INT(11) NOT NULL,
  `fkIdLocalSecundario` INT(11) NOT NULL,
  PRIMARY KEY (`idLocalAgregado`),
  INDEX `fk_tbLocalAgregado_tbLocal1_idx` (`fkIdLocalPrincipal` ASC) VISIBLE,
  INDEX `fk_tbLocalAgregado_tbLocal2_idx` (`fkIdLocalSecundario` ASC) VISIBLE,
  CONSTRAINT `fk_tbLocalAgregado_tbLocal1`
    FOREIGN KEY (`fkIdLocalPrincipal`)
    REFERENCES `db_sos_cidadao`.`tbLocal` (`idLocal`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbLocalAgregado_tbLocal2`
    FOREIGN KEY (`fkIdLocalSecundario`)
    REFERENCES `db_sos_cidadao`.`tbLocal` (`idLocal`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbOcorrenciaTipoOcorrencia` (
  `idOcorrenciaTipoOcorrencia` INT(11) NOT NULL AUTO_INCREMENT,
  `fkIdTipoOcorrencia` INT(11) NOT NULL,
  `fkIdOcorrencia` INT(11) NOT NULL,
  PRIMARY KEY (`idOcorrenciaTipoOcorrencia`),
  INDEX `fk_tbOcorrenciaTipoOcorrencia_tbTipoOcorrencia1_idx` (`fkIdTipoOcorrencia` ASC) VISIBLE,
  INDEX `fk_tbOcorrenciaTipoOcorrencia_tbOcorrencia1_idx` (`fkIdOcorrencia` ASC) VISIBLE,
  CONSTRAINT `fk_tbOcorrenciaTipoOcorrencia_tbTipoOcorrencia1`
    FOREIGN KEY (`fkIdTipoOcorrencia`)
    REFERENCES `db_sos_cidadao`.`tbTipoOcorrencia` (`idTipoOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbOcorrenciaTipoOcorrencia_tbOcorrencia1`
    FOREIGN KEY (`fkIdOcorrencia`)
    REFERENCES `db_sos_cidadao`.`tbOcorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbPessoa` (
  `idPessoa` INT(11) NOT NULL AUTO_INCREMENT,
  `nmPessoa` VARCHAR(250) NOT NULL,
  `cpfPessoa` VARCHAR(14) NOT NULL,
  `rgPessoa` VARCHAR(14) NOT NULL,
  `dtNascimento` DATE NULL DEFAULT NULL,
  `telefonePessoa` VARCHAR(16) NULL DEFAULT NULL,
  `login` VARCHAR(45) NULL DEFAULT NULL,
  `senha` TEXT NULL DEFAULT NULL,
  `emailPessoa` VARCHAR(45) NULL DEFAULT NULL,
  `tokenRecuSenha` TEXT NULL DEFAULT NULL,
  `fkIdNivelAcesso` INT(11) NOT NULL,
  PRIMARY KEY (`idPessoa`),
  UNIQUE INDEX `rgPessoa_UNIQUE` (`rgPessoa` ASC) VISIBLE,
  UNIQUE INDEX `cpfPessoa_UNIQUE` (`cpfPessoa` ASC) VISIBLE,
  UNIQUE INDEX `emailPessoa_UNIQUE` (`emailPessoa` ASC) VISIBLE,
  UNIQUE INDEX `login_UNIQUE` (`login` ASC) VISIBLE,
  UNIQUE INDEX `telefonePessoa_UNIQUE` (`telefonePessoa` ASC) VISIBLE,
  INDEX `fk_tbPessoa_tbNivelAcesso1_idx` (`fkIdNivelAcesso` ASC) VISIBLE,
  CONSTRAINT `fk_tbPessoa_tbNivelAcesso1`
    FOREIGN KEY (`fkIdNivelAcesso`)
    REFERENCES `db_sos_cidadao`.`tbNivelAcesso` (`idNivelAcesso`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbAtendimentoOcorrencia` (
  `idAtendimentoOcorrencia` INT(11) NOT NULL AUTO_INCREMENT,
  `fkIdOcorrencia` INT(11) NOT NULL,
  `fkIdPessoaAtende` INT(11) NOT NULL,
  PRIMARY KEY (`idAtendimentoOcorrencia`),
  INDEX `fk_tbAtendimentoOcorrencia_tbPessoa1_idx` (`fkIdPessoaAtende` ASC) VISIBLE,
  INDEX `fk_tbAtendimentoOcorrencia_tbOcorrencia1_idx` (`fkIdOcorrencia` ASC) VISIBLE,
  CONSTRAINT `fk_tbAtendimentoOcorrencia_tbPessoa1`
    FOREIGN KEY (`fkIdPessoaAtende`)
    REFERENCES `db_sos_cidadao`.`tbPessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbAtendimentoOcorrencia_tbOcorrencia1`
    FOREIGN KEY (`fkIdOcorrencia`)
    REFERENCES `db_sos_cidadao`.`tbOcorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbNivelAcesso` (
  `idNivelAcesso` INT(11) NOT NULL AUTO_INCREMENT,
  `nmNivelAcesso` VARCHAR(250) NOT NULL,
  PRIMARY KEY (`idNivelAcesso`),
  UNIQUE INDEX `nmNivelAcesso_UNIQUE` (`nmNivelAcesso` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbPertence` (
  `idPertence` INT(11) NOT NULL AUTO_INCREMENT,
  `nmPertence` VARCHAR(250) NOT NULL,
  `descPertence` TEXT NULL DEFAULT NULL,
  `fkIdTipoPertence` INT(11) NOT NULL,
  PRIMARY KEY (`idPertence`),
  INDEX `fk_tbPertence_tbTipoPertence1_idx` (`fkIdTipoPertence` ASC) VISIBLE,
  CONSTRAINT `fk_tbPertence_tbTipoPertence1`
    FOREIGN KEY (`fkIdTipoPertence`)
    REFERENCES `db_sos_cidadao`.`tbTipoPertence` (`idTipoPertence`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbTipoPertence` (
  `idTipoPertence` INT(11) NOT NULL AUTO_INCREMENT,
  `nmTipoPertence` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idTipoPertence`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbOcorrenciaPertence` (
  `idOcorrenciaPertence` INT(11) NOT NULL AUTO_INCREMENT,
  `fkIdPertence` INT(11) NOT NULL,
  `fkIdOcorrencia` INT(11) NOT NULL,
  PRIMARY KEY (`idOcorrenciaPertence`),
  INDEX `fk_tbOcorrenciaPertence_tbPertence1_idx` (`fkIdPertence` ASC) VISIBLE,
  INDEX `fk_tbOcorrenciaPertence_tbOcorrencia1_idx` (`fkIdOcorrencia` ASC) VISIBLE,
  CONSTRAINT `fk_tbOcorrenciaPertence_tbPertence1`
    FOREIGN KEY (`fkIdPertence`)
    REFERENCES `db_sos_cidadao`.`tbPertence` (`idPertence`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbOcorrenciaPertence_tbOcorrencia1`
    FOREIGN KEY (`fkIdOcorrencia`)
    REFERENCES `db_sos_cidadao`.`tbOcorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbComentario` (
  `idComentario` INT(11) NOT NULL AUTO_INCREMENT,
  `dataHora` DATETIME NOT NULL,
  `comentario` TEXT NOT NULL,
  `fkIdPessoa` INT(11) NOT NULL,
  `fkIdOcorrencia` INT(11) NOT NULL,
  PRIMARY KEY (`idComentario`),
  INDEX `fk_tbComentario_tbPessoa1_idx` (`fkIdPessoa` ASC) VISIBLE,
  INDEX `fk_tbComentario_tbOcorrencia1_idx` (`fkIdOcorrencia` ASC) VISIBLE,
  CONSTRAINT `fk_tbComentario_tbPessoa1`
    FOREIGN KEY (`fkIdPessoa`)
    REFERENCES `db_sos_cidadao`.`tbPessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbComentario_tbOcorrencia1`
    FOREIGN KEY (`fkIdOcorrencia`)
    REFERENCES `db_sos_cidadao`.`tbOcorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `db_sos_cidadao`.`tbAnexoPertence` (
  `idAnexoPertence` INT(11) NOT NULL AUTO_INCREMENT,
  `nmAnexoPertence` VARCHAR(250) NOT NULL,
  `urlArquivo` VARCHAR(250) NOT NULL,
  `dataHora` DATETIME NULL DEFAULT NULL,
  `fkIdPessoa` INT(11) NOT NULL,
  `fkIdOcorrencia` INT(11) NOT NULL,
  PRIMARY KEY (`idAnexoPertence`),
  INDEX `fk_tbAnexoPertence_tbPessoa1_idx` (`fkIdPessoa` ASC) VISIBLE,
  INDEX `fk_tbAnexoPertence_tbOcorrencia1_idx` (`fkIdOcorrencia` ASC) VISIBLE,
  CONSTRAINT `fk_tbAnexoPertence_tbPessoa1`
    FOREIGN KEY (`fkIdPessoa`)
    REFERENCES `db_sos_cidadao`.`tbPessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbAnexoPertence_tbOcorrencia1`
    FOREIGN KEY (`fkIdOcorrencia`)
    REFERENCES `db_sos_cidadao`.`tbOcorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
