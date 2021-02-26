-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema MiRegistro
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema MiRegistro
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `MiRegistro` DEFAULT CHARACTER SET utf8 ;
-- -----------------------------------------------------
-- Schema matias_sqlfundamentalscourse
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema matias_sqlfundamentalscourse
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `matias_sqlfundamentalscourse` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `MiRegistro` ;

-- -----------------------------------------------------
-- Table `MiRegistro`.`Security_user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Security_user` (
  `Id` INT NOT NULL,
  `Question_id` INT NULL,
  `Answer` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Profile`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Profile` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(150) NULL,
  `Nickname` VARCHAR(45) NULL,
  `Date_birthday` DATE NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Users` (
  `Id` INT NOT NULL,
  `Profile_id` INT NULL,
  `Security_id` INT NULL,
  `User` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Last_access` DATE NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE,
  UNIQUE INDEX `User_UNIQUE` (`User` ASC) VISIBLE,
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE,
  INDEX `Fk_security_idx` (`Security_id` ASC) VISIBLE,
  INDEX `Fk_profile_idx` (`Profile_id` ASC) VISIBLE,
  CONSTRAINT `Fk_security`
    FOREIGN KEY (`Security_id`)
    REFERENCES `MiRegistro`.`Security_user` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_profile`
    FOREIGN KEY (`Profile_id`)
    REFERENCES `MiRegistro`.`Profile` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Roles` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`User_roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`User_roles` (
  `User_id` INT NOT NULL,
  `Role_id` INT NOT NULL,
  `Start_time` DATE NULL,
  `End_time` DATE NULL,
  PRIMARY KEY (`User_id`, `Role_id`),
  INDEX `Fk_roleid_idx` (`Role_id` ASC) VISIBLE,
  CONSTRAINT `Fk_userid`
    FOREIGN KEY (`User_id`)
    REFERENCES `MiRegistro`.`Users` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_roleid`
    FOREIGN KEY (`Role_id`)
    REFERENCES `MiRegistro`.`Roles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Company`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Company` (
  `Id` INT NOT NULL,
  `Name` INT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Employee` (
  `Id` INT NOT NULL,
  `User_id` INT NOT NULL,
  `Company_id` INT NULL,
  `Notes` VARCHAR(240) NULL,
  `Status` TINYINT NULL,
  PRIMARY KEY (`Id`, `User_id`),
  INDEX `Fk_userid_idx` (`User_id` ASC) VISIBLE,
  INDEX `Fk_company_id_idx` (`Company_id` ASC) VISIBLE,
  CONSTRAINT `FkEmployee_userid`
    FOREIGN KEY (`User_id`)
    REFERENCES `MiRegistro`.`Users` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_company_id`
    FOREIGN KEY (`Company_id`)
    REFERENCES `MiRegistro`.`Company` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Country_adress`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Country_adress` (
  `Id` INT NOT NULL,
  `Country` INT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Adress`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Adress` (
  `Id` INT NOT NULL,
  `Country_id` INT NULL,
  `City` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`),
  INDEX `Fk_countryid_idx` (`Country_id` ASC) VISIBLE,
  CONSTRAINT `Fk_countryid`
    FOREIGN KEY (`Country_id`)
    REFERENCES `MiRegistro`.`Country_adress` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Profile_Adress`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Profile_Adress` (
  `Profile_id` INT NOT NULL,
  `Adress_id` INT NOT NULL,
  `Street` VARCHAR(45) NULL,
  PRIMARY KEY (`Profile_id`, `Adress_id`),
  INDEX `Fk_adressid_idx` (`Adress_id` ASC) VISIBLE,
  CONSTRAINT `Fk_profileid`
    FOREIGN KEY (`Profile_id`)
    REFERENCES `MiRegistro`.`Profile` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_adressid`
    FOREIGN KEY (`Adress_id`)
    REFERENCES `MiRegistro`.`Adress` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Company_Adress`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Company_Adress` (
  `Company_id` INT NOT NULL,
  `Adress_id` INT NOT NULL,
  `Street` VARCHAR(45) NULL,
  PRIMARY KEY (`Company_id`, `Adress_id`),
  INDEX `Fk_addressid_idx` (`Adress_id` ASC) VISIBLE,
  CONSTRAINT `Fk_companyid`
    FOREIGN KEY (`Company_id`)
    REFERENCES `MiRegistro`.`Company` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_addressid`
    FOREIGN KEY (`Adress_id`)
    REFERENCES `MiRegistro`.`Adress` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Class_formularios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Class_formularios` (
  `Id` INT NOT NULL,
  `Name` INT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Categoria_formularios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Categoria_formularios` (
  `Id` INT NOT NULL,
  `Name` INT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Class_Categoria_Formularios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Class_Categoria_Formularios` (
  `Id` INT NOT NULL,
  `Class_id` INT NULL,
  `Category_id` INT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE,
  INDEX `FkClass_Classid_idx` (`Class_id` ASC) VISIBLE,
  INDEX `FkCategory_Categoryid_idx` (`Category_id` ASC) VISIBLE,
  CONSTRAINT `FkClass_Classid`
    FOREIGN KEY (`Class_id`)
    REFERENCES `MiRegistro`.`Class_formularios` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkCategory_Categoryid`
    FOREIGN KEY (`Category_id`)
    REFERENCES `MiRegistro`.`Categoria_formularios` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Formularios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Formularios` (
  `Id` INT NOT NULL,
  `Company_id` INT NOT NULL,
  `Category_id` INT NOT NULL,
  `Last_upgrade` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE,
  INDEX `Fk_companyid_idx` (`Company_id` ASC) VISIBLE,
  INDEX `FkFormulario_categoryid_idx` (`Category_id` ASC) VISIBLE,
  CONSTRAINT `FkFormulario_companyid`
    FOREIGN KEY (`Company_id`)
    REFERENCES `MiRegistro`.`Company` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkFormulario_categoryid`
    FOREIGN KEY (`Category_id`)
    REFERENCES `MiRegistro`.`Class_Categoria_Formularios` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Categorias_tramites`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Categorias_tramites` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Tramites`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Tramites` (
  `Id` INT NOT NULL,
  `Dominio` VARCHAR(6) NULL,
  `Date` DATE NULL,
  `Tramite_id` INT NOT NULL,
  `Company_id` INT NULL,
  `Observaciones` VARCHAR(240) NULL,
  `Deleted_at` DATE NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Dominio_UNIQUE` (`Dominio` ASC) VISIBLE,
  INDEX `Fk_tramiteid_idx` (`Tramite_id` ASC) VISIBLE,
  INDEX `Fk_companyid_idx` (`Company_id` ASC) VISIBLE,
  CONSTRAINT `Fk_tramiteid`
    FOREIGN KEY (`Tramite_id`)
    REFERENCES `MiRegistro`.`Categorias_tramites` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkTramite_companyid`
    FOREIGN KEY (`Company_id`)
    REFERENCES `MiRegistro`.`Company` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Numeracion_formularios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Numeracion_formularios` (
  `Id` INT NOT NULL,
  `Formulario_id` INT NOT NULL,
  `Numearcion` VARCHAR(45) NOT NULL,
  `Stock` INT NOT NULL,
  `Deleted` TINYINT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE,
  UNIQUE INDEX `User_UNIQUE` (`Numearcion` ASC) VISIBLE,
  INDEX `Fk_formularioid_idx` (`Formulario_id` ASC) VISIBLE,
  CONSTRAINT `Fk_formularioid`
    FOREIGN KEY (`Formulario_id`)
    REFERENCES `MiRegistro`.`Formularios` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Parametros`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Parametros` (
  `Id` INT NOT NULL,
  `Name` INT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Formulario_parametros`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Formulario_parametros` (
  `Formulario_id` INT NOT NULL,
  `Parametros_id` INT NOT NULL,
  `Value` INT NULL,
  PRIMARY KEY (`Formulario_id`, `Parametros_id`),
  INDEX `Fk_parametrosid_idx` (`Parametros_id` ASC) VISIBLE,
  CONSTRAINT `FkParametros_formularioid`
    FOREIGN KEY (`Formulario_id`)
    REFERENCES `MiRegistro`.`Formularios` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_parametrosid`
    FOREIGN KEY (`Parametros_id`)
    REFERENCES `MiRegistro`.`Parametros` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Alertas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Alertas` (
  `Id` INT NOT NULL,
  `Employee_id` INT NOT NULL,
  `Date` DATE NULL,
  `Description` VARCHAR(240) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Formulario_Alertas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Formulario_Alertas` (
  `Formulario_id` INT NOT NULL,
  `Alerta_id` INT NOT NULL,
  PRIMARY KEY (`Formulario_id`, `Alerta_id`),
  INDEX `Fk_alertasid_idx` (`Alerta_id` ASC) VISIBLE,
  CONSTRAINT `FkFormulario_alertasid`
    FOREIGN KEY (`Alerta_id`)
    REFERENCES `MiRegistro`.`Alertas` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkAlertas_formularioid`
    FOREIGN KEY (`Formulario_id`)
    REFERENCES `MiRegistro`.`Formularios` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Categoria_errores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Categoria_errores` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(120) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Tramite_errores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Tramite_errores` (
  `Id` INT NOT NULL,
  `Tramite_id` INT NOT NULL,
  `Error_id` INT NOT NULL,
  `Employee_id` INT NOT NULL,
  `Resolved` TINYINT NULL,
  PRIMARY KEY (`Id`),
  INDEX `Fk_errorid_idx` (`Error_id` ASC) VISIBLE,
  INDEX `Fk_employeeid_idx` (`Employee_id` ASC) VISIBLE,
  INDEX `Fk_tramiteid_idx` (`Tramite_id` ASC) VISIBLE,
  CONSTRAINT `FkErrores_errorid`
    FOREIGN KEY (`Error_id`)
    REFERENCES `MiRegistro`.`Categoria_errores` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkErrores_employeeid`
    FOREIGN KEY (`Employee_id`)
    REFERENCES `MiRegistro`.`Employee` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkErrores_tramiteid`
    FOREIGN KEY (`Tramite_id`)
    REFERENCES `MiRegistro`.`Tramites` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Etapas_tramites`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Etapas_tramites` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(120) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Tramite_proceso`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Tramite_proceso` (
  `Id` INT NOT NULL,
  `Tramite_id` INT NOT NULL,
  `Proceso_id` INT NOT NULL,
  `Employee_id` INT NOT NULL,
  `Status` TINYINT NULL DEFAULT 0,
  PRIMARY KEY (`Id`),
  INDEX `Fk_procesoid_idx` (`Proceso_id` ASC) VISIBLE,
  INDEX `Fk_employeeid_idx` (`Employee_id` ASC) VISIBLE,
  INDEX `Fk_tramiteid_idx` (`Tramite_id` ASC) VISIBLE,
  CONSTRAINT `FkProceso_procesoid`
    FOREIGN KEY (`Proceso_id`)
    REFERENCES `MiRegistro`.`Etapas_tramites` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkProceso_employeeid`
    FOREIGN KEY (`Employee_id`)
    REFERENCES `MiRegistro`.`Employee` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkProceso_tramiteid`
    FOREIGN KEY (`Tramite_id`)
    REFERENCES `MiRegistro`.`Tramites` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `matias_sqlfundamentalscourse` ;

-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`contact_persons`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`contact_persons` (
  `id` INT NOT NULL,
  `name` VARCHAR(300) NULL DEFAULT NULL,
  `role` VARCHAR(300) NULL DEFAULT NULL,
  `phone_number` VARCHAR(12) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`contractors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`contractors` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(300) NOT NULL,
  `last_name` VARCHAR(300) NOT NULL,
  `phone_number` VARCHAR(20) NULL DEFAULT NULL,
  `hire_date` DATE NOT NULL,
  `contract_length` INT NOT NULL,
  `hourly_wage` FLOAT(6,2) NOT NULL,
  `agency_id` INT NOT NULL,
  `has_suscription` TINYINT(1) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `idx_agencyid` (`agency_id` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`zips`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`zips` (
  `zip` VARCHAR(5) NOT NULL,
  `city` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`zip`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`customers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`customers` (
  `id` INT NOT NULL,
  `name` VARCHAR(255) NULL DEFAULT NULL,
  `industry` VARCHAR(255) NULL DEFAULT NULL,
  `contact_person_id` INT NULL DEFAULT NULL,
  `address` VARCHAR(255) NULL DEFAULT NULL,
  `zip` VARCHAR(5) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_contact_person` (`contact_person_id` ASC) VISIBLE,
  INDEX `fk_zip` (`zip` ASC) VISIBLE,
  CONSTRAINT `fk_contact_person`
    FOREIGN KEY (`contact_person_id`)
    REFERENCES `matias_sqlfundamentalscourse`.`contact_persons` (`id`),
  CONSTRAINT `fk_zip`
    FOREIGN KEY (`zip`)
    REFERENCES `matias_sqlfundamentalscourse`.`zips` (`zip`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`employees`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`employees` (
  `id` INT NOT NULL,
  `e_name` VARCHAR(300) NULL DEFAULT NULL,
  `hourly_wage` FLOAT(5,2) NULL DEFAULT NULL,
  `hire_date` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`projects`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`projects` (
  `id` INT NOT NULL,
  `name` VARCHAR(300) NULL DEFAULT NULL,
  `value` FLOAT(5,2) NULL DEFAULT NULL,
  `start_date` DATE NULL DEFAULT NULL,
  `end_date` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`job_orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`job_orders` (
  `id` INT NOT NULL,
  `employee_id` INT NOT NULL,
  `project_id` INT NOT NULL,
  `description` VARCHAR(300) NULL DEFAULT NULL,
  `order_datetime` TIMESTAMP NULL DEFAULT NULL,
  `quantity` INT NULL DEFAULT NULL,
  `price` FLOAT(6,2) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `employee_id` (`employee_id` ASC) VISIBLE,
  INDEX `project_id` (`project_id` ASC) VISIBLE,
  CONSTRAINT `job_orders_ibfk_1`
    FOREIGN KEY (`employee_id`)
    REFERENCES `matias_sqlfundamentalscourse`.`employees` (`id`),
  CONSTRAINT `job_orders_ibfk_2`
    FOREIGN KEY (`project_id`)
    REFERENCES `matias_sqlfundamentalscourse`.`projects` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`project_feedbacks`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`project_feedbacks` (
  `id` INT NOT NULL,
  `project_id` INT NULL DEFAULT NULL,
  `customer_id` INT NULL DEFAULT NULL,
  `project_feedback` VARCHAR(12) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `project_id` (`project_id` ASC) VISIBLE,
  INDEX `customer_id` (`customer_id` ASC) VISIBLE,
  CONSTRAINT `project_feedbacks_ibfk_1`
    FOREIGN KEY (`project_id`)
    REFERENCES `matias_sqlfundamentalscourse`.`projects` (`id`),
  CONSTRAINT `project_feedbacks_ibfk_2`
    FOREIGN KEY (`customer_id`)
    REFERENCES `matias_sqlfundamentalscourse`.`customers` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `matias_sqlfundamentalscourse`.`projects_employees`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `matias_sqlfundamentalscourse`.`projects_employees` (
  `employee_id` INT NOT NULL,
  `project_id` INT NOT NULL,
  `hours` FLOAT(5,2) NULL DEFAULT NULL,
  PRIMARY KEY (`employee_id`, `project_id`),
  INDEX `project_id` (`project_id` ASC) VISIBLE,
  CONSTRAINT `projects_employees_ibfk_1`
    FOREIGN KEY (`employee_id`)
    REFERENCES `matias_sqlfundamentalscourse`.`employees` (`id`),
  CONSTRAINT `projects_employees_ibfk_2`
    FOREIGN KEY (`project_id`)
    REFERENCES `matias_sqlfundamentalscourse`.`projects` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
