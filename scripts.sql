use master
go 

if exists(select * from sys.databases where name = 'aulaBD')
	drop database aulaBD

create database aulaBD
go

use aulaBD
go

create table Cliente(
	ID int identity primary key,
	Nome varchar(100) not null,
	Senha varchar(100) not null,
	DataNasc date not null
);
go

create table Produto(
	ID int identity primary key,
	Nome varchar(100) not null,
	Valor float not null
);
go

create table Vendedor(
	ID int identity primary key,
	Nome varchar(100) not null,
	Setor varchar(30) not null,
	DataNasc date not null
);
go

create table NotaFiscal(
	ID int identity primary key,
	Cliente int references Cliente(ID) not null,
	Produto int references Produto(ID) not null,
	Vendedor int references Vendedor(ID) not null,
	DataVenda date not null
);
go

select * from NotaFiscal NF
left join Cliente C on NF.Cliente = C.ID;