-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema restaurante
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `restaurante` ;

-- -----------------------------------------------------
-- Schema restaurante
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `restaurante` DEFAULT CHARACTER SET utf8 ;
USE `restaurante` ;

-- -----------------------------------------------------
-- Table `restaurante`.`TipoRestaurante`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`TipoRestaurante` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`restaurante`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`restaurante` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `idTipoRestaurante` INT UNSIGNED NOT NULL,
  `cnpj` VARCHAR(15) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  `cep` VARCHAR(8) NULL,
  `rua` VARCHAR(45) NULL,
  `bairro` VARCHAR(45) NULL,
  `cidade` VARCHAR(45) NULL,
  `estado` VARCHAR(2) NULL,
  `telefone1` VARCHAR(14) NULL,
  `telefone2` VARCHAR(14) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_restaurante_TipoRestaurante1_idx` (`idTipoRestaurante` ASC) VISIBLE,
  CONSTRAINT `fk_restaurante_TipoRestaurante1`
    FOREIGN KEY (`idTipoRestaurante`)
    REFERENCES `restaurante`.`TipoRestaurante` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`TipoFuncionario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`TipoFuncionario` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`Funcionario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`Funcionario` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `cpf` VARCHAR(11) NOT NULL,
  `cep` VARCHAR(8) NULL,
  `rua` VARCHAR(45) NULL,
  `bairro` VARCHAR(45) NULL,
  `cidade` VARCHAR(45) NULL,
  `estado` VARCHAR(2) NULL,
  `telefone1` VARCHAR(11) NULL,
  `telefone2` VARCHAR(11) NULL,
  `idRestaurante` INT UNSIGNED NOT NULL,
  `idTipoFuncionario` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_garcom_restaurante1_idx` (`idRestaurante` ASC) VISIBLE,
  INDEX `fk_Funcionario_TipoFuncionario1_idx` (`idTipoFuncionario` ASC) VISIBLE,
  CONSTRAINT `fk_garcom_restaurante1`
    FOREIGN KEY (`idRestaurante`)
    REFERENCES `restaurante`.`restaurante` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_Funcionario_TipoFuncionario1`
    FOREIGN KEY (`idTipoFuncionario`)
    REFERENCES `restaurante`.`TipoFuncionario` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`mesa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`mesa` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `identificacao` VARCHAR(45) NOT NULL,
  `idRestaurante` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_mesa_restaurante_idx` (`idRestaurante` ASC) VISIBLE,
  CONSTRAINT `fk_mesa_restaurante`
    FOREIGN KEY (`idRestaurante`)
    REFERENCES `restaurante`.`restaurante` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`GrupoCardapio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`GrupoCardapio` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`itemcardapio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`itemcardapio` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `preco` DECIMAL(10,2) NULL,
  `detalhes` VARCHAR(500) NULL,
  `ativo` TINYINT NOT NULL DEFAULT 1,
  `disponivel` VARCHAR(45) NOT NULL DEFAULT '1',
  `idRestaurante` INT UNSIGNED NOT NULL,
  `idGrupoCardapio` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_itemcardapio_restaurante1_idx` (`idRestaurante` ASC) VISIBLE,
  INDEX `fk_itemcardapio_GrupoCardapio1_idx` (`idGrupoCardapio` ASC) VISIBLE,
  CONSTRAINT `fk_itemcardapio_restaurante1`
    FOREIGN KEY (`idRestaurante`)
    REFERENCES `restaurante`.`restaurante` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_itemcardapio_GrupoCardapio1`
    FOREIGN KEY (`idGrupoCardapio`)
    REFERENCES `restaurante`.`GrupoCardapio` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`Atendimento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`Atendimento` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `dataHoraInicio` DATETIME NOT NULL,
  `dataHoraFim` DATETIME NULL,
  `status` ENUM('I', 'C', 'F') NOT NULL DEFAULT 'I' COMMENT 'I - INICIADO\nC- CANCELADO\nF - FINALIZADO\n',
  `totalConta` DECIMAL(10,2) NOT NULL,
  `totalServico` DECIMAL(10,2) NOT NULL,
  `totalDesconto` DECIMAL(10,2) NOT NULL,
  `total` DECIMAL(10,2) NOT NULL,
  `idMesa` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Atendimento_mesa1_idx` (`idMesa` ASC) VISIBLE,
  CONSTRAINT `fk_Atendimento_mesa1`
    FOREIGN KEY (`idMesa`)
    REFERENCES `restaurante`.`mesa` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`pedido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`pedido` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `dataHoraSolicitacao` DATETIME NOT NULL,
  `daaHoraAtendimento` DATETIME NOT NULL,
  `idAtendimento` INT UNSIGNED NOT NULL,
  `idGarcom` INT UNSIGNED NOT NULL,
  `status` ENUM('S', 'C', 'A') NOT NULL COMMENT 'S - SOLICITADO\nC - CANCELADO\nA - ATENDIDO',
  `Pedidocol` VARCHAR(45) NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Pedido_Atendimento1_idx` (`idAtendimento` ASC) VISIBLE,
  INDEX `fk_Pedido_garcom1_idx` (`idGarcom` ASC) VISIBLE,
  CONSTRAINT `fk_Pedido_Atendimento1`
    FOREIGN KEY (`idAtendimento`)
    REFERENCES `restaurante`.`Atendimento` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_Pedido_garcom1`
    FOREIGN KEY (`idGarcom`)
    REFERENCES `restaurante`.`Funcionario` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`PedidoItemCardapio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`PedidoItemCardapio` (
  `idItemCardapio` INT UNSIGNED NOT NULL,
  `idPedido` INT UNSIGNED NOT NULL,
  `quantidade` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`idItemCardapio`, `idPedido`),
  INDEX `fk_itemcardapio_has_Pedido_Pedido1_idx` (`idPedido` ASC) VISIBLE,
  INDEX `fk_itemcardapio_has_Pedido_itemcardapio1_idx` (`idItemCardapio` ASC) VISIBLE,
  CONSTRAINT `fk_itemcardapio_has_Pedido_itemcardapio1`
    FOREIGN KEY (`idItemCardapio`)
    REFERENCES `restaurante`.`itemcardapio` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT `fk_itemcardapio_has_Pedido_Pedido1`
    FOREIGN KEY (`idPedido`)
    REFERENCES `restaurante`.`pedido` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`FormaPagamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`FormaPagamento` (
  `id` INT UNSIGNED NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `restaurante`.`Pagamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurante`.`Pagamento` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `dataHora` DATETIME NOT NULL,
  `valor` DECIMAL(10,2) NOT NULL,
  `idAtendimento` INT UNSIGNED NOT NULL,
  `idFormaPagamento` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Pagamento_Atendimento1_idx` (`idAtendimento` ASC) VISIBLE,
  INDEX `fk_Pagamento_FormaPagamento1_idx` (`idFormaPagamento` ASC) VISIBLE,
  CONSTRAINT `fk_Pagamento_Atendimento1`
    FOREIGN KEY (`idAtendimento`)
    REFERENCES `restaurante`.`Atendimento` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pagamento_FormaPagamento1`
    FOREIGN KEY (`idFormaPagamento`)
    REFERENCES `restaurante`.`FormaPagamento` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
