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
-- Table `MiRegistro`.`PreguntaSeguridad`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`PreguntaSeguridad` (
  `IdPregunta` INT NOT NULL AUTO_INCREMENT,
  `Pregunta` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdPregunta`),
  UNIQUE INDEX `Id_UNIQUE` (`IdPregunta` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`UsuarioSeguridad`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`UsuarioSeguridad` (
  `IdUsuarioSeguridad` INT NOT NULL,
  `FkIdPregunta` INT NOT NULL,
  `Respuesta` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdUsuarioSeguridad`),
  INDEX `FkPregunta_PreguntaId_idx` (`FkIdPregunta` ASC) VISIBLE,
  CONSTRAINT `FkPregunta_PreguntaId`
    FOREIGN KEY (`FkIdPregunta`)
    REFERENCES `MiRegistro`.`PreguntaSeguridad` (`IdPregunta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Perfil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Perfil` (
  `IdPerfil` INT NOT NULL,
  `Nombre` VARCHAR(45) NULL,
  `Apellido` VARCHAR(45) NULL,
  `Nick` VARCHAR(10) NOT NULL,
  `FechaCumpleaños` DATE NULL,
  PRIMARY KEY (`IdPerfil`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Usuario` (
  `IdUsuario` INT NOT NULL AUTO_INCREMENT,
  `FkIdPerfil` INT NOT NULL,
  `FkIdSeguridad` INT NULL,
  `Usuario` VARCHAR(45) NOT NULL,
  `Contraseña` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(75) NOT NULL,
  `UltimoAcceso` DATE NULL,
  PRIMARY KEY (`IdUsuario`),
  UNIQUE INDEX `Id_UNIQUE` (`IdUsuario` ASC) VISIBLE,
  UNIQUE INDEX `User_UNIQUE` (`Usuario` ASC) VISIBLE,
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE,
  INDEX `Fk_security_idx` (`FkIdSeguridad` ASC) VISIBLE,
  INDEX `Fk_profile_idx` (`FkIdPerfil` ASC) VISIBLE,
  CONSTRAINT `Fk_security`
    FOREIGN KEY (`FkIdSeguridad`)
    REFERENCES `MiRegistro`.`UsuarioSeguridad` (`IdUsuarioSeguridad`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_profile`
    FOREIGN KEY (`FkIdPerfil`)
    REFERENCES `MiRegistro`.`Perfil` (`IdPerfil`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Rol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Rol` (
  `IdRol` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(15) NULL,
  PRIMARY KEY (`IdRol`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Usuario_Rol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Usuario_Rol` (
  `IdUsuario` INT NOT NULL,
  `IdRol` INT NOT NULL,
  `FechaInicio` DATE NULL,
  `FechaFin` DATE NULL,
  PRIMARY KEY (`IdUsuario`, `IdRol`),
  INDEX `Fk_roleid_idx` (`IdRol` ASC) VISIBLE,
  CONSTRAINT `Fk_userid`
    FOREIGN KEY (`IdUsuario`)
    REFERENCES `MiRegistro`.`Usuario` (`IdUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_roleid`
    FOREIGN KEY (`IdRol`)
    REFERENCES `MiRegistro`.`Rol` (`IdRol`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Empresa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Empresa` (
  `IdEmpresa` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(35) NOT NULL,
  `FechaApertura` DATE NULL,
  PRIMARY KEY (`IdEmpresa`),
  UNIQUE INDEX `IdEmpresa_UNIQUE` (`IdEmpresa` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Empleado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Empleado` (
  `IdEmpleado` INT NOT NULL,
  `FkIdUsuario` INT NOT NULL,
  `FkIdEmpresa` INT NOT NULL,
  `EstadoActual` TINYINT NULL,
  PRIMARY KEY (`IdEmpleado`),
  INDEX `Fk_userid_idx` (`FkIdUsuario` ASC) VISIBLE,
  INDEX `Fk_company_id_idx` (`FkIdEmpresa` ASC) VISIBLE,
  UNIQUE INDEX `IdEmpleado_UNIQUE` (`IdEmpleado` ASC) VISIBLE,
  CONSTRAINT `FkEmployee_userid`
    FOREIGN KEY (`FkIdUsuario`)
    REFERENCES `MiRegistro`.`Usuario` (`IdUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_company_id`
    FOREIGN KEY (`FkIdEmpresa`)
    REFERENCES `MiRegistro`.`Empresa` (`IdEmpresa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Pais`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Pais` (
  `IdPais` INT NOT NULL AUTO_INCREMENT,
  `NombrePais` VARCHAR(45) NULL,
  PRIMARY KEY (`IdPais`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Direccion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Direccion` (
  `IdDireccion` INT NOT NULL AUTO_INCREMENT,
  `FkIdPais` INT NULL DEFAULT 1,
  `Ciudad` VARCHAR(45) NULL,
  PRIMARY KEY (`IdDireccion`),
  INDEX `Fk_countryid_idx` (`FkIdPais` ASC) VISIBLE,
  CONSTRAINT `Fk_countryid`
    FOREIGN KEY (`FkIdPais`)
    REFERENCES `MiRegistro`.`Pais` (`IdPais`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Perfil_Direccion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Perfil_Direccion` (
  `IdPerfil` INT NOT NULL,
  `IdDireccion` INT NOT NULL,
  `Calle` VARCHAR(45) NULL,
  PRIMARY KEY (`IdPerfil`, `IdDireccion`),
  INDEX `Fk_adressid_idx` (`IdDireccion` ASC) VISIBLE,
  CONSTRAINT `Fk_profileid`
    FOREIGN KEY (`IdPerfil`)
    REFERENCES `MiRegistro`.`Perfil` (`IdPerfil`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_adressid`
    FOREIGN KEY (`IdDireccion`)
    REFERENCES `MiRegistro`.`Direccion` (`IdDireccion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Direccion_Empresa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Direccion_Empresa` (
  `IdEmpresa` INT NOT NULL,
  `IdDireccion` INT NOT NULL,
  `Calle` VARCHAR(45) NULL,
  PRIMARY KEY (`IdEmpresa`, `IdDireccion`),
  INDEX `Fk_addressid_idx` (`IdDireccion` ASC) VISIBLE,
  CONSTRAINT `Fk_companyid`
    FOREIGN KEY (`IdEmpresa`)
    REFERENCES `MiRegistro`.`Empresa` (`IdEmpresa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_addressid`
    FOREIGN KEY (`IdDireccion`)
    REFERENCES `MiRegistro`.`Direccion` (`IdDireccion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`ClaseFormulario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`ClaseFormulario` (
  `IdClase` INT NOT NULL AUTO_INCREMENT,
  `NombreClase` VARCHAR(12) NULL,
  PRIMARY KEY (`IdClase`),
  UNIQUE INDEX `Id_UNIQUE` (`IdClase` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`CategoriaFormulario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`CategoriaFormulario` (
  `IdCategoria` INT NOT NULL AUTO_INCREMENT,
  `NombreCategoria` VARCHAR(15) NULL,
  PRIMARY KEY (`IdCategoria`),
  UNIQUE INDEX `Id_UNIQUE` (`IdCategoria` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`TipoFormulario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`TipoFormulario` (
  `IdTipoFormulario` INT NOT NULL AUTO_INCREMENT,
  `FkIdClase` INT NOT NULL DEFAULT 1,
  `FkIdCategoria` INT NOT NULL DEFAULT 1,
  PRIMARY KEY (`IdTipoFormulario`),
  UNIQUE INDEX `Id_UNIQUE` (`IdTipoFormulario` ASC) VISIBLE,
  INDEX `FkClass_ClassID_idx` (`FkIdClase` ASC) VISIBLE,
  INDEX `FkClass_CategoryID_idx` (`FkIdCategoria` ASC) VISIBLE,
  CONSTRAINT `Fk_TipoFormulario_IdClase`
    FOREIGN KEY (`FkIdClase`)
    REFERENCES `MiRegistro`.`ClaseFormulario` (`IdClase`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_TipoFormulario_IdCategoria`
    FOREIGN KEY (`FkIdCategoria`)
    REFERENCES `MiRegistro`.`CategoriaFormulario` (`IdCategoria`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`NumeracionFormulario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`NumeracionFormulario` (
  `IdNumearcion` INT NOT NULL,
  `Numearcion` VARCHAR(15) NULL DEFAULT '444null',
  `Stock` INT NULL DEFAULT 0,
  `Deleted` TINYINT NULL,
  PRIMARY KEY (`IdNumearcion`),
  UNIQUE INDEX `Id_UNIQUE` (`IdNumearcion` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Formulario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Formulario` (
  `IdFormulario` INT NOT NULL AUTO_INCREMENT,
  `FkIdEmpresa` INT NOT NULL,
  `FkIdTipo` INT NOT NULL,
  `FkIdNumeracion` INT NOT NULL,
  `UltimaActualizacion` DATETIME NULL,
  `Deleted` TINYINT NULL,
  PRIMARY KEY (`IdFormulario`),
  UNIQUE INDEX `Id_UNIQUE` (`IdFormulario` ASC) VISIBLE,
  INDEX `Fk_companyid_idx` (`FkIdEmpresa` ASC) VISIBLE,
  INDEX `FkFormulario_typeid_idx` (`FkIdTipo` ASC) VISIBLE,
  INDEX `FkFormulario_numeracionid_idx` (`FkIdNumeracion` ASC) VISIBLE,
  CONSTRAINT `FkFormulario_companyid`
    FOREIGN KEY (`FkIdEmpresa`)
    REFERENCES `MiRegistro`.`Empresa` (`IdEmpresa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkFormulario_typeid`
    FOREIGN KEY (`FkIdTipo`)
    REFERENCES `MiRegistro`.`TipoFormulario` (`IdTipoFormulario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkFormulario_numeracionid`
    FOREIGN KEY (`FkIdNumeracion`)
    REFERENCES `MiRegistro`.`NumeracionFormulario` (`IdNumearcion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`CategoriaTramite`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`CategoriaTramite` (
  `IdCategoriaTramite` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NULL,
  PRIMARY KEY (`IdCategoriaTramite`),
  UNIQUE INDEX `IdCategoriaTramite_UNIQUE` (`IdCategoriaTramite` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Tramite`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Tramite` (
  `IdTramite` INT NOT NULL AUTO_INCREMENT,
  `Dominio` VARCHAR(7) NOT NULL,
  `FkIdCategoria` INT NOT NULL,
  `FkIdEmpresa` INT NOT NULL,
  `Fecha` DATE NULL,
  `Observaciones` VARCHAR(60) NULL,
  `Deleted` TINYINT NULL,
  PRIMARY KEY (`IdTramite`),
  UNIQUE INDEX `Dominio_UNIQUE` (`Dominio` ASC) VISIBLE,
  INDEX `Fk_tramiteid_idx` (`FkIdCategoria` ASC) VISIBLE,
  INDEX `Fk_companyid_idx` (`FkIdEmpresa` ASC) VISIBLE,
  CONSTRAINT `Fk_tramiteid`
    FOREIGN KEY (`FkIdCategoria`)
    REFERENCES `MiRegistro`.`CategoriaTramite` (`IdCategoriaTramite`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkTramite_companyid`
    FOREIGN KEY (`FkIdEmpresa`)
    REFERENCES `MiRegistro`.`Empresa` (`IdEmpresa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Parametro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Parametro` (
  `IdParametro` INT NOT NULL AUTO_INCREMENT,
  `NombreParametro` VARCHAR(15) NULL,
  PRIMARY KEY (`IdParametro`),
  UNIQUE INDEX `Id_UNIQUE` (`IdParametro` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Formulario_Parametro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Formulario_Parametro` (
  `IdFormulario` INT NOT NULL,
  `IdParametro` INT NOT NULL,
  `ValorParametro` INT NULL DEFAULT 0,
  PRIMARY KEY (`IdFormulario`, `IdParametro`),
  INDEX `Fk_parametrosid_idx` (`IdParametro` ASC) VISIBLE,
  CONSTRAINT `FkParametros_formularioid`
    FOREIGN KEY (`IdFormulario`)
    REFERENCES `MiRegistro`.`Formulario` (`IdFormulario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_parametrosid`
    FOREIGN KEY (`IdParametro`)
    REFERENCES `MiRegistro`.`Parametro` (`IdParametro`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`CategoriaAlerta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`CategoriaAlerta` (
  `IdCategoriaAlerta` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(15) NULL,
  PRIMARY KEY (`IdCategoriaAlerta`),
  UNIQUE INDEX `IdCategoriaAlerta_UNIQUE` (`IdCategoriaAlerta` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Alerta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Alerta` (
  `IdAlerta` INT NOT NULL AUTO_INCREMENT,
  `FkIdTipoAlerta` INT NULL,
  `Descripcion` VARCHAR(45) NULL,
  `EstadoActual` TINYINT NULL,
  PRIMARY KEY (`IdAlerta`),
  INDEX `FkAlerta_IdTipoAlerta_idx` (`FkIdTipoAlerta` ASC) VISIBLE,
  CONSTRAINT `FkAlerta_IdTipoAlerta`
    FOREIGN KEY (`FkIdTipoAlerta`)
    REFERENCES `MiRegistro`.`CategoriaAlerta` (`IdCategoriaAlerta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Formulario_Alerta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Formulario_Alerta` (
  `IdFormulario` INT NOT NULL,
  `IdAlerta` INT NOT NULL,
  `FkIdEmpleado` INT NULL,
  `FechaAlerta` DATETIME NULL,
  PRIMARY KEY (`IdFormulario`, `IdAlerta`),
  INDEX `Fk_Formulario_IdAlerta_idx` (`IdAlerta` ASC) VISIBLE,
  CONSTRAINT `Fk_Formulario_IdAlerta`
    FOREIGN KEY (`IdAlerta`)
    REFERENCES `MiRegistro`.`Alerta` (`IdAlerta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `Fk_Alerta_IdFormulario`
    FOREIGN KEY (`IdFormulario`)
    REFERENCES `MiRegistro`.`Formulario` (`IdFormulario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`CategoriaError`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`CategoriaError` (
  `IdCategoriaError` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(15) NULL,
  PRIMARY KEY (`IdCategoriaError`),
  UNIQUE INDEX `IdCategoriaError_UNIQUE` (`IdCategoriaError` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Tramite_Error`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Tramite_Error` (
  `IdTramite` INT NOT NULL,
  `IdCategoriaError` INT NOT NULL,
  `FkIdEmpleado` INT NOT NULL,
  `Resuelto` TINYINT NULL DEFAULT 0,
  INDEX `Fk_errorid_idx` (`IdCategoriaError` ASC) VISIBLE,
  INDEX `Fk_employeeid_idx` (`FkIdEmpleado` ASC) VISIBLE,
  INDEX `Fk_tramiteid_idx` (`IdTramite` ASC) VISIBLE,
  PRIMARY KEY (`IdTramite`, `IdCategoriaError`),
  CONSTRAINT `FkErrores_errorid`
    FOREIGN KEY (`IdCategoriaError`)
    REFERENCES `MiRegistro`.`CategoriaError` (`IdCategoriaError`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkErrores_employeeid`
    FOREIGN KEY (`FkIdEmpleado`)
    REFERENCES `MiRegistro`.`Empleado` (`IdEmpleado`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkErrores_tramiteid`
    FOREIGN KEY (`IdTramite`)
    REFERENCES `MiRegistro`.`Tramite` (`IdTramite`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`EtapaTramite`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`EtapaTramite` (
  `IdEtapaTramite` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(14) NULL,
  PRIMARY KEY (`IdEtapaTramite`),
  UNIQUE INDEX `IdEtapaTramite_UNIQUE` (`IdEtapaTramite` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MiRegistro`.`Tramite_Proceso`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `MiRegistro`.`Tramite_Proceso` (
  `IdTramite` INT NOT NULL,
  `IdEtapaTramite` INT NOT NULL,
  `FkIdEmpleado` INT NOT NULL,
  `EstadoActual` TINYINT NULL DEFAULT 0,
  PRIMARY KEY (`IdTramite`, `IdEtapaTramite`),
  INDEX `FkProceso_EtapaId_idx` (`IdEtapaTramite` ASC) VISIBLE,
  INDEX `FkProceso_EmployeeId_idx` (`FkIdEmpleado` ASC) VISIBLE,
  CONSTRAINT `FkProceso_EtapaId`
    FOREIGN KEY (`IdEtapaTramite`)
    REFERENCES `MiRegistro`.`EtapaTramite` (`IdEtapaTramite`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkProceso_TramiteId`
    FOREIGN KEY (`IdTramite`)
    REFERENCES `MiRegistro`.`Tramite` (`IdTramite`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FkProceso_EmployeeId`
    FOREIGN KEY (`FkIdEmpleado`)
    REFERENCES `MiRegistro`.`Empleado` (`IdEmpleado`)
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
