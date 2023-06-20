DROP TABLE Module_Class_Trainer

CREATE TABLE [dbo].[Module_Class_Trainer] (
    [ModuleId]         INT       NOT NULL,
    [ClassId]     INT           NOT NULL,
    [TrainerId]   INT           NOT NULL,
    CONSTRAINT [FK_Modules_Class_Trainer_Modules] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id]),
    CONSTRAINT [FK_Modules_Class_Trainer_Trainers] FOREIGN KEY ([TrainerId]) REFERENCES [dbo].[Trainers] ([Id]),
    CONSTRAINT [FK_Modules_Class_Trainer_Classes] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Classes] ([Id])
);

INSERT INTO [dbo].[Module_Class_Trainer] ([ModuleId], [ClassId], [TrainerId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[Module_Class_Trainer] ([ModuleId], [ClassId], [TrainerId]) VALUES (1, 2, 2)
INSERT INTO [dbo].[Module_Class_Trainer] ([ModuleId], [ClassId], [TrainerId]) VALUES (1, 3, 1)
INSERT INTO [dbo].[Module_Class_Trainer] ([ModuleId], [ClassId], [TrainerId]) VALUES (2, 1, 2)
INSERT INTO [dbo].[Module_Class_Trainer] ([ModuleId], [ClassId], [TrainerId]) VALUES (2, 2, 2)
INSERT INTO [dbo].[Module_Class_Trainer] ([ModuleId], [ClassId], [TrainerId]) VALUES (2, 3, 1)

