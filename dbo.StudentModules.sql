CREATE TABLE [dbo].[StudentModules] (
    [StudentId] INT           NOT NULL,
    [ModuleId]  INT           NOT NULL,
    [Level]     NVARCHAR (50) NULL,
    [ClassId]   INT           NULL,
	[PaymentStatus] NVARCHAR(50) NULL, 
    [EnrollmentDate] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_StudentModules_Students] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]),
    CONSTRAINT [FK_StudentModules_Modules] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[Modules] ([Id])
);

