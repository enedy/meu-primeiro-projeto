IF OBJECT_ID(N'[migration-history]') IS NULL
BEGIN
    CREATE TABLE [migration-history] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK_migration-history] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [User] (
    [Id] uniqueidentifier NOT NULL,
    [Name] VARCHAR(100) NULL,
    [EmailAdress] VARCHAR(50) NULL,
    [Number] VARCHAR(14) NULL,
    [DocumentType] int NULL,
    [Status] INT NOT NULL,
    [Password] VARCHAR(50) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [idx_user_name] ON [User] ([Name]);
GO

CREATE INDEX [idx_user_name_status] ON [User] ([Name], [Status]);
GO

CREATE INDEX [IX_User_Number] ON [User] ([Number]);
GO

INSERT INTO [migration-history] ([MigrationId], [ProductVersion])
VALUES (N'20210127001332_FirstMigration', N'5.0.2');
GO

COMMIT;
GO

