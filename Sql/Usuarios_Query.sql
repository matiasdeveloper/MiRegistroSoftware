USE miregistro;

INSERT rol (Nombre, Descripcion) 
VALUES ('Analisis de estadisticas', 'Permisos para leer estadisticas de empleados'),
	   ('Administrador de tramites', 'Encargado con permisos lectura / escritura en tramites'),
	   ('Administrador de formularios', 'Encargado con permisos lectura / escritura en formularios'),
       ('Acceso a caja', 'Permisos de acceso a caja');
	
SELECT * FROM rol;

ALTER TABLE rol AUTO_INCREMENT = 1;
DELETE FROM rol WHERE IdRol = 2;

INSERT INTO preguntaseguridad (Pregunta)
VALUES ('¿Cual era el nombre de tu primer mascota?'),
('¿Cual es el nombre de la ciudad en la que naciste?'),
('¿Cual era tu apodo de infancia?'),
('¿Cual es el nombre de la ciudad en la que se conocieron tus padres?'),
('¿Cual es el nombre de tu primo mayor?'),
('¿Como se llamaba la primera escuela a la que asististe?');

SELECT * FROM preguntaseguridad;

/* Insert nuevos usuarios */

INSERT INTO usuario(FkIdPerfil, Usuario, Contraseña, Email)
VALUES(3, 'valeriacalafate', '12345', 'valericalafate@gmail.com');

INSERT INTO perfil (IdPerfil, Nombre, Apellido, Nick, FechaCumpleaños)
VALUES (3, 'Valeria', 'Calafate', 'Pao', NOW());

INSERT INTO empleado (IdEmpleado, FkIdUsuario, FkIdEmpresa, EstadoActual)
VALUES
(
	3,
	5,
    1,
    1
);

DELETE FROM empleado WHERE idempleado = 1001;

UPDATE empleado set IdEmpleado = 1 where IdEmpleado = 1001;

SELECT * FROM usuario;
SELECT * FROM empleado;

/*Autentificar*/
SELECT * FROM usuario WHERE usuario='noelicalafate' AND contraseña='12345' LIMIT 1;

SELECT U.IdUsuario, P.Nombre, P.Apellido, P.FechaCumpleaños, U.Usuario, U.Email
FROM usuario U
INNER JOIN perfil P ON P.IdPerfil = U.FkIdPerfil;

ALTER TABLE usuario AUTO_INCREMENT = 1;
DELETE FROM usuario WHERE idusuario = 2;
