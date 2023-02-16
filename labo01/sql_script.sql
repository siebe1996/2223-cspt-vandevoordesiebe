-- MySQL Script generated by MySQL Workbench
-- Wed Feb 15 22:15:10 2023
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`members`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`members` ;

CREATE TABLE IF NOT EXISTS `mydb`.`members` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `date_of_birth` DATETIME NOT NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `gender` CHAR(1) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb3;

CREATE UNIQUE INDEX `id_UNIQUE` ON `mydb`.`members` (`id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `mydb`.`coaches`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`coaches` ;

CREATE TABLE IF NOT EXISTS `mydb`.`coaches` (
  `id` INT NOT NULL,
  `level` ENUM('INITIATOR', 'INSTRUCTOR', 'TRAINER_B', 'TRAINER_A') NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `id_coach`
    FOREIGN KEY (`id`)
    REFERENCES `mydb`.`members` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`swimmers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`swimmers` ;

CREATE TABLE IF NOT EXISTS `mydb`.`swimmers` (
  `id` INT NOT NULL,
  `fina_points` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `id_swimmer`
    FOREIGN KEY (`id`)
    REFERENCES `mydb`.`members` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`swimming_pool`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`swimming_pool` ;

CREATE TABLE IF NOT EXISTS `mydb`.`swimming_pool` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `city` VARCHAR(255) NOT NULL,
  `lane_length` ENUM('_25', '_50') NOT NULL,
  `name` VARCHAR(255) NOT NULL,
  `street` VARCHAR(45) NOT NULL,
  `zip_code` INT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb3;

CREATE UNIQUE INDEX `id_UNIQUE` ON `mydb`.`swimming_pool` (`id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `mydb`.`workouts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`workouts` ;

CREATE TABLE IF NOT EXISTS `mydb`.`workouts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `coach_id` INT NOT NULL,
  `duration` INT NOT NULL,
  `schedule` DATETIME NOT NULL,
  `swimming_pool_id` INT NOT NULL,
  `type` ENUM('ENDURANCE', 'POWER', 'INTERVAL') NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `coach_id`
    FOREIGN KEY (`coach_id`)
    REFERENCES `mydb`.`coaches` (`id`),
  CONSTRAINT `swimming_pool_id`
    FOREIGN KEY (`swimming_pool_id`)
    REFERENCES `mydb`.`swimming_pool` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb3;

CREATE UNIQUE INDEX `id_UNIQUE` ON `mydb`.`workouts` (`id` ASC) VISIBLE;

CREATE INDEX `id_idx` ON `mydb`.`workouts` (`coach_id` ASC) VISIBLE;

CREATE INDEX `swimming_pool_id_idx` ON `mydb`.`workouts` (`swimming_pool_id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `mydb`.`swimmers_workouts`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`swimmers_workouts` ;

CREATE TABLE IF NOT EXISTS `mydb`.`swimmers_workouts` (
  `swimmer_id` INT NOT NULL,
  `workout_id` INT NOT NULL,
  PRIMARY KEY (`swimmer_id`, `workout_id`),
  CONSTRAINT `swimmer_id`
    FOREIGN KEY (`swimmer_id`)
    REFERENCES `mydb`.`swimmers` (`id`),
  CONSTRAINT `workout_id`
    FOREIGN KEY (`workout_id`)
    REFERENCES `mydb`.`workouts` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;

CREATE INDEX `workout_id_idx` ON `mydb`.`swimmers_workouts` (`workout_id` ASC) VISIBLE;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
