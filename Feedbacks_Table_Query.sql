CREATE TABLE [dbo].[Feedbacks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TrainerId] INT NOT NULL, 
    [AdministratorId] INT NOT NULL, 
    [Feedback] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Feedbacks_Trainers] FOREIGN KEY ([TrainerId]) REFERENCES [dbo].[Trainers] ([Id]),
    CONSTRAINT [FK_Feedbacks_Administrators] FOREIGN KEY ([AdministratorId]) REFERENCES [dbo].[Administrators] ([Id])
)


SET IDENTITY_INSERT [dbo].[Feedbacks] ON
INSERT INTO [dbo].[Feedbacks] ([Id], [TrainerId], [AdministratorId], [Feedback]) VALUES (1, 1, 1, N'"I would like to commend the administration for their support and assistance throughout the training program."
')
INSERT INTO [dbo].[Feedbacks] ([Id], [TrainerId], [AdministratorId], [Feedback]) VALUES (2, 2, 2, N'"I appreciate the prompt response and cooperation from the administration team during the course."
')
INSERT INTO [dbo].[Feedbacks] ([Id], [TrainerId], [AdministratorId], [Feedback]) VALUES (3, 2, 1, N'"The administration''s assistance in managing student enrollment and scheduling has been invaluable."
')
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
