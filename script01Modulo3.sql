USE [BDInstituto]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 26/11/2022 09:31:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[instructor]    Script Date: 26/11/2022 09:31:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instructor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](300) NULL,
	[Apellidos] [varchar](300) NULL,
	[NumeroDocumento] [varchar](300) NULL,
	[Celular] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taller]    Script Date: 26/11/2022 09:31:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taller](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[FechaInicio] [date] NULL,
	[FechaFin] [date] NULL,
	[CodigoInstructor] [int] NULL,
	[CodigoCategoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/11/2022 09:31:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NULL,
	[Clave] [varchar](100) NULL,
	[token_recovery] [varchar](200) NULL,
	[fechaCreacion] [date] NULL,
	[bloqueado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [email], [Clave], [token_recovery], [fechaCreacion], [bloqueado]) VALUES (1, N'anthony-nek22@hotmail.com', N'12345', N'916b5f8c86655c2a92fdacba62dc522d96275f4e26f178ba3fdd58dd526b74a8', CAST(N'2022-11-26' AS Date), 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((0)) FOR [bloqueado]
GO
ALTER TABLE [dbo].[taller]  WITH CHECK ADD  CONSTRAINT [FK_IdCategoria] FOREIGN KEY([CodigoCategoria])
REFERENCES [dbo].[Categorias] ([Id])
GO
ALTER TABLE [dbo].[taller] CHECK CONSTRAINT [FK_IdCategoria]
GO
ALTER TABLE [dbo].[taller]  WITH CHECK ADD  CONSTRAINT [FK_IdTaller] FOREIGN KEY([CodigoInstructor])
REFERENCES [dbo].[instructor] ([Id])
GO
ALTER TABLE [dbo].[taller] CHECK CONSTRAINT [FK_IdTaller]
GO
