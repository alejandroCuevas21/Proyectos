Create Database BdEmpresas
GO


Use BdEmpresas
GO


DROP TABLE IF EXISTS CatPais
CREATE TABLE CatPais(

	Id Int Identity,
	Descripcion varchar(250),
	Estatus int,
	CONSTRAINT PK_CatPais PRIMARY KEY(Id)

)
GO


DROP TABLE IF EXISTS CatProvincias
CREATE TABLE CatProvincias (

	Id Int Identity, 
	Descripcion varchar(250),
	Estatus int, 
	CONSTRAINT PK_CatProvincias PRIMARY KEY(Id)

	)
GO


DROP TABLE IF EXISTS CatCompa�ias
CREATE TABLE CatCompa�ias (
	IdContacto  int Identity,
	NombreCompa�ia varchar(250),
	Logo varbinary(max),
	NombreCalle varchar(250),
	NoExterior varchar(10),
	NoPuerta varchar(10),
	Colonia varchar(250),
	Ciudad varchar (50),
	Provinicia int,
	CP varchar(5),
	IdPais int,
	Telefono varchar (50),
	CorreoElectronico varchar(150),
	SitioWeb varchar(250),
	RFC varchar(250),
	RegistroCompa�ia varchar(250),
	Moneda varchar(10),
	CONSTRAINT PK_CatCompa�ias PRIMARY KEY(IdContacto)


)

DROP PROCEDURE IF EXISTS sp_ObtenerPaises
GO
CREATE PROCEDURE [dbo].[sp_ObtenerPaises]  
AS  
    BEGIN  
        SET NOCOUNT ON;  
        SELECT Id, Descripcion 
        FROM CatPais(NOLOCK)  
        WHERE estatus = 1;  
        SET NOCOUNT OFF;  
    END;
	go
	
	insert into CatPais values ('MEXICO',1)
	insert into CatPais values('CHILE', 1)


DROP PROCEDURE IF EXISTS sp_ObtenerProvincias
GO
CREATE PROCEDURE [dbo].[sp_ObtenerProvincias]  
AS  
    BEGIN  
        SET NOCOUNT ON;  
        SELECT Id, Descripcion 
        FROM CatProvincias(NOLOCK)  
        WHERE estatus = 1;  
        SET NOCOUNT OFF;  
    END;
	go
	
	Insert into CatProvincias values ('SINALOA',1)
	Insert into CatProvincias values ('SONORA',1)


	
DROP PROCEDURE IF EXISTS [sp_ObtenerCompa�ia]
GO
CREATE PROCEDURE [dbo].[sp_ObtenerCompa�ia]  
@idCompa�ia INT       
AS  
    BEGIN  
        SET NOCOUNT ON;  
        SELECT IdContacto, NombreCompa�ia,Logo,NombreCalle,NoExterior,NoPuerta,Colonia,Ciudad,Provinicia,
		       cp.Descripcion as DescProvincia, CP,IdPais, cpais.Descripcion as DescPais,
		       Telefono,CorreoElectronico,SitioWeb,RFC,RegistroCompa�ia, Moneda, CASE when Moneda = 1 THEN 'MXN' ELSE 'USD' END as DescMoneda
        FROM CatCompa�ias(NOLOCK) cc 
			 INNER JOIN CatProvincias(NOLOCK) cp on cp.Id = cc.Provinicia
			 INNER JOIN CatPais(NOLOCK) cpais on cpais.Id = cc.IdPais

        SET NOCOUNT OFF;  
    END;
	go
	

DROP PROCEDURE IF EXISTS [sp_GuardaCompa�ia]
GO
CREATE PROCEDURE [dbo].[sp_GuardaCompa�ia]  
@NombreCompa�ia VARCHAR(250),
@NombreCalle VARCHAR(250),
@NoExterior VARCHAR(10),
@NoPuerta VARCHAR(10),
@Colonia VARCHAR(150),
@Ciudad VARCHAR(150),
@Provincia INT,
@CP INT,
@IdPais INT,
@Telefono varchar(100),
@CorreoElectronico varchar(250),
@SitioWeb varchar(250),
@RFC varchar(250),
@RegistroCompa�ia Varchar(250),
@Moneda varchar(10)
AS  
    BEGIN  
        SET NOCOUNT ON;  
			
			INSERT INTO CatCompa�ias(NombreCompa�ia,NombreCalle,NoExterior,NoPuerta,Colonia,Ciudad,Provinicia,CP,IdPais,Telefono,CorreoElectronico,SitioWeb,RFC,RegistroCompa�ia,Moneda)
							 VALUES(@NombreCompa�ia,@NombreCalle,@NoExterior,@NoPuerta,@Colonia,@Ciudad,@Provincia,@CP,@IdPais,@Telefono,@CorreoElectronico,@SitioWeb,@RFC,@RegistroCompa�ia,@Moneda)
        
		SELECT SCOPE_IDENTITY()
		SET NOCOUNT OFF;  
    END;
	go
	

DROP PROCEDURE IF EXISTS [sp_EditarCompa�ia]
GO
CREATE PROCEDURE [dbo].[sp_EditarCompa�ia]  
@IdCompa�ia int,
@NombreCompa�ia VARCHAR(250),
@NombreCalle VARCHAR(250),
@NoExterior VARCHAR(10),
@NoPuerta VARCHAR(10),
@Colonia VARCHAR(150),
@Ciudad VARCHAR(150),
@Provincia INT,
@CP INT,
@IdPais INT,
@Telefono varchar(100),
@CorreoElectronico varchar(250),
@SitioWeb varchar(250),
@RFC varchar(250),
@RegistroCompa�ia Varchar(250),
@Moneda varchar(10)
AS  
    BEGIN  
        SET NOCOUNT ON;  


		UPDATE CatCompa�ias SET NombreCompa�ia = @NombreCompa�ia, NombreCalle = @NombreCalle, NoExterior =  @NoExterior,
								NoPuerta = @NoPuerta,Colonia = @Colonia, Ciudad = @Ciudad, Provinicia = @Provincia, CP =@CP, 
								IdPais =  @IdPais, Telefono= @Telefono, CorreoElectronico = @CorreoElectronico,
								SitioWeb = @SitioWeb ,RFC = @RFC, RegistroCompa�ia = @RegistroCompa�ia,Moneda = @Moneda
						  WHERE IdContacto =  @IdCompa�ia
			

	
		SET NOCOUNT OFF;  
    END;
	go
	



