CREATE DATABASE HospitalDB
GO
USE HospitalDB
GO
/****** Object:  Table [dbo].[Diagnoses]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diagnoses](
	[IdDiagnosis] [int] IDENTITY(1,1) NOT NULL,
	[NameDiagnosis] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Diagnoses] PRIMARY KEY CLUSTERED 
(
	[IdDiagnosis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor's Appointment]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor's Appointment](
	[IdAppointment] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[PatientId] [int] NOT NULL,
 CONSTRAINT [PK_Doctor's Appointment] PRIMARY KEY CLUSTERED 
(
	[IdAppointment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HospitalDepartments]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalDepartments](
	[IdDepartment] [int] IDENTITY(1,1) NOT NULL,
	[NameDepartment] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HospitalDepartments] PRIMARY KEY CLUSTERED 
(
	[IdDepartment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HospitalPatients]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalPatients](
	[IdPatient] [int] IDENTITY(1,1) NOT NULL,
	[NamePatient] [nvarchar](50) NOT NULL,
	[SurnamePatient] [nvarchar](50) NOT NULL,
	[PatronymicPatient] [nvarchar](50) NOT NULL,
	[WardId] [int] NULL,
	[RegistrationNumber] [varchar](50) NOT NULL,
	[IdDiagnosis] [int] NOT NULL,
	[BirthdayPatient] [date] NOT NULL,
	[ArrivalDate] [date] NOT NULL,
 CONSTRAINT [PK_HospitalPatients] PRIMARY KEY CLUSTERED 
(
	[IdPatient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HospitalPosts]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalPosts](
	[IdPost] [int] IDENTITY(1,1) NOT NULL,
	[NamePost] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HospitalPosts] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HospitalWards]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalWards](
	[IdWard] [int] IDENTITY(1,1) NOT NULL,
	[NameWard] [nvarchar](10) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_HospitalWards] PRIMARY KEY CLUSTERED 
(
	[IdWard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HospitalWorkers]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalWorkers](
	[IdWorker] [int] IDENTITY(1,1) NOT NULL,
	[NameWorker] [nvarchar](50) NOT NULL,
	[SurnameWorker] [nvarchar](50) NOT NULL,
	[PatronymicWorker] [nvarchar](50) NOT NULL,
	[PostId] [int] NOT NULL,
	[BirthdayWorker] [date] NOT NULL,
 CONSTRAINT [PK_HospitalWorkers] PRIMARY KEY CLUSTERED 
(
	[IdWorker] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parameters]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parameters](
	[IdParameter] [int] IDENTITY(1,1) NOT NULL,
	[NameParameter] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Parameters] PRIMARY KEY CLUSTERED 
(
	[IdParameter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientInfo]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientInfo](
	[IdInfo] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[BloodGroup] [nvarchar](50) NULL,
	[RhesusType] [nvarchar](50) NULL,
	[SideEffect] [nvarchar](50) NULL,
	[DrugNameOfSideEffect] [nvarchar](50) NULL,
	[Adress] [nvarchar](50) NULL,
	[PlaceOfWork_Study] [nvarchar](50) NULL,
 CONSTRAINT [PK_PatientInfo] PRIMARY KEY CLUSTERED 
(
	[IdInfo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TemperatureSheet]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemperatureSheet](
	[IdRecord] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DateStaying] [date] NOT NULL,
	[TimeId] [int] NOT NULL,
	[ParameterId] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TemperatureSheet] PRIMARY KEY CLUSTERED 
(
	[IdRecord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeOfDay]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeOfDay](
	[IdTime] [int] IDENTITY(1,1) NOT NULL,
	[NameTime] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_TimeOfDay] PRIMARY KEY CLUSTERED 
(
	[IdTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[RoleId] [int] NOT NULL,
	[WorkerId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkerInWards]    Script Date: 09.06.2024 20:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerInWards](
	[IdWorkerInWards] [int] IDENTITY(1,1) NOT NULL,
	[WardId] [int] NOT NULL,
	[WorkerId] [int] NOT NULL,
 CONSTRAINT [PK_WorkerInWards] PRIMARY KEY CLUSTERED 
(
	[IdWorkerInWards] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Diagnoses] ON 

INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (1, N'Гастрит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (2, N'Остеохондроз')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (3, N'Грипп')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (4, N'Пневмония')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (5, N'Диабет')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (6, N'Ишемическая болезнь сердца')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (7, N'Артрит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (8, N'Гипертония')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (9, N'Геморрой')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (10, N'Варикозное расширение вен')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (11, N'Остеопороз')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (12, N'Аппендицит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (13, N'Коронавирусная инфекция')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (14, N'Астма')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (15, N'Ожирение')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (16, N'Аллергический ринит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (17, N'Гепатит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (18, N'Гастроэнтерит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (19, N'Язва желудка')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (20, N'Шизофрения')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (21, N'Биполярное расстройство')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (22, N'Лейкемия')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (23, N'Катаракта')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (24, N'Артроз')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (25, N'Эпилепсия')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (26, N'Туберкулез')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (27, N'Сахарный диабет 2 типа')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (28, N'Алкоголизм')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (29, N'Стресс')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (30, N'Головная боль')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (31, N'Стенокардия')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (32, N'Депрессия')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (33, N'Бронхит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (34, N'Отит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (35, N'Ревматоидный артрит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (36, N'Мигрень')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (37, N'ДВС-синдром')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (38, N'Онкология')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (39, N'Глаукома')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (40, N'Цистит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (41, N'Сахарный диабет 1 типа')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (42, N'Простуда')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (43, N'Ангина')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (44, N'Дислексия')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (45, N'Панкреатит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (46, N'Аллергия')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (47, N'Инсульт')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (48, N'Гастродуоденит')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (49, N'Печеночная недостаточность')
INSERT [dbo].[Diagnoses] ([IdDiagnosis], [NameDiagnosis]) VALUES (50, N'Психосоматика')
SET IDENTITY_INSERT [dbo].[Diagnoses] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctor's Appointment] ON 

INSERT [dbo].[Doctor's Appointment] ([IdAppointment], [Description], [PatientId]) VALUES (4, N'отказ от еды', 58)
INSERT [dbo].[Doctor's Appointment] ([IdAppointment], [Description], [PatientId]) VALUES (6, N'ау', 85)
INSERT [dbo].[Doctor's Appointment] ([IdAppointment], [Description], [PatientId]) VALUES (7, N'1', 75)
INSERT [dbo].[Doctor's Appointment] ([IdAppointment], [Description], [PatientId]) VALUES (17, N'отказ от воды', 103)
SET IDENTITY_INSERT [dbo].[Doctor's Appointment] OFF
GO
SET IDENTITY_INSERT [dbo].[HospitalDepartments] ON 

INSERT [dbo].[HospitalDepartments] ([IdDepartment], [NameDepartment]) VALUES (1, N'Терапевтическое')
INSERT [dbo].[HospitalDepartments] ([IdDepartment], [NameDepartment]) VALUES (2, N'Хирургическое')
INSERT [dbo].[HospitalDepartments] ([IdDepartment], [NameDepartment]) VALUES (3, N'Травмотологическое')
INSERT [dbo].[HospitalDepartments] ([IdDepartment], [NameDepartment]) VALUES (4, N'Кардиологическое')
INSERT [dbo].[HospitalDepartments] ([IdDepartment], [NameDepartment]) VALUES (5, N'Реабелитационное')
INSERT [dbo].[HospitalDepartments] ([IdDepartment], [NameDepartment]) VALUES (6, N'Онкологическое')
INSERT [dbo].[HospitalDepartments] ([IdDepartment], [NameDepartment]) VALUES (7, N'Тестовое')
SET IDENTITY_INSERT [dbo].[HospitalDepartments] OFF
GO
SET IDENTITY_INSERT [dbo].[HospitalPatients] ON 

INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (42, N'Егоров', N'Егор', N'Иванович', 12, N'58391', 37, CAST(N'1987-04-23' AS Date), CAST(N'2024-04-30' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (43, N'Козлова', N'Ирина', N'Петровна', 6, N'29510', 41, CAST(N'1975-11-09' AS Date), CAST(N'2024-05-04' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (44, N'Макаров', N'Сергей', N'Александрович', 19, N'77236', 14, CAST(N'1981-09-17' AS Date), CAST(N'2024-05-09' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (45, N'Павлов', N'Павел', N'Дмитриевич', 3, N'44899', 28, CAST(N'1993-12-01' AS Date), CAST(N'2024-05-07' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (46, N'Смирнова', N'Ольга', N'Владимировна', 15, N'63724', 45, CAST(N'1968-07-26' AS Date), CAST(N'2024-04-30' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (47, N'Захаров', N'Владимир', N'Викторович', 2, N'19985', 35, CAST(N'1989-03-25' AS Date), CAST(N'2024-05-01' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (48, N'Соколова', N'Наталья', N'Алексеевна', 20, N'50974', 9, CAST(N'1976-06-13' AS Date), CAST(N'2024-05-08' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (49, N'Кузнецов', N'Кузнецов', N'Васильевич', 5, N'78342', 39, CAST(N'1965-10-30' AS Date), CAST(N'2024-05-01' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (50, N'Иванова', N'Елена', N'Андреевна', 8, N'35841', 20, CAST(N'1971-02-11' AS Date), CAST(N'2024-05-03' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (51, N'Попов', N'Артем', N'Степанович', 16, N'92435', 48, CAST(N'1987-08-29' AS Date), CAST(N'2024-04-30' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (52, N'Сорокина', N'Анна', N'Игоревна', 7, N'62317', 25, CAST(N'1980-01-14' AS Date), CAST(N'2024-05-06' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (53, N'Григорьев', N'Дмитрий', N'Алексеевич', 13, N'16789', 37, CAST(N'1979-05-05' AS Date), CAST(N'2024-05-09' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (54, N'Шилова', N'Юлия', N'Валерьевна', 10, N'81248', 34, CAST(N'1996-04-18' AS Date), CAST(N'2024-04-30' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (55, N'Лебедева', N'Марина', N'Геннадьевна', 17, N'49675', 47, CAST(N'1973-12-29' AS Date), CAST(N'2024-05-02' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (56, N'Федоров', N'Александр', N'Игоревич', 22, N'33908', 5, CAST(N'1984-10-21' AS Date), CAST(N'2024-05-02' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (57, N'Дмитриева', N'Екатерина', N'Сергеевна', 23, N'54927', 3, CAST(N'1977-07-16' AS Date), CAST(N'2024-04-29' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (58, N'Тимофеев', N'Тимофеев', N'Михайлович', 5, N'23561', 42, CAST(N'1972-09-08' AS Date), CAST(N'2024-05-10' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (59, N'Никитина', N'Татьяна', N'Витальевна', 21, N'61327', 18, CAST(N'1990-03-24' AS Date), CAST(N'2024-05-03' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (60, N'Сидоров', N'Михаил', N'Николаевич', 4, N'89176', 26, CAST(N'1982-11-11' AS Date), CAST(N'2024-05-06' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (61, N'Алексеева', N'Ирина', N'Станиславовна', 17, N'72643', 45, CAST(N'1966-08-04' AS Date), CAST(N'2024-05-05' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (62, N'Васильев', N'Владислав', N'Алексеевич', 11, N'40216', 36, CAST(N'1974-06-01' AS Date), CAST(N'2024-04-30' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (63, N'Козырев', N'Даниил', N'Васильевич', 1, N'58092', 7, CAST(N'1988-01-28' AS Date), CAST(N'2024-05-01' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (64, N'Успенский', N'Илья', N'Григорьевич', 2, N'36345', 29, CAST(N'1978-04-03' AS Date), CAST(N'2024-04-30' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (65, N'Жукова', N'Ольга', N'Эдуардовна', 9, N'13785', 44, CAST(N'1969-12-20' AS Date), CAST(N'2024-05-07' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (66, N'Белов', N'Антон', N'Павлович', 18, N'64129', 50, CAST(N'1995-02-03' AS Date), CAST(N'2024-05-03' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (67, N'Воробьева', N'Елена', N'Александровна', 6, N'76104', 24, CAST(N'1983-09-15' AS Date), CAST(N'2024-05-10' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (68, N'Миронов', N'Артемий', N'Валерьевич', 19, N'54092', 8, CAST(N'1971-10-17' AS Date), CAST(N'2024-05-09' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (69, N'Кудряшова', N'Мария', N'Алексеевна', 20, N'38647', 15, CAST(N'1985-07-02' AS Date), CAST(N'2024-05-03' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (70, N'Поляков', N'Сергей', N'Вадимович', 3, N'92036', 21, CAST(N'1987-05-29' AS Date), CAST(N'2024-05-06' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (71, N'Романова', N'Надежда', N'Дмитриевна', 2, N'57834', 28, CAST(N'1974-08-10' AS Date), CAST(N'2024-05-06' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (72, N'Горбунов', N'Алексей', N'Вячеславович', 15, N'44927', 47, CAST(N'1977-01-03' AS Date), CAST(N'2024-04-29' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (73, N'Краснова', N'Людмила', N'Георгиевна', 3, N'31947', 19, CAST(N'1992-06-16' AS Date), CAST(N'2024-05-02' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (74, N'Тарасов', N'Павел', N'Алексеевич', 13, N'68910', 31, CAST(N'1976-11-18' AS Date), CAST(N'2024-05-09' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (75, N'Андреева', N'Вера', N'Витальевна', 5, N'74296', 33, CAST(N'1979-03-08' AS Date), CAST(N'2024-05-01' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (76, N'Захарова', N'Анастасия', N'Степановна', 11, N'53847', 10, CAST(N'1993-04-21' AS Date), CAST(N'2024-05-01' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (77, N'Панфилова', N'Екатерина', N'Ивановна', 4, N'89612', 49, CAST(N'1967-08-14' AS Date), CAST(N'2024-05-05' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (78, N'Суворова', N'Алена', N'Александровна', 12, N'65834', 4, CAST(N'1970-12-30' AS Date), CAST(N'2024-05-04' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (79, N'Крылова', N'София', N'Сергеевна', 16, N'27045', 23, CAST(N'1986-02-28' AS Date), CAST(N'2024-05-02' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (80, N'Волков', N'Андрей', N'Анатольевич', 9, N'58291', 46, CAST(N'1981-07-07' AS Date), CAST(N'2024-05-07' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (81, N'Медведева', N'Дарья', N'Николаевна', 20, N'48396', 27, CAST(N'1973-09-23' AS Date), CAST(N'2024-05-09' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (82, N'Ефимов', N'Арсений', N'Дмитриевич', 7, N'72658', 12, CAST(N'1982-03-19' AS Date), CAST(N'2024-05-06' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (83, N'Щербакова', N'Алла', N'Станиславовна', 18, N'40293', 38, CAST(N'1968-10-26' AS Date), CAST(N'2024-05-02' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (84, N'Носов', N'Станислав', N'Владимирович', 10, N'64209', 22, CAST(N'1990-08-07' AS Date), CAST(N'2024-05-03' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (85, N'Лапина', N'Лапина', N'Егоровна', 14, N'81736', 28, CAST(N'1983-12-15' AS Date), CAST(N'2024-04-29' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (86, N'Галкина', N'Ольга', N'Викторовна', 19, N'59413', 16, CAST(N'1969-06-24' AS Date), CAST(N'2024-05-09' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (87, N'Некрасов', N'Александр', N'Александрович', 17, N'36841', 6, CAST(N'1984-01-31' AS Date), CAST(N'2024-05-05' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (88, N'Петрова', N'Ирина', N'Анатольевна', 1, N'27469', 40, CAST(N'1976-11-03' AS Date), CAST(N'2024-05-01' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (89, N'Куликов', N'Куликов', N'Федорович', 5, N'72608', 8, CAST(N'1988-04-05' AS Date), CAST(N'2024-05-01' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (90, N'Шестакова', N'Анастасия', N'Николаевна', 22, N'68097', 30, CAST(N'1972-03-04' AS Date), CAST(N'2024-05-05' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (91, N'Трофимов', N'Лев', N'Валерьевич', 16, N'51347', 2, CAST(N'1997-02-07' AS Date), CAST(N'2024-05-01' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (92, N'Иванов', N'Иванов', N'Иванович', 5, N'66511', 43, CAST(N'2005-03-03' AS Date), CAST(N'2024-05-02' AS Date))
INSERT [dbo].[HospitalPatients] ([IdPatient], [NamePatient], [SurnamePatient], [PatronymicPatient], [WardId], [RegistrationNumber], [IdDiagnosis], [BirthdayPatient], [ArrivalDate]) VALUES (103, N'Тест', N'Тест', N'Тестов', 25, N'74208', 21, CAST(N'2018-12-31' AS Date), CAST(N'2024-05-22' AS Date))
SET IDENTITY_INSERT [dbo].[HospitalPatients] OFF
GO
SET IDENTITY_INSERT [dbo].[HospitalPosts] ON 

INSERT [dbo].[HospitalPosts] ([IdPost], [NamePost]) VALUES (1, N'Терапевт')
INSERT [dbo].[HospitalPosts] ([IdPost], [NamePost]) VALUES (2, N'Невропатолог')
INSERT [dbo].[HospitalPosts] ([IdPost], [NamePost]) VALUES (3, N'Хирург')
INSERT [dbo].[HospitalPosts] ([IdPost], [NamePost]) VALUES (4, N'Психиатр')
INSERT [dbo].[HospitalPosts] ([IdPost], [NamePost]) VALUES (5, N'Стоматолог')
INSERT [dbo].[HospitalPosts] ([IdPost], [NamePost]) VALUES (6, N'Офтальмолог')
INSERT [dbo].[HospitalPosts] ([IdPost], [NamePost]) VALUES (7, N'Невролог')
SET IDENTITY_INSERT [dbo].[HospitalPosts] OFF
GO
SET IDENTITY_INSERT [dbo].[HospitalWards] ON 

INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (1, N'21', 1)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (2, N'22', 1)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (3, N'23', 1)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (4, N'24', 1)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (5, N'25', 1)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (6, N'25а', 1)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (7, N'26', 1)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (8, N'31', 2)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (9, N'32', 2)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (10, N'33', 2)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (11, N'41', 3)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (12, N'41а', 3)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (13, N'42', 3)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (14, N'51', 4)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (15, N'52', 4)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (16, N'53', 4)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (17, N'61', 5)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (18, N'61а', 5)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (19, N'61б', 5)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (20, N'62', 5)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (21, N'71', 6)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (22, N'72', 6)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (23, N'72а', 6)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (24, N'99', 7)
INSERT [dbo].[HospitalWards] ([IdWard], [NameWard], [DepartmentId]) VALUES (25, N'98', 7)
SET IDENTITY_INSERT [dbo].[HospitalWards] OFF
GO
SET IDENTITY_INSERT [dbo].[HospitalWorkers] ON 

INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (1, N'Антонина', N'Платонова', N'Олеговна', 1, CAST(N'1992-08-24' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (2, N'Евграф', N'Галицын', N'Андреевич', 2, CAST(N'1976-06-06' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (3, N'Розалия', N'Чернышова', N'Тарасовна', 3, CAST(N'1987-03-15' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (4, N'Яков', N'Мечников', N'Макарович', 4, CAST(N'2000-04-06' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (5, N'Симон', N'Тюрин', N'Валерьевич', 5, CAST(N'1981-10-03' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (6, N'Трофим', N'Гоголь', N'Данилович', 6, CAST(N'2004-12-27' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (7, N'Агриппина', N'Головина', N'Кирилловна', 7, CAST(N'1995-11-16' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (8, N'Лев', N'Яндутов', N'Закирович', 1, CAST(N'1994-06-25' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (9, N'Лаврентий', N'Владов', N'Андреевич', 1, CAST(N'2002-06-10' AS Date))
INSERT [dbo].[HospitalWorkers] ([IdWorker], [NameWorker], [SurnameWorker], [PatronymicWorker], [PostId], [BirthdayWorker]) VALUES (10, N'Маенко', N'Михаил', N'Антонович', 6, CAST(N'2000-05-01' AS Date))
SET IDENTITY_INSERT [dbo].[HospitalWorkers] OFF
GO
SET IDENTITY_INSERT [dbo].[Parameters] ON 

INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (1, N'Пульс, уд. /мин')
INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (2, N'Артериальное давление, мм рт. ст.')
INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (3, N'Температура, ℃')
INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (4, N'Дыхание, вдох/мин')
INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (5, N'Вес, кг')
INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (6, N'Выпито жидкости, мл')
INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (7, N'Суточное количество мочи, мл')
INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (8, N'Стул')
INSERT [dbo].[Parameters] ([IdParameter], [NameParameter]) VALUES (9, N'Ванна')
SET IDENTITY_INSERT [dbo].[Parameters] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientInfo] ON 

INSERT [dbo].[PatientInfo] ([IdInfo], [PatientId], [BloodGroup], [RhesusType], [SideEffect], [DrugNameOfSideEffect], [Adress], [PlaceOfWork_Study]) VALUES (1, 103, N'C#', N'Abm', N'головокружение', N'пеницилин', N'переулок Трактористов 17, кв 37', N'емк')
INSERT [dbo].[PatientInfo] ([IdInfo], [PatientId], [BloodGroup], [RhesusType], [SideEffect], [DrugNameOfSideEffect], [Adress], [PlaceOfWork_Study]) VALUES (2, 49, N'23к23к2', N'3к23к23к', N'23к23к2', N'3к23к23к', N'23к23к23к', N'23к23к23к23к23к23к23к2')
INSERT [dbo].[PatientInfo] ([IdInfo], [PatientId], [BloodGroup], [RhesusType], [SideEffect], [DrugNameOfSideEffect], [Adress], [PlaceOfWork_Study]) VALUES (3, 85, N'--22', N'231', N'смерть', N'ergergeg', N'3904оп09ок9о30по039коп0кошпок0шпошкпо', N'емк')
SET IDENTITY_INSERT [dbo].[PatientInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IdRole], [NameRole]) VALUES (1, N'врач')
INSERT [dbo].[Roles] ([IdRole], [NameRole]) VALUES (2, N'главврач')
INSERT [dbo].[Roles] ([IdRole], [NameRole]) VALUES (3, N'администратор')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[TemperatureSheet] ON 

INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (1, 85, CAST(N'2024-04-29' AS Date), 1, 1, N'1')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (2, 85, CAST(N'2024-04-29' AS Date), 1, 2, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (3, 85, CAST(N'2024-04-29' AS Date), 1, 3, N'3')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (4, 85, CAST(N'2024-04-29' AS Date), 1, 4, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (5, 85, CAST(N'2024-04-29' AS Date), 1, 5, N'5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (6, 85, CAST(N'2024-04-29' AS Date), 1, 6, N'6')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (7, 85, CAST(N'2024-04-29' AS Date), 1, 7, N'7')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (8, 85, CAST(N'2024-04-29' AS Date), 1, 8, N'8')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (9, 85, CAST(N'2024-04-29' AS Date), 1, 9, N'9')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (10, 85, CAST(N'2024-04-29' AS Date), 2, 1, N'12')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (11, 85, CAST(N'2024-04-29' AS Date), 2, 2, N'13')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (12, 85, CAST(N'2024-04-29' AS Date), 2, 3, N'14')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (13, 85, CAST(N'2024-04-29' AS Date), 2, 4, N'15')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (14, 85, CAST(N'2024-04-29' AS Date), 2, 5, N'16')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (15, 85, CAST(N'2024-04-29' AS Date), 2, 6, N'17')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (16, 85, CAST(N'2024-04-29' AS Date), 2, 7, N'18')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (17, 85, CAST(N'2024-04-29' AS Date), 2, 8, N'19')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (18, 85, CAST(N'2024-04-29' AS Date), 2, 9, N'20')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (19, 85, CAST(N'2024-04-30' AS Date), 1, 1, N'fr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (20, 85, CAST(N'2024-04-30' AS Date), 1, 2, N'fr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (21, 85, CAST(N'2024-04-30' AS Date), 1, 3, N'fr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (22, 85, CAST(N'2024-04-30' AS Date), 1, 4, N'fr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (23, 85, CAST(N'2024-04-30' AS Date), 1, 5, N'fr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (24, 85, CAST(N'2024-04-30' AS Date), 1, 6, N'fr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (25, 85, CAST(N'2024-04-30' AS Date), 1, 7, N'fr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (26, 85, CAST(N'2024-04-30' AS Date), 1, 8, N'frfr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (27, 85, CAST(N'2024-04-30' AS Date), 1, 9, N'fr')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (28, 85, CAST(N'2024-04-30' AS Date), 2, 1, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (29, 85, CAST(N'2024-04-30' AS Date), 2, 2, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (30, 85, CAST(N'2024-04-30' AS Date), 2, 3, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (31, 85, CAST(N'2024-04-30' AS Date), 2, 4, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (32, 85, CAST(N'2024-04-30' AS Date), 2, 5, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (33, 85, CAST(N'2024-04-30' AS Date), 2, 6, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (34, 85, CAST(N'2024-04-30' AS Date), 2, 7, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (35, 85, CAST(N'2024-04-30' AS Date), 2, 8, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (36, 85, CAST(N'2024-04-30' AS Date), 2, 9, N'we')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (37, 85, CAST(N'2024-05-01' AS Date), 1, 1, N'q')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (38, 85, CAST(N'2024-05-01' AS Date), 1, 2, N'w')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (39, 85, CAST(N'2024-05-01' AS Date), 1, 3, N'e')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (40, 85, CAST(N'2024-05-01' AS Date), 1, 4, N'r')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (41, 85, CAST(N'2024-05-01' AS Date), 1, 5, N't')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (42, 85, CAST(N'2024-05-01' AS Date), 1, 6, N'y')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (43, 85, CAST(N'2024-05-01' AS Date), 1, 7, N'u')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (44, 85, CAST(N'2024-05-01' AS Date), 1, 8, N'i')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (45, 85, CAST(N'2024-05-01' AS Date), 1, 9, N'o')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (46, 85, CAST(N'2024-05-01' AS Date), 2, 1, N'a')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (47, 85, CAST(N'2024-05-01' AS Date), 2, 2, N's')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (48, 85, CAST(N'2024-05-01' AS Date), 2, 3, N'd')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (49, 85, CAST(N'2024-05-01' AS Date), 2, 4, N'f')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (50, 85, CAST(N'2024-05-01' AS Date), 2, 5, N'g')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (51, 85, CAST(N'2024-05-01' AS Date), 2, 6, N'h')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (52, 85, CAST(N'2024-05-01' AS Date), 2, 7, N'j')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (53, 85, CAST(N'2024-05-01' AS Date), 2, 8, N'k')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (54, 85, CAST(N'2024-05-01' AS Date), 2, 9, N'l')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (55, 85, CAST(N'2024-05-02' AS Date), 1, 1, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (56, 85, CAST(N'2024-05-02' AS Date), 1, 2, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (57, 85, CAST(N'2024-05-02' AS Date), 1, 3, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (58, 85, CAST(N'2024-05-02' AS Date), 1, 4, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (59, 85, CAST(N'2024-05-02' AS Date), 1, 5, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (60, 85, CAST(N'2024-05-02' AS Date), 1, 6, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (61, 85, CAST(N'2024-05-02' AS Date), 1, 7, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (62, 85, CAST(N'2024-05-02' AS Date), 1, 8, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (63, 85, CAST(N'2024-05-02' AS Date), 1, 9, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (64, 85, CAST(N'2024-05-02' AS Date), 2, 1, N'й')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (65, 85, CAST(N'2024-05-02' AS Date), 2, 2, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (66, 85, CAST(N'2024-05-02' AS Date), 2, 3, N'у')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (67, 85, CAST(N'2024-05-02' AS Date), 2, 4, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (68, 85, CAST(N'2024-05-02' AS Date), 2, 5, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (69, 85, CAST(N'2024-05-02' AS Date), 2, 6, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (70, 85, CAST(N'2024-05-02' AS Date), 2, 7, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (71, 85, CAST(N'2024-05-02' AS Date), 2, 8, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (72, 85, CAST(N'2024-05-02' AS Date), 2, 9, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (73, 85, CAST(N'2024-05-03' AS Date), 1, 1, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (74, 85, CAST(N'2024-05-03' AS Date), 1, 2, N'у')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (75, 85, CAST(N'2024-05-03' AS Date), 1, 3, N'к')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (76, 85, CAST(N'2024-05-03' AS Date), 1, 4, N'уцу')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (77, 85, CAST(N'2024-05-03' AS Date), 1, 5, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (78, 85, CAST(N'2024-05-03' AS Date), 1, 6, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (79, 85, CAST(N'2024-05-03' AS Date), 1, 7, N'у')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (80, 85, CAST(N'2024-05-03' AS Date), 1, 8, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (81, 85, CAST(N'2024-05-03' AS Date), 1, 9, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (82, 85, CAST(N'2024-05-03' AS Date), 2, 1, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (83, 85, CAST(N'2024-05-03' AS Date), 2, 2, N'ав')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (84, 85, CAST(N'2024-05-03' AS Date), 2, 3, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (85, 85, CAST(N'2024-05-03' AS Date), 2, 4, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (86, 85, CAST(N'2024-05-03' AS Date), 2, 5, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (87, 85, CAST(N'2024-05-03' AS Date), 2, 6, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (88, 85, CAST(N'2024-05-03' AS Date), 2, 7, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (89, 85, CAST(N'2024-05-03' AS Date), 2, 8, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (90, 85, CAST(N'2024-05-03' AS Date), 2, 9, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (91, 85, CAST(N'2024-05-04' AS Date), 1, 1, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (92, 85, CAST(N'2024-05-04' AS Date), 1, 2, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (93, 85, CAST(N'2024-05-04' AS Date), 1, 3, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (94, 85, CAST(N'2024-05-04' AS Date), 1, 4, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (95, 85, CAST(N'2024-05-04' AS Date), 1, 5, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (96, 85, CAST(N'2024-05-04' AS Date), 1, 6, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (97, 85, CAST(N'2024-05-04' AS Date), 1, 7, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (98, 85, CAST(N'2024-05-04' AS Date), 1, 8, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (99, 85, CAST(N'2024-05-04' AS Date), 1, 9, N'в')
GO
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (100, 85, CAST(N'2024-05-04' AS Date), 2, 1, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (101, 85, CAST(N'2024-05-04' AS Date), 2, 2, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (102, 85, CAST(N'2024-05-04' AS Date), 2, 3, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (103, 85, CAST(N'2024-05-04' AS Date), 2, 4, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (104, 85, CAST(N'2024-05-04' AS Date), 2, 5, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (105, 85, CAST(N'2024-05-04' AS Date), 2, 6, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (106, 85, CAST(N'2024-05-04' AS Date), 2, 7, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (107, 85, CAST(N'2024-05-04' AS Date), 2, 8, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (108, 85, CAST(N'2024-05-04' AS Date), 2, 9, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (109, 85, CAST(N'2024-05-05' AS Date), 1, 1, N'ы')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (110, 85, CAST(N'2024-05-05' AS Date), 1, 2, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (111, 85, CAST(N'2024-05-05' AS Date), 1, 3, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (112, 85, CAST(N'2024-05-05' AS Date), 1, 4, N'п')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (113, 85, CAST(N'2024-05-05' AS Date), 1, 5, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (114, 85, CAST(N'2024-05-05' AS Date), 1, 6, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (115, 85, CAST(N'2024-05-05' AS Date), 1, 7, N'ф')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (116, 85, CAST(N'2024-05-05' AS Date), 1, 8, N'ы')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (117, 85, CAST(N'2024-05-05' AS Date), 1, 9, N'с')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (118, 85, CAST(N'2024-05-05' AS Date), 2, 1, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (119, 85, CAST(N'2024-05-05' AS Date), 2, 2, N'ц')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (120, 85, CAST(N'2024-05-05' AS Date), 2, 3, N'у')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (121, 85, CAST(N'2024-05-05' AS Date), 2, 4, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (122, 85, CAST(N'2024-05-05' AS Date), 2, 5, N'к')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (123, 85, CAST(N'2024-05-05' AS Date), 2, 6, N'кек')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (124, 85, CAST(N'2024-05-05' AS Date), 2, 7, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (125, 85, CAST(N'2024-05-05' AS Date), 2, 8, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (126, 85, CAST(N'2024-05-05' AS Date), 2, 9, N'м')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (127, 85, CAST(N'2024-05-06' AS Date), 1, 1, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (128, 85, CAST(N'2024-05-06' AS Date), 1, 2, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (129, 85, CAST(N'2024-05-06' AS Date), 1, 3, N'е')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (130, 85, CAST(N'2024-05-06' AS Date), 1, 4, N'в')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (131, 85, CAST(N'2024-05-06' AS Date), 1, 5, N'у')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (132, 85, CAST(N'2024-05-06' AS Date), 1, 6, N'к')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (133, 85, CAST(N'2024-05-06' AS Date), 1, 7, N'п')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (134, 85, CAST(N'2024-05-06' AS Date), 1, 8, N'вп')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (135, 85, CAST(N'2024-05-06' AS Date), 1, 9, N'м')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (136, 85, CAST(N'2024-05-06' AS Date), 2, 1, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (137, 85, CAST(N'2024-05-06' AS Date), 2, 2, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (138, 85, CAST(N'2024-05-06' AS Date), 2, 3, N'л')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (139, 85, CAST(N'2024-05-06' AS Date), 2, 4, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (140, 85, CAST(N'2024-05-06' AS Date), 2, 5, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (141, 85, CAST(N'2024-05-06' AS Date), 2, 6, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (142, 85, CAST(N'2024-05-06' AS Date), 2, 7, N'л')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (143, 85, CAST(N'2024-05-06' AS Date), 2, 8, N'л')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (144, 85, CAST(N'2024-05-06' AS Date), 2, 9, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (145, 85, CAST(N'2024-05-07' AS Date), 1, 1, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (146, 85, CAST(N'2024-05-07' AS Date), 1, 2, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (147, 85, CAST(N'2024-05-07' AS Date), 1, 3, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (148, 85, CAST(N'2024-05-07' AS Date), 1, 4, N'пр')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (149, 85, CAST(N'2024-05-07' AS Date), 1, 5, N'т')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (150, 85, CAST(N'2024-05-07' AS Date), 1, 6, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (151, 85, CAST(N'2024-05-07' AS Date), 1, 7, N'п')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (152, 85, CAST(N'2024-05-07' AS Date), 1, 8, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (153, 85, CAST(N'2024-05-07' AS Date), 1, 9, N'т')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (154, 85, CAST(N'2024-05-07' AS Date), 2, 1, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (155, 85, CAST(N'2024-05-07' AS Date), 2, 2, N'г')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (156, 85, CAST(N'2024-05-07' AS Date), 2, 3, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (157, 85, CAST(N'2024-05-07' AS Date), 2, 4, N'щз')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (158, 85, CAST(N'2024-05-07' AS Date), 2, 5, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (159, 85, CAST(N'2024-05-07' AS Date), 2, 6, N'г')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (160, 85, CAST(N'2024-05-07' AS Date), 2, 7, N'шг')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (161, 85, CAST(N'2024-05-07' AS Date), 2, 8, N'щ')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (162, 85, CAST(N'2024-05-07' AS Date), 2, 9, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (163, 85, CAST(N'2024-05-08' AS Date), 1, 1, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (164, 85, CAST(N'2024-05-08' AS Date), 1, 2, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (165, 85, CAST(N'2024-05-08' AS Date), 1, 3, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (166, 85, CAST(N'2024-05-08' AS Date), 1, 4, N'щ')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (167, 85, CAST(N'2024-05-08' AS Date), 1, 5, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (168, 85, CAST(N'2024-05-08' AS Date), 1, 6, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (169, 85, CAST(N'2024-05-08' AS Date), 1, 7, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (170, 85, CAST(N'2024-05-08' AS Date), 1, 8, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (171, 85, CAST(N'2024-05-08' AS Date), 1, 9, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (172, 85, CAST(N'2024-05-08' AS Date), 2, 1, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (173, 85, CAST(N'2024-05-08' AS Date), 2, 2, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (174, 85, CAST(N'2024-05-08' AS Date), 2, 3, N'л')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (175, 85, CAST(N'2024-05-08' AS Date), 2, 4, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (176, 85, CAST(N'2024-05-08' AS Date), 2, 5, N'шд')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (177, 85, CAST(N'2024-05-08' AS Date), 2, 6, N'гш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (178, 85, CAST(N'2024-05-08' AS Date), 2, 7, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (179, 85, CAST(N'2024-05-08' AS Date), 2, 8, N'щ')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (180, 85, CAST(N'2024-05-08' AS Date), 2, 9, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (181, 85, CAST(N'2024-05-09' AS Date), 1, 1, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (182, 85, CAST(N'2024-05-09' AS Date), 1, 2, N'г')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (183, 85, CAST(N'2024-05-09' AS Date), 1, 3, N'л')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (184, 85, CAST(N'2024-05-09' AS Date), 1, 4, N'гн')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (185, 85, CAST(N'2024-05-09' AS Date), 1, 5, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (186, 85, CAST(N'2024-05-09' AS Date), 1, 6, N'л')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (187, 85, CAST(N'2024-05-09' AS Date), 1, 7, N'г')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (188, 85, CAST(N'2024-05-09' AS Date), 1, 8, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (189, 85, CAST(N'2024-05-09' AS Date), 1, 9, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (190, 85, CAST(N'2024-05-09' AS Date), 2, 1, N'щ')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (191, 85, CAST(N'2024-05-09' AS Date), 2, 2, N'ш')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (192, 85, CAST(N'2024-05-09' AS Date), 2, 3, N'г')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (193, 85, CAST(N'2024-05-09' AS Date), 2, 4, N'н')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (194, 85, CAST(N'2024-05-09' AS Date), 2, 5, N'е')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (195, 85, CAST(N'2024-05-09' AS Date), 2, 6, N'к')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (196, 85, CAST(N'2024-05-09' AS Date), 2, 7, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (197, 85, CAST(N'2024-05-09' AS Date), 2, 8, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (198, 85, CAST(N'2024-05-09' AS Date), 2, 9, N'ь')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (199, 85, CAST(N'2024-05-10' AS Date), 1, 1, N'а')
GO
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (200, 85, CAST(N'2024-05-10' AS Date), 1, 2, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (201, 85, CAST(N'2024-05-10' AS Date), 1, 3, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (202, 85, CAST(N'2024-05-10' AS Date), 1, 4, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (203, 85, CAST(N'2024-05-10' AS Date), 1, 5, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (204, 85, CAST(N'2024-05-10' AS Date), 1, 6, N'що')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (205, 85, CAST(N'2024-05-10' AS Date), 1, 7, N'що')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (206, 85, CAST(N'2024-05-10' AS Date), 1, 8, N'щ')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (207, 85, CAST(N'2024-05-10' AS Date), 1, 9, N'лщл')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (208, 85, CAST(N'2024-05-10' AS Date), 2, 1, N'ж')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (209, 85, CAST(N'2024-05-10' AS Date), 2, 2, N'ж')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (210, 85, CAST(N'2024-05-10' AS Date), 2, 3, N'ж')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (211, 85, CAST(N'2024-05-10' AS Date), 2, 4, N'ж')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (212, 85, CAST(N'2024-05-10' AS Date), 2, 5, N'лд')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (213, 85, CAST(N'2024-05-10' AS Date), 2, 6, N'о')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (214, 85, CAST(N'2024-05-10' AS Date), 2, 7, N'т')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (215, 85, CAST(N'2024-05-10' AS Date), 2, 8, N'ло')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (216, 85, CAST(N'2024-05-10' AS Date), 2, 9, N'ор')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (217, 85, CAST(N'2024-05-11' AS Date), 1, 1, N'ю')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (218, 85, CAST(N'2024-05-11' AS Date), 1, 2, N'ю')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (219, 85, CAST(N'2024-05-11' AS Date), 1, 3, N'ю')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (220, 85, CAST(N'2024-05-11' AS Date), 1, 4, N'ю')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (221, 85, CAST(N'2024-05-11' AS Date), 1, 5, N'б')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (222, 85, CAST(N'2024-05-11' AS Date), 1, 6, N'л')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (223, 85, CAST(N'2024-05-11' AS Date), 1, 7, N'щдж')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (224, 85, CAST(N'2024-05-11' AS Date), 1, 8, N'дб')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (225, 85, CAST(N'2024-05-11' AS Date), 1, 9, N'л')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (226, 85, CAST(N'2024-05-11' AS Date), 2, 1, N'к')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (227, 85, CAST(N'2024-05-11' AS Date), 2, 2, N'и')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (228, 85, CAST(N'2024-05-11' AS Date), 2, 3, N'итт')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (229, 85, CAST(N'2024-05-11' AS Date), 2, 4, N'ь')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (230, 85, CAST(N'2024-05-11' AS Date), 2, 5, N'ьл')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (231, 85, CAST(N'2024-05-11' AS Date), 2, 6, N'т')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (232, 85, CAST(N'2024-05-11' AS Date), 2, 7, N'к')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (233, 85, CAST(N'2024-05-11' AS Date), 2, 8, N'и')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (234, 85, CAST(N'2024-05-11' AS Date), 2, 9, N'р')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (235, 85, CAST(N'2024-05-12' AS Date), 1, 1, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (236, 85, CAST(N'2024-05-12' AS Date), 1, 2, N'0')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (237, 85, CAST(N'2024-05-12' AS Date), 1, 3, N'-')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (238, 85, CAST(N'2024-05-12' AS Date), 1, 4, N'0')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (239, 85, CAST(N'2024-05-12' AS Date), 1, 5, N'9')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (240, 85, CAST(N'2024-05-12' AS Date), 1, 6, N'0-')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (241, 85, CAST(N'2024-05-12' AS Date), 1, 7, N'-0')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (242, 85, CAST(N'2024-05-12' AS Date), 1, 8, N'0щ')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (243, 85, CAST(N'2024-05-12' AS Date), 1, 9, N'9')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (244, 85, CAST(N'2024-05-12' AS Date), 2, 1, N'-')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (245, 85, CAST(N'2024-05-12' AS Date), 2, 2, N'-')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (246, 85, CAST(N'2024-05-12' AS Date), 2, 3, N'=-')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (247, 85, CAST(N'2024-05-12' AS Date), 2, 4, N'х')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (248, 85, CAST(N'2024-05-12' AS Date), 2, 5, N'з')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (249, 85, CAST(N'2024-05-12' AS Date), 2, 6, N'з')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (250, 85, CAST(N'2024-05-12' AS Date), 2, 7, N'з')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (251, 85, CAST(N'2024-05-12' AS Date), 2, 8, N'з')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (252, 85, CAST(N'2024-05-12' AS Date), 2, 9, N'-=')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (253, 85, CAST(N'2024-05-13' AS Date), 1, 1, N'0щ')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (254, 85, CAST(N'2024-05-13' AS Date), 1, 2, N'0щ')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (255, 85, CAST(N'2024-05-13' AS Date), 1, 3, N'з-')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (256, 85, CAST(N'2024-05-13' AS Date), 1, 4, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (257, 85, CAST(N'2024-05-13' AS Date), 1, 5, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (258, 85, CAST(N'2024-05-13' AS Date), 1, 6, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (259, 85, CAST(N'2024-05-13' AS Date), 1, 7, N'дж')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (260, 85, CAST(N'2024-05-13' AS Date), 1, 8, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (261, 85, CAST(N'2024-05-13' AS Date), 1, 9, N'д')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (262, 85, CAST(N'2024-05-13' AS Date), 2, 1, N'ау')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (263, 85, CAST(N'2024-05-13' AS Date), 2, 2, N'ауцуа')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (264, 85, CAST(N'2024-05-13' AS Date), 2, 3, N'м')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (265, 85, CAST(N'2024-05-13' AS Date), 2, 4, N'к')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (266, 85, CAST(N'2024-05-13' AS Date), 2, 5, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (267, 85, CAST(N'2024-05-13' AS Date), 2, 6, N'п')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (268, 85, CAST(N'2024-05-13' AS Date), 2, 7, N'м')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (269, 85, CAST(N'2024-05-13' AS Date), 2, 8, N'а')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (270, 85, CAST(N'2024-05-13' AS Date), 2, 9, N'жх')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (271, 49, CAST(N'2024-05-01' AS Date), 1, 1, N'a1')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (272, 49, CAST(N'2024-05-01' AS Date), 1, 2, N'a2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (273, 49, CAST(N'2024-05-01' AS Date), 1, 3, N'a3')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (274, 49, CAST(N'2024-05-01' AS Date), 1, 4, N'a4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (275, 49, CAST(N'2024-05-01' AS Date), 1, 5, N'a5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (276, 49, CAST(N'2024-05-01' AS Date), 1, 6, N'a6')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (277, 49, CAST(N'2024-05-01' AS Date), 1, 7, N'a7')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (278, 49, CAST(N'2024-05-01' AS Date), 1, 8, N'a8')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (279, 49, CAST(N'2024-05-01' AS Date), 1, 9, N'a9')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (280, 49, CAST(N'2024-05-01' AS Date), 2, 1, N's1')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (281, 49, CAST(N'2024-05-01' AS Date), 2, 2, N's2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (282, 49, CAST(N'2024-05-01' AS Date), 2, 3, N's3')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (283, 49, CAST(N'2024-05-01' AS Date), 2, 4, N's4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (284, 49, CAST(N'2024-05-01' AS Date), 2, 5, N's5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (285, 49, CAST(N'2024-05-01' AS Date), 2, 6, N's6')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (286, 49, CAST(N'2024-05-01' AS Date), 2, 7, N's7')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (287, 49, CAST(N'2024-05-01' AS Date), 2, 8, N's8')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (288, 49, CAST(N'2024-05-01' AS Date), 2, 9, N's9')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (289, 103, CAST(N'2024-05-22' AS Date), 1, 1, N'7*')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (290, 103, CAST(N'2024-05-22' AS Date), 1, 2, N'8*')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (291, 103, CAST(N'2024-05-22' AS Date), 1, 3, N'9*')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (292, 103, CAST(N'2024-05-22' AS Date), 1, 4, N'48')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (293, 103, CAST(N'2024-05-22' AS Date), 1, 5, N'48')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (294, 103, CAST(N'2024-05-22' AS Date), 1, 6, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (295, 103, CAST(N'2024-05-22' AS Date), 1, 7, N'5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (296, 103, CAST(N'2024-05-22' AS Date), 1, 8, N'41')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (297, 103, CAST(N'2024-05-22' AS Date), 1, 9, N'5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (298, 103, CAST(N'2024-05-22' AS Date), 2, 1, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (299, 103, CAST(N'2024-05-22' AS Date), 2, 2, N'/*')
GO
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (300, 103, CAST(N'2024-05-22' AS Date), 2, 3, N'*5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (301, 103, CAST(N'2024-05-22' AS Date), 2, 4, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (302, 103, CAST(N'2024-05-22' AS Date), 2, 5, N'5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (303, 103, CAST(N'2024-05-22' AS Date), 2, 6, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (304, 103, CAST(N'2024-05-22' AS Date), 2, 7, N'1')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (305, 103, CAST(N'2024-05-22' AS Date), 2, 8, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (306, 103, CAST(N'2024-05-22' AS Date), 2, 9, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (307, 49, CAST(N'2024-05-02' AS Date), 1, 1, N'12')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (308, 49, CAST(N'2024-05-02' AS Date), 1, 2, N'12')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (309, 49, CAST(N'2024-05-02' AS Date), 1, 3, N'12')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (310, 49, CAST(N'2024-05-02' AS Date), 1, 4, N'12')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (311, 49, CAST(N'2024-05-02' AS Date), 1, 5, N'121')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (312, 49, CAST(N'2024-05-02' AS Date), 1, 6, N'21')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (313, 49, CAST(N'2024-05-02' AS Date), 1, 7, N'212')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (314, 49, CAST(N'2024-05-02' AS Date), 1, 8, N'12')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (315, 49, CAST(N'2024-05-02' AS Date), 1, 9, N'12')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (316, 49, CAST(N'2024-05-02' AS Date), 2, 1, N'34')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (317, 49, CAST(N'2024-05-02' AS Date), 2, 2, N'343')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (318, 49, CAST(N'2024-05-02' AS Date), 2, 3, N'43')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (319, 49, CAST(N'2024-05-02' AS Date), 2, 4, N'43')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (320, 49, CAST(N'2024-05-02' AS Date), 2, 5, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (321, 49, CAST(N'2024-05-02' AS Date), 2, 6, N'34')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (322, 49, CAST(N'2024-05-02' AS Date), 2, 7, N'343')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (323, 49, CAST(N'2024-05-02' AS Date), 2, 8, N'34')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (324, 49, CAST(N'2024-05-02' AS Date), 2, 9, N'34')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (325, 84, CAST(N'2024-06-09' AS Date), 1, 1, N'1')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (326, 84, CAST(N'2024-06-09' AS Date), 1, 2, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (327, 84, CAST(N'2024-06-09' AS Date), 1, 3, N'3')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (328, 84, CAST(N'2024-06-09' AS Date), 1, 4, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (329, 84, CAST(N'2024-06-09' AS Date), 1, 5, N'5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (330, 84, CAST(N'2024-06-09' AS Date), 1, 6, N'6')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (331, 84, CAST(N'2024-06-09' AS Date), 1, 7, N'7')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (332, 84, CAST(N'2024-06-09' AS Date), 1, 8, N'8')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (333, 84, CAST(N'2024-06-09' AS Date), 1, 9, N'9')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (334, 84, CAST(N'2024-06-09' AS Date), 2, 1, N'1')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (335, 84, CAST(N'2024-06-09' AS Date), 2, 2, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (336, 84, CAST(N'2024-06-09' AS Date), 2, 3, N'3')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (337, 84, CAST(N'2024-06-09' AS Date), 2, 4, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (338, 84, CAST(N'2024-06-09' AS Date), 2, 5, N'5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (339, 84, CAST(N'2024-06-09' AS Date), 2, 6, N'6')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (340, 84, CAST(N'2024-06-09' AS Date), 2, 7, N'7')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (341, 84, CAST(N'2024-06-09' AS Date), 2, 8, N'8')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (342, 84, CAST(N'2024-06-09' AS Date), 2, 9, N'9')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (343, 84, CAST(N'2024-06-09' AS Date), 1, 1, N'1')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (344, 84, CAST(N'2024-06-09' AS Date), 1, 2, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (345, 84, CAST(N'2024-06-09' AS Date), 1, 3, N'3')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (346, 84, CAST(N'2024-06-09' AS Date), 1, 4, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (347, 84, CAST(N'2024-06-09' AS Date), 1, 5, N'5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (348, 84, CAST(N'2024-06-09' AS Date), 1, 6, N'6')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (349, 84, CAST(N'2024-06-09' AS Date), 1, 7, N'7')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (350, 84, CAST(N'2024-06-09' AS Date), 1, 8, N'8')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (351, 84, CAST(N'2024-06-09' AS Date), 1, 9, N'9')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (352, 84, CAST(N'2024-06-09' AS Date), 2, 1, N'1')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (353, 84, CAST(N'2024-06-09' AS Date), 2, 2, N'2')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (354, 84, CAST(N'2024-06-09' AS Date), 2, 3, N'3')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (355, 84, CAST(N'2024-06-09' AS Date), 2, 4, N'4')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (356, 84, CAST(N'2024-06-09' AS Date), 2, 5, N'5')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (357, 84, CAST(N'2024-06-09' AS Date), 2, 6, N'6')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (358, 84, CAST(N'2024-06-09' AS Date), 2, 7, N'7')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (359, 84, CAST(N'2024-06-09' AS Date), 2, 8, N'8')
INSERT [dbo].[TemperatureSheet] ([IdRecord], [PatientId], [DateStaying], [TimeId], [ParameterId], [Value]) VALUES (360, 84, CAST(N'2024-06-09' AS Date), 2, 9, N'9')
SET IDENTITY_INSERT [dbo].[TemperatureSheet] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeOfDay] ON 

INSERT [dbo].[TimeOfDay] ([IdTime], [NameTime]) VALUES (1, N'утро')
INSERT [dbo].[TimeOfDay] ([IdTime], [NameTime]) VALUES (2, N'вечер')
SET IDENTITY_INSERT [dbo].[TimeOfDay] OFF
GO
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'AntoninaPlatonova283', N'85eff7d87b0264feae5f9c562e9e19523bc38922c2a2b8ef51dd23c120caa26c', 1, 1)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'EvgrafGalitsyn18', N'c27b95f75c569e082817595d44489c569f12bda4239f79f321fa45843456b922', 2, 2)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'Gogol123', N'd45b4d4722134a2ce32e8fe32d5d0702417efdff43cc7e6504a29bbcc6c58ce1', 2, 6)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'KirilinaGolovina', N'a205033819864e505854cbad2e324fb821aab3cc0f1ec371cfb0d18496b070d8', 1, 7)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'LavrentiyVladov393', N'5524cfa1ec14bf46dacac6f47c72ce5b69dfe7e64f5bb1e5caa326f5544f36e6', 3, 9)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'LevYandutov987', N'e6046fb233abd2406bd327d11a5a611ff7631618398f6a583ff8391280d40c4e', 1, 8)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'maenko123', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, 10)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'RozaliyaChernyshova207', N'96e165822988d44d086d184f36271fbd2c56a458898957e54c3297aa81ffebc1', 1, 3)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'SimonTyurin30', N'3d6442548efcfc9fa5af60dba7b28f82d59d700d894b77245928d2b99c904fc4', 1, 5)
INSERT [dbo].[Users] ([Login], [Password], [RoleId], [WorkerId]) VALUES (N'YakovMechnikov171', N'84f0e15df55a25bcc7885b061c94e78e74cd6183409b7a49f5dc5d63ca5cad16', 1, 4)
GO
SET IDENTITY_INSERT [dbo].[WorkerInWards] ON 

INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (1, 1, 4)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (2, 7, 2)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (3, 12, 6)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (4, 3, 8)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (5, 18, 5)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (6, 14, 1)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (8, 23, 7)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (9, 9, 2)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (10, 2, 8)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (11, 17, 4)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (12, 5, 1)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (14, 21, 6)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (15, 8, 5)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (16, 13, 2)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (17, 4, 7)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (18, 20, 1)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (19, 15, 4)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (20, 11, 8)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (21, 24, 4)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (22, 25, 1)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (31, 6, 3)
INSERT [dbo].[WorkerInWards] ([IdWorkerInWards], [WardId], [WorkerId]) VALUES (32, 10, 3)
SET IDENTITY_INSERT [dbo].[WorkerInWards] OFF
GO
ALTER TABLE [dbo].[Doctor's Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Doctor's Appointment_HospitalPatients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[HospitalPatients] ([IdPatient])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctor's Appointment] CHECK CONSTRAINT [FK_Doctor's Appointment_HospitalPatients]
GO
ALTER TABLE [dbo].[HospitalPatients]  WITH CHECK ADD  CONSTRAINT [FK_HospitalPatients_Diagnoses] FOREIGN KEY([IdDiagnosis])
REFERENCES [dbo].[Diagnoses] ([IdDiagnosis])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HospitalPatients] CHECK CONSTRAINT [FK_HospitalPatients_Diagnoses]
GO
ALTER TABLE [dbo].[HospitalPatients]  WITH CHECK ADD  CONSTRAINT [FK_HospitalPatients_HospitalWards] FOREIGN KEY([WardId])
REFERENCES [dbo].[HospitalWards] ([IdWard])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HospitalPatients] CHECK CONSTRAINT [FK_HospitalPatients_HospitalWards]
GO
ALTER TABLE [dbo].[HospitalWards]  WITH CHECK ADD  CONSTRAINT [FK_HospitalWards_HospitalDepartments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[HospitalDepartments] ([IdDepartment])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HospitalWards] CHECK CONSTRAINT [FK_HospitalWards_HospitalDepartments]
GO
ALTER TABLE [dbo].[HospitalWorkers]  WITH CHECK ADD  CONSTRAINT [FK_HospitalWorkers_HospitalPosts] FOREIGN KEY([PostId])
REFERENCES [dbo].[HospitalPosts] ([IdPost])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HospitalWorkers] CHECK CONSTRAINT [FK_HospitalWorkers_HospitalPosts]
GO
ALTER TABLE [dbo].[PatientInfo]  WITH CHECK ADD  CONSTRAINT [FK_PatientInfo_HospitalPatients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[HospitalPatients] ([IdPatient])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientInfo] CHECK CONSTRAINT [FK_PatientInfo_HospitalPatients]
GO
ALTER TABLE [dbo].[TemperatureSheet]  WITH CHECK ADD  CONSTRAINT [FK_TemperatureSheet_HospitalPatients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[HospitalPatients] ([IdPatient])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TemperatureSheet] CHECK CONSTRAINT [FK_TemperatureSheet_HospitalPatients]
GO
ALTER TABLE [dbo].[TemperatureSheet]  WITH CHECK ADD  CONSTRAINT [FK_TemperatureSheet_Parameters] FOREIGN KEY([ParameterId])
REFERENCES [dbo].[Parameters] ([IdParameter])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TemperatureSheet] CHECK CONSTRAINT [FK_TemperatureSheet_Parameters]
GO
ALTER TABLE [dbo].[TemperatureSheet]  WITH CHECK ADD  CONSTRAINT [FK_TemperatureSheet_TimeOfDay] FOREIGN KEY([TimeId])
REFERENCES [dbo].[TimeOfDay] ([IdTime])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TemperatureSheet] CHECK CONSTRAINT [FK_TemperatureSheet_TimeOfDay]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_HospitalWorkers] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[HospitalWorkers] ([IdWorker])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_HospitalWorkers]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([IdRole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[WorkerInWards]  WITH CHECK ADD  CONSTRAINT [FK_WorkerInWards_HospitalWards] FOREIGN KEY([WardId])
REFERENCES [dbo].[HospitalWards] ([IdWard])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkerInWards] CHECK CONSTRAINT [FK_WorkerInWards_HospitalWards]
GO
ALTER TABLE [dbo].[WorkerInWards]  WITH CHECK ADD  CONSTRAINT [FK_WorkerInWards_HospitalWorkers] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[HospitalWorkers] ([IdWorker])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkerInWards] CHECK CONSTRAINT [FK_WorkerInWards_HospitalWorkers]
GO
