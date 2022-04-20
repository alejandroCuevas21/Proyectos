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


DROP TABLE IF EXISTS CatCompañias
CREATE TABLE CatCompañias (
	IdContacto  int Identity,
	NombreCompañia varchar(250),
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
	RegistroCompañia varchar(250),
	Moneda varchar(10),
	CONSTRAINT PK_CatCompañias PRIMARY KEY(IdContacto)


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


	
DROP PROCEDURE IF EXISTS [sp_ObtenerCompañia]
GO
CREATE PROCEDURE [dbo].[sp_ObtenerCompañia]  
@idCompañia INT       
AS  
    BEGIN  
        SET NOCOUNT ON;  
        SELECT IdContacto, NombreCompañia,Logo,NombreCalle,NoExterior,NoPuerta,Colonia,Ciudad,Provinicia,
		       cp.Descripcion as DescProvincia, CP,IdPais, cpais.Descripcion as DescPais,
		       Telefono,CorreoElectronico,SitioWeb,RFC,RegistroCompañia, Moneda, CASE when Moneda = 1 THEN 'MXN' ELSE 'USD' END as DescMoneda
        FROM CatCompañias(NOLOCK) cc 
			 INNER JOIN CatProvincias(NOLOCK) cp on cp.Id = cc.Provinicia
			 INNER JOIN CatPais(NOLOCK) cpais on cpais.Id = cc.IdPais

        SET NOCOUNT OFF;  
    END;
	go
	

DROP PROCEDURE IF EXISTS [sp_GuardaCompañia]
GO
CREATE PROCEDURE [dbo].[sp_GuardaCompañia]  
@NombreCompañia VARCHAR(250),
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
@RegistroCompañia Varchar(250),
@Moneda varchar(10)
AS  
    BEGIN  
        SET NOCOUNT ON;  
			
			INSERT INTO CatCompañias(NombreCompañia,NombreCalle,NoExterior,NoPuerta,Colonia,Ciudad,Provinicia,CP,IdPais,Telefono,CorreoElectronico,SitioWeb,RFC,RegistroCompañia,Moneda)
							 VALUES(@NombreCompañia,@NombreCalle,@NoExterior,@NoPuerta,@Colonia,@Ciudad,@Provincia,@CP,@IdPais,@Telefono,@CorreoElectronico,@SitioWeb,@RFC,@RegistroCompañia,@Moneda)
        
		SELECT SCOPE_IDENTITY()
		SET NOCOUNT OFF;  
    END;
	go
	

DROP PROCEDURE IF EXISTS [sp_EditarCompañia]
GO
CREATE PROCEDURE [dbo].[sp_EditarCompañia]  
@IdCompañia int,
@NombreCompañia VARCHAR(250),
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
@RegistroCompañia Varchar(250),
@Moneda varchar(10)
AS  
    BEGIN  
        SET NOCOUNT ON;  


		UPDATE CatCompañias SET NombreCompañia = @NombreCompañia, NombreCalle = @NombreCalle, NoExterior =  @NoExterior,
								NoPuerta = @NoPuerta,Colonia = @Colonia, Ciudad = @Ciudad, Provinicia = @Provincia, CP =@CP, 
								IdPais =  @IdPais, Telefono= @Telefono, CorreoElectronico = @CorreoElectronico,
								SitioWeb = @SitioWeb ,RFC = @RFC, RegistroCompañia = @RegistroCompañia,Moneda = @Moneda
						  WHERE IdContacto =  @IdCompañia
			

	
		SET NOCOUNT OFF;  
    END;
	go
	



