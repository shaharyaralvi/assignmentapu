DROP TABLE Users

CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Role]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Username], [Password]) VALUES (1, N'Student1', N'abcdef')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password]) VALUES (2, N'Student2', N'studentpass')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password]) VALUES (3, N'admin2', N'12345')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password]) VALUES (4, N'admin3', N'password123')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password]) VALUES (5, N'trainer1', N'trainer1')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password]) VALUES (6, N'trainer2', N'abcdef')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password]) VALUES (7, N'lecturer1', N'123456')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password]) VALUES (8, N'lecturer2', N'password123')
SET IDENTITY_INSERT [dbo].[Users] OFF