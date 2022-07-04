CREATE DATABASE BdEscolar
go

use BdEscolar 
GO


if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_GruposAlumnos_Alumnos]') AND parent_object_id = OBJECT_ID('GruposAlumnos')) BEGIN
		alter table GruposAlumnos drop constraint FK_GruposAlumnos_Alumnos
END
GO


if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_GruposAlumnos_HorariosMaestros]') AND parent_object_id = OBJECT_ID('GruposAlumnos')) BEGIN
		alter table GruposAlumnos drop constraint FK_GruposAlumnos_HorariosMaestros
END
GO



if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Calificaciones_Materias]') AND parent_object_id = OBJECT_ID('Calificaciones')) BEGIN
		alter table Calificaciones drop constraint FK_Calificaciones_Materias
END
GO


if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Calificaciones_Alumnos]') AND parent_object_id = OBJECT_ID('Calificaciones')) BEGIN
		alter table Calificaciones drop constraint FK_Calificaciones_Alumnos
END
GO


if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_HorariosMaestros_DetalleMateria]') AND parent_object_id = OBJECT_ID('HorariosMaestros')) BEGIN
		alter table HorariosMaestros drop constraint FK_HorariosMaestros_DetalleMateria
END
GO


if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_HorariosMaestros_Maestros]') AND parent_object_id = OBJECT_ID('HorariosMaestros')) BEGIN
		alter table HorariosMaestros drop constraint FK_HorariosMaestros_Maestros
END
GO


if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_DetalleMateria_Materias]') AND parent_object_id = OBJECT_ID('DetalleMateria')) BEGIN
		alter table DetalleMateria drop constraint FK_DetalleMateria_Materias
END
GO


if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_DetalleMateria_HorarioGeneral]') AND parent_object_id = OBJECT_ID('DetalleMateria')) BEGIN
		alter table DetalleMateria drop constraint FK_DetalleMateria_HorarioGeneral
END
GO


DROP TABLE IF EXISTS GruposAlumnos
DROP TABLE IF EXISTS Calificaciones
DROP TABLE IF EXISTS Alumnos 
DROP TABLE IF EXISTS DetalleMateria
DROP TABLE IF EXISTS HorariosMaestros
DROP TABLE IF EXISTS Materias
DROP TABLE IF EXISTS Maestros 
DROP TABLE IF EXISTS HorarioGeneral
GO


CREATE TABLE Maestros 
(
	Id Int Identity,
	Nombre varchar(100) NOT NULL,
	ApePaterno varchar(100) NOT NULL,
	ApeMaterno varchar(100) NOT NULL,
	Telefono varchar(50),
	Email varchar(150),
	Estatus int,
	CONSTRAINT Pk_Maestros PRIMARY KEY (Id)

	 
)
GO


CREATE TABLE Materias
(
	
	Id Int Identity, 
	Nombre varchar(100) NOT NULL,
	Estatus int,
	CONSTRAINT PK_Materias PRIMARY KEY(Id)

)
GO


CREATE TABLE HorarioGeneral 
(

	Id Int Identity,
	Hora Varchar(20),
	Estatus Int
    CONSTRAINT PK_HorarioGeneral Primary key(Id),
)
GO


CREATE Table DetalleMateria 
(

	Id Int Identity, 
	IdMateria Int, 
	LimiteAlumno Int,
	IdHora int,
	Estatus int,
	CONSTRAINT PK_DetalleMateria PRIMARY KEY(Id),
	CONSTRAINT FK_DetalleMateria_Materias FOREIGN KEY (IdMateria) REFERENCES Materias(Id),
	CONSTRAINT FK_DetalleMateria_HorarioGeneral FOREIGN KEY (IdHora) REFERENCES HorarioGeneral(Id)
	
)
GO


Create Table HorariosMaestros 
(
	
	Id Int Identity,
	IdDetalleMateria Int,
	IdMaestro int,
	Estatus Int
	CONSTRAINT PK_HorariosMaestros PRIMARY KEY(Id),
	CONSTRAINT FK_HorariosMaestros_DetalleMateria FOREIGN KEY (IdDetalleMateria) REFERENCES DetalleMateria (Id),
	CONSTRAINT FK_HorariosMaestros_Maestros FOREIGN KEY(IdMaestro) REFERENCES Maestros (Id)
)
GO


CREATE TABLE Alumnos
(
	Matricula int identity,
	Nombre varchar(100) NOT NULL,
	ApePaterno varchar(100) NOT NULL,
	ApeMaterno varchar(100) NOT NULL,
	Telefono varchar(50),
	Email varchar(150),
	Estatus int, 
	CONSTRAINT PK_Alumnos PRIMARY KEY (Matricula)
)
GO


