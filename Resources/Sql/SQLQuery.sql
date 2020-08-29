use DB_Friday
GO

drop table Formularios
drop table CategoriaForm
drop table VehiculoForm
drop table SubcategoriaAuto
drop table SubcategoriaMoto

create table Formularios
(
	id_formulario int identity primary key,
	cod_categoria int,
	cod_elemento int,
	numeracion varchar(50),
	stock int not null,
)
GO
create table CategoriaForm
(
	cod_categoria int identity not null primary key,
	name_subcategoria varchar(20),
	descripcion_categoria varchar(60),
)
create table CategoriaElemento
(
	cod_elemento int identity not null primary key,
	name_elemento varchar(30),
	descripcion_elemento varchar(60),
)