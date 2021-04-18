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

CREATE TABLE [Authors] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Libraries] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Code] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Libraries] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [LibraryOpenTimes] (
    [Id] uniqueidentifier NOT NULL,
    [Day] int NOT NULL,
    [From] datetime2 NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_LibraryOpenTimes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Works] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Works] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Publications] (
    [Id] uniqueidentifier NOT NULL,
    [MarcData] nvarchar(max) NOT NULL,
    [Year] int NOT NULL,
    [WorkId] uniqueidentifier NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Publications] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Publications_Works_WorkId] FOREIGN KEY ([WorkId]) REFERENCES [Works] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [WorkAuthors] (
    [Id] uniqueidentifier NOT NULL,
    [WorkId] uniqueidentifier NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_WorkAuthors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkAuthors_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkAuthors_Works_WorkId] FOREIGN KEY ([WorkId]) REFERENCES [Works] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Items] (
    [Id] uniqueidentifier NOT NULL,
    [Code] nvarchar(max) NOT NULL,
    [PublicationId] uniqueidentifier NOT NULL,
    [LibraryId] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Items_Libraries_LibraryId] FOREIGN KEY ([LibraryId]) REFERENCES [Libraries] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Items_Publications_PublicationId] FOREIGN KEY ([PublicationId]) REFERENCES [Publications] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PublicationAuthors] (
    [Id] uniqueidentifier NOT NULL,
    [PublicationId] uniqueidentifier NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_PublicationAuthors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PublicationAuthors_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PublicationAuthors_Publications_PublicationId] FOREIGN KEY ([PublicationId]) REFERENCES [Publications] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PublicationLanguages] (
    [Id] uniqueidentifier NOT NULL,
    [PublicationId] uniqueidentifier NOT NULL,
    [Language] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [DeletedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_PublicationLanguages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PublicationLanguages_Publications_PublicationId] FOREIGN KEY ([PublicationId]) REFERENCES [Publications] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Items_LibraryId] ON [Items] ([LibraryId]);
GO

CREATE INDEX [IX_Items_PublicationId] ON [Items] ([PublicationId]);
GO

CREATE INDEX [IX_PublicationAuthors_AuthorId] ON [PublicationAuthors] ([AuthorId]);
GO

CREATE INDEX [IX_PublicationAuthors_PublicationId] ON [PublicationAuthors] ([PublicationId]);
GO

CREATE INDEX [IX_PublicationLanguages_PublicationId] ON [PublicationLanguages] ([PublicationId]);
GO

CREATE INDEX [IX_Publications_WorkId] ON [Publications] ([WorkId]);
GO

CREATE INDEX [IX_WorkAuthors_AuthorId] ON [WorkAuthors] ([AuthorId]);
GO

CREATE INDEX [IX_WorkAuthors_WorkId] ON [WorkAuthors] ([WorkId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210414221008_InitialCreate', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Libraries]') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Libraries] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Libraries] ALTER COLUMN [Name] nvarchar(255) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Libraries]') AND [c].[name] = N'Code');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Libraries] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Libraries] ALTER COLUMN [Code] nvarchar(255) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Items]') AND [c].[name] = N'Code');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Items] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Items] ALTER COLUMN [Code] nvarchar(255) NOT NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'Name');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Authors] ALTER COLUMN [Name] nvarchar(255) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210414221654_StringMaxLength', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Items] ADD [ItemStatus] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210415202631_ItemStatus', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Works]') AND [c].[name] = N'UpdatedAt');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Works] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Works] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Works]') AND [c].[name] = N'DeletedAt');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Works] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Works] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WorkAuthors]') AND [c].[name] = N'UpdatedAt');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [WorkAuthors] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [WorkAuthors] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WorkAuthors]') AND [c].[name] = N'DeletedAt');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [WorkAuthors] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [WorkAuthors] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Publications]') AND [c].[name] = N'UpdatedAt');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Publications] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Publications] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Publications]') AND [c].[name] = N'DeletedAt');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Publications] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Publications] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicationLanguages]') AND [c].[name] = N'UpdatedAt');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [PublicationLanguages] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [PublicationLanguages] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicationLanguages]') AND [c].[name] = N'DeletedAt');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [PublicationLanguages] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [PublicationLanguages] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicationAuthors]') AND [c].[name] = N'UpdatedAt');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [PublicationAuthors] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [PublicationAuthors] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicationAuthors]') AND [c].[name] = N'DeletedAt');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [PublicationAuthors] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [PublicationAuthors] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LibraryOpenTimes]') AND [c].[name] = N'UpdatedAt');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [LibraryOpenTimes] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [LibraryOpenTimes] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LibraryOpenTimes]') AND [c].[name] = N'DeletedAt');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [LibraryOpenTimes] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [LibraryOpenTimes] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Libraries]') AND [c].[name] = N'UpdatedAt');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Libraries] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [Libraries] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Libraries]') AND [c].[name] = N'DeletedAt');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Libraries] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [Libraries] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Items]') AND [c].[name] = N'UpdatedAt');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Items] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [Items] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Items]') AND [c].[name] = N'DeletedAt');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Items] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [Items] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'UpdatedAt');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [Authors] ALTER COLUMN [UpdatedAt] datetime2 NULL;
GO

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'DeletedAt');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [Authors] ALTER COLUMN [DeletedAt] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210415203314_BaseEntity', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Libraries] ADD [LibraryStatus] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210415203811_LibraryStatus', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210415205921_LibraryStatusDefault', N'5.0.5');
GO

COMMIT;
GO

