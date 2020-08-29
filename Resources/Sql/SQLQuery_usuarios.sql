use miRegistro

drop table Users
drop table Info_users

create table Users
(
Id int primary key identity(1,1),
Usuario varchar(20) not null,
Contraseña varbinary(50) not null
) 

create table Info_users
(
Id int primary key,
Nombre varchar(30),
Nombre_corto varchar(15),
Email varchar(60),
Fecha_creacion datetime,
Fecha_ultimoacesso datetime,
)