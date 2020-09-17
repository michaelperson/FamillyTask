CREATE TABLE [dbo].[Membre]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	Prenom NVARCHAR(250) NOT NULL,
	DateNaissance Date NOT NULL,
	Gsm nvarchar(10) not null
)
