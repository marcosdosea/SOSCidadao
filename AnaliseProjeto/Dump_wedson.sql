-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: sos_cidadao
-- ------------------------------------------------------
-- Server version	8.0.23

CREATE SCHEMA `sos_cidadao` ;
USE `sos_cidadao` ;

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
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
INSERT INTO `__efmigrationshistory` VALUES ('20210214034937_CreateIdentitySchema','3.1.10');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `anexo`
--

DROP TABLE IF EXISTS `anexo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `anexo` (
  `idAnexoPertence` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) NOT NULL,
  `urlArquivo` varchar(250) NOT NULL,
  `dataCadastro` datetime DEFAULT NULL,
  `idOcorrencia` int NOT NULL,
  `idPessoa` int NOT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(85) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(85) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(85) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(85) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(85) NOT NULL,
  `ProviderKey` varchar(85) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(85) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
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
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(85) NOT NULL,
  `RoleId` varchar(85) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('27f5e888-f43b-44e2-aed3-f91388de9dfb','luizmoitinho2','LUIZMOITINHO2',NULL,NULL,0,'AQAAAAEAACcQAAAAEJrpje/zvhIgNZr/iVNbuuX8q+DEYOmOtdsjnly4XVsov4ixgF4cOMzv14cSyjruug==','2C5KWNCTSHHLZK3NGFD2EYHVFNRVB3LD','59b490e6-a5ad-4249-9cde-c433160205ec',NULL,0,0,NULL,1,0),('43074be3-2369-4089-a4c1-b79c735c5114','luizmoitinho3','LUIZMOITINHO3',NULL,NULL,0,'AQAAAAEAACcQAAAAEEhcWCzJ4RDhKuBC/kNfj+Ka8bCoUH7Up7s8jqSlu8dOO95BrKZJWUtZGySnOqstpg==','324SYOTRJRL5LTVJJVRS3NTWDZGYPYYS','7e80383c-5ac3-4517-b0ff-8e1bfd21de2c',NULL,0,0,NULL,1,0),('75dcaaea-ceb0-40ca-8510-8b6db161cc42','luizmoitinho','LUIZMOITINHO',NULL,NULL,0,'AQAAAAEAACcQAAAAECU4a0BMbtuGuyxBci4JVP4JTHZFF5vN9702PXxDrWD/w9uFhBtdm1QY4my3p1i3Uw==','VKXEJEJUL3S26L4KK4HPGIDKVNSALPF5','b6db0bd4-530a-45ec-b8c6-734d724c8227',NULL,0,0,NULL,1,0),('85f50bcc-8095-48ea-a2e4-281afe02d863','Wedson','WEDSON',NULL,NULL,0,'AQAAAAEAACcQAAAAEFxasSelPViPYVshfUJpaPkVqrH40qCuAZkrj2MEuLWcOYQFJ27jYh6pEtOeHkQVXw==','QKQS5KSMGK747MUPKEJFOEG6REZQD57H','307304c8-9b39-41fa-ae46-7994b26eda3e',NULL,0,0,NULL,1,0),('e3563ca7-142f-435f-ae72-e1cfc2b2d23d','sos_cidadao','SOS_CIDADAO',NULL,NULL,0,'AQAAAAEAACcQAAAAEDmlMKfZCs2TJ+ml8MKt1q0L4XHvaWi3h1yA7doy73hSGz7pQSV1yNfu1xybU3Cq0g==','F2OFGBKIORH5R6XRVL6BQILNWWQZ4WTX','3b907165-74c3-480d-994c-8081c365c500',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(85) NOT NULL,
  `LoginProvider` varchar(85) NOT NULL,
  `Name` varchar(85) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `atendimentoocorrencia`
--

DROP TABLE IF EXISTS `atendimentoocorrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `atendimentoocorrencia` (
  `idAtendimentoOcorrencia` int NOT NULL AUTO_INCREMENT,
  `dataCadastro` datetime NOT NULL,
  `idOcorrencia` int NOT NULL,
  `idPessoa` int NOT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comentario` (
  `idComentario` int NOT NULL AUTO_INCREMENT,
  `dataCadastro` datetime NOT NULL,
  `descricao` text NOT NULL,
  `idOcorrencia` int NOT NULL,
  `iidPessoa` int NOT NULL,
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
/*!40000 ALTER TABLE `comentario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `identityuser`
--

DROP TABLE IF EXISTS `identityuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `identityuser` (
  `Id` varchar(85) NOT NULL,
  `UserName` text,
  `NormalizedUserName` varchar(85) DEFAULT NULL,
  `Email` text,
  `NormalizedEmail` varchar(85) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `identityuser`
--

LOCK TABLES `identityuser` WRITE;
/*!40000 ALTER TABLE `identityuser` DISABLE KEYS */;
/*!40000 ALTER TABLE `identityuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `local`
--

DROP TABLE IF EXISTS `local`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `local` (
  `idLocal` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) DEFAULT NULL,
  `latitude` decimal(10,0) DEFAULT NULL,
  `longitude` decimal(10,0) DEFAULT NULL,
  `cep` varchar(10) DEFAULT NULL,
  `rua` varchar(250) DEFAULT NULL,
  `bairro` varchar(250) DEFAULT NULL,
  `cidade` varchar(250) DEFAULT NULL,
  `uf` char(2) DEFAULT NULL,
  `numeroEndereco` int DEFAULT NULL,
  `idOrganizacao` int NOT NULL,
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
/*!40000 ALTER TABLE `local` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ocorrencia`
--

DROP TABLE IF EXISTS `ocorrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ocorrencia` (
  `idOcorrencia` int NOT NULL AUTO_INCREMENT,
  `dataCadastro` datetime NOT NULL,
  `descricao` text,
  `statusOcorrencia` enum('Em andamento','Em aberto','Arquivada','Atendida','Inativa') NOT NULL DEFAULT 'Em aberto',
  `telefoneContato` varchar(15) DEFAULT NULL,
  `emergencia` tinyint NOT NULL,
  `idPessoaSolicitante` int DEFAULT NULL,
  `idLocal` int NOT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ocorrenciatipoocorrencia` (
  `idOcorrenciaTipoOcorrencia` int NOT NULL AUTO_INCREMENT,
  `idOcorrencia` int NOT NULL,
  `idTipoOcorrencia` int NOT NULL,
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organizacao` (
  `idOrganizacao` int NOT NULL AUTO_INCREMENT,
  `cnpj` varchar(14) NOT NULL,
  `nomeRazao` varchar(250) NOT NULL,
  `nomeFantasia` varchar(250) NOT NULL,
  `cep` varchar(10) NOT NULL,
  `rua` varchar(250) NOT NULL,
  `bairro` varchar(250) NOT NULL,
  `cidade` varchar(250) NOT NULL,
  `uf` char(2) NOT NULL,
  `numeroEndereco` int DEFAULT NULL,
  `dataRegistro` datetime NOT NULL,
  `idPessoa` int DEFAULT NULL,
  PRIMARY KEY (`idOrganizacao`),
  UNIQUE KEY `cpj_UNIQUE` (`cnpj`),
  KEY `fk_Organizacao_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_Organizacao_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`idPessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizacao`
--

LOCK TABLES `organizacao` WRITE;
/*!40000 ALTER TABLE `organizacao` DISABLE KEYS */;
INSERT INTO `organizacao` VALUES (1,'00000000000000','Sem Organização','Sem Organização','0000000000','0','0','0','0',0,'2021-01-01 00:00:00',NULL);
/*!40000 ALTER TABLE `organizacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pertence`
--

DROP TABLE IF EXISTS `pertence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pertence` (
  `idPertence` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) NOT NULL,
  `descricao` text,
  `statusPertence` enum('Em análise','Arquivado','Encontrado','Entregue') NOT NULL DEFAULT 'Em análise',
  `idOcorrencia` int NOT NULL,
  `idTipoPertence` int NOT NULL,
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
/*!40000 ALTER TABLE `pertence` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `idPessoa` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(250) NOT NULL,
  `sexo` enum('F','M') NOT NULL DEFAULT 'M',
  `cpf` varchar(15) NOT NULL,
  `telefone` varchar(16) DEFAULT NULL,
  `dataNascimento` datetime NOT NULL,
  `email` varchar(250) NOT NULL,
  `cep` varchar(10) NOT NULL,
  `rua` varchar(250) NOT NULL,
  `bairro` varchar(250) NOT NULL,
  `cidade` varchar(250) NOT NULL,
  `uf` char(2) NOT NULL,
  `numeroEndereco` int DEFAULT NULL,
  `tipoPessoa` enum('Pessoa','Agente','Administrador') NOT NULL DEFAULT 'Pessoa',
  `statusPessoa` enum('Ativo','Inativo','Excluido') NOT NULL DEFAULT 'Ativo',
  `dataCadastro` datetime NOT NULL,
  `idOrganizacao` int DEFAULT NULL,
  PRIMARY KEY (`idPessoa`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  KEY `fk_Pessoa_Organizacao1_idx` (`idOrganizacao`),
  CONSTRAINT `fk_Pessoa_Organizacao1` FOREIGN KEY (`idOrganizacao`) REFERENCES `organizacao` (`idOrganizacao`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'luiz carlos costa moitinho','M','07462030552','11969744218','2021-01-22 00:00:00','luizcarloscmoitinho@gmail.com','48200-00','Teste','Teste','Macapa','BA',12,'Pessoa','Ativo','0001-01-01 00:00:00',NULL),(8,'root_admin','F','99999999999','11969744218','2021-02-06 00:00:00','root@soscidadao.com','48200-00','Av. olimpio','Sergipe','Macapa','AP',NULL,'Pessoa','Ativo','0001-01-01 00:00:00',NULL);
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoocorrencia`
--

DROP TABLE IF EXISTS `tipoocorrencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipoocorrencia` (
  `idTipoOcorrencia` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `idOrganizacao` int NOT NULL,
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
/*!40000 ALTER TABLE `tipoocorrencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipopertence`
--

DROP TABLE IF EXISTS `tipopertence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipopertence` (
  `idTipoPertence` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `idOrganizacao` int NOT NULL,
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

-- Dump completed on 2021-07-17 17:53:10
