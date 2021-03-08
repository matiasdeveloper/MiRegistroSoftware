USE miregistro;

/* Cargar clases*/
INSERT INTO claseformulario (NombreClase) 
VALUES('Auto'),
	  ('Moto'),
      ('Varios');

SELECT * FROM claseformulario;

/* Cargar categorias motos, autos varios*/
INSERT INTO categoriaformulario (NombreCategoria)
VALUES(('2'),
	  ('3D'),
      ('4'),
      ('4D'),
	  ('5'),
      ('8'),
      ('8D'),
	  ('11'),
      ('12'),
      ('53'),
	  ('57'),
      ('59U'),
      ('60'),
	  ('88'),
      ('99'),
      ('121'),
	  ('153'),
      ('TP'),
      ('13D'),
	  ('CHAPA OK'),
      ('LEG SURA'),
      ('OBLEA RTO'),
	  ('CEDULA'),
      ('STICK BAJA C/R'),
      ('PLACA PROV'),
      ('CERT BAJ DESAR'),
	  ('TITULO DIGITAL'),
	  ('08'),
	  ('31J'));
INSERT INTO categoriaformulario (NombreCategoria)
VALUES(('3'),
      ('31A'),
	  ('57'),
      ('59'),
      ('RESMAS'),
      ('TONER'),
      ('HOJAS REGISTRO'));

SELECT * FROM categoriaformulario;

/* Cargar datos motos y autos*/
INSERT INTO tipoformulario (FkIdClase, FkIdCategoria)
VALUES((2,1),
	  (2,44),
      (2,3),
      (2,5),
	  (2,6),
      (2,7),
      (2,8),
	  (2,9),
      (2,45),
      (2,46),
	  (2,47),
      (2,15),
      (2,18),
	  (2,19),
      (2,20),
      (2,21),
	  (2,23),
      (2,27));
INSERT INTO tipoformulario (FkIdClase, FkIdCategoria)
VALUES(3,48),
	  (3,49),
      (3,50);

SELECT * FROM claseformulario;
SELECT * FROM categoriaformulario;

/* Consulta Categorias*/
# Consulta Por Categoria
(SELECT Tf.IdTipoFormulario AS 'ID', Clf.NombreClase AS 'NAME', Cf.NombreCategoria AS 'CATEGORY' 
FROM tipoformulario Tf
JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
HAVING Clf.NombreClase = 'Moto');
# Consulta Count
(SELECT Tf.IdTipoFormulario AS 'ID', Clf.NombreClase AS 'NAME', Count(Cf.NombreCategoria) AS 'CATEGORY' 
FROM tipoformulario Tf
JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
GROUP BY Clf.NombreClase);

/*INSERT INTO Formularios*/
SELECT * FROM Formulario;
SELECT * FROM NumeracionFormulario;
SELECT * FROM Formulario_parametro;

INSERT INTO Formulario (FkIdEmpresa, FkIdTipo, UltimaActualizacion)
VALUES (1, 34, NOW());
SET @last_id_numeracion = LAST_INSERT_ID();

INSERT INTO NumeracionFormulario (FkIdFormulario, Numearcion, Stock)
VALUES (@last_id_numeracion, 'AA124', 50),
       (@last_id_numeracion, 'AA125', 45);

INSERT INTO Formulario_Parametro (IdFormulario, IdParametro, ValorParametro)
VALUES (@last_id_numeracion, 1, 100),
(@last_id_numeracion, 2, 50),
(@last_id_numeracion, 3, 10);

/*Consulta Formularios ID, EMPRESA, CLASE, CATEGORIA, NUMEREACION*/
SELECT F.IdFormulario AS ID, E.Nombre AS Empresa, Clf.NombreClase AS Clase, Cf.NombreCategoria AS Categoria, N.Numearcion AS Numeracion, Sum(N.Stock) AS Stock, F.ultimaactualizacion
FROM Formulario F
INNER JOIN TipoFormulario Tf ON Tf.IdTipoFormulario = F.FkIdTipo
INNER JOIN Empresa E On E.IdEmpresa = F.FkIdEmpresa
JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
JOIN numeracionformulario N ON N.FkIdFormulario = F.IdFormulario
GROUP BY N.IdNumearcion;

SELECT N.numeracion, Clf.NombreClase AS Clase, Cf.NombreCategoria, Sum(N.Stock)
FROM numeracionformulario N
JOIN Formulario F ON F.IdFormulario = N.FkIdFormulario
INNER JOIN TipoFormulario Tf ON Tf.IdTipoFormulario = F.FkIdTipo
JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
GROUP BY N.FkIdFormulario;

/* Parametros formularios */
INSERT INTO parametro (NombreParametro)
VALUES ('Stock alto'),
	   ('Stock medio'),
       ('Stock bajo');
       
/*Consulta parametros formulario*/
SELECT * FROM parametro;

SELECT F.IdFormulario AS ID, Clf.NombreClase AS Clase, Cf.NombreCategoria AS Categoria, P.NombreParametro, Fp.ValorParametro
FROM Formulario F
JOIN formulario_parametro Fp ON Fp.IdFormulario = F.IdFormulario
JOIN parametro P ON Fp.IdParametro = P.IdParametro
INNER JOIN TipoFormulario Tf ON Tf.IdTipoFormulario = F.FkIdTipo
JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
ORDER BY Cf.NombreCategoria;


