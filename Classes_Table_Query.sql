
CREATE TABLE [dbo].[Classes] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [ModuleId]     INT           NOT NULL,
	[TrainerId]   INT           NOT NULL,
    [ScheduleDay] NVARCHAR (50) NULL,
    [StartHour]   NVARCHAR (50) NULL,
    [EndHour]     NVARCHAR (50) NULL,
    [Level]    NVARCHAR (50) NULL,
    [Fee]      INT           NULL,
    [Duration] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Classes_Modules] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id]),
    CONSTRAINT [FK_Classes_Trainers] FOREIGN KEY ([TrainerId]) REFERENCES [dbo].[Trainers] ([Id]),
);

SET IDENTITY_INSERT [dbo].[Classes] ON
INSERT INTO [dbo].[Classes] ([Id], [ModuleId], [TrainerId], [ScheduleDay], [StartHour], [EndHour], [Level], [Fee], [Duration]) VALUES (1, 1, 1, N'Monday', N'18', N'20', N'Beginner', 300, 3)
INSERT INTO [dbo].[Classes] ([Id], [ModuleId], [TrainerId], [ScheduleDay], [StartHour], [EndHour], [Level], [Fee], [Duration]) VALUES (2, 1, 2, N'Tuesday', N'13', N'15', N'Intermediate', 500, 3)
INSERT INTO [dbo].[Classes] ([Id], [ModuleId], [TrainerId], [ScheduleDay], [StartHour], [EndHour], [Level], [Fee], [Duration]) VALUES (3, 1, 1, N'Wednesday', N'14', N'16', N'Advance', 700, 3)
INSERT INTO [dbo].[Classes] ([Id], [ModuleId], [TrainerId], [ScheduleDay], [StartHour], [EndHour], [Level], [Fee], [Duration]) VALUES (4, 2, 2, N'Monday', N'13', N'15', N'Beginner', 300, 3)
INSERT INTO [dbo].[Classes] ([Id], [ModuleId], [TrainerId], [ScheduleDay], [StartHour], [EndHour], [Level], [Fee], [Duration]) VALUES (5, 2, 2, N'Friday', N'14', N'16', N'Intermediate', 500, 3)
INSERT INTO [dbo].[Classes] ([Id], [ModuleId], [TrainerId], [ScheduleDay], [StartHour], [EndHour], [Level], [Fee], [Duration]) VALUES (6, 2, 1, N'Thursday', N'16', N'18', N'Advance', 700, 3)
SET IDENTITY_INSERT [dbo].[Classes] OFF



