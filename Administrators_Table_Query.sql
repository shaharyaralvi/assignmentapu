DROP TABLE Administrators

CREATE TABLE [dbo].[Administrators] (
    [Id]   INT NOT NULL IDENTITY,
    [Name] NVARCHAR (50) NOT NULL,
	[Address]     NVARCHAR (50) NOT NULL,
    [PhoneNumber] NVARCHAR (50) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    [UserId]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Administrators_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
);

SET IDENTITY_INSERT [dbo].[Administrators] ON
INSERT INTO [dbo].[Administrators] ([Id], [Name], [Address], [PhoneNumber], [Email], [UserId]) VALUES (1, N'Max', N'456 Main Street
', N'148029386
', N'maxwell.maxwell@2434gmail.com
', 3)
INSERT INTO [dbo].[Administrators] ([Id], [Name], [Address], [PhoneNumber], [Email], [UserId]) VALUES (2, N'John Doe', N'123 Main Street
', N'141312112
', N'john@example.com
', 4)
SET IDENTITY_INSERT [dbo].[Administrators] OFF

SELECT * FROM Administrators