/****** Object:  ForeignKey [FK_Company_State]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_State]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_Company_State]
GO
/****** Object:  ForeignKey [FK_CompanyContact_Company]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_Company]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact] DROP CONSTRAINT [FK_CompanyContact_Company]
GO
/****** Object:  ForeignKey [FK_CompanyContact_Contact]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_Contact]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact] DROP CONSTRAINT [FK_CompanyContact_Contact]
GO
/****** Object:  ForeignKey [FK_CompanyContact_ContactType]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_ContactType]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact] DROP CONSTRAINT [FK_CompanyContact_ContactType]
GO
/****** Object:  ForeignKey [FK_Contact_State]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contact_State]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contact]'))
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_Contact_State]
GO
/****** Object:  Table [dbo].[CompanyContact]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyContact]') AND type in (N'U'))
DROP TABLE [dbo].[CompanyContact]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
DROP TABLE [dbo].[Contact]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Company]') AND type in (N'U'))
DROP TABLE [dbo].[Company]
GO
/****** Object:  Table [dbo].[ContactType]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactType]') AND type in (N'U'))
DROP TABLE [dbo].[ContactType]
GO
/****** Object:  Table [dbo].[State]    Script Date: 10/21/2010 09:04:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
DROP TABLE [dbo].[State]
GO
/****** Object:  Table [dbo].[State]    Script Date: 10/21/2010 09:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[State](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Abbreviation] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Display] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[State] ON
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (1, N'01', N'AL', N'Alabama', N'Alabama')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (2, N'02', N'AK', N'Alaska', N'Alaska')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (3, N'04', N'AZ', N'Arizona', N'Arizona')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (4, N'05', N'AR', N'Arkansas', N'Arkansas')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (5, N'06', N'CA', N'California', N'California')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (6, N'08', N'CO', N'Colorado', N'Colorado')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (7, N'09', N'CT', N'Connecticut', N'Connecticut')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (8, N'10', N'DE', N'Delaware', N'Delaware')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (9, N'11', N'DC', N'District of Columbia', N'District of Columbia')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (10, N'12', N'FL', N'Florida', N'Florida')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (11, N'13', N'GA', N'Georgia', N'Georgia')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (12, N'15', N'HI', N'Hawaii', N'Hawaii')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (13, N'16', N'ID', N'Idaho', N'Idaho')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (14, N'17', N'IL', N'Illinois', N'Illinois')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (15, N'18', N'IN', N'Indiana', N'Indiana')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (16, N'19', N'IA', N'Iowa', N'Iowa')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (17, N'20', N'KS', N'Kansas', N'Kansas')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (18, N'21', N'KY', N'Kentucky', N'Kentucky')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (19, N'22', N'LA', N'Louisiana', N'Louisiana')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (20, N'23', N'ME', N'Maine', N'Maine')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (21, N'24', N'MD', N'Maryland', N'Maryland')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (22, N'25', N'MA', N'Massachusetts', N'Massachusetts')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (23, N'26', N'MI', N'Michigan', N'Michigan')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (24, N'27', N'MN', N'Minnesota', N'Minnesota')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (25, N'28', N'MS', N'Mississippi', N'Mississippi')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (26, N'29', N'MO', N'Missouri', N'Missouri')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (27, N'30', N'MT', N'Montana', N'Montana')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (28, N'31', N'NE', N'Nebraska', N'Nebraska')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (29, N'32', N'NV', N'Nevada', N'Nevada')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (30, N'33', N'NH', N'New Hampshire', N'New Hampshire')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (31, N'34', N'NJ', N'New Jersey', N'New Jersey')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (32, N'35', N'NM', N'New Mexico', N'New Mexico')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (33, N'36', N'NY', N'New York', N'New York')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (34, N'37', N'NC', N'North Carolina', N'North Carolina')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (35, N'38', N'ND', N'North Dakota', N'North Dakota')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (36, N'39', N'OH', N'Ohio', N'Ohio')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (37, N'40', N'OK', N'Oklahoma', N'Oklahoma')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (38, N'41', N'OR', N'Oregon', N'Oregon')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (39, N'42', N'PA', N'Pennsylvania', N'Pennsylvania')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (40, N'44', N'RI', N'Rhode Island', N'Rhode Island')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (41, N'45', N'SC', N'South Carolina', N'South Carolina')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (42, N'46', N'SD', N'South Dakota', N'South Dakota')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (43, N'47', N'TN', N'Tennessee', N'Tennessee')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (44, N'48', N'TX', N'Texas', N'Texas')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (45, N'49', N'UT', N'Utah', N'Utah')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (46, N'50', N'VT', N'Vermont', N'Vermont')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (47, N'51', N'VA', N'Virginia', N'Virginia')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (48, N'53', N'WA', N'Washington', N'Washington')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (49, N'54', N'WV', N'West Virginia', N'West Virginia')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (50, N'55', N'WI', N'Wisconsin', N'Wisconsin')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (51, N'56', N'WY', N'Wyoming', N'Wyoming')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (52, N'60', N'AS', N'American Samoa', N'American Samoa')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (53, N'64', N'FM', N'Federated States of Micronesia', N'Micronesia')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (54, N'66', N'GU', N'Guam', N'Guam')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (55, N'68', N'MH', N'Marshall Islands', N'Marshall Islands')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (56, N'69', N'MP', N'Northern Mariana Islands', N'Mariana Islands')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (57, N'70', N'PW', N'Palau', N'Palau')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (58, N'72', N'PR', N'Puerto Rico', N'Puerto Rico')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (59, N'74', N'UM', N'U.S. Minor Outlying Islands', N'Outlying Islands')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (60, N'78', N'VI', N'Virgin Islands of the U.S.', N'Virgin Islands')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (61, N'79', N'AB', N'Alberta', N'Alberta')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (62, N'80', N'BC', N'British Columbia', N'British Columbia')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (63, N'81', N'MB', N'Manitoba', N'Manitoba')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (64, N'82', N'NL', N'Newfoundland and Labrador', N'Newfoundland')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (65, N'83', N'NT', N'Northwest Territories', N'Northwest Territories')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (66, N'84', N'NS', N'Nunavut', N'Nunavut')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (67, N'85', N'ON', N'Ontario', N'Ontario')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (68, N'86', N'PE', N'Prince Edward Island', N'Prince Edward Island')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (69, N'87', N'QC', N'Quebec', N'Quebec')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (70, N'88', N'SK', N'Saskatchewan', N'Saskatchewan')
INSERT [dbo].[State] ([ID], [Code], [Abbreviation], [Name], [Display]) VALUES (71, N'89', N'YT', N'Yukon', N'Yukon')
SET IDENTITY_INSERT [dbo].[State] OFF
/****** Object:  Table [dbo].[ContactType]    Script Date: 10/21/2010 09:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ContactType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[ContactType] ON
INSERT [dbo].[ContactType] ([ID], [Label]) VALUES (1, N'Sales Rep')
INSERT [dbo].[ContactType] ([ID], [Label]) VALUES (2, N'Business Location')
SET IDENTITY_INSERT [dbo].[ContactType] OFF
/****** Object:  Table [dbo].[Company]    Script Date: 10/21/2010 09:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Company]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Address] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[City] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StateID] [int] NOT NULL,
	[Zip] [varchar](9) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 10/21/2010 09:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Address] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StateID] [int] NULL,
	[Zip] [varchar](9) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[CompanyContact]    Script Date: 10/21/2010 09:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyContact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CompanyContact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ContactID] [int] NOT NULL,
	[ContactTypeID] [int] NOT NULL,
 CONSTRAINT [PK_CompanyContact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  ForeignKey [FK_Company_State]    Script Date: 10/21/2010 09:04:03 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_State]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_State]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_State]
GO
/****** Object:  ForeignKey [FK_CompanyContact_Company]    Script Date: 10/21/2010 09:04:03 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_Company]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact]  WITH CHECK ADD  CONSTRAINT [FK_CompanyContact_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_Company]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact] CHECK CONSTRAINT [FK_CompanyContact_Company]
GO
/****** Object:  ForeignKey [FK_CompanyContact_Contact]    Script Date: 10/21/2010 09:04:03 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_Contact]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact]  WITH CHECK ADD  CONSTRAINT [FK_CompanyContact_Contact] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Contact] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_Contact]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact] CHECK CONSTRAINT [FK_CompanyContact_Contact]
GO
/****** Object:  ForeignKey [FK_CompanyContact_ContactType]    Script Date: 10/21/2010 09:04:03 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_ContactType]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact]  WITH CHECK ADD  CONSTRAINT [FK_CompanyContact_ContactType] FOREIGN KEY([ContactTypeID])
REFERENCES [dbo].[ContactType] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CompanyContact_ContactType]') AND parent_object_id = OBJECT_ID(N'[dbo].[CompanyContact]'))
ALTER TABLE [dbo].[CompanyContact] CHECK CONSTRAINT [FK_CompanyContact_ContactType]
GO
/****** Object:  ForeignKey [FK_Contact_State]    Script Date: 10/21/2010 09:04:03 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contact_State]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contact]'))
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contact_State]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contact]'))
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_State]
GO
