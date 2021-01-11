CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[Nom] nvarchar(250) NOT NULL,
	[Prenom] nvarchar(250) NOT NULL,
	[DateNaissance] date NOT NULL,
	[Login] nvarchar(320) NOT NULL,
	[Password] nvarchar(Max) NOT NULL
)
