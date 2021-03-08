USE miregistro;

/* Cargar categorias tramites*/
ALTER TABLE categoriatramite AUTO_INCREMENT = 10;

INSERT INTO categoriatramite (Nombre)
VALUES(('Informe historico de dominio'),
	  ('Cambio de domicilio con pedido'),
      ('Canc prenda inc c'),
	  ('Canc prenda inc a/b'),
      ('Informe multa e infracciones'),
	  ('Asignacion de Cedula'),
      ('Modificacion Prenda'),
	  ('Informe Estado de Dominio por correo'),
      ('Transferencia c/pedido'),
	  ('Fotocopia de constancias registrales'),
	  ('Informe historico por corresponder'),
	  ('Reposicion de placa metalica'),
      ('Devolucion del automotor al titular'),
	  ('Certificados dominiales'),
      ('Denuncia de robo'),
	  ('Dominiales'));

SELECT * FROM categoriatramite;

/* Cargar etapas tramites */
INSERT INTO etapatramite (Nombre)
VALUES ('Proceso'),
	   ('Inscripcion');

SELECT * FROM etapatramite;
ALTER TABLE etapatramite AUTO_INCREMENT = 1;
DELETE FROM etapatramite WHERE IdEtapaTramite = 1;

/* Cargar categoria de errores */

INSERT INTO categoriaerror (Nombre)
VALUES  ('Error categoria A'),
		('Error categoria B');
        
SELECT * FROM categoriaerror;
