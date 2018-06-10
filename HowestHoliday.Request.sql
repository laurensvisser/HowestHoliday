/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2016
    Target Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [HowestHoliday]
GO

/****** Object:  Table [dbo].[Request]    Script Date: 10/06/2018 10:26:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Request](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[Requestor] [nvarchar](256) NOT NULL,
	[Date] [date] NOT NULL,
	[MotivationRequestor] [nvarchar](256) NULL,
	[Status] [tinyint] NOT NULL,
	[Manager] [nvarchar](256) NULL,
	[MotivationManager] [nvarchar](256) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