CREATE TABLE Calificaciones 
(
	
	Id Int Identity, 
	IdMateria Int not null, 
	MatriculaAlumno Int not null, 
	Calificacion decimal(5,2) not null,
	CONSTRAINT PK_Calificaciones PRIMARY KEY (Id),
	CONSTRAINT FK_Calificaciones_Materias FOREIGN KEY (IdMateria) REFERENCES Materias (Id),
	CONSTRAINT FK_Calificaciones_Alumnos FOREIGN KEY (MatriculaAlumno) REFERENCES Alumnos (Matricula)
)
GO

CREATE TABLE GruposAlumnos 
(

	Id int Identity ,
	IdHorariosMaestros int not null, 
	MatriculaAlumno int not null, 
	Estatus int not null,
	CONSTRAINT PK_GruposAlumnos Primary key(Id),
	CONSTRAINT FK_GruposAlumnos_Alumnos FOREIGN KEY (MatriculaAlumno) REFERENCES Alumnos(Matricula),
	CONSTRAINT FK_GruposAlumnos_HorariosMaestros FOREIGN KEY (IdHorariosMaestros) REFERENCES HorariosMaestros(Id)
)
GO


 DROP PROCEDURE IF EXISTS InsertarMaestro
 GO
 CREATE PROCEDURE InsertarMaestro 
	
	@Nombre varchar(100),
	@ApePaterno varchar(100),
	@ApeMaterno varchar(100),
	@Telefono varchar(50),
	@Email varchar(150),
	@Estatus Int

	AS BEGIN

	SET NOCOUNT ON;

	Insert into Maestros VALUES(@Nombre, @ApePaterno,@ApeMaterno ,@Telefono,@Email, @Estatus)

	SET NOCOUNT OFF;
	END
  GO
  

  DROP PROCEDURE IF EXISTS InsertarMaterias
  GO
  CREATE PROCEDURE InsertarMaterias 
	
	@Nombre varchar(100),
	@Estatus Int

	AS BEGIN

	SET NOCOUNT ON;

	Insert into Materias VALUES(@Nombre, @Estatus)

	SELECT @@IDENTITY

	SET NOCOUNT OFF;
	END
	GO


  DROP PROCEDURE IF EXISTS InsertarDetalleMateria
  GO
  CREATE PROCEDURE InsertarDetalleMateria
   @IdMateria Int,
   @LimiteAlumno Int,
   @Hora int,
   @Estatus int

   AS BEGIN 
   SET NOCOUNT ON;

   Insert into DetalleMateria VALUES(@IdMateria,@LimiteAlumno,@Hora,@Estatus)

   SET NOCOUNT OFF;
   END 
   GO

 
  DROP PROCEDURE IF EXISTS InsertarHorariosMaestros 
  GO
  CREATE PROCEDURE InsertarHorariosMaestros 

   @IdDetalleMateria Int, 
   @IdMaestro Int
   AS BEGIN
	SET NOCOUNT ON;

	INSERT INTO HorariosMaestros VALUES (@IdDetalleMateria,@IdMaestro,1)

	SET NOCOUNT OFF;

  END
  GO


  DROP PROCEDURE IF EXISTS InsertarAlumnos
  GO
  CREATE PROCEDURE InsertarAlumnos
	
	@Nombre Varchar(100),
	@ApePaterno Varchar(100),
	@ApeMaterno Varchar(100),
	@Telefono Varchar(50),
	@Email Varchar(150),
	@Estatus int

	AS BEGIN

	SET NOCOUNT ON;

	Insert into Alumnos VALUES(@Nombre,@ApePaterno,@ApeMaterno, @Telefono, @Email, @Estatus )

	SET NOCOUNT OFF;
	END
	GO

	
	DROP PROCEDURE IF EXISTS ActualizarAlumnos 
	GO
	CREATE PROCEDURE ActualizarAlumnos
	 @Matricula int,
	 @Nombre varchar(100), 
     @ApePaterno varchar(100),
	 @ApeMaterno varchar(100),
	 @Telefono varchar(50),
	 @Email varchar(150),
	 @Estatus int
	AS BEGIN
	SET NOCOUNT ON;


	UPDATE Alumnos 
	            SET Nombre =  @Nombre, ApePaterno = @ApePaterno, ApeMaterno = @ApeMaterno, Telefono = @Telefono, Email = @Email, Estatus = @Estatus
	          WHERE Matricula = @Matricula

	SET NOCOUNT OFF; 

	END
	GO


   DROP PROCEDURE IF EXISTS InsertarCalificaciones 
   GO
   CREATE PROCEDURE InsertarCalificaciones 

	@IdMateria Int, 
	@MatriculaAlumno Int, 
	@Calificacion decimal(5,2)
	
	AS BEGIN
	SET NOCOUNT ON;

	Insert into Calificaciones values (@IdMateria, @MatriculaAlumno, @Calificacion)
	
	SET NOCOUNT OFF;

	END
	GO


	DROP PROCEDURE IF EXISTS ObtenerMaestros
	GO
	CREATE PROCEDURE ObtenerMaestros 
	AS BEGIN
	SET NOCOUNT ON;


	SELECT Id,Nombre, ApePaterno, ApeMaterno, Telefono, Email , Estatus, 
	  Case Estatus  WHEN 1 THEN  'ACTIVO' ELSE 'INACTIVO' END as DescEstatus FROM Maestros

	SET NOCOUNT OFF; 

	END
	GO


	DROP PROCEDURE IF EXISTS ActualizarMaestros 
	GO
	CREATE PROCEDURE ActualizarMaestros 
	 @Id int,
	 @Nombre varchar(100), 
     @ApePaterno varchar(100),
	 @ApeMaterno varchar(100),
	 @Telefono varchar(50),
	 @Email varchar(150),
	 @Estatus int
	AS BEGIN
	SET NOCOUNT ON;


	UPDATE Maestros 
	            SET Nombre =  @Nombre, ApePaterno = @ApePaterno, ApeMaterno = @ApeMaterno, Telefono = @Telefono, Email = @Email, Estatus = @Estatus
	          WHERE Id = @Id

	SET NOCOUNT OFF; 

	END
	GO
	

	DROP PROCEDURE IF EXISTS ObtenerMateriasDetalle
	GO
	CREATE PROCEDURE ObtenerMateriasDetalle
		@IdMaterias varchar(100)

		AS BEGIN
		SET NOCOUNT ON;
			
			Create Table #tmpMaterias
			 (
				Id Int 
			 )

			 insert into #tmpMaterias
			 select value from string_split(@IdMaterias,'|')

				
				SELECT dm.Id as IdDetalle ,CASE WHEN HM.Id IS NULL  THEN 0 ELSE HM.Id  END AS IdHorarioMaestro,  M.Nombre, Dm.LimiteAlumno,
				       hg.Id as IdHorario, hg.Hora as Horario,
				       CASE WHEN HM.Id IS NULL THEN 0 ELSE HM.Id  END as IdMaestro, 
					   CASE  WHEN HM.Id IS NULL  THEN 'NO ASIGNADO' ELSE CONCAT(ma.Nombre , ' ', ma.ApePaterno , ' ', ma.ApeMaterno)   END AS Maestro
				 FROM Materias m
						INNER JOIN DetalleMateria dm on  dm.IdMateria = m.Id 
					     LEFT JOIN HorariosMaestros HM on HM.IdDetalleMateria = dm.Id
						  left JOIN Maestros ma ON   MA.Id = HM.IdMaestro
						INNER JOIN HorarioGeneral hg on hg.Id = dm.IdHora
			    WHERE m.id in (SELECT Id FROM #tmpMaterias)

			 DROP TABLE #tmpMaterias
		SET NOCOUNT OFF;
		END 
		GO

		
		DROP PROCEDURE IF EXISTS ObtenerMateriasHorariosMaestro 
		GO
		CREATE PROCEDURE ObtenerMateriasHorariosMaestro
			AS BEGIN 
			SET NOCOUNT ON;

		SELECT m.Id as IdMateria,m.Nombre NomMateria, ma.Id as IdMaestro, CONCAT(ma.Nombre, ' ',ma.ApePaterno, ' ' ,ma.ApeMaterno) as NomMaestros,
		      hg.Id as IdHora, hg.Hora as NomHora, DM.LimiteAlumno, HM.Id as IdHorarioMaestro 
		      
	      FROM Materias m
			   INNER JOIN DetalleMateria as DM on DM.idMateria = m.id 
			   INNER JOIN HorariosMaestros as HM on HM.IdDetalleMateria  = DM.Id 
			   INNER JOIN Maestros as ma on HM.IdMaestro = ma.Id
			   INNER JOIN HorarioGeneral as HG on HG.Id = DM.IdHora
		 WHERE ma.Estatus = 1 and m.Estatus = 1 and DM.Estatus = 1 

			   SET NOCOUNT OFF;
			   END
		GO


		select * from    Materias m
			   INNER JOIN DetalleMateria as DM on DM.idMateria = m.id  
			    INNER JOIN HorariosMaestros as HM on HM.IdDetalleMateria  = DM.Id 
				INNER JOIN Maestros as ma on HM.IdMaestro = MA.Id

	DROP PROCEDURE IF EXISTS ObtenerMaterias 
	GO
	CREATE PROCEDURE ObtenerMaterias 

	AS BEGIN 
	SET NOCOUNT ON;

		SELECT Id, Nombre 
		  FROM Materias as mat
		 WHERE Estatus = 1 
			 

   SET NOCOUNT OFF;		  
   END
   GO

   DROP PROCEDURE IF EXISTS ObtenerHorariosGeneral
   GO
   CREATE PROCEDURE ObtenerHorariosGeneral
   AS BEGIN 
   SET NOCOUNT ON;
	
		 Select Id, Hora, Estatus, Case Estatus when 1 Then 'Activo' Else 'Inactivo' End as DescEstatus 
		   From HorarioGeneral
		  where Estatus =1

	SET NOCOUNT OFF;
	END
	GO


	DROP PROCEDURE IF EXISTS ObtenerAlumnos 
	GO 
	CREATE PROCEDURE ObtenerAlumnos 

	AS BEGIN 
	SET NOCOUNT ON;

		Select Matricula, Nombre,ApePaterno, ApeMaterno, Telefono, Email,Estatus, case Estatus when 1 then 'ACTIVO' ELSE 'INACTIVO' End as DescEstatus from Alumnos

	SET NOCOUNT OFF;

	END
	GO

	

	DROP PROCEDURE IF EXISTS ObtenerMaestros
	GO
	CREATE PROCEDURE ObtenerMaestros 
	AS BEGIN
	SET NOCOUNT ON;


	SELECT Id,Nombre, ApePaterno, ApeMaterno, Telefono, Email , Estatus, 
	  Case Estatus  WHEN 1 THEN  'ACTIVO' ELSE 'INACTIVO' END as DescEstatus FROM Maestros

	SET NOCOUNT OFF; 

	END
	GO

	DROP PROCEDURE IF EXISTS GuardarGruposAlumnos
	GO
	CREATE PROCEDURE GuardarGruposAlumnos 
		
			@IdHorarioMaestro int, 
			@MatriculaAlumno int
			AS BEGIN 
			SET NOCOUNT ON;

					INSERT INTO GruposAlumnos VALUES(@IdHorarioMaestro,@MatriculaAlumno,1)

			SET NOCOUNT OFF;

		END

  DROP PROCEDURE IF EXISTS ObtenerAlumnosMateria 
  GO
  CREATE PROCEDURE ObtenerAlumnosMateria 
	
	@IdAlumno INT
	AS BEGIN 
		SET NOCOUNT ON;

		SELECT GA.Id, M.Id as IdMateria, M.Nombre as NomMateria, MA.Id as IdMaestro, MatriculaAlumno, 
		       CONCAT(MA.Nombre , ' ' , MA.ApePaterno ,  ' ' , MA.ApeMaterno ) as NomMaestros,
		        DM.IdHora as IdHora, HG.Hora as NomHora
		  FROM GruposAlumnos GA
		      INNER JOIN HorariosMaestros HM ON HM.Id = GA.IdHorariosMaestros 
			  INNER JOIN DetalleMateria DM ON DM.Id = HM.IdDetalleMateria
			  INNER JOIN Materias M ON M.Id = DM.IdMateria
			  INNER JOIN HorarioGeneral HG ON HG.Id = DM.IdHora
			  INNER JOIN Maestros MA ON MA.Id = HM.IdMaestro
		WHERE MatriculaAlumno = @IdAlumno AND GA.Estatus = 1 
	    
		SET NOCOUNT OFF;

		END 



	  INSERT INTO HorarioGeneral VALUES('7:00',1)
	  INSERT INTO HorarioGeneral VALUES('8:00',1)
	  INSERT INTO HorarioGeneral VALUES('9:00',1)
	  INSERT INTO HorarioGeneral VALUES('10:00',1)
	  INSERT INTO HorarioGeneral VALUES('11:00',1)
	  INSERT INTO HorarioGeneral VALUES('12:00',1)
	  INSERT INTO HorarioGeneral VALUES('13:00',1)
	  INSERT INTO HorarioGeneral VALUES('15:00',1)
	  INSERT INTO HorarioGeneral VALUES('16:00',1)
	  INSERT INTO HorarioGeneral VALUES('17:00',1)
	  INSERT INTO HorarioGeneral VALUES('18:00',1)
	  INSERT INTO HorarioGeneral VALUES('19:00',1)






	 
		







