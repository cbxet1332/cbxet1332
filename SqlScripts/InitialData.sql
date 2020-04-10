USE [cbxet1332]
GO

DELETE FROM [dbo].[Persons];
DELETE FROM [dbo].[Groups];

-- Groups
INSERT INTO [dbo].[Groups]([Name]) VALUES ('Family');
INSERT INTO [dbo].[Groups]([Name]) VALUES ('Friends');
INSERT INTO [dbo].[Groups]([Name]) VALUES ('Teammates');
INSERT INTO [dbo].[Groups]([Name]) VALUES ('Colleagues');
INSERT INTO [dbo].[Groups]([Name]) VALUES ('Associates');

-- Family
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Simon Marc','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Amanda Jane','Calcutt', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Anthony','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Sarah Elizabeth','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joan Evelyn','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joanne','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Rachel August','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Leah Mae','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Hannah Mary','Calcutt', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('James','Leatherdale', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Paul','Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joanna','Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Fiona','Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Sophie','Carter-Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Harry','Carter-Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));

-- Friends
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('James William Edward','Kemp', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Barry','Roach', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Toni','Piccolo', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jeff','Simons', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Colin','McClernon', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('David','Barry', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jeff','Higgs', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jan','Regan', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Brian','Regan', (SELECT Id FROM Groups WHERE [Name]='Friends'));

--Teammates
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Ellis','Smith', (SELECT Id FROM Groups WHERE [Name]='Teammates'));

--Teammates
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Natasha','Hudson', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));

--Associates
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Conail','Gallagher', (SELECT Id FROM Groups WHERE [Name]='Associates'));

SELECT * FROM Groups;
SELECT * FROM Persons;
