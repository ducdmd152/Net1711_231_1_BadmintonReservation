USE [master]
GO
/****** Object:  Database [Net1711_231_1_BadmintonReservation]    Script Date: 8/4/2024 9:28:57 PM ******/
CREATE DATABASE [Net1711_231_1_BadmintonReservation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Net1711_231_1_BadmintonReservation', FILENAME = N'D:\NET1711_231_1_BadmintonReservation\project\DB\Net1711_231_1_BadmintonReservation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Net1711_231_1_BadmintonReservation_log', FILENAME = N'D:\NET1711_231_1_BadmintonReservation\project\DB\Net1711_231_1_BadmintonReservation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Net1711_231_1_BadmintonReservation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET ARITHABORT OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET  MULTI_USER 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET QUERY_STORE = OFF
GO
USE [Net1711_231_1_BadmintonReservation]
GO
/****** Object:  Table [dbo].[booking]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[booking_type_id] [int] NOT NULL,
	[booking_date_from] [datetime] NULL,
	[booking_date_to] [datetime] NULL,
	[status] [int] NOT NULL,
	[payment_status] [int] NOT NULL,
	[promotion_amount] [float] NOT NULL,
	[payment_type] [int] NOT NULL,
	[payment_id] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [booking_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking_detail]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[booking_id] [int] NOT NULL,
	[book_date] [datetime] NOT NULL,
	[frame_id] [int] NOT NULL,
	[time_from] [int] NOT NULL,
	[time_to] [int] NOT NULL,
	[price] [float] NOT NULL,
	[status] [int] NOT NULL,
	[payment_status] [int] NOT NULL,
	[checkin_time] [date] NULL,
	[checkout_time] [date] NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [booking_detail_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking_type]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [nvarchar](200) NULL,
	[promotion_amount] [float] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [booking_type_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[name] [nvarchar](200) NOT NULL,
	[slogan] [nvarchar](300) NOT NULL,
	[description] [nvarchar](400) NOT NULL,
	[location] [nvarchar](400) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[court]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[court](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](512) NOT NULL,
	[surface_type] [int] NOT NULL,
	[status] [int] NOT NULL,
	[total_booking] [nvarchar](512) NOT NULL,
	[opening_hours] [int] NOT NULL,
	[close_hours] [int] NOT NULL,
	[amentities] [nvarchar](512) NULL,
	[capacity] [int] NOT NULL,
	[court_type] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [court_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[custom_frame]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[custom_frame](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[price] [float] NOT NULL,
	[specific_date] [datetime] NOT NULL,
	[status] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[frame_id] [int] NOT NULL,
	[fixed_date_type_id] [int] NOT NULL,
 CONSTRAINT [custom_frame_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phone_number] [varchar](50) NOT NULL,
	[password] [nvarchar](512) NOT NULL,
	[full_name] [nvarchar](200) NOT NULL,
	[total_hours_monthly] [float] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[account_id] [int] NULL,
 CONSTRAINT [customer_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[date_type]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[date_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [date_type_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[frame]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[frame](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time_from] [int] NOT NULL,
	[time_to] [int] NOT NULL,
	[status] [int] NOT NULL,
	[price] [float] NOT NULL,
	[label] [nvarchar](512) NOT NULL,
	[note] [nvarchar](512) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[court_id] [int] NOT NULL,
 CONSTRAINT [frame_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[holiday]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[holiday](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [holiday_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[operation]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[operation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[open_time_from] [datetime] NOT NULL,
	[open_time_to] [datetime] NOT NULL,
	[status] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [operation_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[amount] [float] NOT NULL,
	[status] [int] NOT NULL,
	[third_party_payment_id] [int] NULL,
	[third_party_response] [int] NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [payment_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchased_hours_monthly]    Script Date: 8/4/2024 9:28:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchased_hours_monthly](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[amount_hour] [float] NOT NULL,
	[status] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[customer_id] [int] NOT NULL,
	[payment_id] [int] NOT NULL,
 CONSTRAINT [purchased_hours_monthly_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[booking] ON 
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (1, 1, 1, CAST(N'2024-06-01T08:00:00.000' AS DateTime), CAST(N'2024-06-01T10:00:00.000' AS DateTime), 2, 4, 0, 1, 1, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-06-10T07:49:12.663' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (9, 1, 5, CAST(N'2024-06-02T15:18:17.000' AS DateTime), CAST(N'2024-06-02T15:18:17.000' AS DateTime), 1, 1, 0, 1, 9, CAST(N'2024-06-02T15:18:24.243' AS DateTime), CAST(N'2024-06-09T21:32:51.157' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (11, 1, 5, CAST(N'2024-06-02T15:34:04.000' AS DateTime), CAST(N'2024-06-02T15:34:04.000' AS DateTime), 4, 1, 0, 2, 11, CAST(N'2024-06-02T15:34:06.510' AS DateTime), CAST(N'2024-06-09T21:32:59.947' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (12, 1, 2, CAST(N'2024-06-03T08:21:45.000' AS DateTime), CAST(N'2024-06-03T08:21:45.000' AS DateTime), 2, 1, 0, 2, 12, CAST(N'2024-06-03T08:22:00.540' AS DateTime), CAST(N'2024-06-09T21:33:07.590' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (13, 1, 1, NULL, NULL, 1, 2, 0, 1, 15, CAST(N'2024-06-08T14:20:03.757' AS DateTime), CAST(N'2024-06-08T16:55:29.123' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (14, 1, 1, NULL, NULL, 1, 2, 15000, 1, 16, CAST(N'2024-06-08T15:57:27.907' AS DateTime), CAST(N'2024-06-09T20:31:14.880' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (15, 1, 1, NULL, NULL, 2, 2, 20000, 2, 17, CAST(N'2024-06-08T16:44:50.673' AS DateTime), CAST(N'2024-06-08T16:44:50.673' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (16, 2, 1, NULL, NULL, 4, 1, 0, 1, 18, CAST(N'2024-06-08T16:45:47.550' AS DateTime), CAST(N'2024-06-08T16:45:47.550' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (17, 1, 1, NULL, NULL, 2, 2, 20000, 2, 19, CAST(N'2024-06-22T14:55:25.903' AS DateTime), CAST(N'2024-06-23T06:19:27.057' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (18, 2, 2, NULL, NULL, 2, 1, 0, 2, 20, CAST(N'2024-06-23T05:56:23.863' AS DateTime), CAST(N'2024-06-23T05:56:23.863' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (19, 2, 1, NULL, NULL, 2, 2, 15000, 2, 21, CAST(N'2024-06-23T05:57:01.833' AS DateTime), CAST(N'2024-06-23T06:19:19.733' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (20, 1, 1, NULL, NULL, 2, 2, 0, 2, 22, CAST(N'2024-06-23T05:57:31.127' AS DateTime), CAST(N'2024-06-23T05:57:31.127' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (29, 1, 1, NULL, NULL, 1, 1, 0, 1, 31, CAST(N'2024-07-10T13:32:24.247' AS DateTime), CAST(N'2024-07-10T13:34:21.533' AS DateTime))
GO
INSERT [dbo].[booking] ([id], [customer_id], [booking_type_id], [booking_date_from], [booking_date_to], [status], [payment_status], [promotion_amount], [payment_type], [payment_id], [created_date], [updated_date]) VALUES (34, 2, 1, NULL, NULL, 2, 1, 20000, 2, 36, CAST(N'2024-07-11T10:26:46.907' AS DateTime), CAST(N'2024-07-11T10:37:02.073' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[booking] OFF
GO
SET IDENTITY_INSERT [dbo].[booking_detail] ON 
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (1, 1, CAST(N'2024-06-01T00:00:00.000' AS DateTime), 1, 700, 800, 40000, 2, 1, NULL, NULL, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-06-08T16:09:24.313' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (2, 1, CAST(N'2024-06-01T00:00:00.000' AS DateTime), 2, 800, 900, 45000, 2, 1, NULL, NULL, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-06-08T16:09:24.313' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (3, 13, CAST(N'2024-06-08T00:00:00.000' AS DateTime), 1, 700, 800, 50000, 0, 1, NULL, NULL, CAST(N'2024-06-08T14:20:03.763' AS DateTime), CAST(N'2024-06-08T14:20:03.763' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (4, 14, CAST(N'2024-06-08T00:00:00.000' AS DateTime), 2, 800, 900, 60000, 0, 1, NULL, NULL, CAST(N'2024-06-08T15:57:27.907' AS DateTime), CAST(N'2024-06-08T15:57:27.907' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (5, 14, CAST(N'2024-06-08T00:00:00.000' AS DateTime), 6, 800, 900, 65000, 0, 1, NULL, NULL, CAST(N'2024-06-08T15:57:27.907' AS DateTime), CAST(N'2024-06-08T15:57:27.907' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (6, 15, CAST(N'2024-06-29T00:00:00.000' AS DateTime), 2, 800, 900, 60000, 0, 1, NULL, NULL, CAST(N'2024-06-08T16:44:50.677' AS DateTime), CAST(N'2024-06-08T16:44:50.677' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (7, 16, CAST(N'2024-07-05T00:00:00.000' AS DateTime), 1, 700, 800, 50000, 0, 1, NULL, NULL, CAST(N'2024-06-08T16:45:47.550' AS DateTime), CAST(N'2024-06-08T16:45:47.550' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (8, 17, CAST(N'2024-06-22T00:00:00.000' AS DateTime), 1, 700, 800, 50000, 0, 1, NULL, NULL, CAST(N'2024-06-22T14:55:25.907' AS DateTime), CAST(N'2024-06-22T14:55:25.907' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (9, 17, CAST(N'2024-06-22T00:00:00.000' AS DateTime), 2, 800, 900, 60000, 0, 1, NULL, NULL, CAST(N'2024-06-22T14:55:25.907' AS DateTime), CAST(N'2024-06-22T14:55:25.907' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (10, 18, CAST(N'2024-06-22T00:00:00.000' AS DateTime), 4, 700, 800, 55000, 0, 1, NULL, NULL, CAST(N'2024-06-23T05:56:23.867' AS DateTime), CAST(N'2024-06-23T05:56:23.867' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (11, 19, CAST(N'2024-06-23T00:00:00.000' AS DateTime), 1, 700, 800, 50000, 0, 1, NULL, NULL, CAST(N'2024-06-23T05:57:01.833' AS DateTime), CAST(N'2024-06-23T05:57:01.833' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (12, 19, CAST(N'2024-06-23T00:00:00.000' AS DateTime), 4, 700, 800, 55000, 0, 1, NULL, NULL, CAST(N'2024-06-23T05:57:01.833' AS DateTime), CAST(N'2024-06-23T05:57:01.833' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (13, 20, CAST(N'2024-06-23T00:00:00.000' AS DateTime), 2, 800, 900, 60000, 0, 1, NULL, NULL, CAST(N'2024-06-23T05:57:31.127' AS DateTime), CAST(N'2024-06-23T05:57:31.127' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (14, 20, CAST(N'2024-06-23T00:00:00.000' AS DateTime), 6, 800, 900, 65000, 0, 1, NULL, NULL, CAST(N'2024-06-23T05:57:31.127' AS DateTime), CAST(N'2024-06-23T05:57:31.127' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (23, 29, CAST(N'2024-08-01T00:00:00.000' AS DateTime), 1, 700, 800, 40000, 0, 1, NULL, NULL, CAST(N'2024-07-10T13:32:24.247' AS DateTime), CAST(N'2024-07-10T13:32:24.247' AS DateTime))
GO
INSERT [dbo].[booking_detail] ([id], [booking_id], [book_date], [frame_id], [time_from], [time_to], [price], [status], [payment_status], [checkin_time], [checkout_time], [created_date], [updated_date]) VALUES (28, 34, CAST(N'2024-09-28T00:00:00.000' AS DateTime), 1, 700, 800, 54000, 0, 1, NULL, NULL, CAST(N'2024-07-11T10:26:46.910' AS DateTime), CAST(N'2024-07-11T10:26:59.523' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[booking_detail] OFF
GO
SET IDENTITY_INSERT [dbo].[booking_type] ON 
GO
INSERT [dbo].[booking_type] ([id], [name], [description], [promotion_amount], [created_date], [updated_date]) VALUES (1, N'Normaly', N'Standard booking without any discount', 0, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime))
GO
INSERT [dbo].[booking_type] ([id], [name], [description], [promotion_amount], [created_date], [updated_date]) VALUES (2, N'Monthly', N'Booking with a promotional discount', 5, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime))
GO
INSERT [dbo].[booking_type] ([id], [name], [description], [promotion_amount], [created_date], [updated_date]) VALUES (5, N'Hourly', N'By buyed hours', 2, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[booking_type] OFF
GO
INSERT [dbo].[company] ([name], [slogan], [description], [location]) VALUES (N'Smash Sports', N'Unleash Your Potential', N'The best place to play badminton', N'123 Sports Ave')
GO
INSERT [dbo].[company] ([name], [slogan], [description], [location]) VALUES (N'Birdie Bash', N'Serve, Smash, Win', N'Top-notch badminton courts and services', N'456 Fitness St')
GO
SET IDENTITY_INSERT [dbo].[court] ON 
GO
INSERT [dbo].[court] ([id], [name], [surface_type], [status], [total_booking], [opening_hours], [close_hours], [amentities], [capacity], [court_type], [created_date], [updated_date]) VALUES (1, N'Court A', 1, 1, N'114', 8, 22, N'Showers, Lockers', 50, 1, CAST(N'2024-06-23T06:13:01.337' AS DateTime), CAST(N'2024-07-11T10:26:46.910' AS DateTime))
GO
INSERT [dbo].[court] ([id], [name], [surface_type], [status], [total_booking], [opening_hours], [close_hours], [amentities], [capacity], [court_type], [created_date], [updated_date]) VALUES (2, N'Court B', 2, 1, N'75', 9, 23, N'Cafe, Parking', 100, 2, CAST(N'2024-06-23T06:13:01.337' AS DateTime), CAST(N'2024-06-23T06:13:01.337' AS DateTime))
GO
INSERT [dbo].[court] ([id], [name], [surface_type], [status], [total_booking], [opening_hours], [close_hours], [amentities], [capacity], [court_type], [created_date], [updated_date]) VALUES (3, N'Court C', 1, 2, N'50', 7, 21, N'Pro Shop', 30, 1, CAST(N'2024-06-23T06:13:01.337' AS DateTime), CAST(N'2024-06-23T06:13:01.337' AS DateTime))
GO
INSERT [dbo].[court] ([id], [name], [surface_type], [status], [total_booking], [opening_hours], [close_hours], [amentities], [capacity], [court_type], [created_date], [updated_date]) VALUES (4, N'Court D', 3, 1, N'120', 6, 20, N'Gym, Pool', 80, 3, CAST(N'2024-06-23T06:13:01.337' AS DateTime), CAST(N'2024-06-23T06:13:01.337' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[court] OFF
GO
SET IDENTITY_INSERT [dbo].[customer] ON 
GO
INSERT [dbo].[customer] ([id], [phone_number], [password], [full_name], [total_hours_monthly], [created_date], [updated_date], [account_id]) VALUES (1, N'0934968393', N'1', N'Duy Duc', 10.5, CAST(N'2024-05-22T21:13:48.530' AS DateTime), CAST(N'2024-05-22T21:13:48.530' AS DateTime), NULL)
GO
INSERT [dbo].[customer] ([id], [phone_number], [password], [full_name], [total_hours_monthly], [created_date], [updated_date], [account_id]) VALUES (2, N'0933232121', N'1', N'Smith David', 0, CAST(N'2024-05-22T21:13:48.530' AS DateTime), CAST(N'2024-05-22T21:13:48.530' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[date_type] ON 
GO
INSERT [dbo].[date_type] ([id], [name], [created_date], [updated_date]) VALUES (1, N'Holiday', CAST(N'2024-05-22T21:13:48.530' AS DateTime), CAST(N'2024-05-22T21:13:48.530' AS DateTime))
GO
INSERT [dbo].[date_type] ([id], [name], [created_date], [updated_date]) VALUES (2, N'Weekend', CAST(N'2024-05-22T21:13:48.530' AS DateTime), CAST(N'2024-05-22T21:13:48.530' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[date_type] OFF
GO
SET IDENTITY_INSERT [dbo].[frame] ON 
GO
INSERT [dbo].[frame] ([id], [time_from], [time_to], [status], [price], [label], [note], [created_date], [updated_date], [court_id]) VALUES (1, 700, 800, 1, 50000, N'Morning Slot', N'Regular booking slot in the morning', CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime), 1)
GO
INSERT [dbo].[frame] ([id], [time_from], [time_to], [status], [price], [label], [note], [created_date], [updated_date], [court_id]) VALUES (2, 800, 900, 1, 60000, N'Midday Slot', N'Regular booking slot around midday', CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime), 1)
GO
INSERT [dbo].[frame] ([id], [time_from], [time_to], [status], [price], [label], [note], [created_date], [updated_date], [court_id]) VALUES (4, 700, 800, 1, 55000, N'Morning Slot', N'Regular booking slot in the morning', CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime), 2)
GO
INSERT [dbo].[frame] ([id], [time_from], [time_to], [status], [price], [label], [note], [created_date], [updated_date], [court_id]) VALUES (6, 800, 900, 1, 65000, N'Midday Slot', N'Regular booking slot around midday', CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[frame] OFF
GO
SET IDENTITY_INSERT [dbo].[holiday] ON 
GO
INSERT [dbo].[holiday] ([id], [date], [created_date], [updated_date]) VALUES (1, CAST(N'2024-12-25T00:00:00.000' AS DateTime), CAST(N'2024-05-22T21:13:48.530' AS DateTime), CAST(N'2024-05-22T21:13:48.530' AS DateTime))
GO
INSERT [dbo].[holiday] ([id], [date], [created_date], [updated_date]) VALUES (2, CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-05-22T21:13:48.530' AS DateTime), CAST(N'2024-05-22T21:13:48.530' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[holiday] OFF
GO
SET IDENTITY_INSERT [dbo].[operation] ON 
GO
INSERT [dbo].[operation] ([id], [open_time_from], [open_time_to], [status], [created_date], [updated_date]) VALUES (1, CAST(N'2024-01-01T06:00:00.000' AS DateTime), CAST(N'2024-01-01T22:00:00.000' AS DateTime), 1, CAST(N'2024-05-22T21:13:48.527' AS DateTime), CAST(N'2024-05-22T21:13:48.527' AS DateTime))
GO
INSERT [dbo].[operation] ([id], [open_time_from], [open_time_to], [status], [created_date], [updated_date]) VALUES (2, CAST(N'2024-01-02T06:00:00.000' AS DateTime), CAST(N'2024-01-02T22:00:00.000' AS DateTime), 1, CAST(N'2024-05-22T21:13:48.527' AS DateTime), CAST(N'2024-05-22T21:13:48.527' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[operation] OFF
GO
SET IDENTITY_INSERT [dbo].[payment] ON 
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (1, 85000, 4, NULL, NULL, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-06-10T07:49:12.667' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (2, 75, 1, NULL, NULL, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (3, 0, 0, NULL, NULL, CAST(N'2024-06-01T14:34:52.893' AS DateTime), CAST(N'2024-06-01T14:34:52.893' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (7, 0, 2, NULL, NULL, CAST(N'2024-06-01T15:34:16.180' AS DateTime), CAST(N'2024-06-10T07:45:07.637' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (8, 0, 0, NULL, NULL, CAST(N'2024-06-01T15:34:58.090' AS DateTime), CAST(N'2024-06-01T15:34:58.090' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (9, 0, 0, NULL, NULL, CAST(N'2024-06-02T15:18:24.247' AS DateTime), CAST(N'2024-06-02T15:18:24.247' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (10, 0, 0, NULL, NULL, CAST(N'2024-06-02T15:19:05.780' AS DateTime), CAST(N'2024-06-02T15:19:05.780' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (11, 0, 0, NULL, NULL, CAST(N'2024-06-02T15:34:06.510' AS DateTime), CAST(N'2024-06-02T15:34:06.510' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (12, 0, 0, NULL, NULL, CAST(N'2024-06-03T08:22:00.540' AS DateTime), CAST(N'2024-06-03T08:22:00.540' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (13, 0, 0, NULL, NULL, CAST(N'2024-06-03T08:33:22.547' AS DateTime), CAST(N'2024-06-03T08:33:22.547' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (14, 0, 0, NULL, NULL, CAST(N'2024-06-03T08:53:43.303' AS DateTime), CAST(N'2024-06-03T08:53:43.303' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (15, 50000, 0, NULL, NULL, CAST(N'2024-06-08T14:20:03.767' AS DateTime), CAST(N'2024-06-08T14:20:03.767' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (16, 125000, 1, NULL, NULL, CAST(N'2024-06-08T15:57:27.907' AS DateTime), CAST(N'2024-06-08T15:57:27.907' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (17, 60000, 2, NULL, NULL, CAST(N'2024-06-08T16:44:50.680' AS DateTime), CAST(N'2024-06-08T16:44:50.680' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (18, 50000, 1, NULL, NULL, CAST(N'2024-06-08T16:45:47.550' AS DateTime), CAST(N'2024-06-08T16:45:47.550' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (19, 90000, 2, NULL, NULL, CAST(N'2024-06-22T14:55:25.907' AS DateTime), CAST(N'2024-06-23T06:19:27.057' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (20, 55000, 1, NULL, NULL, CAST(N'2024-06-23T05:56:23.867' AS DateTime), CAST(N'2024-06-23T05:56:23.867' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (21, 90000, 2, NULL, NULL, CAST(N'2024-06-23T05:57:01.833' AS DateTime), CAST(N'2024-06-23T06:19:19.737' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (22, 125000, 2, NULL, NULL, CAST(N'2024-06-23T05:57:31.127' AS DateTime), CAST(N'2024-06-23T05:57:31.127' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (23, 40000, 1, NULL, NULL, CAST(N'2024-07-10T11:54:00.160' AS DateTime), CAST(N'2024-07-10T11:54:00.160' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (24, 40000, 1, NULL, NULL, CAST(N'2024-07-10T11:57:21.320' AS DateTime), CAST(N'2024-07-10T11:57:21.320' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (25, 40000, 1, NULL, NULL, CAST(N'2024-07-10T13:06:25.213' AS DateTime), CAST(N'2024-07-10T13:06:25.213' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (26, 40000, 1, NULL, NULL, CAST(N'2024-07-10T13:09:48.083' AS DateTime), CAST(N'2024-07-10T13:09:48.083' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (27, 40000, 1, NULL, NULL, CAST(N'2024-07-10T13:13:42.800' AS DateTime), CAST(N'2024-07-10T13:13:42.800' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (28, 40000, 1, NULL, NULL, CAST(N'2024-07-10T13:14:05.910' AS DateTime), CAST(N'2024-07-10T13:14:05.910' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (29, 40000, 1, NULL, NULL, CAST(N'2024-07-10T13:27:07.157' AS DateTime), CAST(N'2024-07-10T13:27:07.157' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (30, 40000, 1, NULL, NULL, CAST(N'2024-07-10T13:31:31.450' AS DateTime), CAST(N'2024-07-10T13:31:31.450' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (31, 40000, 1, NULL, NULL, CAST(N'2024-07-10T13:32:24.247' AS DateTime), CAST(N'2024-07-10T13:32:24.247' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (32, 40000, 1, NULL, NULL, CAST(N'2024-07-11T07:57:11.313' AS DateTime), CAST(N'2024-07-11T07:57:11.313' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (33, 40000, 1, NULL, NULL, CAST(N'2024-07-11T08:01:32.280' AS DateTime), CAST(N'2024-07-11T08:01:32.280' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (34, 40000, 1, NULL, NULL, CAST(N'2024-07-11T08:02:21.370' AS DateTime), CAST(N'2024-07-11T08:02:21.370' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (35, 40000, 1, NULL, NULL, CAST(N'2024-07-11T08:05:45.733' AS DateTime), CAST(N'2024-07-11T08:05:45.733' AS DateTime))
GO
INSERT [dbo].[payment] ([id], [amount], [status], [third_party_payment_id], [third_party_response], [created_date], [updated_date]) VALUES (36, 34000, 1, NULL, NULL, CAST(N'2024-07-11T10:26:46.910' AS DateTime), CAST(N'2024-07-11T10:37:02.073' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[payment] OFF
GO
SET IDENTITY_INSERT [dbo].[purchased_hours_monthly] ON 
GO
INSERT [dbo].[purchased_hours_monthly] ([id], [amount_hour], [status], [created_date], [updated_date], [customer_id], [payment_id]) VALUES (1, 5, 1, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime), 1, 1)
GO
INSERT [dbo].[purchased_hours_monthly] ([id], [amount_hour], [status], [created_date], [updated_date], [customer_id], [payment_id]) VALUES (2, 7, 1, CAST(N'2024-05-22T21:13:48.533' AS DateTime), CAST(N'2024-05-22T21:13:48.533' AS DateTime), 2, 2)
GO
SET IDENTITY_INSERT [dbo].[purchased_hours_monthly] OFF
GO
ALTER TABLE [dbo].[booking] ADD  CONSTRAINT [DF_booking_payment_status]  DEFAULT ((1)) FOR [payment_status]
GO
ALTER TABLE [dbo].[booking_detail] ADD  CONSTRAINT [DF__booking_d__price__4222D4EF]  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[booking_detail] ADD  CONSTRAINT [DF_booking_detail_payment_status]  DEFAULT ((1)) FOR [payment_status]
GO
ALTER TABLE [dbo].[booking_type] ADD  DEFAULT ((0)) FOR [promotion_amount]
GO
ALTER TABLE [dbo].[custom_frame] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT ((0)) FOR [total_hours_monthly]
GO
ALTER TABLE [dbo].[frame] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[purchased_hours_monthly] ADD  DEFAULT ((0)) FOR [amount_hour]
GO
ALTER TABLE [dbo].[booking]  WITH CHECK ADD  CONSTRAINT [booking_booking_type_FK] FOREIGN KEY([booking_type_id])
REFERENCES [dbo].[booking_type] ([id])
GO
ALTER TABLE [dbo].[booking] CHECK CONSTRAINT [booking_booking_type_FK]
GO
ALTER TABLE [dbo].[booking]  WITH CHECK ADD  CONSTRAINT [booking_customer_FK] FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[booking] CHECK CONSTRAINT [booking_customer_FK]
GO
ALTER TABLE [dbo].[booking]  WITH CHECK ADD  CONSTRAINT [booking_payment_FK] FOREIGN KEY([payment_id])
REFERENCES [dbo].[payment] ([id])
GO
ALTER TABLE [dbo].[booking] CHECK CONSTRAINT [booking_payment_FK]
GO
ALTER TABLE [dbo].[booking_detail]  WITH CHECK ADD  CONSTRAINT [booking_detail_booking_FK] FOREIGN KEY([booking_id])
REFERENCES [dbo].[booking] ([id])
GO
ALTER TABLE [dbo].[booking_detail] CHECK CONSTRAINT [booking_detail_booking_FK]
GO
ALTER TABLE [dbo].[booking_detail]  WITH CHECK ADD  CONSTRAINT [booking_detail_frame_FK] FOREIGN KEY([frame_id])
REFERENCES [dbo].[frame] ([id])
GO
ALTER TABLE [dbo].[booking_detail] CHECK CONSTRAINT [booking_detail_frame_FK]
GO
ALTER TABLE [dbo].[custom_frame]  WITH CHECK ADD  CONSTRAINT [custom_frame_date_type_FK] FOREIGN KEY([fixed_date_type_id])
REFERENCES [dbo].[date_type] ([id])
GO
ALTER TABLE [dbo].[custom_frame] CHECK CONSTRAINT [custom_frame_date_type_FK]
GO
ALTER TABLE [dbo].[custom_frame]  WITH CHECK ADD  CONSTRAINT [custom_frame_frame_FK] FOREIGN KEY([frame_id])
REFERENCES [dbo].[frame] ([id])
GO
ALTER TABLE [dbo].[custom_frame] CHECK CONSTRAINT [custom_frame_frame_FK]
GO
ALTER TABLE [dbo].[frame]  WITH CHECK ADD  CONSTRAINT [frame_court_FK] FOREIGN KEY([court_id])
REFERENCES [dbo].[court] ([id])
GO
ALTER TABLE [dbo].[frame] CHECK CONSTRAINT [frame_court_FK]
GO
ALTER TABLE [dbo].[purchased_hours_monthly]  WITH CHECK ADD  CONSTRAINT [purchased_hours_monthly_customer_FK] FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[purchased_hours_monthly] CHECK CONSTRAINT [purchased_hours_monthly_customer_FK]
GO
ALTER TABLE [dbo].[purchased_hours_monthly]  WITH CHECK ADD  CONSTRAINT [purchased_hours_monthly_payment_FK] FOREIGN KEY([payment_id])
REFERENCES [dbo].[payment] ([id])
GO
ALTER TABLE [dbo].[purchased_hours_monthly] CHECK CONSTRAINT [purchased_hours_monthly_payment_FK]
GO
USE [master]
GO
ALTER DATABASE [Net1711_231_1_BadmintonReservation] SET  READ_WRITE 
GO
