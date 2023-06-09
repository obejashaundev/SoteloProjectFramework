/****** Object:  Database [SOTELO_ASPNET]    Script Date: 13/04/2023 09:10:27 p. m. ******/
CREATE DATABASE [SOTELO_ASPNET]  (EDITION = 'Standard', SERVICE_OBJECTIVE = 'S0', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [SOTELO_ASPNET] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [SOTELO_ASPNET] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET ARITHABORT OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SOTELO_ASPNET] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SOTELO_ASPNET] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [SOTELO_ASPNET] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SOTELO_ASPNET] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SOTELO_ASPNET] SET  MULTI_USER 
GO
ALTER DATABASE [SOTELO_ASPNET] SET ENCRYPTION ON
GO
ALTER DATABASE [SOTELO_ASPNET] SET QUERY_STORE = ON
GO
ALTER DATABASE [SOTELO_ASPNET] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cBuzonEstatus]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cBuzonEstatus](
	[BuzonEstatusId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbBuzonEstatus] PRIMARY KEY CLUSTERED 
(
	[BuzonEstatusId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cMenus]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cMenus](
	[MenuId] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[DependeDe] [int] NOT NULL,
	[CSS] [varchar](150) NOT NULL,
	[Estatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cRecursosGenerales]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cRecursosGenerales](
	[RecursoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Valor] [varchar](200) NOT NULL,
	[Estatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RecursoId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbBuzon]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBuzon](
	[BuzonId] [int] IDENTITY(1,1) NOT NULL,
	[BuzonEstatusId] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Asunto] [text] NOT NULL,
	[Estatus] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_tbBuzon] PRIMARY KEY CLUSTERED 
