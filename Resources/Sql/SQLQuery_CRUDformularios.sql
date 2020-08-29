use DB_Friday

SELECT id_formulario as ID, name_categoria as Categoria , name_elemento as Objeto,
numeracion as Numeracion, stock as 'Stock actual', ultima_actualizacion as 'Ultima actualizacion'
FROM 
Formularios 
inner join CategoriasFormularios on Formularios.cod_categoria = CategoriasFormularios.cod_categoria 
inner join CategoriasElementos on Formularios.cod_elemento = CategoriasElementos.cod_elemento
WHERE  CategoriasElementos.cod_elemento = '3'
ORDER BY stock, ultima_actualizacion

INSERT INTO Formularios VALUES ('47', '3', '-', '10', GETDATE())
INSERT INTO Formularios VALUES ('48', '3', '-', '70', GETDATE())

INSERT INTO CategoriasElementos VALUES ('Auto', '')
INSERT INTO CategoriasElementos VALUES ('Moto', '')
INSERT INTO CategoriasElementos VALUES ('Varios', '')

INSERT INTO CategoriasFormularios VALUES ('RESMAS', 'Moto')
INSERT INTO CategoriasFormularios VALUES ('TONER', 'Moto')

UPDATE  CategoriasFormularios 
    SET descripcion_categoria = 'Varios'
    WHERE cod_categoria = '48'

SELECT * FROM CategoriasElementos
SELECT * FROM CategoriasFormularios
SELECT * FROM Formularios

DELETE FROM Formularios
DBCC CHECKIDENT ('[Formularios]', RESEED, 0);
DELETE FROM CategoriasFormularios
DBCC CHECKIDENT ('[CategoriasFormularios]', RESEED, 0);

DELETE FROM CategoriasFormularios WHERE cod_categoria = '28'

SELECT cod_categoria,name_categoria FROM CategoriasFormularios WHERE descripcion_categoria = 'Auto'