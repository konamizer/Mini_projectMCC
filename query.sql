CREATE DATABASE Db_Kantors;


CREATE TABLE Data_Karyawan(
	Id Int Primary Key,
	NIP Varchar(18) not null unique,
	NIK Varchar(16) not null unique,
	Nama Varchar(100) not null,
	Jenis_Kelamin Varchar(10) NULL ,
	Tempat_Lahir Varchar(100),
	Tanggal_Lahir Varchar,
	Nomor_Telp int,
	Agama Varchar(10) NULL,
	Alamat Varchar(100) Not Null
);

Create Table Lembur(
	Id int Primary key,
	Karyawan_id int not null,
	Tanggal_lembur Varchar(50) not null,
	Jumlah int not null
);

Create Table Cuti (
	Id int Primary key,
	Karyawan_id int,
	Tanggal_cuti Varchar(50) not null,
	jumlah int not null
);
Create Table Penggajian(
	Id int Primary key,
	Tanggal Varchar(50) not null,
	Keterangan text Not Null,
	Karyawan_Id int,
	Jumlah_Gaji int not null,
	Potongan int not null,
	Total_Gaji int not null 

);