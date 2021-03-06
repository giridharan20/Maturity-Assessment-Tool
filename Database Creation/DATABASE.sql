USE [master]
GO
/****** Object:  Database [MaturityAssessmenttool]    Script Date: 25-04-2022 22:27:38 ******/
CREATE DATABASE [MaturityAssessmenttool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MaturityAssessmenttool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MaturityAssessmenttool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MaturityAssessmenttool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MaturityAssessmenttool_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MaturityAssessmenttool] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MaturityAssessmenttool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MaturityAssessmenttool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET ARITHABORT OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MaturityAssessmenttool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MaturityAssessmenttool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MaturityAssessmenttool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MaturityAssessmenttool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET RECOVERY FULL 
GO
ALTER DATABASE [MaturityAssessmenttool] SET  MULTI_USER 
GO
ALTER DATABASE [MaturityAssessmenttool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MaturityAssessmenttool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MaturityAssessmenttool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MaturityAssessmenttool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MaturityAssessmenttool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MaturityAssessmenttool] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MaturityAssessmenttool', N'ON'
GO
ALTER DATABASE [MaturityAssessmenttool] SET QUERY_STORE = OFF
GO
USE [MaturityAssessmenttool]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 25-04-2022 22:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Question_id] [int] NULL,
	[Answer_id] [int] IDENTITY(1,1) NOT NULL,
	[Answer] [varchar](25) NULL,
	[Answer_Weightage] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Answer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 25-04-2022 22:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Project_id] [int] IDENTITY(1,1) NOT NULL,
	[Projectname] [varchar](25) NULL,
	[ProjectDescription] [varchar](50) NULL,
	[Function_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectFunction]    Script Date: 25-04-2022 22:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFunction](
	[Function_id] [int] IDENTITY(1,1) NOT NULL,
	[FunctionName] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Function_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectMembers]    Script Date: 25-04-2022 22:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectMembers](
	[ProjectMember_id] [int] IDENTITY(1,1) NOT NULL,
	[Project_id] [int] NULL,
	[user_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectMember_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 25-04-2022 22:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Question_id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [varchar](300) NULL,
	[Function_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 25-04-2022 22:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[Survey_id] [int] IDENTITY(1,1) NOT NULL,
	[Surveyname] [varchar](25) NULL,
	[Survey_Start_date] [date] NULL,
	[Survey_End_date] [date] NULL,
	[Project_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Survey_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 25-04-2022 22:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](25) NULL,
	[LastName] [varchar](25) NULL,
	[userType] [varchar](25) NULL,
	[Emailid] [varchar](25) NULL,
	[password] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSurvey]    Script Date: 25-04-2022 22:27:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSurvey](
	[User_Survey_id] [int] IDENTITY(1,1) NOT NULL,
	[Question_id] [int] NULL,
	[Answer_id] [int] NULL,
	[Survey_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[User_Survey_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD FOREIGN KEY([Question_id])
REFERENCES [dbo].[Questions] ([Question_id])
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD FOREIGN KEY([Function_id])
REFERENCES [dbo].[ProjectFunction] ([Function_id])
GO
ALTER TABLE [dbo].[ProjectMembers]  WITH CHECK ADD FOREIGN KEY([Project_id])
REFERENCES [dbo].[Project] ([Project_id])
GO
ALTER TABLE [dbo].[ProjectMembers]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD FOREIGN KEY([Function_id])
REFERENCES [dbo].[ProjectFunction] ([Function_id])
GO
ALTER TABLE [dbo].[Survey]  WITH CHECK ADD FOREIGN KEY([Project_id])
REFERENCES [dbo].[Project] ([Project_id])
GO
ALTER TABLE [dbo].[UserSurvey]  WITH CHECK ADD FOREIGN KEY([Answer_id])
REFERENCES [dbo].[Answers] ([Answer_id])
GO
ALTER TABLE [dbo].[UserSurvey]  WITH CHECK ADD FOREIGN KEY([Question_id])
REFERENCES [dbo].[Questions] ([Question_id])
GO
ALTER TABLE [dbo].[UserSurvey]  WITH CHECK ADD FOREIGN KEY([Survey_id])
REFERENCES [dbo].[Survey] ([Survey_id])
GO
USE [master]
GO
ALTER DATABASE [MaturityAssessmenttool] SET  READ_WRITE 
GO
