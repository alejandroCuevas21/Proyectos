
USE MonitorVentas
GO

IF EXISTS (
    SELECT * 
    FROM sys.foreign_keys 
    WHERE name = 'FK_Cliente' AND parent_object_id = OBJECT_ID('PedidosVenta')
)
BEGIN
    ALTER TABLE PedidosVenta DROP CONSTRAINT FK_Cliente;
END
GO


IF EXISTS (
    SELECT * 
    FROM sys.foreign_keys 
    WHERE name = 'FK_PedidosCliente_PedidosVenta' AND parent_object_id = OBJECT_ID('PedidosCliente')
)
BEGIN
 
    ALTER TABLE PedidosCliente DROP CONSTRAINT FK_PedidosCliente_PedidosVenta;
END
GO

IF EXISTS (
    SELECT * 
    FROM sys.foreign_keys 
    WHERE name = 'FK_PedidosCliente_StatusGuia' AND parent_object_id = OBJECT_ID('PedidosCliente')
)
BEGIN

    ALTER TABLE PedidosCliente DROP CONSTRAINT FK_PedidosCliente_StatusGuia;
END
GO


DROP TABLE IF EXISTS Clientes
GO
CREATE TABLE Clientes (
	id int,
	Descripcion varchar(250) not null,
	CONSTRAINT PK_Clientes PRIMARY KEY(Id)
)

DROP TABLE IF EXISTS EstatusPedido
GO
CREATE TABLE EstatusPedido
(
	Id int identity,
	Descripcion varchar(50) not null,
	CONSTRAINT PK_EstatusPedido PRIMARY KEY(Id),

)

DROP TABLE IF EXISTS PedidosVenta
GO
CREATE TABLE PedidosVenta 
(
	Id int IDENTITY,
	PedidoMPA Varchar(250),
	IdCliente int not null,
	Estado varchar(200) not null,
	Cadena varchar(400) not null,
	Producto varchar(400) not null,
	PiezasSolicitadas int not null,
	PiezasRemisionadas int not null,
	Importe decimal(10,2) not null,
	ImporteRemisionado decimal(10,2) not null,
	CONSTRAINT FK_Cliente FOREIGN KEY (IdCliente) REFERENCES Clientes(Id),
	CONSTRAINT PK_PedidosVenta PRIMARY KEY(Id)
)
DROP TABLE IF EXISTS PedidosCliente
GO
CREATE TABLE PedidosCliente
(
	Id int Identity,
	PedCliente Varchar(250),
	PedidoVenta varchar(250),
	Alta_imss Varchar(500),
	FechaCaptura date not null,
	FechaExpedicion date not null,
	FechaLimite date not null,
	Guia Varchar(100) not null,
	Status char(1) not null,
	FechaEntrega date DEFAULT NULL,
	StatusGuia int not null,
	Comentarios varchar (500),
	Factura varchar(50) not null,
	CONSTRAINT FK_PedidosCliente_StatusGuia FOREIGN KEY (StatusGuia) REFERENCES EstatusPedido(Id),
	CONSTRAINT PK_PedidosCliente PRIMARY KEY (Id)

)
DROP TABLE IF EXISTS DocumentosPedidos
GO
CREATE TABLE DocumentosPedidos 
(
	Id Int Identity,
	PedCliente varchar(250),
	Archivo Varchar(400),
	CONSTRAINT PK_DocumentosPedidos PRIMARY KEY (Id)

)
GO

INSERT INTO EstatusPedido ( Descripcion)
VALUES
	('Cancelado'  ),
	('Capturado'	),
	('En Surtido'	),
	('En Transito'),
	('Entregado'	);


IF OBJECT_ID('ObtenerEstatusPedido') IS NOT NULL 
DROP PROCEDURE ObtenerEstatusPedido

GO

CREATE PROCEDURE ObtenerEstatusPedido 
AS BEGIN
	
	SELECT Id,Descripcion from EstatusPedido
END ;
GO


IF OBJECT_ID('ObtenerEstatusActivo') IS NOT NULL 
DROP PROCEDURE ObtenerEstatusActivo

GO


CREATE PROCEDURE ObtenerEstatusActivo 
 @PedCliente VARCHAR(100)
AS BEGIN 
	
	SELECT StatusGuia from PedidosCliente where PedCliente =@PedCliente
	
END 
GO

IF OBJECT_ID('ActualizarEstatus') IS NOT NULL 
DROP PROCEDURE ActualizarEstatus

GO

CREATE PROCEDURE ActualizarEstatus 
	@PedCliente VARCHAR(100),
	@StatusGuia int
AS BEGIN

	UPDATE PedidosCliente  set StatusGuia = @StatusGuia where PedCliente = @PedCliente

	END
	GO

	
IF OBJECT_ID('ObtenerPedidoClientes') IS NOT NULL 
DROP PROCEDURE ObtenerPedidoClientes

GO


	CREATE PROCEDURE ObtenerPedidoClientes 
	AS BEGIN 


	 select  distinct  pv.Producto, pv.id,  pedCliente as PedCliente, pc.PedidoVenta as PedVenta, pv.IdCliente, cl.Descripcion  as NomCliente, Alta_imss, pv.piezasSolicitadas,pv.PiezasRemisionadas,pv.Importe,
	        pv.ImporteRemisionado
     from PedidosCliente pc
		   inner join PedidosVenta pv on  pc.PedidoVenta =pv.PedidoMPA 
		   inner join Clientes cl on cl.id = pv.IdCliente
  group by pc.PedidoVenta, pv.IdCliente,pc.Alta_imss,pc.Guia,pc.FechaEntrega,pc.StatusGuia,pv.producto,
		   pv.piezasSolicitadas,pv.PiezasRemisionadas,pv.Importe, pv.ImporteRemisionado,
		   pc.StatusGuia , pc.Factura, PedCliente,pv.PedidoMPA, pv.id,pc.guia, pv.IdCliente, cl.Descripcion
				
	END
	GO
IF OBJECT_ID('GuardarDocumentosPedidos') IS NOT NULL 
DROP PROCEDURE GuardarDocumentosPedidos

GO
 CREATE PROCEDURE GuardarDocumentosPedidos
 @Archivo VARCHAR(400),
 @PedidoCliente VARCHAR(250)
 AS BEGIN

  INSERT INTO  DocumentosPedidos VALUES (@PedidoCliente, @Archivo)

 END 
 GO

 IF OBJECT_ID('ObtenerDocumentosPedidos') IS NOT NULL 
DROP PROCEDURE ObtenerDocumentosPedidos
GO


 CREATE PROCEDURE ObtenerDocumentosPedidos
 @PedidoCliente Varchar(250)
 AS BEGIN
	
	Select Id, Archivo from DocumentosPedidos where PedCliente = @PedidoCliente 	
 END











				


