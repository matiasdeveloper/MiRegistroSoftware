use miRegistro

insert into Users VALUES ('matiasdeveloper',CAST('12345' AS VARBINARY(MAX)), 'Administrador')
insert into Info_users VALUES(SCOPE_IDENTITY(),'Matias','Mati', 'mativallejos@outlook.com', GETDATE(), GETDATE())

SELECT * FROM Users WHERE Usuario = 'matiasdeveloper' AND Contraseña = CAST('12345' AS varbinary(MAX))
SELECT * FROM Info_users 

DELETE FROM Users
DELETE FROM Info_Users

DBCC CHECKIDENT (Users, RESEED,0)