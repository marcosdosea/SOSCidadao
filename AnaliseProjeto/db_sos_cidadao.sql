CREATE DATABASE  IF NOT EXISTS `sos_cidadao` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `sos_cidadao`;
-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: sos_cidadao
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `anexo`
--

DROP TABLE IF EXISTS `anexo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `anexo` (
  `idAnexoPertence` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) NOT NULL,
  `urlArquivo` varchar(250) NOT NULL,
  `dataCadastro` datetime DEFAULT NULL,
  `idOcorrencia` int(11) NOT NULL,
  `idPessoa` int(11) NOT NULL,
  PRIMARY KEY (`idAnexoPertence`),
  KEY `fk_Anexo_Ocorrencia_idx` (`idOcorrencia`),
  KEY `fk_Anexo_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_Anexo_Ocorrencia` FOREIGN KEY (`idOcorrencia`) REFERENCES `ocorrencia` (`idOcorrencia`),
  CONSTRAINT `fk_Anexo_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anexo`
--

LOCK TABLES `anexo` WRITE;
/*!40000 ALTER TABLE `anexo` DISABLE KEYS */;
/*!40000 ALTER TABLE `anexo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetRoleClaims_AspNetRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `FK_AspNetUserClaims_AspNetUsers_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `FK_AspNetUserLogins_AspNetUsers_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('2aa0ef3b-3777-4a60-ab86-30b24dec5d68','luizcarlos@hotmail.com','LUIZCARLOS@HOTMAIL.COM','luizcarlos@hotmail.com','LUIZCARLOS@HOTMAIL.COM',0,'AQAAAAEAACcQAAAAEKHUvI6DukyS1JFVCAeUXlYnxO1nfLtaURJdONdtbx2b5N5yAvXGPrML3oWzx4WVxg==','AQC7WFIM247BDKDYWVN6JSL4SVKHEAQT','0fd56631-f443-48a0-9a31-d07e6fb9c17d',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `atendimentoocorrencia`
--

DROP TABLE IF EXISTS `atendimentoocorrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `atendimentoocorrencia` (
  `idAtendimentoOcorrencia` int(11) NOT NULL AUTO_INCREMENT,
  `dataCadastro` datetime NOT NULL,
  `idOcorrencia` int(11) NOT NULL,
  `idPessoa` int(11) NOT NULL,
  PRIMARY KEY (`idAtendimentoOcorrencia`),
  KEY `fk_AtendimentoOcorrencia_Ocorrencia1_idx` (`idOcorrencia`),
  KEY `fk_AtendimentoOcorrencia_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_AtendimentoOcorrencia_Ocorrencia1` FOREIGN KEY (`idOcorrencia`) REFERENCES `ocorrencia` (`idOcorrencia`),
  CONSTRAINT `fk_AtendimentoOcorrencia_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atendimentoocorrencia`
--

LOCK TABLES `atendimentoocorrencia` WRITE;
/*!40000 ALTER TABLE `atendimentoocorrencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `atendimentoocorrencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comentario`
--

DROP TABLE IF EXISTS `comentario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `comentario` (
  `idComentario` int(11) NOT NULL AUTO_INCREMENT,
  `dataCadastro` datetime NOT NULL,
  `descricao` text NOT NULL,
  `idOcorrencia` int(11) NOT NULL,
  `iidPessoa` int(11) NOT NULL,
  PRIMARY KEY (`idComentario`),
  KEY `fk_Comentario_Ocorrencia1_idx` (`idOcorrencia`),
  KEY `fk_Comentario_Pessoa1_idx` (`iidPessoa`),
  CONSTRAINT `fk_Comentario_Ocorrencia1` FOREIGN KEY (`idOcorrencia`) REFERENCES `ocorrencia` (`idOcorrencia`),
  CONSTRAINT `fk_Comentario_Pessoa1` FOREIGN KEY (`iidPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comentario`
--

LOCK TABLES `comentario` WRITE;
/*!40000 ALTER TABLE `comentario` DISABLE KEYS */;
INSERT INTO `comentario` VALUES (7,'2021-01-18 23:57:16','teste comentario',3,1),(8,'2021-01-19 00:23:38','teste',3,1),(11,'2021-01-19 00:24:20','123123',3,1);
/*!40000 ALTER TABLE `comentario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `local`
--

DROP TABLE IF EXISTS `local`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `local` (
  `idLocal` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) DEFAULT NULL,
  `latitude` decimal(10,0) DEFAULT NULL,
  `longitude` decimal(10,0) DEFAULT NULL,
  `cep` varchar(10) DEFAULT NULL,
  `rua` varchar(250) DEFAULT NULL,
  `bairro` varchar(250) DEFAULT NULL,
  `cidade` varchar(250) DEFAULT NULL,
  `uf` char(2) DEFAULT NULL,
  `numeroEndereco` int(11) DEFAULT NULL,
  `idOrganizacao` int(11) NOT NULL,
  PRIMARY KEY (`idLocal`),
  KEY `fk_Local_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_Local_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `local`
--

LOCK TABLES `local` WRITE;
/*!40000 ALTER TABLE `local` DISABLE KEYS */;
INSERT INTO `local` VALUES (1,'root_admin',12500,12500,'00000-00','Rua Vereador Olimpio Grande','Centro','Itabaiana','SE',108,1);
/*!40000 ALTER TABLE `local` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ocorrencia`
--

DROP TABLE IF EXISTS `ocorrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ocorrencia` (
  `idOcorrencia` int(11) NOT NULL AUTO_INCREMENT,
  `dataCadastro` datetime NOT NULL,
  `descricao` text,
  `statusOcorrencia` enum('Em andamento','Em aberto','Arquivada','Atendida','Inativa') NOT NULL DEFAULT 'Em aberto',
  `telefoneContato` varchar(15) DEFAULT NULL,
  `emergencia` tinyint(4) NOT NULL,
  `idPessoaSolicitante` int(11) DEFAULT NULL,
  `idLocal` int(11) NOT NULL,
  PRIMARY KEY (`idOcorrencia`),
  KEY `fk_Ocorrencia_Local1_idx` (`idLocal`),
  KEY `fk_Ocorrencia_Pessoa1_idx` (`idPessoaSolicitante`),
  CONSTRAINT `fk_Ocorrencia_Local1` FOREIGN KEY (`idLocal`) REFERENCES `local` (`idLocal`),
  CONSTRAINT `fk_Ocorrencia_Pessoa1` FOREIGN KEY (`idPessoaSolicitante`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ocorrencia`
--

LOCK TABLES `ocorrencia` WRITE;
/*!40000 ALTER TABLE `ocorrencia` DISABLE KEYS */;
INSERT INTO `ocorrencia` VALUES (3,'2021-01-18 00:00:00','root','Em aberto','9999999',0,1,1);
/*!40000 ALTER TABLE `ocorrencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ocorrenciatipoocorrencia`
--

DROP TABLE IF EXISTS `ocorrenciatipoocorrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ocorrenciatipoocorrencia` (
  `idOcorrenciaTipoOcorrencia` int(11) NOT NULL AUTO_INCREMENT,
  `idOcorrencia` int(11) NOT NULL,
  `idTipoOcorrencia` int(11) NOT NULL,
  PRIMARY KEY (`idOcorrenciaTipoOcorrencia`),
  KEY `fk_OcorrenciaTipoOcorrencia_Ocorrencia1_idx` (`idOcorrencia`),
  KEY `fk_OcorrenciaTipoOcorrencia_TipoOcorrencia1_idx` (`idTipoOcorrencia`),
  CONSTRAINT `fk_OcorrenciaTipoOcorrencia_Ocorrencia1` FOREIGN KEY (`idOcorrencia`) REFERENCES `ocorrencia` (`idOcorrencia`),
  CONSTRAINT `fk_OcorrenciaTipoOcorrencia_TipoOcorrencia1` FOREIGN KEY (`idTipoOcorrencia`) REFERENCES `tipoocorrencia` (`idTipoOcorrencia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ocorrenciatipoocorrencia`
--

LOCK TABLES `ocorrenciatipoocorrencia` WRITE;
/*!40000 ALTER TABLE `ocorrenciatipoocorrencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `ocorrenciatipoocorrencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizacao`
--

DROP TABLE IF EXISTS `organizacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `organizacao` (
  `idOrganizacao` int(11) NOT NULL AUTO_INCREMENT,
  `cnpj` varchar(14) NOT NULL,
  `nomeRazao` varchar(250) NOT NULL,
  `nomeFantasia` varchar(250) NOT NULL,
  `cep` varchar(10) NOT NULL,
  `rua` varchar(250) NOT NULL,
  `bairro` varchar(250) NOT NULL,
  `cidade` varchar(250) NOT NULL,
  `uf` char(2) NOT NULL,
  `numeroEndereco` int(11) DEFAULT NULL,
  `dataRegistro` datetime NOT NULL,
  `idPessoa` int(11) DEFAULT NULL,
  PRIMARY KEY (`idOrganizacao`),
  UNIQUE KEY `cpj_UNIQUE` (`cnpj`),
  KEY `fk_Organizacao_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_Organizacao_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizacao`
--

LOCK TABLES `organizacao` WRITE;
/*!40000 ALTER TABLE `organizacao` DISABLE KEYS */;
INSERT INTO `organizacao` VALUES (1,'123456789','SOS Cidadao Softwares Solutions','SOS Cidadao','00000-00','Rua Vereador Olimpio Grande','Centro','Itabaiana','SE',1,'2021-01-01 00:00:00',NULL),(7,'12345678914','Campus Prof. Alberto Carvalho - ITA','Universidade Federal de Sergipe','49506-03','Av. Vereador Olímpio Grande','Porto','Itabaiana','SE',0,'2021-01-31 17:15:29',1);
/*!40000 ALTER TABLE `organizacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pertence`
--

DROP TABLE IF EXISTS `pertence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pertence` (
  `idPertence` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) NOT NULL,
  `descricao` text,
  `statusPertence` enum('Em análise','Arquivado','Encontrado','Entregue') NOT NULL DEFAULT 'Em análise',
  `idOcorrencia` int(11) NOT NULL,
  `idTipoPertence` int(11) NOT NULL,
  PRIMARY KEY (`idPertence`),
  KEY `fk_Pertence_Ocorrencia1_idx` (`idOcorrencia`),
  KEY `fk_Pertence_TipoPertence1_idx` (`idTipoPertence`),
  CONSTRAINT `fk_Pertence_Ocorrencia1` FOREIGN KEY (`idOcorrencia`) REFERENCES `ocorrencia` (`idOcorrencia`),
  CONSTRAINT `fk_Pertence_TipoPertence1` FOREIGN KEY (`idTipoPertence`) REFERENCES `tipopertence` (`idTipoPertence`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pertence`
--

LOCK TABLES `pertence` WRITE;
/*!40000 ALTER TABLE `pertence` DISABLE KEYS */;
INSERT INTO `pertence` VALUES (6,'Moto G','Tela quebrada e adesivo da coca cola atrás','Em análise',3,7);
/*!40000 ALTER TABLE `pertence` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pessoa` (
  `idPessoa` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) NOT NULL,
  `sexo` enum('F','M') NOT NULL DEFAULT 'M',
  `cpf` varchar(15) NOT NULL,
  `telefone` varchar(16) DEFAULT NULL,
  `dataNascimento` datetime NOT NULL,
  `email` varchar(250) NOT NULL,
  `login` varchar(30) NOT NULL,
  `senha` text NOT NULL,
  `cep` varchar(10) NOT NULL,
  `rua` varchar(250) NOT NULL,
  `bairro` varchar(250) NOT NULL,
  `cidade` varchar(250) NOT NULL,
  `uf` char(2) NOT NULL,
  `numeroEndereco` int(11) DEFAULT NULL,
  `tipoPessoa` enum('Pessoa','Agente','Administrador') NOT NULL DEFAULT 'Pessoa',
  `statusPessoa` enum('Ativo','Inativo','Excluido') NOT NULL DEFAULT 'Ativo',
  `dataCadastro` datetime NOT NULL,
  `idOrganizacao` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPessoa`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `login_UNIQUE` (`login`),
  KEY `fk_Pessoa_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_Pessoa_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'luiz carlos costa moitinho','M','07462030552','11969744218','2021-01-22 00:00:00','luizcarloscmoitinho@gmail.com','teste','123123','48200-00','Teste','Teste','Macapa','BA',12,'Pessoa','Ativo','0001-01-01 00:00:00',1),(8,'root_admin','F','99999999999','11969744218','2021-02-06 00:00:00','root@soscidadao.com','root_admin','123123','48200-00','Av. olimpio','Sergipe','Macapa','AP',NULL,'Pessoa','Ativo','0001-01-01 00:00:00',NULL);
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoocorrencia`
--

DROP TABLE IF EXISTS `tipoocorrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tipoocorrencia` (
  `idTipoOcorrencia` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `idOrganizacao` int(11) NOT NULL,
  PRIMARY KEY (`idTipoOcorrencia`),
  UNIQUE KEY `nome_UNIQUE` (`nome`),
  KEY `fk_TipoOcorrencia_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_TipoOcorrencia_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoocorrencia`
--

LOCK TABLES `tipoocorrencia` WRITE;
/*!40000 ALTER TABLE `tipoocorrencia` DISABLE KEYS */;
INSERT INTO `tipoocorrencia` VALUES (3,'Assédio',1),(4,'Assédio Sexual',7);
/*!40000 ALTER TABLE `tipoocorrencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipopertence`
--

DROP TABLE IF EXISTS `tipopertence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tipopertence` (
  `idTipoPertence` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `idOrganizacao` int(11) NOT NULL,
  PRIMARY KEY (`idTipoPertence`),
  KEY `fk_TipoPertence_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_TipoPertence_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipopertence`
--

LOCK TABLES `tipopertence` WRITE;
/*!40000 ALTER TABLE `tipopertence` DISABLE KEYS */;
INSERT INTO `tipopertence` VALUES (5,'Celular',1),(6,'Notebook',1),(7,'Moto 150v',1);
/*!40000 ALTER TABLE `tipopertence` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'sos_cidadao'
--

--
-- Dumping routines for database 'sos_cidadao'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-09 13:07:04
