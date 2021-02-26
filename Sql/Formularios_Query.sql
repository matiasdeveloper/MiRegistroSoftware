USE miregistro;

INSERT INTO class_formularios 
VALUES(1, 'Autos'),
	  (2, 'Motos'),
      (3, 'Varios');
      
INSERT INTO categoria_formularios 
VALUES(1, '2'),
	  (2, '3D'),
      (3, '4'),
      (4, '4D');

INSERT INTO class_categoria_formularios 
VALUES(1,1, 1),
	  (2,1, 2),
      (3,1, 3),
      (4,1, 4);

SELECT * FROM class_formularios;
SELECT * FROM categoria_formularios;

SELECT CC.name AS Clase, CF.Name AS Categoria
FROM class_categoria_formularios CCF
JOIN categoria_formularios CF ON CCF.Category_id = CF.Id
JOIN class_formularios CC ON CCF.Class_id = CC.Id
WHERE CC.name = 'Autos';

INSERT INTO Formularios
VALUES (1, 144, 4, NULL);

SELECT F.Id, C.Name, CC.Name AS Clase, CF.Name AS Categoria, Last_upgrade AS 'Ultima actualizacion'
FROM Formularios as F
INNER JOIN class_categoria_formularios CCF ON F.Category_id = CCF.Id
JOIN categoria_formularios CF ON CCF.Category_id = CF.Id
JOIN class_formularios CC ON CCF.Class_id = CC.Id
JOIN company C ON C.id = F.company_id;