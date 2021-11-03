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

CREATE TABLE [Rankings] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [UserSentPointId] uniqueidentifier NOT NULL,
    [Point] int NOT NULL,
    [TopicId] uniqueidentifier NOT NULL,
    [CommentId] int NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Rankings] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Sections] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    CONSTRAINT [PK_Sections] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [IdentityId] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Avatar] varchar(100) NULL,
    [UserTypeId] int NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [LastActivity] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Topics] (
    [Id] uniqueidentifier NOT NULL,
    [Title] varchar(100) NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Topics] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Topics_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Comments] (
    [Id] uniqueidentifier NOT NULL,
    [Text] varchar(max) NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [TopicId] uniqueidentifier NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [CommentId] int NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Topics_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [Topics] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Comments_TopicId] ON [Comments] ([TopicId]);
GO

CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
GO

CREATE INDEX [IX_Topics_UserId] ON [Topics] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211101013658_InitialCreate', N'5.0.11');
GO

COMMIT;
GO

