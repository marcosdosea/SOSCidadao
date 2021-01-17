-- MySQL Workbench Synchronization
-- Generated: 2021-01-17 17:38
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: MAGAZINE

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `sos_cidadao` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`Ocorrencia` (
  `idOcorrencia` INT(11) NOT NULL AUTO_INCREMENT,
  `dataCadastro` DATETIME NOT NULL,
  `descricao` TEXT NULL DEFAULT NULL,
  `statusOcorrencia` ENUM('Em andamento', 'Em aberto', 'Arquivada', 'Atendida', 'Inativa') NOT NULL DEFAULT 'Em Aberto',
  `telefoneContato` VARCHAR(15) NULL DEFAULT NULL,
  `emergencia` TINYINT(4) NOT NULL,
  `idPessoaSolicitante` INT(11) NULL DEFAULT NULL,
  `idLocal` INT(11) NOT NULL,
  PRIMARY KEY (`idOcorrencia`),
  INDEX `fk_Ocorrencia_Local1_idx` (`idLocal` ASC) VISIBLE,
  INDEX `fk_Ocorrencia_Pessoa1_idx` (`idPessoaSolicitante` ASC) VISIBLE,
  CONSTRAINT `fk_Ocorrencia_Local1`
    FOREIGN KEY (`idLocal`)
    REFERENCES `sos_cidadao`.`Local` (`idLocal`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Ocorrencia_Pessoa1`
    FOREIGN KEY (`idPessoaSolicitante`)
    REFERENCES `sos_cidadao`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`OcorrenciaTipoOcorrencia` (
  `idOcorrenciaTipoOcorrencia` INT(11) NOT NULL AUTO_INCREMENT,
  `idOcorrencia` INT(11) NOT NULL,
  `idTipoOcorrencia` INT(11) NOT NULL,
  PRIMARY KEY (`idOcorrenciaTipoOcorrencia`),
  INDEX `fk_OcorrenciaTipoOcorrencia_Ocorrencia1_idx` (`idOcorrencia` ASC) VISIBLE,
  INDEX `fk_OcorrenciaTipoOcorrencia_TipoOcorrencia1_idx` (`idTipoOcorrencia` ASC) VISIBLE,
  CONSTRAINT `fk_OcorrenciaTipoOcorrencia_Ocorrencia1`
    FOREIGN KEY (`idOcorrencia`)
    REFERENCES `sos_cidadao`.`Ocorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_OcorrenciaTipoOcorrencia_TipoOcorrencia1`
    FOREIGN KEY (`idTipoOcorrencia`)
    REFERENCES `sos_cidadao`.`TipoOcorrencia` (`idTipoOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`Pessoa` (
  `idPessoa` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(250) NOT NULL,
  `sexo` ENUM('F', 'M') NOT NULL DEFAULT 'M',
  `cpf` VARCHAR(15) NOT NULL,
  `telefone` VARCHAR(16) NULL DEFAULT NULL,
  `dataNascimento` DATETIME NOT NULL,
  `email` VARCHAR(250) NOT NULL,
  `login` VARCHAR(30) NOT NULL,
  `senha` TEXT NOT NULL,
  `cep` VARCHAR(10) NOT NULL,
  `rua` VARCHAR(250) NOT NULL,
  `bairro` VARCHAR(250) NOT NULL,
  `cidade` VARCHAR(250) NOT NULL,
  `uf` CHAR(2) NOT NULL,
  `numeroEndereco` INT(11) NULL DEFAULT NULL,
  `tipoPessoa` ENUM('Pessoa', 'Agente', 'Administrador') NOT NULL DEFAULT 'Pessoa',
  `statusPessoa` ENUM('Ativo', 'Inativo', 'Excluido') NOT NULL DEFAULT 'Ativo',
  `dataCadastro` DATETIME NOT NULL,
  `idOrganizacao` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idPessoa`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  UNIQUE INDEX `login_UNIQUE` (`login` ASC) VISIBLE,
  INDEX `fk_Pessoa_Organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  CONSTRAINT `fk_Pessoa_Organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `sos_cidadao`.`Organizacao` (`idOrganizacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`AtendimentoOcorrencia` (
  `idAtendimentoOcorrencia` INT(11) NOT NULL AUTO_INCREMENT,
  `dataCadastro` DATETIME NOT NULL,
  `idOcorrencia` INT(11) NOT NULL,
  `idPessoa` INT(11) NOT NULL,
  PRIMARY KEY (`idAtendimentoOcorrencia`),
  INDEX `fk_AtendimentoOcorrencia_Ocorrencia1_idx` (`idOcorrencia` ASC) VISIBLE,
  INDEX `fk_AtendimentoOcorrencia_Pessoa1_idx` (`idPessoa` ASC) VISIBLE,
  CONSTRAINT `fk_AtendimentoOcorrencia_Ocorrencia1`
    FOREIGN KEY (`idOcorrencia`)
    REFERENCES `sos_cidadao`.`Ocorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_AtendimentoOcorrencia_Pessoa1`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `sos_cidadao`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`Pertence` (
  `idPertence` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(250) NOT NULL,
  `descricao` TEXT NULL DEFAULT NULL,
  `statusPertence` ENUM('Em análise', 'Arquivado', 'Encontrado', 'Entregue') NOT NULL DEFAULT 'Em análise',
  `idOcorrencia` INT(11) NOT NULL,
  `idTipoPertence` INT(11) NOT NULL,
  PRIMARY KEY (`idPertence`),
  INDEX `fk_Pertence_Ocorrencia1_idx` (`idOcorrencia` ASC) VISIBLE,
  INDEX `fk_Pertence_TipoPertence1_idx` (`idTipoPertence` ASC) VISIBLE,
  CONSTRAINT `fk_Pertence_Ocorrencia1`
    FOREIGN KEY (`idOcorrencia`)
    REFERENCES `sos_cidadao`.`Ocorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pertence_TipoPertence1`
    FOREIGN KEY (`idTipoPertence`)
    REFERENCES `sos_cidadao`.`TipoPertence` (`idTipoPertence`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`TipoPertence` (
  `idTipoPertence` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `idOrganizacao` INT(11) NOT NULL,
  PRIMARY KEY (`idTipoPertence`),
  INDEX `fk_TipoPertence_Organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  CONSTRAINT `fk_TipoPertence_Organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `sos_cidadao`.`Organizacao` (`idOrganizacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`Comentario` (
  `idComentario` INT(11) NOT NULL AUTO_INCREMENT,
  `dataCadastro` DATETIME NOT NULL,
  `descricao` TEXT NOT NULL,
  `idOcorrencia` INT(11) NOT NULL,
  `iidPessoa` INT(11) NOT NULL,
  PRIMARY KEY (`idComentario`),
  INDEX `fk_Comentario_Ocorrencia1_idx` (`idOcorrencia` ASC) VISIBLE,
  INDEX `fk_Comentario_Pessoa1_idx` (`iidPessoa` ASC) VISIBLE,
  CONSTRAINT `fk_Comentario_Ocorrencia1`
    FOREIGN KEY (`idOcorrencia`)
    REFERENCES `sos_cidadao`.`Ocorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Comentario_Pessoa1`
    FOREIGN KEY (`iidPessoa`)
    REFERENCES `sos_cidadao`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`Anexo` (
  `idAnexoPertence` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(250) NOT NULL,
  `urlArquivo` VARCHAR(250) NOT NULL,
  `dataCadastro` DATETIME NULL DEFAULT NULL,
  `idOcorrencia` INT(11) NOT NULL,
  `idPessoa` INT(11) NOT NULL,
  PRIMARY KEY (`idAnexoPertence`),
  INDEX `fk_Anexo_Ocorrencia_idx` (`idOcorrencia` ASC) VISIBLE,
  INDEX `fk_Anexo_Pessoa1_idx` (`idPessoa` ASC) VISIBLE,
  CONSTRAINT `fk_Anexo_Ocorrencia`
    FOREIGN KEY (`idOcorrencia`)
    REFERENCES `sos_cidadao`.`Ocorrencia` (`idOcorrencia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Anexo_Pessoa1`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `sos_cidadao`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`TipoOcorrencia` (
  `idTipoOcorrencia` INT(11) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  `idOrganizacao` INT(11) NOT NULL,
  PRIMARY KEY (`idTipoOcorrencia`),
  UNIQUE INDEX `nome_UNIQUE` (`nome` ASC) VISIBLE,
  INDEX `fk_TipoOcorrencia_Organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  CONSTRAINT `fk_TipoOcorrencia_Organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `sos_cidadao`.`Organizacao` (`idOrganizacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`Organizacao` (
  `idOrganizacao` INT(11) NOT NULL,
  `cnpj` VARCHAR(14) NOT NULL,
  `nomeRazao` VARCHAR(250) NOT NULL,
  `nomeFantasia` VARCHAR(250) NOT NULL,
  `cep` VARCHAR(10) NOT NULL,
  `rua` VARCHAR(250) NOT NULL,
  `bairro` VARCHAR(250) NOT NULL,
  `cidade` VARCHAR(250) NOT NULL,
  `uf` CHAR(2) NOT NULL,
  `numeroEndereco` INT(11) NULL DEFAULT NULL,
  `dataRegistro` DATETIME NOT NULL,
  `idPessoa` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`idOrganizacao`),
  INDEX `fk_Organizacao_Pessoa1_idx` (`idPessoa` ASC) VISIBLE,
  UNIQUE INDEX `cpj_UNIQUE` (`cnpj` ASC) VISIBLE,
  CONSTRAINT `fk_Organizacao_Pessoa1`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `sos_cidadao`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `sos_cidadao`.`Local` (
  `idLocal` INT(11) NOT NULL,
  `nome` VARCHAR(250) NULL DEFAULT NULL,
  `latitude` DECIMAL NULL DEFAULT NULL,
  `longitude` DECIMAL NULL DEFAULT NULL,
  `cep` VARCHAR(10) NULL DEFAULT NULL,
  `rua` VARCHAR(250) NULL DEFAULT NULL,
  `bairro` VARCHAR(250) NULL DEFAULT NULL,
  `cidade` VARCHAR(250) NULL DEFAULT NULL,
  `uf` CHAR(2) NULL DEFAULT NULL,
  `numeroEndereco` INT(11) NULL DEFAULT NULL,
  `idOrganizacao` INT(11) NOT NULL,
  PRIMARY KEY (`idLocal`),
  INDEX `fk_Local_Organizacao1_idx` (`idOrganizacao` ASC) VISIBLE,
  CONSTRAINT `fk_Local_Organizacao1`
    FOREIGN KEY (`idOrganizacao`)
    REFERENCES `sos_cidadao`.`Organizacao` (`idOrganizacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
