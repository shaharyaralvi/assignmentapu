CREATE TABLE [dbo].[Trainers] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Address] NVARCHAR (50) NOT NULL,
    [Phone]   NVARCHAR (50) NOT NULL,
    [Email]   NVARCHAR (50) NOT NULL,
    [UserId]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Trainers_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

SET IDENTITY_INSERT [dbo].[Trainers] ON
INSERT INTO [dbo].[Trainers] ([Id], [Name], [Address], [Phone], [Email], [UserId]) VALUES (1, N'David
', N'321 Pine Road
', N'4314121242
', N'David@example.com
', 5)
INSERT INTO [dbo].[Trainers] ([Id], [Name], [Address], [Phone], [Email], [UserId]) VALUES (2, N'Sarah johnson
', N'789 Oak Lane
', N'1231231041
', N'Sarah@example.com
', 6)
SET IDENTITY_INSERT [dbo].[Trainers] OFF
