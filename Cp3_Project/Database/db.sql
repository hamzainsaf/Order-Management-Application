USE [master]
GO
/****** Object:  Database [ProjectCp_db]    Script Date: 10/02/2023 9:35:09 PM ******/
CREATE DATABASE [ProjectCp_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectCp_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjectCp_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectCp_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjectCp_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectCp_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectCp_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectCp_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectCp_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectCp_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectCp_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectCp_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectCp_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectCp_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectCp_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectCp_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectCp_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectCp_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectCp_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectCp_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectCp_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectCp_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectCp_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectCp_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectCp_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectCp_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectCp_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectCp_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectCp_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectCp_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectCp_db] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectCp_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectCp_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectCp_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectCp_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectCp_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectCp_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProjectCp_db] SET QUERY_STORE = OFF
GO
USE [ProjectCp_db]
GO
/****** Object:  Table [dbo].[Inventory1]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory1](
	[Name] [nvarchar](50) NULL,
	[Catagory] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[Availability] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordertb6]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordertb6](
	[Product] [nvarchar](50) NULL,
	[UnitPrice] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[Quantity] [nchar](10) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ordertb6] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb1_userdata]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb1_userdata](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb1_userdata] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb2_table]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb2_table](
	[id] [int] NULL,
	[Date] [date] NULL,
	[username] [nvarchar](50) NULL,
	[Total] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb3_orders]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb3_orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[username] [nvarchar](50) NULL,
	[total] [nchar](10) NULL,
 CONSTRAINT [PK_tb3_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb4_orders]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb4_orders](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[Uname] [nvarchar](50) NULL,
	[Product] [nvarchar](50) NULL,
	[Quantity] [nvarchar](50) NULL,
	[Total] [nvarchar](50) NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_tb4_orders] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_data]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User_data] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[addorders]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[addorders]
@date Date,
@username varchar(50),
@totalprice varchar(50)

AS
	INSERT INTO tb3_orders(date,username,total)
	VALUES(@date,@username,@totalprice)
GO
/****** Object:  StoredProcedure [dbo].[addorders3]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[addorders3]

@Uname nvarchar(50),
@Product nvarchar(50),
@Quantity nvarchar(50),
@Total nvarchar(50)

AS
	INSERT INTO tb4_orders(Uname,Product,Quantity, Total)
	VALUES(@Uname,@Product,@Quantity,@Total)
GO
/****** Object:  StoredProcedure [dbo].[addorders4]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[addorders4]
@Date Date,
@Uname nvarchar(50),
@Product nvarchar(50),
@Quantity nvarchar(50),
@Total nvarchar(50)

AS
	INSERT INTO tb4_orders(Date,Uname,Product,Quantity, Total)
	VALUES(@Date,@Uname,@Product,@Quantity,@Total)
GO
/****** Object:  StoredProcedure [dbo].[addorders6]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[addorders6]

@Product nvarchar(50),
@UnitPrice nvarchar(50),
@Quantity nvarchar(50),
@Price nvarchar(50)

AS
	INSERT INTO ordertb6(Product,UnitPrice,Quantity, Price)
	VALUES(@Product,@UnitPrice,@Quantity,@Price)
GO
/****** Object:  StoredProcedure [dbo].[sp_userdata]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_userdata]
@username nvarchar(50),
@upass nvarchar(50)
as 
begin 
select * from tb1_userdata where username = @username And password = @upass
end
GO
/****** Object:  StoredProcedure [dbo].[UserAddInventory]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserAddInventory]

@ProductName nvarchar(50),
@Catagory nvarchar(50),
@Price int,
@Availability int

AS
	INSERT INTO dbo.Inventory1(Name,Catagory,Price,Availability)
	VALUES(@ProductName,@Catagory,@Price,@Availability)
GO
/****** Object:  StoredProcedure [dbo].[userdataADD]    Script Date: 10/02/2023 9:35:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[userdataADD]
@name nvarchar(50),
@username nvarchar(50),
@password nvarchar(50)

As 
 Insert  INTO tb1_userdata(name,username,password)
 VALUES (@name,@username,@password)
GO
USE [master]
GO
ALTER DATABASE [ProjectCp_db] SET  READ_WRITE 
GO
