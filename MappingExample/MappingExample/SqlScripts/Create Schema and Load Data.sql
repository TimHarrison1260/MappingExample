USE [master]
GO
/****** Object:  Database [NDbT_Lab1]    Script Date: 01/18/2013 15:46:16 ******/
CREATE DATABASE [NDbT_Lab1] ON  PRIMARY 
( NAME = N'NDbT_Lab1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\NDbT_Lab1.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NDbT_Lab1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\NDbT_Lab1_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NDbT_Lab1] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NDbT_Lab1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NDbT_Lab1] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [NDbT_Lab1] SET ANSI_NULLS OFF
GO
ALTER DATABASE [NDbT_Lab1] SET ANSI_PADDING OFF
GO
ALTER DATABASE [NDbT_Lab1] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [NDbT_Lab1] SET ARITHABORT OFF
GO
ALTER DATABASE [NDbT_Lab1] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [NDbT_Lab1] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [NDbT_Lab1] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [NDbT_Lab1] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [NDbT_Lab1] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [NDbT_Lab1] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [NDbT_Lab1] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [NDbT_Lab1] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [NDbT_Lab1] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [NDbT_Lab1] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [NDbT_Lab1] SET  DISABLE_BROKER
GO
ALTER DATABASE [NDbT_Lab1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [NDbT_Lab1] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [NDbT_Lab1] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [NDbT_Lab1] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [NDbT_Lab1] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [NDbT_Lab1] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [NDbT_Lab1] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [NDbT_Lab1] SET  READ_WRITE
GO
ALTER DATABASE [NDbT_Lab1] SET RECOVERY SIMPLE
GO
ALTER DATABASE [NDbT_Lab1] SET  MULTI_USER
GO
ALTER DATABASE [NDbT_Lab1] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [NDbT_Lab1] SET DB_CHAINING OFF
GO
USE [NDbT_Lab1]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 01/18/2013 15:46:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT [dbo].[Department] ([Id], [Name]) VALUES (1, N'Purchasing                                                                                          ')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (2, N'Sales                                                                                               ')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (3, N'Accounts                                                                                            ')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (4, N'Manufacturing                                                                                       ')
SET IDENTITY_INSERT [dbo].[Department] OFF
/****** Object:  Table [dbo].[Address]    Script Date: 01/18/2013 15:46:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostCode] [nchar](10) NOT NULL,
	[PropertyName] [nchar](100) NULL,
	[PropertyNumber] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON
INSERT [dbo].[Address] ([Id], [PostCode], [PropertyName], [PropertyNumber]) VALUES (1, N'KA3 6EX   ', N'Cauldstanes                                                                                         ', NULL)
INSERT [dbo].[Address] ([Id], [PostCode], [PropertyName], [PropertyNumber]) VALUES (2, N'G77 6A    ', N'Wylie Av.                                                                                           ', 12)
SET IDENTITY_INSERT [dbo].[Address] OFF
/****** Object:  Table [dbo].[Employee]    Script Date: 01/18/2013 15:46:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NULL,
	[UserName] [nchar](10) NOT NULL,
	[PhoneNumber] [nchar](15) NULL,
	[SupervisorId] [int] NULL,
	[DeptId] [int] NOT NULL,
	[AddressId] [int] NULL,
	[Type] [tinyint] NOT NULL,
	[PayGrade] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT [dbo].[Employee] ([Id], [Name], [UserName], [PhoneNumber], [SupervisorId], [DeptId], [AddressId], [Type], [PayGrade]) VALUES (1, N'Tim Harrison                                                                                        ', N'THarrison ', N'01234 567789   ', NULL, 3, 1, 1, 9)
INSERT [dbo].[Employee] ([Id], [Name], [UserName], [PhoneNumber], [SupervisorId], [DeptId], [AddressId], [Type], [PayGrade]) VALUES (2, N'Nancy Harrison                                                                                      ', N'NHarrison ', N'01234 567890   ', 1, 3, 1, 2, NULL)
INSERT [dbo].[Employee] ([Id], [Name], [UserName], [PhoneNumber], [SupervisorId], [DeptId], [AddressId], [Type], [PayGrade]) VALUES (3, N'Niall Harrison                                                                                      ', N'Niharrison', N'02345 456789   ', NULL, 1, 1, 1, 6)
INSERT [dbo].[Employee] ([Id], [Name], [UserName], [PhoneNumber], [SupervisorId], [DeptId], [AddressId], [Type], [PayGrade]) VALUES (4, N'Bill MacGregor                                                                                      ', N'BMacGregor', N'0141 999 8888  ', 3, 1, 2, 1, NULL)
INSERT [dbo].[Employee] ([Id], [Name], [UserName], [PhoneNumber], [SupervisorId], [DeptId], [AddressId], [Type], [PayGrade]) VALUES (5, N'Grant MacGretor                                                                                     ', N'GMacGregor', N'0141 998 7878  ', 3, 1, 2, 2, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
/****** Object:  ForeignKey [FK_Employee_Address]    Script Date: 01/18/2013 15:46:20 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Address]
GO
/****** Object:  ForeignKey [FK_Employee_Department]    Script Date: 01/18/2013 15:46:20 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
