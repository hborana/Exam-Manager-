USE [master]
GO
/****** Object:  Database [ExamManager]    Script Date: 02-Jan-18 5:17:20 PM ******/
CREATE DATABASE [ExamManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExamManager', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ExamManager.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ExamManager_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ExamManager_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ExamManager] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExamManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExamManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExamManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExamManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExamManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExamManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExamManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExamManager] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ExamManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExamManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExamManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExamManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExamManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExamManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExamManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExamManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExamManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExamManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExamManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExamManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExamManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExamManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExamManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExamManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExamManager] SET RECOVERY FULL 
GO
ALTER DATABASE [ExamManager] SET  MULTI_USER 
GO
ALTER DATABASE [ExamManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExamManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExamManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExamManager] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ExamManager', N'ON'
GO
USE [ExamManager]
GO
/****** Object:  Table [dbo].[Branch_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branch_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](50) NULL,
	[Course_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Table_1_2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Chapter_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chapter_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Subject_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Table_1_6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Class_Allocation]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Allocation](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Class_ID] [numeric](18, 0) NULL,
	[Student_ID] [numeric](18, 0) NULL,
	[Exam_ID] [numeric](18, 0) NULL,
	[Timetable_ID] [numeric](18, 0) NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Seat_No] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Class_Allocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Class_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Class_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Class_No] [varchar](50) NULL,
	[Number_Of_Benches] [numeric](18, 0) NULL,
	[Student_Per_Benches] [numeric](18, 0) NULL,
	[Remark] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1_8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Remark] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1_3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Exam_Attendence]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam_Attendence](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Student_ID] [numeric](18, 0) NULL,
	[Timetable_ID] [numeric](18, 0) NULL,
	[isPresent] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Exam_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Exam_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Remark] [varchar](50) NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Is_Active] [bit] NULL,
 CONSTRAINT [PK_Table_1_7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faculty_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faculty_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Contact_No] [varchar](50) NULL,
	[EMail] [varchar](50) NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Designation] [varchar](50) NULL,
	[Enrolment] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1_5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Function_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Function_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Intermediate]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intermediate](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Exam_ID] [numeric](18, 0) NULL,
	[Student_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Intermediate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[User_Name] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Faculty_ID] [numeric](18, 0) NULL,
	[Student_ID] [numeric](18, 0) NULL,
	[Designation] [varchar](50) NULL,
	[Role_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Login_Master] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaperFormat]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaperFormat](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Total_Marks] [numeric](18, 0) NULL,
 CONSTRAINT [PK_PaperFormat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Question_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Question_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Sem_ID] [numeric](18, 0) NULL,
	[Subject_ID] [numeric](18, 0) NULL,
	[Chapter_ID] [numeric](18, 0) NULL,
	[Marks] [numeric](18, 0) NULL,
	[Format_ID] [numeric](18, 0) NULL,
	[Question] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1_12] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionFormat_Detail]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionFormat_Detail](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[QuestionPaper_Format_ID] [numeric](18, 0) NULL,
	[Marks] [numeric](18, 0) NULL,
	[Question_Sub_No] [numeric](18, 0) NULL,
	[Is_Required] [bit] NULL,
 CONSTRAINT [PK_QuestionFormat_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questionpaper_Detail]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questionpaper_Detail](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Question_ID] [numeric](18, 0) NULL,
	[Questionpaper_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Questionpaper_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuestionPaper_Format]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionPaper_Format](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Question_No] [numeric](18, 0) NULL,
	[Required_No] [numeric](18, 0) NULL,
	[Out_Of] [numeric](18, 0) NULL,
	[Marks] [numeric](18, 0) NULL,
	[Is_Of_Same_Marks] [bit] NULL,
	[Format_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Question_Format_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuestionPaper_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionPaper_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Sem_ID] [numeric](18, 0) NULL,
	[Subject_ID] [numeric](18, 0) NULL,
	[Total_Marks] [numeric](18, 0) NULL,
	[Passing_Marks] [numeric](18, 0) NULL,
	[Total_Duretion] [datetime] NULL,
	[Format_ID] [numeric](18, 0) NULL,
	[Timetable_ID] [numeric](18, 0) NULL,
	[Remark] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1_10] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Result_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Student_ID] [numeric](18, 0) NULL,
	[Subject_ID] [numeric](18, 0) NULL,
	[Attendence_ID] [numeric](18, 0) NULL,
	[Sem_ID] [numeric](18, 0) NULL,
	[Marks] [numeric](18, 0) NULL,
	[Exam_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Table1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role_Alloction]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role_Alloction](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Is_Allow] [varchar](20) NULL,
	[Function_ID] [numeric](18, 0) NULL,
	[Role_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Roll_Alloction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Roll_Master] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Section_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Section_Master](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Section] [varchar](50) NULL,
	[No_Of_Student] [numeric](18, 0) NULL,
	[Academic_Year] [varchar](20) NULL,
	[Sem_Id] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Section_Master] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Sem] [numeric](18, 0) NULL,
	[Branch_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Semester_Master] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Similar_Branch]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Similar_Branch](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Branch_ID1] [numeric](18, 0) NULL,
	[Branch_ID2] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Table_1_11] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Enrolment] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Sem_ID] [numeric](18, 0) NULL,
	[Contact_No] [varchar](50) NULL,
	[EMail] [varchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Table_1_13] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Subject_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Sem_ID] [numeric](18, 0) NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1_4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Supervisor_Order]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supervisor_Order](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Class_ID] [numeric](18, 0) NULL,
	[Timetable_ID] [numeric](18, 0) NULL,
	[Faculty_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Supervisor_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supervisor_Report]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supervisor_Report](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Student_ID] [numeric](18, 0) NULL,
	[Enrollment] [varchar](50) NULL,
	[Class_ID] [numeric](18, 0) NULL,
	[Timetable_ID] [numeric](18, 0) NULL,
	[Seat_No] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Supervisor_Report] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Timetable_Master]    Script Date: 02-Jan-18 5:17:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timetable_Master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[tt_date] [date] NULL,
	[Fromtime] [time](7) NULL,
	[Totime] [time](7) NULL,
	[Format_ID] [numeric](18, 0) NULL,
	[Branch_ID] [numeric](18, 0) NULL,
	[Sem_ID] [numeric](18, 0) NULL,
	[Subject_ID] [numeric](18, 0) NULL,
	[Exam_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Table_1_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Branch_Master] ON 

INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(1 AS Numeric(18, 0)), N'Mechanical Engineering', N'ME', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(2 AS Numeric(18, 0)), N'Computer Engineering', N'CE', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(3 AS Numeric(18, 0)), N'Information Technology', N'IT', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(4 AS Numeric(18, 0)), N'Automobile Engineering', N'AE', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(5 AS Numeric(18, 0)), N'Architectural Engineering', N'ARCH', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(6 AS Numeric(18, 0)), N'Chemical Engineering', N'CHE', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(7 AS Numeric(18, 0)), N'Electrical Engineering', N'EE', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(8 AS Numeric(18, 0)), N'Agricultural Engineering', N'AGRI', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(9 AS Numeric(18, 0)), N'Chemical Engineering', N'CHE', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(10 AS Numeric(18, 0)), N'Petroleum Engineering', N'PE', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(11 AS Numeric(18, 0)), N'Biotechnology Engineering', N'BIOE', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(12 AS Numeric(18, 0)), N'Genetic Engineering', N'GE', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(13 AS Numeric(18, 0)), N'Aeronautical Engineering', N'AROE', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(14 AS Numeric(18, 0)), N'B.Sc. Agriculture', N'BscAGRI', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(15 AS Numeric(18, 0)), N'B.Sc. Mathematics', N'BscMath', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(16 AS Numeric(18, 0)), N'B.Sc. Physics', N'BscPhy', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(17 AS Numeric(18, 0)), N'B.Sc. Chemistry', N'BscChem', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(18 AS Numeric(18, 0)), N'B.Sc. LLB', N'BscLLB', CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(19 AS Numeric(18, 0)), N'Bachleor of Interior Designing', N'BID', CAST(7 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(20 AS Numeric(18, 0)), N'Bachelor of Design', N'BDES', CAST(7 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(23 AS Numeric(18, 0)), N'degree', N'de', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(24 AS Numeric(18, 0)), N'degree', N'de', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(25 AS Numeric(18, 0)), N'degree', N'de', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(10026 AS Numeric(18, 0)), N'Information Technology', N'IT', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Branch_Master] ([Id], [Name], [Code], [Course_ID]) VALUES (CAST(10027 AS Numeric(18, 0)), N'fff', N'sd', CAST(1 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Branch_Master] OFF
SET IDENTITY_INSERT [dbo].[Chapter_Master] ON 

INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(1 AS Numeric(18, 0)), N'Determinants and Matrices', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(2 AS Numeric(18, 0)), N'Logarithm', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(3 AS Numeric(18, 0)), N'Trignometry', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(4 AS Numeric(18, 0)), N'Vectors', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(5 AS Numeric(18, 0)), N'Menstruation', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(6 AS Numeric(18, 0)), N'Ecology and Environment', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(7 AS Numeric(18, 0)), N'Sustainable Development', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(8 AS Numeric(18, 0)), N'Wind Power', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(9 AS Numeric(18, 0)), N'Solar Power', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(10 AS Numeric(18, 0)), N'Biomass Energy', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(11 AS Numeric(18, 0)), N'Seismic Engineering and Disaster Management', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(12 AS Numeric(18, 0)), N'Flowchart and Algorithm', CAST(12 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(13 AS Numeric(18, 0)), N'Basics of ''c''', CAST(12 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(14 AS Numeric(18, 0)), N'Operators and Expression', CAST(12 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(15 AS Numeric(18, 0)), N'Decision Statements', CAST(12 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(16 AS Numeric(18, 0)), N'Loop Control Statements', CAST(12 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(17 AS Numeric(18, 0)), N'Introduction of Array(one dimensional)', CAST(12 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(18 AS Numeric(18, 0)), N'Integration', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(19 AS Numeric(18, 0)), N'Integration', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(20 AS Numeric(18, 0)), N'Matrix', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(21 AS Numeric(18, 0)), N'Determinant', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(22 AS Numeric(18, 0)), N'df', CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Chapter_Master] ([Id], [Name], [Subject_ID]) VALUES (CAST(25 AS Numeric(18, 0)), N'Basics of ''c''', CAST(12 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Chapter_Master] OFF
SET IDENTITY_INSERT [dbo].[Class_Allocation] ON 

INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(14 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(15 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(16 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(17 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(18 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(19 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(20 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(21 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(22 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(24 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(25 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(26 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(27 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(28 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(16 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(29 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(30 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(31 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(33 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(34 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(35 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(36 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(37 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(38 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(39 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(40 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(41 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(42 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(23 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(43 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(26 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(44 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(27 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(45 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(29 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(46 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(31 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(47 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(35 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(48 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(37 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(49 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(50 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(51 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(52 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10011 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10012 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10013 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10014 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10015 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10016 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(16 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10017 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10018 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10019 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10020 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10021 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(26 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10022 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(27 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10023 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(29 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10024 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(31 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10025 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(33 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10026 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(35 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10027 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(37 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10028 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10029 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10030 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10031 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10032 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10033 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10034 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10035 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10036 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10037 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(16 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10038 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10039 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10040 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10041 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10042 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(26 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10043 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(27 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10044 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(29 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10045 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(31 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10046 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(33 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10047 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(35 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10048 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(37 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10049 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10050 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10051 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Class_Allocation] ([Id], [Class_ID], [Student_ID], [Exam_ID], [Timetable_ID], [Branch_ID], [Seat_No]) VALUES (CAST(10052 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Class_Allocation] OFF
SET IDENTITY_INSERT [dbo].[Class_Master] ON 

INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(2 AS Numeric(18, 0)), N'202', CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(3 AS Numeric(18, 0)), N'203', CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(4 AS Numeric(18, 0)), N'204', CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(5 AS Numeric(18, 0)), N'205', CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(6 AS Numeric(18, 0)), N'206', CAST(7 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(7 AS Numeric(18, 0)), N'207', CAST(8 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(8 AS Numeric(18, 0)), N'209', CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(9 AS Numeric(18, 0)), N'210', CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), NULL)
INSERT [dbo].[Class_Master] ([Id], [Class_No], [Number_Of_Benches], [Student_Per_Benches], [Remark]) VALUES (CAST(12 AS Numeric(18, 0)), N'201', CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'')
SET IDENTITY_INSERT [dbo].[Class_Master] OFF
SET IDENTITY_INSERT [dbo].[Course_Master] ON 

INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(1 AS Numeric(18, 0)), N'Diploma', N'')
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(2 AS Numeric(18, 0)), N'Bachelor of Engineering', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(3 AS Numeric(18, 0)), N'Science Courses', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(4 AS Numeric(18, 0)), N'Law Courses', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(5 AS Numeric(18, 0)), N'ManagementCourses', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(6 AS Numeric(18, 0)), N'Bachelor of Architecture', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(7 AS Numeric(18, 0)), N'Designing Courses', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(8 AS Numeric(18, 0)), N'Fashion Courses', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(9 AS Numeric(18, 0)), N'Bachelor of Pharmacy', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(10 AS Numeric(18, 0)), N'Bachelor of Arts', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(11 AS Numeric(18, 0)), N'Master of Arts', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(12 AS Numeric(18, 0)), N'Master of Engineering', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(13 AS Numeric(18, 0)), N'Hotel Management', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(14 AS Numeric(18, 0)), N'Mass Communication', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(15 AS Numeric(18, 0)), N'Animation and Multimedia', N'')
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(16 AS Numeric(18, 0)), N'Event Management', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(17 AS Numeric(18, 0)), N'Hospitality Management', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(18 AS Numeric(18, 0)), N'Event Management', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(19 AS Numeric(18, 0)), N'Bachelor of Commerece', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(20 AS Numeric(18, 0)), N'Charted Accountancy', NULL)
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(21 AS Numeric(18, 0)), N'3433', N'')
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(22 AS Numeric(18, 0)), N'Bachelor of Arts	', N'')
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(10021 AS Numeric(18, 0)), N'Diploma', N'')
INSERT [dbo].[Course_Master] ([Id], [Name], [Remark]) VALUES (CAST(10022 AS Numeric(18, 0)), N'Diploma', N'')
SET IDENTITY_INSERT [dbo].[Course_Master] OFF
SET IDENTITY_INSERT [dbo].[Exam_Master] ON 

INSERT [dbo].[Exam_Master] ([Id], [Name], [Remark], [Branch_ID], [Is_Active]) VALUES (CAST(1 AS Numeric(18, 0)), N'Mid-Sem ', N'', CAST(2 AS Numeric(18, 0)), 1)
INSERT [dbo].[Exam_Master] ([Id], [Name], [Remark], [Branch_ID], [Is_Active]) VALUES (CAST(2 AS Numeric(18, 0)), N'Mid-Sem  2', N'', CAST(2 AS Numeric(18, 0)), 1)
INSERT [dbo].[Exam_Master] ([Id], [Name], [Remark], [Branch_ID], [Is_Active]) VALUES (CAST(3 AS Numeric(18, 0)), N'Regular', N'', CAST(1 AS Numeric(18, 0)), 1)
INSERT [dbo].[Exam_Master] ([Id], [Name], [Remark], [Branch_ID], [Is_Active]) VALUES (CAST(4 AS Numeric(18, 0)), N'Remideal', N'', CAST(2 AS Numeric(18, 0)), 0)
INSERT [dbo].[Exam_Master] ([Id], [Name], [Remark], [Branch_ID], [Is_Active]) VALUES (CAST(5 AS Numeric(18, 0)), N'mid sem', N'', CAST(3 AS Numeric(18, 0)), 0)
SET IDENTITY_INSERT [dbo].[Exam_Master] OFF
SET IDENTITY_INSERT [dbo].[Faculty_Master] ON 

INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(1 AS Numeric(18, 0)), N'Adhir Chouhan', N'7539514628', N'adhir@gmail.com', CAST(3 AS Numeric(18, 0)), N'Visiting Faculty', N'6330316001')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(2 AS Numeric(18, 0)), N'Ravindra Borana', N'9876532144', N'raviborana@gmail.com', CAST(3 AS Numeric(18, 0)), N'HOD', N'6330316002')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(3 AS Numeric(18, 0)), N'Jesha Shah', N'9517536248', N'jeshaSh@yahoo.com', CAST(3 AS Numeric(18, 0)), N'Proffesor', N'6330316003')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(4 AS Numeric(18, 0)), N'Revati Nasara', N'759314682', N'revanas@yahoo.com', CAST(3 AS Numeric(18, 0)), N'Proffesor', N'6330316004')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(5 AS Numeric(18, 0)), N'Nitin Patel ', N'957412368', N'nitinpatel@gmail.com', CAST(3 AS Numeric(18, 0)), N'Proffesor', N'6330316005')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(6 AS Numeric(18, 0)), N'Mitesh Shah', N'741256983', N'miteshShah@gmail.com', CAST(3 AS Numeric(18, 0)), N'Proffesor', N'6330316006')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(7 AS Numeric(18, 0)), N'Misti Sisodia', N'987456321', N'misti@yahoo.com', CAST(5 AS Numeric(18, 0)), N'HOD', N'6330315001')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(8 AS Numeric(18, 0)), N'Mahima Parmar', N'789623541', N'mahi@gmail.com', CAST(5 AS Numeric(18, 0)), N'Proffesor', N'6330315002')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(9 AS Numeric(18, 0)), N'Kusum Parmar', N'698745123', N'kusumPrmar@gmail.com', CAST(5 AS Numeric(18, 0)), N'Proffesor', N'6330315003')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(10 AS Numeric(18, 0)), N'Bhagwat Sashtri', N'957864231', N'bhagwatt@yahoo.com', CAST(5 AS Numeric(18, 0)), N'Proffesor', N'6330315004')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(11 AS Numeric(18, 0)), N'Chitresh Parmar', N'987654123', N'chitresh@yahoo.com', CAST(5 AS Numeric(18, 0)), N'Visiting Faculty', N'6330315005')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(12 AS Numeric(18, 0)), N'Anjali Kapadia', N'987654126', N'anjali@yahoo.com', CAST(2 AS Numeric(18, 0)), N'Proffesor', N'6330312001')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(13 AS Numeric(18, 0)), N'Dharvi Shah', N'789652314', N'dharvi@yahoo.com', CAST(2 AS Numeric(18, 0)), N'Proffesor', N'6330312002')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(14 AS Numeric(18, 0)), N'Dhanraj Gir', N'985614723', N'dhanraj@gmail.com', CAST(2 AS Numeric(18, 0)), N'HOD', N'6330312003')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(15 AS Numeric(18, 0)), N'Falguni Pathak', N'754123682', N'falguni@gmail.com', CAST(2 AS Numeric(18, 0)), N'Proffesor', N'6330312004')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(17 AS Numeric(18, 0)), N' Neha Patel', N'9632584712', N'n@gmail.com', CAST(2 AS Numeric(18, 0)), N'Admin', N'6330312993')
INSERT [dbo].[Faculty_Master] ([Id], [Name], [Contact_No], [EMail], [Branch_ID], [Designation], [Enrolment]) VALUES (CAST(18 AS Numeric(18, 0)), N'Tiger Rajput', N'12345698972', N't@gmail.com', CAST(1 AS Numeric(18, 0)), N'Exam-Cordinator', N'6330312994')
SET IDENTITY_INSERT [dbo].[Faculty_Master] OFF
SET IDENTITY_INSERT [dbo].[Function_Master] ON 

INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(1 AS Numeric(18, 0)), N'StudentEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(2 AS Numeric(18, 0)), N'StudentView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(3 AS Numeric(18, 0)), N'StudentEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(4 AS Numeric(18, 0)), N'StudentDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(5 AS Numeric(18, 0)), N'FacultyEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(6 AS Numeric(18, 0)), N'FacultyView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(7 AS Numeric(18, 0)), N'FacultyEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(8 AS Numeric(18, 0)), N'FacultyDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(9 AS Numeric(18, 0)), N'BranchEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(10 AS Numeric(18, 0)), N'BranchView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(11 AS Numeric(18, 0)), N'BranchEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(12 AS Numeric(18, 0)), N'BranchDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(13 AS Numeric(18, 0)), N'CourseEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(14 AS Numeric(18, 0)), N'CourseView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(15 AS Numeric(18, 0)), N'CourseEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(16 AS Numeric(18, 0)), N'CourseDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(17 AS Numeric(18, 0)), N'FormatEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(18 AS Numeric(18, 0)), N'FormatView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(19 AS Numeric(18, 0)), N'FormatEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(20 AS Numeric(18, 0)), N'FormatDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(21 AS Numeric(18, 0)), N'SubjectEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(22 AS Numeric(18, 0)), N'SubjectView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(23 AS Numeric(18, 0)), N'SubjectEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(24 AS Numeric(18, 0)), N'SubjectDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(25 AS Numeric(18, 0)), N'ChapterEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(26 AS Numeric(18, 0)), N'ChapterView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(27 AS Numeric(18, 0)), N'ChapterEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(28 AS Numeric(18, 0)), N'ChapterDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(29 AS Numeric(18, 0)), N'ExamEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(30 AS Numeric(18, 0)), N'ExamView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(31 AS Numeric(18, 0)), N'ExamEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(32 AS Numeric(18, 0)), N'ExamDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(33 AS Numeric(18, 0)), N'TimetableEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(34 AS Numeric(18, 0)), N'TimetableView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(35 AS Numeric(18, 0)), N'TimetableEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(36 AS Numeric(18, 0)), N'TimetableDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(37 AS Numeric(18, 0)), N'ClassEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(38 AS Numeric(18, 0)), N'ClassView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(39 AS Numeric(18, 0)), N'ClassEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(40 AS Numeric(18, 0)), N'ClassDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(41 AS Numeric(18, 0)), N'ClassAllocationEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(42 AS Numeric(18, 0)), N'ClassAllocationView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(43 AS Numeric(18, 0)), N'ClassAllocationEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(44 AS Numeric(18, 0)), N'ClassAllocationDelete')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(45 AS Numeric(18, 0)), N'SectionEntry')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(46 AS Numeric(18, 0)), N'SectionView')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(47 AS Numeric(18, 0)), N'SectionEdit')
INSERT [dbo].[Function_Master] ([Id], [Name]) VALUES (CAST(48 AS Numeric(18, 0)), N'SectionDelete')
SET IDENTITY_INSERT [dbo].[Function_Master] OFF
SET IDENTITY_INSERT [dbo].[Intermediate] ON 

INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(9 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(10 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(11 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(14 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(14 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(15 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(16 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(16 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(17 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(18 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(18 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(19 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(19 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(20 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(20 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(21 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(21 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(22 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(23 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(24 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(24 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(25 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(25 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(26 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(26 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(27 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(27 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(28 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(28 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(29 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(29 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(30 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(30 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(31 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(31 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(32 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(33 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(33 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(34 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(34 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(35 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(35 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(36 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(36 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(37 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(37 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(38 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(38 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(39 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(39 AS Numeric(18, 0)))
INSERT [dbo].[Intermediate] ([Id], [Branch_ID], [Exam_ID], [Student_ID]) VALUES (CAST(40 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Intermediate] OFF
SET IDENTITY_INSERT [dbo].[Login_Master] ON 

INSERT [dbo].[Login_Master] ([Id], [User_Name], [Password], [Faculty_ID], [Student_ID], [Designation], [Role_ID]) VALUES (CAST(1 AS Numeric(18, 0)), N'adhir@gmail.com', N'7539514628', CAST(1 AS Numeric(18, 0)), NULL, N'Visiting Faculty', CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Login_Master] ([Id], [User_Name], [Password], [Faculty_ID], [Student_ID], [Designation], [Role_ID]) VALUES (CAST(2 AS Numeric(18, 0)), N'JeshaSh@yahoo.com', N'9517536248', CAST(3 AS Numeric(18, 0)), NULL, N'Profesor', CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Login_Master] ([Id], [User_Name], [Password], [Faculty_ID], [Student_ID], [Designation], [Role_ID]) VALUES (CAST(3 AS Numeric(18, 0)), N'n@gmail.com', N'123', CAST(17 AS Numeric(18, 0)), NULL, N'Administrator', CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Login_Master] ([Id], [User_Name], [Password], [Faculty_ID], [Student_ID], [Designation], [Role_ID]) VALUES (CAST(4 AS Numeric(18, 0)), N't@gmail.com', N'321', CAST(18 AS Numeric(18, 0)), NULL, N'Exam-cordinator', CAST(2 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Login_Master] OFF
SET IDENTITY_INSERT [dbo].[Question_Master] ON 

INSERT [dbo].[Question_Master] ([Id], [Branch_ID], [Sem_ID], [Subject_ID], [Chapter_ID], [Marks], [Format_ID], [Question]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'factorial')
INSERT [dbo].[Question_Master] ([Id], [Branch_ID], [Sem_ID], [Subject_ID], [Chapter_ID], [Marks], [Format_ID], [Question]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), N'hello world')
INSERT [dbo].[Question_Master] ([Id], [Branch_ID], [Sem_ID], [Subject_ID], [Chapter_ID], [Marks], [Format_ID], [Question]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'febonaci')
INSERT [dbo].[Question_Master] ([Id], [Branch_ID], [Sem_ID], [Subject_ID], [Chapter_ID], [Marks], [Format_ID], [Question]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(13 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'* patern for dimand')
SET IDENTITY_INSERT [dbo].[Question_Master] OFF
SET IDENTITY_INSERT [dbo].[Role_Alloction] ON 

INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(1 AS Numeric(18, 0)), N'1', CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(2 AS Numeric(18, 0)), N'1', CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(3 AS Numeric(18, 0)), N'1', CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(4 AS Numeric(18, 0)), N'1', CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(5 AS Numeric(18, 0)), N'1', CAST(5 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(6 AS Numeric(18, 0)), N'1', CAST(6 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(7 AS Numeric(18, 0)), N'1', CAST(7 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(8 AS Numeric(18, 0)), N'1', CAST(8 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(9 AS Numeric(18, 0)), N'1', CAST(9 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(10 AS Numeric(18, 0)), N'1', CAST(10 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(11 AS Numeric(18, 0)), N'1', CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(12 AS Numeric(18, 0)), N'1', CAST(12 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(13 AS Numeric(18, 0)), N'1', CAST(13 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(14 AS Numeric(18, 0)), N'1', CAST(14 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(15 AS Numeric(18, 0)), N'1', CAST(15 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(16 AS Numeric(18, 0)), N'1', CAST(16 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(17 AS Numeric(18, 0)), N'1', CAST(17 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(18 AS Numeric(18, 0)), N'1', CAST(18 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(19 AS Numeric(18, 0)), N'1', CAST(19 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(20 AS Numeric(18, 0)), N'1', CAST(20 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(21 AS Numeric(18, 0)), N'1', CAST(21 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(22 AS Numeric(18, 0)), N'1', CAST(22 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(23 AS Numeric(18, 0)), N'1', CAST(23 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(24 AS Numeric(18, 0)), N'1', CAST(24 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(25 AS Numeric(18, 0)), N'1', CAST(25 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(26 AS Numeric(18, 0)), N'1', CAST(26 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(27 AS Numeric(18, 0)), N'1', CAST(27 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(28 AS Numeric(18, 0)), N'1', CAST(28 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(29 AS Numeric(18, 0)), N'1', CAST(29 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(30 AS Numeric(18, 0)), N'1', CAST(30 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(31 AS Numeric(18, 0)), N'1', CAST(31 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(32 AS Numeric(18, 0)), N'1', CAST(32 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(33 AS Numeric(18, 0)), N'1', CAST(33 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(34 AS Numeric(18, 0)), N'1', CAST(34 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(35 AS Numeric(18, 0)), N'1', CAST(35 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(36 AS Numeric(18, 0)), N'1', CAST(36 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(37 AS Numeric(18, 0)), N'1', CAST(41 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(38 AS Numeric(18, 0)), N'1', CAST(42 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(39 AS Numeric(18, 0)), N'1', CAST(43 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(40 AS Numeric(18, 0)), N'1', CAST(44 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(41 AS Numeric(18, 0)), N'0', CAST(41 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(42 AS Numeric(18, 0)), N'1', CAST(42 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(43 AS Numeric(18, 0)), N'0', CAST(43 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(44 AS Numeric(18, 0)), N'0', CAST(44 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(45 AS Numeric(18, 0)), N'1', CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(46 AS Numeric(18, 0)), N'1', CAST(10 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(47 AS Numeric(18, 0)), N'1', CAST(14 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(48 AS Numeric(18, 0)), N'1', CAST(18 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(49 AS Numeric(18, 0)), N'1', CAST(22 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(50 AS Numeric(18, 0)), N'1', CAST(26 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(51 AS Numeric(18, 0)), N'1', CAST(30 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(52 AS Numeric(18, 0)), N'1', CAST(34 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(53 AS Numeric(18, 0)), N'1', CAST(42 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(54 AS Numeric(18, 0)), N'1', CAST(34 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(55 AS Numeric(18, 0)), N'1', CAST(42 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(56 AS Numeric(18, 0)), N'0', CAST(27 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Role_Alloction] ([Id], [Is_Allow], [Function_ID], [Role_ID]) VALUES (CAST(57 AS Numeric(18, 0)), N'0', CAST(28 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Role_Alloction] OFF
SET IDENTITY_INSERT [dbo].[Role_Master] ON 

INSERT [dbo].[Role_Master] ([Id], [Name]) VALUES (CAST(1 AS Numeric(18, 0)), N'HOD')
INSERT [dbo].[Role_Master] ([Id], [Name]) VALUES (CAST(2 AS Numeric(18, 0)), N'Exam Co-Ordinator')
INSERT [dbo].[Role_Master] ([Id], [Name]) VALUES (CAST(3 AS Numeric(18, 0)), N'Administrator')
INSERT [dbo].[Role_Master] ([Id], [Name]) VALUES (CAST(4 AS Numeric(18, 0)), N'Faculty')
INSERT [dbo].[Role_Master] ([Id], [Name]) VALUES (CAST(5 AS Numeric(18, 0)), N'Student')
SET IDENTITY_INSERT [dbo].[Role_Master] OFF
SET IDENTITY_INSERT [dbo].[Section_Master] ON 

INSERT [dbo].[Section_Master] ([ID], [Branch_ID], [Section], [No_Of_Student], [Academic_Year], [Sem_Id]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'A', CAST(50 AS Numeric(18, 0)), N'2017-2018', CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Section_Master] ([ID], [Branch_ID], [Section], [No_Of_Student], [Academic_Year], [Sem_Id]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), N'A', CAST(90 AS Numeric(18, 0)), N'2017-2018', CAST(1 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Section_Master] OFF
SET IDENTITY_INSERT [dbo].[Semester_Master] ON 

INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Semester_Master] ([Id], [Sem], [Branch_ID]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Semester_Master] OFF
SET IDENTITY_INSERT [dbo].[Student_Master] ON 

INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(1 AS Numeric(18, 0)), N'176330316001', N'Abhimanyu  Jadav', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9998877456', N'abhij@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(2 AS Numeric(18, 0)), N'176330316002', N'Aahan Shah', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9876541235', N'ahansh@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(3 AS Numeric(18, 0)), N'176330316003', N'Akansha Patel', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'6541239877', N'akansh@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(4 AS Numeric(18, 0)), N'176330316004', N'Aahana Kanugo', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'456321799', N'ahanak@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(5 AS Numeric(18, 0)), N'176330316005', N'Avinash Shah', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9632587411', N'avinashS@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(6 AS Numeric(18, 0)), N'176330316006', N'Bijoy Patel', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9727200233', N'bijoypatel@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(7 AS Numeric(18, 0)), N'176330316007', N'Brijesh Shah', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9876523141', N'brajeshs@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(8 AS Numeric(18, 0)), N'176330316008', N'Brijraj Mori', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'6523149877', N'brijMori@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(9 AS Numeric(18, 0)), N'176330316009', N'Charvi Shah', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'321456988', N'charviS@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(10 AS Numeric(18, 0)), N'176330316010', N'Dhruv Parekh', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'3625149877', N'dhruvp@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(11 AS Numeric(18, 0)), N'176330316011', N'Kahaan Patel', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'6325149877', N'kahaanP@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(12 AS Numeric(18, 0)), N'176330316012', N'Seya Jadav', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'7563214899', N'seya12@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(13 AS Numeric(18, 0)), N'176330316013', N'Vahin Joishi', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'6987412332', N'VahinJoishi@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(14 AS Numeric(18, 0)), N'176330316014', N'Riya Patel', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9874563211', N'RiyaP@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(15 AS Numeric(18, 0)), N'176330316015', N'Mahendra Jadav', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9873216544', N'mahendraJ@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(16 AS Numeric(18, 0)), N'176330316016', N'pankti shrma', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'3214569870', N'pan@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(17 AS Numeric(18, 0)), N'176330316017', N'pankti shrma', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'3214569870', N'pan@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(18 AS Numeric(18, 0)), N'176330316018', N'Abhinav Dave', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'7896541230', N'abhi@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(19 AS Numeric(18, 0)), N'176330316019', N'sia', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'7895241630', N'cxf@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(20 AS Numeric(18, 0)), N'176330316020', N'Santanu', CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8632597412', N'San@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(21 AS Numeric(18, 0)), N'176330316021', N'Riya Shah', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9654783215', N'Ria@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(22 AS Numeric(18, 0)), N'176330316022', N'Raghav Darbar', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9756841235', N'Raghav@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(23 AS Numeric(18, 0)), N'176330316023', N'Niara Patel', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8745963215', N'Niara@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(24 AS Numeric(18, 0)), N'176330316024', N'Maria Jadav', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'7895641235', N'Maria@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(25 AS Numeric(18, 0)), N'176330316025', N'Meet Shah', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8965471236', N'Meet@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(26 AS Numeric(18, 0)), N'176330316026', N'Mahira Shah', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8745693126', N'Mahira@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(27 AS Numeric(18, 0)), N'176330316027', N'Mouni Vohra', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8745963512', N'Mouni@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(28 AS Numeric(18, 0)), N'176330316028', N'Kirti Chouhan', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9873216542', N'Kirti@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(29 AS Numeric(18, 0)), N'176330316029', N'Kiran Chouhan', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8621459726', N'Kiran@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(30 AS Numeric(18, 0)), N'176330316030', N'Kamini Kathwadia', CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'7539614826', N'Kamini@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(31 AS Numeric(18, 0)), N'176330316031', N'Priyanka Jadav', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9785236412', N'Priyanka@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(32 AS Numeric(18, 0)), N'176330316032', N'Priti Patel', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'7538961422', N'Priti@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(33 AS Numeric(18, 0)), N'176330316033', N'Param Borana', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8974123654', N'Param@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(34 AS Numeric(18, 0)), N'176330316034', N'Pakhi Shah', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8974326515', N'pakhi@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(35 AS Numeric(18, 0)), N'176330316035', N'Parag Shah', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9873216588', N'parag@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(36 AS Numeric(18, 0)), N'176330316036', N'Piyu Patel', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9745632814', N'piyu@yahoo.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(37 AS Numeric(18, 0)), N'176330316037', N'Ruhi Patel', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'7465231899', N'ruhi@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(38 AS Numeric(18, 0)), N'176330316038', N'Raveti Kanuga', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'7845963256', N'raveti@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(39 AS Numeric(18, 0)), N'176330316039', N'Riyansh Shah', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'8512369477', N'riyansh@gmail.com', 1)
INSERT [dbo].[Student_Master] ([Id], [Enrolment], [Name], [Branch_ID], [Sem_ID], [Contact_No], [EMail], [isActive]) VALUES (CAST(40 AS Numeric(18, 0)), N'176330316040', N'Zeel Patel', CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'9785123648', N'zeel@yahoo.com', 1)
SET IDENTITY_INSERT [dbo].[Student_Master] OFF
SET IDENTITY_INSERT [dbo].[Subject_Master] ON 

INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Basic Mathematics', N'3300001')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'English', N'3300002')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Environment Conservation and Hazard Management', N'3300003')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Engineering Physics', N'3300004')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Basic Engineering Drawing ', N'3300007')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Engineering Workshop Practice', N'3301901')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Engineering Workshop Practice', N'3301901')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Basic Mathematics', N'3300001')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'English', N'3300002')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'English', N'3300002')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Environment Conservation and Hazard Management', N'3300003')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Computer Programming', N'3310701')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Fundamental of Digital Electronics', N'3310702')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(14 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Fundamental of Computer Application', N'3310703')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(15 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'Contributor Personality Development ', N'1990001')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(16 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'Advanced Mathematics (Group-1)', N'3320002')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(17 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'Basic Physics (Group-1)', N'3300005')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(18 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'Basic Electronics', N'3320701')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(19 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'Advanced Computer Programming', N'3320702')
INSERT [dbo].[Subject_Master] ([Id], [Branch_ID], [Sem_ID], [Name], [Code]) VALUES (CAST(20 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), N'Fundamental of Information Technology', N'3321601')
SET IDENTITY_INSERT [dbo].[Subject_Master] OFF
SET IDENTITY_INSERT [dbo].[Timetable_Master] ON 

INSERT [dbo].[Timetable_Master] ([Id], [tt_date], [Fromtime], [Totime], [Format_ID], [Branch_ID], [Sem_ID], [Subject_ID], [Exam_ID]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(0xA13D0B00 AS Date), CAST(0x07001417C6680000 AS Time), CAST(0x0700448E02580000 AS Time), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Timetable_Master] ([Id], [tt_date], [Fromtime], [Totime], [Format_ID], [Branch_ID], [Sem_ID], [Subject_ID], [Exam_ID]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(0xA23D0B00 AS Date), CAST(0x07001417C6680000 AS Time), CAST(0x0700448E02580000 AS Time), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Timetable_Master] ([Id], [tt_date], [Fromtime], [Totime], [Format_ID], [Branch_ID], [Sem_ID], [Subject_ID], [Exam_ID]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(0xA33D0B00 AS Date), CAST(0x07001417C6680000 AS Time), CAST(0x0700448E02580000 AS Time), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[Timetable_Master] ([Id], [tt_date], [Fromtime], [Totime], [Format_ID], [Branch_ID], [Sem_ID], [Subject_ID], [Exam_ID]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(0xA13D0B00 AS Date), CAST(0x07001417C6680000 AS Time), CAST(0x0700448E02580000 AS Time), CAST(1 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[Timetable_Master] ([Id], [tt_date], [Fromtime], [Totime], [Format_ID], [Branch_ID], [Sem_ID], [Subject_ID], [Exam_ID]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(0x9A3D0B00 AS Date), CAST(0x070048F9F66C0000 AS Time), CAST(0x0700E03495640000 AS Time), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Timetable_Master] OFF
USE [master]
GO
ALTER DATABASE [ExamManager] SET  READ_WRITE 
GO
