USE [master]
GO

/****** Object:  Database [DimaCool]    Script Date: 16.05.2024 15:07:59 ******/
CREATE DATABASE [DimaCool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DimaCool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DimaCool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DimaCool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DimaCool_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DimaCool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DimaCool] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DimaCool] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DimaCool] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DimaCool] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DimaCool] SET ARITHABORT OFF 
GO

ALTER DATABASE [DimaCool] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DimaCool] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DimaCool] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DimaCool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DimaCool] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DimaCool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DimaCool] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DimaCool] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DimaCool] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DimaCool] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DimaCool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DimaCool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DimaCool] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DimaCool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DimaCool] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DimaCool] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DimaCool] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DimaCool] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [DimaCool] SET  MULTI_USER 
GO

ALTER DATABASE [DimaCool] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DimaCool] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DimaCool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DimaCool] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [DimaCool] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DimaCool] SET QUERY_STORE = OFF
GO

ALTER DATABASE [DimaCool] SET  READ_WRITE 
GO
