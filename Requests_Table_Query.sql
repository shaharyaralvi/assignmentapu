DROP TABLE Requests

CREATE TABLE [dbo].[Requests]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL, 
    [ModuleId] INT NOT NULL, 
	[Level] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Requests_Students] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]),
    CONSTRAINT [FK_Requests_Modules] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id])
)

SET IDENTITY_INSERT [dbo].[Requests] ON
INSERT INTO [dbo].[Requests] ([Id], [StudentId], [ModuleId], [Level]) VALUES (1, 1, 1, N'Intermediate')
SET IDENTITY_INSERT [dbo].[Requests] OFF
