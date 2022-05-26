create database BdEmpleados
 go


 use BdEmpleados
 go


   IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Empleados' AND COLUMN_NAME= 'Estatus_Id') BEGIN 

	ALTER TABLE Empleados DROP CONSTRAINT FK_Empleados_Estatus

  END


  DROP TABLE  IF Exists Estatus
 Create table Estatus 
 (
	Estatus_Id int Identity,
	Descripcion Varchar(20),
	CONSTRAINT PK_Estatus PRIMARY KEY (Estatus_Id)

 )
 GO


 DROP TABLE  IF Exists Empleados
create table Empleados
(
	Empleado_Id INT Identity,
	Nombre Varchar(50),
	Apellido_Paterno Varchar(50),
	Apellido_Materno Varchar(50),
	Fecha_Nacimiento DateTime,
	Estatus_Id int,
	CONSTRAINT PK_Empleados PRIMARY KEY (Empleado_Id),
	CONSTRAINT FK_Empleados_Estatus FOREIGN KEY (Estatus_Id) REFERENCES  Estatus (Estatus_Id)

)
GO	

IF (SELECT COUNT(*) FROM Estatus) < 1 BEGIN 
  insert into Estatus Values('Activo')
  insert into Estatus Values('No Activo')
END 
GO


  DROP PROCEDURE IF EXISTS LeerCatalogoEstatus
  GO
  CREATE Procedure LeerCatalogoEstatus 
  AS 
  BEGIN

  SELECT Estatus_Id, Descripcion FROM Estatus 

  End

   DROP PROCEDURE IF EXISTS GuardarEmpleado
  GO
  Create Procedure GuardarEmpleado

  @Nombre varchar(50),
  @Apellido_Paterno varchar(50),
  @Apellido_Materno varchar(50),
  @Fecha_Nacimiento datetime,
  @Estatus_Id int

  AS BEGIN 

  INSERT INTO Empleados values(@Nombre, @Apellido_Paterno, @Apellido_Materno, @Fecha_Nacimiento,@Estatus_Id)
  
  END
GO


	DROP PROCEDURE IF Exists ObtenerEmpleados 
	GO
	CREATE PROCEDURE ObtenerEmpleados 

	AS BEGIN 


	Select Empleado_Id, Nombre, Apellido_Paterno, Apellido_Materno, Fecha_Nacimiento, emp.Estatus_Id , est.Descripcion as DescEstatus 
	  From Empleados emp
	       INNER JOIN Estatus est on emp.Estatus_Id = est.Estatus_Id	
	END 
	DROP PROCEDURE IF Exists ActualizaEmpleados
	go
	CREATE PROCEDURE ActualizaEmpleados

	@Empleado_Id Int,
	@Nombre Varchar(50),
	@Apellido_Paterno Varchar(50),
	@Apellido_Materno Varchar(50),
	@Fecha_Nacimiento Datetime,
	@Estatus_Id Int

	AS BEGIN 

	Update Empleados set Nombre = @Nombre, Apellido_Paterno = @Apellido_Paterno, Apellido_Materno = @Apellido_Materno,
		   Fecha_Nacimiento = @Fecha_Nacimiento , Estatus_Id = @Estatus_Id
	   where Empleado_Id = @Empleado_Id 


	   END 