(
	[BuzonId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbCategoriasChoferes]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCategoriasChoferes](
	[CategoriaChoferId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tbCategoriasChoferes] PRIMARY KEY CLUSTERED 
(
	[CategoriaChoferId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbChoferes]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbChoferes](
	[ChoferId] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaChoferId] [int] NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[PrimerApellido] [varchar](100) NOT NULL,
	[SegundoApellido] [varchar](100) NOT NULL,
	[Imagen] [image] NULL,
	[Estatus] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[FechaElimino] [varchar](100) NULL,
 CONSTRAINT [PK_tbChoferes] PRIMARY KEY CLUSTERED 
(
	[ChoferId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbContabilidadViaje]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbContabilidadViaje](
	[ContabilidadViajeId] [int] IDENTITY(1,1) NOT NULL,
	[Diesel] [numeric](18, 2) NULL,
	[Importe] [numeric](18, 2) NOT NULL,
	[SalarioBrutoChofer] [numeric](18, 2) NOT NULL,
	[Gastos] [numeric](18, 2) NOT NULL,
	[SalarioNeto] [numeric](18, 2) NOT NULL,
	[Ganancia] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_tbContabilidadViaje] PRIMARY KEY CLUSTERED 
(
	[ContabilidadViajeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbDetallesChoferes]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDetallesChoferes](
	[DetalleChoferId] [int] IDENTITY(1,1) NOT NULL,
	[ChoferId] [int] NOT NULL,
	[Unidad] [varchar](50) NOT NULL,
	[PlacasUnidad] [varchar](50) NOT NULL,
	[DescripcionUnidad] [text] NULL,
	[Edad] [int] NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[FechaNacimientoStr] [varchar](100) NULL,
	[LicenciaConducir] [varchar](100) NOT NULL,
	[NSS] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbDetallesChoferes] PRIMARY KEY CLUSTERED 
(
	[DetalleChoferId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbMenusRoles]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbMenusRoles](
	[ConfiguracionId] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Estatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ConfiguracionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUsuarios]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUsuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[RolId] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[UserName] [varchar](150) NOT NULL,
	[Nombres] [varchar](150) NULL,
	[PrimerApellido] [varchar](150) NULL,
	[SegundoApellido] [varchar](150) NULL,
	[Email] [varchar](150) NOT NULL,
	[Contrasenia] [varchar](150) NOT NULL,
	[FotoBase64] [text] NULL,
	[Estatus] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[UsuarioElimino] [varchar](150) NULL,
	[FechaElimino] [datetime] NULL,
	[MotivoElimino] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbViajes]    Script Date: 13/04/2023 09:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbViajes](
	[ViajeId] [int] IDENTITY(1,1) NOT NULL,
	[ChoferId] [int] NOT NULL,
	[ContabilidadViajeId] [int] NOT NULL,
	[Folio] [varchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FechaStr] [varchar](100) NOT NULL,
	[LugarOrigen] [text] NOT NULL,
	[LugarDestino] [text] NOT NULL,
 CONSTRAINT [PK_tbViajes] PRIMARY KEY CLUSTERED 
(
	[ViajeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 13/04/2023 09:10:27 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 13/04/2023 09:10:27 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 13/04/2023 09:10:27 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 13/04/2023 09:10:27 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 13/04/2023 09:10:27 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 13/04/2023 09:10:27 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[tbBuzon]  WITH CHECK ADD  CONSTRAINT [FK_tbBuzon_cBuzonEstatus] FOREIGN KEY([BuzonEstatusId])
REFERENCES [dbo].[cBuzonEstatus] ([BuzonEstatusId])
GO
ALTER TABLE [dbo].[tbBuzon] CHECK CONSTRAINT [FK_tbBuzon_cBuzonEstatus]
GO
ALTER TABLE [dbo].[tbChoferes]  WITH CHECK ADD  CONSTRAINT [FK_tbChoferes_tbCategoriasChoferes] FOREIGN KEY([CategoriaChoferId])
REFERENCES [dbo].[tbCategoriasChoferes] ([CategoriaChoferId])
GO
ALTER TABLE [dbo].[tbChoferes] CHECK CONSTRAINT [FK_tbChoferes_tbCategoriasChoferes]
GO
ALTER TABLE [dbo].[tbDetallesChoferes]  WITH CHECK ADD  CONSTRAINT [FK_tbDetallesChoferes_tbChoferes] FOREIGN KEY([ChoferId])
REFERENCES [dbo].[tbChoferes] ([ChoferId])
GO
ALTER TABLE [dbo].[tbDetallesChoferes] CHECK CONSTRAINT [FK_tbDetallesChoferes_tbChoferes]
GO
ALTER TABLE [dbo].[tbMenusRoles]  WITH CHECK ADD  CONSTRAINT [FK_tbMenusRoles_cMenus] FOREIGN KEY([MenuId])
REFERENCES [dbo].[cMenus] ([MenuId])
GO
ALTER TABLE [dbo].[tbMenusRoles] CHECK CONSTRAINT [FK_tbMenusRoles_cMenus]
GO
ALTER TABLE [dbo].[tbMenusRoles]  WITH CHECK ADD  CONSTRAINT [FK_tbMenusRoles_tbUsuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[tbUsuarios] ([UsuarioId])
GO
ALTER TABLE [dbo].[tbMenusRoles] CHECK CONSTRAINT [FK_tbMenusRoles_tbUsuarios]
GO
ALTER TABLE [dbo].[tbUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuarios_AspNetRoles] FOREIGN KEY([RolId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[tbUsuarios] CHECK CONSTRAINT [FK_tbUsuarios_AspNetRoles]
GO
ALTER TABLE [dbo].[tbUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_tbUsuarios_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[tbUsuarios] CHECK CONSTRAINT [FK_tbUsuarios_AspNetUsers]
GO
ALTER TABLE [dbo].[tbViajes]  WITH CHECK ADD  CONSTRAINT [FK_tbViajes_tbChoferes] FOREIGN KEY([ChoferId])
REFERENCES [dbo].[tbChoferes] ([ChoferId])
GO
ALTER TABLE [dbo].[tbViajes] CHECK CONSTRAINT [FK_tbViajes_tbChoferes]
GO
ALTER TABLE [dbo].[tbViajes]  WITH CHECK ADD  CONSTRAINT [FK_tbViajes_tbContabilidadViaje] FOREIGN KEY([ContabilidadViajeId])
REFERENCES [dbo].[tbContabilidadViaje] ([ContabilidadViajeId])
GO
ALTER TABLE [dbo].[tbViajes] CHECK CONSTRAINT [FK_tbViajes_tbContabilidadViaje]
GO
ALTER DATABASE [SOTELO_ASPNET] SET  READ_WRITE 
GO
