use master
go
drop database if exists programacion
go
create database programacion
go
use programacion 
go


CREATE TABLE UserList (
	Id int primary key identity,
	NombreUsuario varchar(50),
	Apellido varchar(50),
	Edad int,
	Pass varchar(50)
);
select * from UserList