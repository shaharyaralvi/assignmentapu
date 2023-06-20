DROP TABLE Modules

CREATE TABLE [dbo].[Modules] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);


SET IDENTITY_INSERT [dbo].[Modules] ON
INSERT INTO [dbo].[Modules] ([Id], [Name]) VALUES (1, N'C#')
INSERT INTO [dbo].[Modules] ([Id], [Name]) VALUES (2, N'C#')
INSERT INTO [dbo].[Modules] ([Id], [Name]) VALUES (3, N'C#')
INSERT INTO [dbo].[Modules] ([Id], [Name]) VALUES (4, N'Java')
INSERT INTO [dbo].[Modules] ([Id], [Name]) VALUES (5, N'Java')
INSERT INTO [dbo].[Modules] ([Id], [Name]) VALUES (6, N'Java')
SET IDENTITY_INSERT [dbo].[Modules] OFF

SELECT * FROM Modules
