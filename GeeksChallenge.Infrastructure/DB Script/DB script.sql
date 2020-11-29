IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [CloudProviders] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_CloudProviders] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Services] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Infrastructures] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(400) NULL,
    [CloudProviderId] int NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_Infrastructures] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Infrastructures_CloudProviders_CloudProviderId] FOREIGN KEY ([CloudProviderId]) REFERENCES [CloudProviders] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ServiceOptions] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [ServiceId] int NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_ServiceOptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ServiceOptions_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [InfrastructureResource] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [InfrastructureId] int NOT NULL,
    [ServiceId] int NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_InfrastructureResource] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InfrastructureResource_Infrastructures_InfrastructureId] FOREIGN KEY ([InfrastructureId]) REFERENCES [Infrastructures] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_InfrastructureResource_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OptionDefaultValues] (
    [Id] int NOT NULL IDENTITY,
    [OptionValue] nvarchar(max) NULL,
    [ServiceOptionId] int NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_OptionDefaultValues] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OptionDefaultValues_ServiceOptions_ServiceOptionId] FOREIGN KEY ([ServiceOptionId]) REFERENCES [ServiceOptions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [InfrastructureResourceOptions] (
    [Id] int NOT NULL IDENTITY,
    [Value] nvarchar(max) NULL,
    [InfrastructureResourceId] int NOT NULL,
    [ServiceOptionId] int NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedById] int NULL,
    [DeletedById] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [DeletedDate] datetime2 NULL,
    CONSTRAINT [PK_InfrastructureResourceOptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InfrastructureResourceOptions_InfrastructureResource_InfrastructureResourceId] FOREIGN KEY ([InfrastructureResourceId]) REFERENCES [InfrastructureResource] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_InfrastructureResourceOptions_ServiceOptions_ServiceOptionId] FOREIGN KEY ([ServiceOptionId]) REFERENCES [ServiceOptions] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[CloudProviders]'))
    SET IDENTITY_INSERT [CloudProviders] ON;
INSERT INTO [CloudProviders] ([Id], [CreatedById], [CreatedDate], [DeletedById], [DeletedDate], [Name], [UpdatedById], [UpdatedDate])
VALUES (1, -1, '2020-11-29T19:32:37.6231287+02:00', NULL, NULL, N'IGS', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[CloudProviders]'))
    SET IDENTITY_INSERT [CloudProviders] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Services]'))
    SET IDENTITY_INSERT [Services] ON;
INSERT INTO [Services] ([Id], [CreatedById], [CreatedDate], [DeletedById], [DeletedDate], [Name], [UpdatedById], [UpdatedDate])
VALUES (1, -1, '2020-11-29T19:32:37.6260778+02:00', NULL, NULL, N'Virtual Machines', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Services]'))
    SET IDENTITY_INSERT [Services] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Services]'))
    SET IDENTITY_INSERT [Services] ON;
INSERT INTO [Services] ([Id], [CreatedById], [CreatedDate], [DeletedById], [DeletedDate], [Name], [UpdatedById], [UpdatedDate])
VALUES (2, -1, '2020-11-29T19:32:37.6260854+02:00', NULL, NULL, N'Database Servers', NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Services]'))
    SET IDENTITY_INSERT [Services] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'ServiceId', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[ServiceOptions]'))
    SET IDENTITY_INSERT [ServiceOptions] ON;
INSERT INTO [ServiceOptions] ([Id], [CreatedById], [CreatedDate], [DeletedById], [DeletedDate], [Name], [ServiceId], [UpdatedById], [UpdatedDate])
VALUES (1, -1, '2020-11-29T19:32:37.6266762+02:00', NULL, NULL, N'Operating System', 1, NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'ServiceId', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[ServiceOptions]'))
    SET IDENTITY_INSERT [ServiceOptions] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'ServiceId', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[ServiceOptions]'))
    SET IDENTITY_INSERT [ServiceOptions] ON;
INSERT INTO [ServiceOptions] ([Id], [CreatedById], [CreatedDate], [DeletedById], [DeletedDate], [Name], [ServiceId], [UpdatedById], [UpdatedDate])
VALUES (2, -1, '2020-11-29T19:32:37.6266847+02:00', NULL, NULL, N'Database Engine', 2, NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'Name', N'ServiceId', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[ServiceOptions]'))
    SET IDENTITY_INSERT [ServiceOptions] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'OptionValue', N'ServiceOptionId', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[OptionDefaultValues]'))
    SET IDENTITY_INSERT [OptionDefaultValues] ON;
INSERT INTO [OptionDefaultValues] ([Id], [CreatedById], [CreatedDate], [DeletedById], [DeletedDate], [OptionValue], [ServiceOptionId], [UpdatedById], [UpdatedDate])
VALUES (1, -1, '2020-11-29T19:32:37.6271427+02:00', NULL, NULL, N'Windows', 1, NULL, NULL),
(2, -1, '2020-11-29T19:32:37.6271488+02:00', NULL, NULL, N'Linux', 1, NULL, NULL),
(3, -1, '2020-11-29T19:32:37.6271490+02:00', NULL, NULL, N'MySQL ', 2, NULL, NULL),
(4, -1, '2020-11-29T19:32:37.6271491+02:00', NULL, NULL, N' SQL Server ', 2, NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedById', N'CreatedDate', N'DeletedById', N'DeletedDate', N'OptionValue', N'ServiceOptionId', N'UpdatedById', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[OptionDefaultValues]'))
    SET IDENTITY_INSERT [OptionDefaultValues] OFF;
GO

CREATE INDEX [IX_InfrastructureResource_InfrastructureId] ON [InfrastructureResource] ([InfrastructureId]);
GO

CREATE INDEX [IX_InfrastructureResource_ServiceId] ON [InfrastructureResource] ([ServiceId]);
GO

CREATE INDEX [IX_InfrastructureResourceOptions_InfrastructureResourceId] ON [InfrastructureResourceOptions] ([InfrastructureResourceId]);
GO

CREATE INDEX [IX_InfrastructureResourceOptions_ServiceOptionId] ON [InfrastructureResourceOptions] ([ServiceOptionId]);
GO

CREATE INDEX [IX_Infrastructures_CloudProviderId] ON [Infrastructures] ([CloudProviderId]);
GO

CREATE INDEX [IX_OptionDefaultValues_ServiceOptionId] ON [OptionDefaultValues] ([ServiceOptionId]);
GO

CREATE INDEX [IX_ServiceOptions_ServiceId] ON [ServiceOptions] ([ServiceId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201129173238_InitialMigration', N'5.0.0');
GO

COMMIT;
GO

