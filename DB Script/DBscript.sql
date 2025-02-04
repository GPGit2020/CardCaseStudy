USE [master]
GO
/****** Object:  Database [UserDB]    Script Date: 7/10/2020 12:47:57 PM ******/
CREATE DATABASE [UserDB]
 GO
ALTER DATABASE [UserDB] SET COMPATIBILITY_LEVEL = 130
GO


USE [UserDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/10/2020 12:47:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardEligibilityDetail]    Script Date: 7/10/2020 12:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardEligibilityDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UserCardStatus] [nvarchar](200) NULL,
	[APROnCard] [decimal](18, 2) NOT NULL,
	[UserPromotionalMsg] [nvarchar](300) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CardEligibilityDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 7/10/2020 12:47:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NULL,
	[DOB] [datetime] NOT NULL,
	[AnnualSalary] [decimal](18, 0) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_UserDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_CardEligibilityDetail_UserId]    Script Date: 7/10/2020 12:47:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_CardEligibilityDetail_UserId] ON [dbo].[CardEligibilityDetail]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CardEligibilityDetail]  WITH CHECK ADD  CONSTRAINT [FK_CardEligibilityDetail_UserDetail_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserDetail] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CardEligibilityDetail] CHECK CONSTRAINT [FK_CardEligibilityDetail_UserDetail_UserId]
GO
USE [master]
GO
ALTER DATABASE [UserDB] SET  READ_WRITE 
GO
