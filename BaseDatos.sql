USE [BancoDB]
GO
/****** Object:  Table [dbo].[tblCliente]    Script Date: 11/09/2022 2:23:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCliente](
	[clienteId] [uniqueidentifier] NOT NULL,
	[personaId] [uniqueidentifier] NULL,
	[contrasenia] [nvarchar](max) NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[clienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCuenta]    Script Date: 11/09/2022 2:23:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCuenta](
	[cuentaId] [uniqueidentifier] NOT NULL,
	[numeroCuenta] [nvarchar](450) NULL,
	[tipoCuenta] [nvarchar](max) NULL,
	[saldoInicial] [decimal](18, 2) NOT NULL,
	[estado] [bit] NOT NULL,
	[clienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tblCuenta] PRIMARY KEY CLUSTERED 
(
	[cuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMovimientos]    Script Date: 11/09/2022 2:23:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMovimientos](
	[movimientoId] [uniqueidentifier] NOT NULL,
	[fecha] [datetime2](7) NOT NULL,
	[tipoMovimiento] [nvarchar](max) NULL,
	[valor] [decimal](18, 2) NOT NULL,
	[saldo] [decimal](18, 2) NOT NULL,
	[cuentaId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tblMovimientos] PRIMARY KEY CLUSTERED 
(
	[movimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPersona]    Script Date: 11/09/2022 2:23:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPersona](
	[personaId] [uniqueidentifier] NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[genero] [nvarchar](max) NULL,
	[edad] [int] NOT NULL,
	[identificacion] [nvarchar](450) NULL,
	[direccion] [nvarchar](max) NULL,
	[telefono] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblPersona] PRIMARY KEY CLUSTERED 
(
	[personaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblCliente]  WITH CHECK ADD  CONSTRAINT [FK_tblCliente_tblPersona_personaId] FOREIGN KEY([personaId])
REFERENCES [dbo].[tblPersona] ([personaId])
GO
ALTER TABLE [dbo].[tblCliente] CHECK CONSTRAINT [FK_tblCliente_tblPersona_personaId]
GO
ALTER TABLE [dbo].[tblCuenta]  WITH CHECK ADD  CONSTRAINT [FK_tblCuenta_tblCliente_clienteId] FOREIGN KEY([clienteId])
REFERENCES [dbo].[tblCliente] ([clienteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblCuenta] CHECK CONSTRAINT [FK_tblCuenta_tblCliente_clienteId]
GO
ALTER TABLE [dbo].[tblMovimientos]  WITH CHECK ADD  CONSTRAINT [FK_tblMovimientos_tblCuenta_cuentaId] FOREIGN KEY([cuentaId])
REFERENCES [dbo].[tblCuenta] ([cuentaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblMovimientos] CHECK CONSTRAINT [FK_tblMovimientos_tblCuenta_cuentaId]
GO
