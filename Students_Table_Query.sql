DROP Table Students

CREATE TABLE [dbo].[Students] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [TP_Number]   NVARCHAR (50) NOT NULL,
    [Address]     NVARCHAR (50) NOT NULL,
    [PhoneNumber] NVARCHAR (50) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    [UserId]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Students_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

SET IDENTITY_INSERT [dbo].[Students] ON
INSERT INTO [dbo].[Students] ([Id], [Name], [TP_Number], [Address], [PhoneNumber], [Email], [UserId]) VALUES (1, N'Amanda Lee
', N'TP067445
', N'198 Elm Street
', N'81983718308
', N'amanda@example.com
', 1)
INSERT INTO [dbo].[Students] ([Id], [Name], [TP_Number], [Address], [PhoneNumber], [Email], [UserId]) VALUES (2, N'Alex Wilson
', N'TP067446
', N'789 Oak Avenue
', N'78912091289
', N'alex@example.com
', 2)
SET IDENTITY_INSERT [dbo].[Students] OFF
