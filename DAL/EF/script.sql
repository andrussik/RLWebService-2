BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210419202816_BaseEntityDefaultValues', N'5.0.5');
GO

COMMIT;
GO

