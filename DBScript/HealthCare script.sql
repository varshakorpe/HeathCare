USE [HealthCare]
GO
/****** Object:  Table [dbo].[PatientReg]    Script Date: 01/16/2017 13:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientReg](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NULL,
	[Name] [varchar](max) NULL,
	[City] [nchar](10) NULL,
	[Address] [varchar](max) NULL,
	[Mobile] [varchar](max) NULL,
	[Gender] [varchar](max) NULL,
	[Blood] [varchar](max) NULL,
	[Problem] [varchar](max) NULL,
	[DoctorName] [varchar](max) NULL,
 CONSTRAINT [PK__PatientR__3213E83F7F60ED59] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientDischarge]    Script Date: 01/16/2017 13:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientDischarge](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NULL,
	[Name] [varchar](max) NULL,
	[Gender] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[CurrentDate] [date] NULL,
	[Address] [varchar](max) NULL,
	[Mobile] [varchar](max) NULL,
	[Blood] [varchar](max) NULL,
	[Problem] [varchar](max) NULL,
	[DoctorName] [varchar](max) NULL,
	[RoomType] [varchar](max) NULL,
	[RoomNo] [varchar](max) NULL,
	[BedNo] [varchar](max) NULL,
	[DischargeDate] [date] NULL,
	[CheckUpFee] [varchar](max) NULL,
	[Maintainance] [varchar](max) NULL,
	[BedCharges] [varchar](max) NULL,
	[Total] [varchar](max) NULL,
	[Remark] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientAdmission]    Script Date: 01/16/2017 13:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientAdmission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NULL,
	[Name] [varchar](max) NULL,
	[Gender] [varchar](max) NULL,
	[City] [nchar](10) NULL,
	[Address] [varchar](max) NULL,
	[Mobile] [varchar](max) NULL,
	[Blood] [varchar](max) NULL,
	[Problem] [varchar](max) NULL,
	[DoctorName] [varchar](max) NULL,
	[RoomType] [varchar](max) NULL,
	[RoomNo] [varchar](max) NULL,
	[BedNo] [varchar](max) NULL,
	[CurrentDate] [date] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 01/16/2017 13:01:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON
INSERT [dbo].[Login] ([id],[Title],[Name],[Gender],[City],[UserName],[Password], [Address],[Mobile]) VALUES (1,N'Mr',N'Admin',N'Male',N'Pune',N'admin', N'admin', N'Pune',N'7758542321')
SET IDENTITY_INSERT [dbo].[Login] OFF
/****** Object:  StoredProcedure [dbo].[Sp_PatientSearch]    Script Date: 01/16/2017 13:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_PatientSearch]
(@id int,
@Title Varchar(Max),
@Name Varchar(Max),
@Address Varchar(Max),
@City varchar(max),
@Mobile Varchar(Max),
@Gender varchar(max),
@Blood Varchar(Max),
@Problem Varchar(Max),
@DoctorName Varchar(Max))
as 
begin
select * from Employee where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_PatientUpdate]    Script Date: 01/16/2017 13:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_PatientUpdate]
(
@id int,
@Title Varchar(Max),
@Name Varchar(Max),
@City varchar(max),
@Address Varchar(Max),
@Mobile Varchar(Max),
@Gender varchar(max),
@Blood Varchar(Max),
@Problem Varchar(Max),
@DoctorName Varchar(Max))
as 
begin
Update PatientReg set
Title=@Title ,
Name=@Name ,
City=@City,
Address=@Address ,
Mobile=@Mobile ,
Gender=@Gender ,
Blood=@Blood ,
Problem=@Problem ,
DoctorName=@DoctorName where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_PatientInsert]    Script Date: 01/16/2017 13:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_PatientInsert]
(
@Title Varchar(Max),
@Name Varchar(Max),
@City varchar(max),
@Address Varchar(Max),

@Mobile Varchar(Max),
@Gender varchar(max),
@Blood Varchar(Max),
@Problem Varchar(Max),
@DoctorName Varchar(Max))
as 
begin
insert into PatientReg values
(
@Title ,
@Name ,
@City,
@Address ,
@Mobile ,
@Gender ,
@Blood ,
@Problem ,
@DoctorName )
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_PatientDischargeInsert]    Script Date: 01/16/2017 13:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_PatientDischargeInsert]
(
@Title Varchar(Max),
@Name Varchar(Max),
@Gender varchar(max),
@City varchar(max),
@CurrentDate date,
@Address Varchar(Max),
@Mobile Varchar(Max),
@Blood Varchar(Max),
@Problem Varchar(Max),
@DoctorName Varchar(Max),
@RoomType varchar(max),
@RoomNo varchar(max),
@BedNo varchar(max),
@DischargeDate date,
@CheckUpFee varchar(max),
@Maintainance varchar(max),
@BedCharges varchar(max),
@Total varchar(max),
@Remark varchar(max))
as 
begin
insert into PatientDischarge values
(
@Title ,
@Name ,
@Gender ,
@City,
@CurrentDate,
@Address ,
@Mobile ,
@Blood ,
@Problem ,
@DoctorName,
@RoomType,
@RoomNo,
@BedNo,
@DischargeDate,
@CheckUpFee,
@Maintainance,
@BedCharges,
@Total,
@Remark)
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_PatientDischarge]    Script Date: 01/16/2017 13:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_PatientDischarge]
(
@Title Varchar(Max),
@Name Varchar(Max),
@Gender varchar(max),
@City varchar(max),
@CurrentDate Date,
@Address Varchar(Max),
@Mobile Varchar(Max),
@Blood Varchar(Max),
@Problem Varchar(Max),
@DoctorName Varchar(Max),
@RoomType varchar(max),
@RoomNo varchar(max),
@BedNo varchar(max),
@DischargeDate date,
@CheckUpFee varchar(max),
@Maintainance varchar(max),
@BedCharges varchar(max),
@Total varchar(max),
@Remark varchar(Max))
as 
begin
insert into PatientDischarge values
(
@Title ,
@Name ,
@Gender ,
@City,
@CurrentDate,
@Address ,
@Mobile ,
@Blood ,
@Problem ,
@DoctorName,
@RoomType,
@RoomNo,
@BedNo,
@DischargeDate ,
@CheckUpFee ,
@Maintainance,
@BedCharges,
@Total,
@Remark )
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_PatientAdmissionInsert]    Script Date: 01/16/2017 13:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_PatientAdmissionInsert]
(
@Title Varchar(Max),
@Name Varchar(Max),
@Gender varchar(max),
@City varchar(max),
@Address Varchar(Max),
@Mobile Varchar(Max),
@Blood Varchar(Max),
@Problem Varchar(Max),
@DoctorName Varchar(Max),
@RoomType varchar(max),
@RoomNo varchar(max),
@BedNo varchar(max),
@CurrentDate Date)
as 
begin
insert into PatientAdmission values
(
@Title ,
@Name ,
@Gender ,
@City,
@Address ,
@Mobile ,
@Blood ,
@Problem ,
@DoctorName,
@RoomType,
@RoomNo,
@BedNo,
@CurrentDate )
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_LoginInsert]    Script Date: 01/16/2017 13:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_LoginInsert]
(
@Title Varchar(50),
@Name Varchar(50),
@Gender varchar(50),
@City varchar(50),
@userName varchar(50),
@Password varchar(50),
@Address Varchar(50),
@Mobile Varchar(50))

as 
begin
insert into Login values
(
@Title ,
@Name ,
@Gender,
@City,
@UserName,
@Password,
@Address ,
@Mobile 
 
 )
end
GO
