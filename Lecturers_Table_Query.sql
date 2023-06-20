CREATE TABLE [dbo].[Lecturers]
(
	[Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Address] NVARCHAR (50) NOT NULL,
    [Phone]   NVARCHAR (50) NOT NULL,
    [Email]   NVARCHAR (50) NOT NULL,
    [UserId]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Lecturers_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
)


SET IDENTITY_INSERT [dbo].[Lecturers] ON
INSERT INTO [dbo].[Lecturers] ([Id], [Name], [Address], [Phone], [Email], [UserId]) VALUES (1, N'Emily Wilson
', N'123 Maple Street
', N'23234234234
', N'emily@example.com
', 7)
INSERT INTO [dbo].[Lecturers] ([Id], [Name], [Address], [Phone], [Email], [UserId]) VALUES (2, N'Michael Davis
', N'789 Cedar Avenue
', N'32151491821
', N'Michael@example.com
', 8)
SET IDENTITY_INSERT [dbo].[Lecturers] OFF

SELECT * FROM Lecturers