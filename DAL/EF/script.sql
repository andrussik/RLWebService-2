BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210415205921_LibraryStatusDefault', N'5.0.5');
GO

COMMIT;
GO

