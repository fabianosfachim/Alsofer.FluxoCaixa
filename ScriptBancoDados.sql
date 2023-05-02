USE [bd_teste]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'receita', @level2type=N'COLUMN',@level2name=N'descricaoReceita'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'receita', @level2type=N'COLUMN',@level2name=N'nomeReceita'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'receita', @level2type=N'COLUMN',@level2name=N'id'
GO
ALTER TABLE [dbo].[contasReceber] DROP CONSTRAINT [FK_contasReceberStatus_contasReceber]
GO
ALTER TABLE [dbo].[contasReceber] DROP CONSTRAINT [FK_contasReceberReceita_contasReceber]
GO
ALTER TABLE [dbo].[contasReceber] DROP CONSTRAINT [FK_contasReceberCliente_contasReceber]
GO
ALTER TABLE [dbo].[contasPagar] DROP CONSTRAINT [FK_contasPagarStatus_contasPagar]
GO
ALTER TABLE [dbo].[contasPagar] DROP CONSTRAINT [FK_contasPagarFornecedor_contasPagar]
GO
ALTER TABLE [dbo].[contasPagar] DROP CONSTRAINT [FK_contasPagarDespesa_contasPagar]
GO
ALTER TABLE [dbo].[status] DROP CONSTRAINT [DF_status_ativo]
GO
ALTER TABLE [dbo].[status] DROP CONSTRAINT [DF_status_dtCadastro]
GO
ALTER TABLE [dbo].[receita] DROP CONSTRAINT [DF_receita_ativo]
GO
ALTER TABLE [dbo].[fornecedor] DROP CONSTRAINT [DF_fornecedor_ativo]
GO
ALTER TABLE [dbo].[despesa] DROP CONSTRAINT [DF_despesa_ativo]
GO
ALTER TABLE [dbo].[cliente] DROP CONSTRAINT [DF_tb_cliente_ativo]
GO
/****** Object:  Table [dbo].[status]    Script Date: 4/27/2023 1:10:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[status]') AND type in (N'U'))
DROP TABLE [dbo].[status]
GO
/****** Object:  Table [dbo].[receita]    Script Date: 4/27/2023 1:10:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[receita]') AND type in (N'U'))
DROP TABLE [dbo].[receita]
GO
/****** Object:  Table [dbo].[login]    Script Date: 4/27/2023 1:10:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[login]') AND type in (N'U'))
DROP TABLE [dbo].[login]
GO
/****** Object:  Table [dbo].[fornecedor]    Script Date: 4/27/2023 1:10:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fornecedor]') AND type in (N'U'))
DROP TABLE [dbo].[fornecedor]
GO
/****** Object:  Table [dbo].[despesa]    Script Date: 4/27/2023 1:10:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[despesa]') AND type in (N'U'))
DROP TABLE [dbo].[despesa]
GO
/****** Object:  Table [dbo].[contasReceber]    Script Date: 4/27/2023 1:10:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[contasReceber]') AND type in (N'U'))
DROP TABLE [dbo].[contasReceber]
GO
/****** Object:  Table [dbo].[contasPagar]    Script Date: 4/27/2023 1:10:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[contasPagar]') AND type in (N'U'))
DROP TABLE [dbo].[contasPagar]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 4/27/2023 1:10:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cliente]') AND type in (N'U'))
DROP TABLE [dbo].[cliente]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 4/27/2023 1:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nomeCliente] [varchar](150) NOT NULL,
	[cpfCnpj] [varchar](15) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[ddd] [varchar](3) NOT NULL,
	[telefone] [varchar](15) NOT NULL,
	[nmUsuarioCadastro] [varchar](50) NOT NULL,
	[dtCadastro] [datetime] NOT NULL,
	[nmUsuarioAlteracao] [varchar](50) NULL,
	[dtAlteracao] [datetime] NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_tb_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contasPagar]    Script Date: 4/27/2023 1:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contasPagar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idFornecedor] [int] NOT NULL,
	[idDespesa] [int] NOT NULL,
	[idStatus] [int] NOT NULL,
	[descricaoContaPagar] [varchar](max) NOT NULL,
	[dtPagamento] [datetime] NOT NULL,
	[vlPagamento] [decimal](19, 2) NOT NULL,
	[nmUsuarioCadastro] [varchar](50) NOT NULL,
	[dtCadastro] [datetime] NOT NULL,
	[nmUsuarioAlteracao] [varchar](50) NULL,
	[dtAlteracao] [datetime] NULL,
 CONSTRAINT [PK_contasPagar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contasReceber]    Script Date: 4/27/2023 1:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contasReceber](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idReceita] [int] NOT NULL,
	[idStatus] [int] NOT NULL,
	[descricaoContasReceber] [varchar](max) NOT NULL,
	[dtPagamento] [datetime] NOT NULL,
	[vlPagamento] [decimal](19, 2) NOT NULL,
	[nmUsuarioCadastro] [varchar](50) NOT NULL,
	[dtCadastro] [datetime] NOT NULL,
	[nmUsuarioAlteracao] [nchar](10)  NULL,
	[dtAlteracao] [datetime]  NULL,
 CONSTRAINT [PK_contasReceber] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[despesa]    Script Date: 4/27/2023 1:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[despesa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nomeDespesa] [varchar](100) NOT NULL,
	[descricaoDespesa] [varchar](250) NOT NULL,
	[nmUsuarioCadastro] [varchar](50) NOT NULL,
	[dtCadastro] [datetime] NOT NULL,
	[nmUsuarioAlteracao] [varchar](50) NULL,
	[dtAlteracao] [datetime] NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_despesa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fornecedor]    Script Date: 4/27/2023 1:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fornecedor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[razaoSocial] [varchar](100) NOT NULL,
	[nomeFantasia] [varchar](150) NULL,
	[cpfCnpj] [varchar](15) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[ddd] [varchar](3) NOT NULL,
	[telefone] [varchar](15) NOT NULL,
	[nmUsuarioCadastro] [varchar](50) NOT NULL,
	[dtCadastro] [datetime] NOT NULL,
	[nmUsuarioAlteracao] [varchar](50) NULL,
	[dtAlteracao] [datetime] NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_tb_fornecedor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login]    Script Date: 4/27/2023 1:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[nmUsuarioCadastro] [varchar](50) NOT NULL,
	[dtCadastro] [datetime] NOT NULL,
	[nmUsuarioAlteracao] [varchar](50) NULL,
	[dtAlteracao] [datetime] NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_tb_login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[receita]    Script Date: 4/27/2023 1:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[receita](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nomeReceita] [varchar](100) NOT NULL,
	[descricaoReceita] [varchar](250) NOT NULL,
	[nmUsuarioCadastro] [varchar](50) NOT NULL,
	[dtCadastro] [datetime] NOT NULL,
	[nmUsuarioAlteracao] [varchar](50) NULL,
	[dtAlteracao] [datetime] NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_receita] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status]    Script Date: 4/27/2023 1:10:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nomeStatus] [varchar](50) NOT NULL,
	[nmUsuarioCadastro] [varchar](50) NOT NULL,
	[dtCadastro] [datetime] NOT NULL,
	[nmUsuarioAlteracao] [varchar](50) NULL,
	[dtAlteracao] [datetime] NULL,
	[ativo] [bit] NOT NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[login] ON 
GO
INSERT [dbo].[login] ([id], [email], [password], [nome], [nmUsuarioCadastro], [dtCadastro], [nmUsuarioAlteracao], [dtAlteracao], [ativo]) VALUES (1, N'teste@teste.com', N'123456', N'Fabiano Spuri Fachim', N'administrador', CAST(N'2023-04-01T00:00:00.000' AS DateTime), NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[login] OFF
GO
SET IDENTITY_INSERT [dbo].[status] ON 
GO
INSERT [dbo].[status] ([id], [nomeStatus], [nmUsuarioCadastro], [dtCadastro], [nmUsuarioAlteracao], [dtAlteracao], [ativo]) VALUES (1, N'Pago', N'admin', CAST(N'2023-04-27T13:06:00.050' AS DateTime), NULL, NULL, 1)
GO
INSERT [dbo].[status] ([id], [nomeStatus], [nmUsuarioCadastro], [dtCadastro], [nmUsuarioAlteracao], [dtAlteracao], [ativo]) VALUES (2, N'Não Pago', N'admin', CAST(N'2023-04-27T13:06:17.263' AS DateTime), NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[status] OFF
GO
ALTER TABLE [dbo].[cliente] ADD  CONSTRAINT [DF_tb_cliente_ativo]  DEFAULT ((1)) FOR [ativo]
GO
ALTER TABLE [dbo].[despesa] ADD  CONSTRAINT [DF_despesa_ativo]  DEFAULT ((1)) FOR [ativo]
GO
ALTER TABLE [dbo].[fornecedor] ADD  CONSTRAINT [DF_fornecedor_ativo]  DEFAULT ((1)) FOR [ativo]
GO
ALTER TABLE [dbo].[receita] ADD  CONSTRAINT [DF_receita_ativo]  DEFAULT ((1)) FOR [ativo]
GO
ALTER TABLE [dbo].[status] ADD  CONSTRAINT [DF_status_dtCadastro]  DEFAULT (getdate()) FOR [dtCadastro]
GO
ALTER TABLE [dbo].[status] ADD  CONSTRAINT [DF_status_ativo]  DEFAULT ((1)) FOR [ativo]
GO
ALTER TABLE [dbo].[contasPagar]  WITH CHECK ADD  CONSTRAINT [FK_contasPagarDespesa_contasPagar] FOREIGN KEY([idDespesa])
REFERENCES [dbo].[despesa] ([id])
GO
ALTER TABLE [dbo].[contasPagar] CHECK CONSTRAINT [FK_contasPagarDespesa_contasPagar]
GO
ALTER TABLE [dbo].[contasPagar]  WITH CHECK ADD  CONSTRAINT [FK_contasPagarFornecedor_contasPagar] FOREIGN KEY([idFornecedor])
REFERENCES [dbo].[fornecedor] ([id])
GO
ALTER TABLE [dbo].[contasPagar] CHECK CONSTRAINT [FK_contasPagarFornecedor_contasPagar]
GO
ALTER TABLE [dbo].[contasPagar]  WITH CHECK ADD  CONSTRAINT [FK_contasPagarStatus_contasPagar] FOREIGN KEY([idStatus])
REFERENCES [dbo].[status] ([id])
GO
ALTER TABLE [dbo].[contasPagar] CHECK CONSTRAINT [FK_contasPagarStatus_contasPagar]
GO
ALTER TABLE [dbo].[contasReceber]  WITH CHECK ADD  CONSTRAINT [FK_contasReceberCliente_contasReceber] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[contasReceber] CHECK CONSTRAINT [FK_contasReceberCliente_contasReceber]
GO
ALTER TABLE [dbo].[contasReceber]  WITH CHECK ADD  CONSTRAINT [FK_contasReceberReceita_contasReceber] FOREIGN KEY([idReceita])
REFERENCES [dbo].[receita] ([id])
GO
ALTER TABLE [dbo].[contasReceber] CHECK CONSTRAINT [FK_contasReceberReceita_contasReceber]
GO
ALTER TABLE [dbo].[contasReceber]  WITH CHECK ADD  CONSTRAINT [FK_contasReceberStatus_contasReceber] FOREIGN KEY([idStatus])
REFERENCES [dbo].[status] ([id])
GO
ALTER TABLE [dbo].[contasReceber] CHECK CONSTRAINT [FK_contasReceberStatus_contasReceber]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id da receita' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'receita', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'nome da receita' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'receita', @level2type=N'COLUMN',@level2name=N'nomeReceita'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'descrição receita' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'receita', @level2type=N'COLUMN',@level2name=N'descricaoReceita'
GO
