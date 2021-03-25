USE miregistro;

/* Insertar empresa */
INSERT INTO Empresa (Nombre, FechaApertura)
VALUES ('Registro El Calafate', NOW());

UPDATE Empresa SET Contraseña = '19573' WHERE IdEmpresa = 1;
/* Insertar direccion empresa*/ 
INSERT INTO Direccion_Empresa
VALUES (1, 2, 'Av. 17 de Octubre');

/* Consulta de empresa */
SELECT E.Nombre, E.FechaApertura, P.NombrePais, D.Ciudad 
FROM Empresa E
JOIN Direccion_empresa De ON De.IdEmpresa = E.IdEmpresa
JOIN Direccion D ON D.IdDireccion = De.IdDireccion
JOIN pais P ON P.IdPais = D.FkIdPais;

SELECT * FROM Empresa;

SELECT * FROM pais;

INSERT INTO pais (NickPais, NombrePais) VALUES('AR', 'Argentina');
INSERT INTO pais (NickPais, NombrePais) VALUES('UY', 'Uruguay');

INSERT INTO direccion (Ciudad)
VALUES ('Rafaela'),
	    ('El Calafate');

SELECT P.NombrePais, D.Ciudad 
FROM direccion D
JOIN pais P ON P.IdPais = D.FkIdPais;