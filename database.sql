USE [master]
GO

/****** Object:  Database [ProjectCp_db]    Script Date: 7/02/2023 8:06:23 PM ******/
CREATE DATABASE [ProjectCp_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectCp_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjectCp_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectCp_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjectCp_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
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

ALTER DATABASE [ProjectCp_db] SET  READ_WRITE 
GO

