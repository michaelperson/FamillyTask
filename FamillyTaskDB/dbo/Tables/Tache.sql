CREATE TABLE [dbo].[Tache] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Nom]             NVARCHAR (50)  NOT NULL,
    [Description]     NVARCHAR (MAX) NOT NULL,
    [DateCreation]    DATE           NOT NULL,
    [DateFinAttendue] DATE           NOT NULL,
    [DateFinReel]     DATE           NULL,
    [Lieu]            NVARCHAR (50)  NULL,
    [Status]          TINYINT        NULL,
    [IdMembre]        INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tache_Membre] FOREIGN KEY ([IdMembre]) REFERENCES [dbo].[Membre] ([Id])
);


