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
INSERT INTO [dbo].[Groups]([Name]) VALUES ('World Leaders');
INSERT INTO [dbo].[Groups]([Name]) VALUES ('Guitar Heros');
INSERT INTO [dbo].[Groups]([Name]) VALUES ('Film Stars');

-- Family
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joan Evelyn','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('James Alan','Leatherdale', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Simon Marc','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Amanda Jane','Calcutt', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Rachel August','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Leah Mae','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Hannah Mary','Calcutt', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jay Thomas Riley','Mercer', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Sarah Elizabeth','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Steve','Mitchel', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Anthony','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Laura','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Catherine','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Paul Evelyn','Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joanna Mary','Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Fiona Elizabeth','Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Kevin','Marshal', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Alice Mary','Marshal', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Sophie Amanda','Carter-Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Harry','Carter-Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Hartley','Carter-Cooper', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Philippa Ann','Humphrey', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Michael','Humphrey', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Mathew Andrew Thomas','Humphrey', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joanne','Edwards', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Anne','Barrie', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Kevin','Barrie', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Paul','Barrie', (SELECT Id FROM Groups WHERE [Name]='Family'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jill','Southall', (SELECT Id FROM Groups WHERE [Name]='Friends'));

-- Friends
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('James William Edward','Kemp', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Trudi','Kemp', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Barry','Roach', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Sue','Roach', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Blake','Roach', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Toni','Piccolo', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Colin','McClernon', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Maricar','McClernon', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('David','Barry', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Becky','Barry', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jeff','Higgs', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Linda','Higgs', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Matt','Ward', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jan','Regan', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Brian','Regan', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Graham','Thame', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Anita','Keen', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Samuel','Keen', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jackie Anne','Edwards', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Bob','Edwards', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Alison','Ladoiska', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Rowland Emmanuel','Ladoiska', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Alison','Saving', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Paul','Saving', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Anna Maria Theresa Veronica','Jennings', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Ritchie','Jennings', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Andrew','Booker', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Annette','Booker', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Pete','Mann', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Andrian','Kenny', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Gary','Boardman', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Shirine','Boardman', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Siara','Boardman', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Carol','Singer', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Roger','Singer', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('David','Mercer', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Karen','Wheelan', (SELECT Id FROM Groups WHERE [Name]='Friends'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jason','Morris', (SELECT Id FROM Groups WHERE [Name]='Friends'));

--Teammates
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Ashley','Welch', (SELECT Id FROM Groups WHERE [Name]='Teammates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Ellis','Smith', (SELECT Id FROM Groups WHERE [Name]='Teammates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Maria','Preto', (SELECT Id FROM Groups WHERE [Name]='Teammates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Dimitri','Galejev', (SELECT Id FROM Groups WHERE [Name]='Teammates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Connie','Collins', (SELECT Id FROM Groups WHERE [Name]='Teammates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Ciaran','Robertson', (SELECT Id FROM Groups WHERE [Name]='Teammates'));

--Colleagues
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Michael','Johns', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Natasha','Hudson', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Paul','Barnes', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Deepak','Nawarthe', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Ricky','Peltz', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('James','Chalmers', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Eric','Burchell', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Sukha','Kahlon', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Dev','Kumar', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Dominic','Hyland', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Rob','Snow', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Terry','Lewis', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Dan','Gwalter', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Gary','Sage', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Gary','Millar', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jamie','LeNotre', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Naresh','Varsarni', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Nayab','Khan', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Mic','Adams', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jeff','Simons', (SELECT Id FROM Groups WHERE [Name]='Colleagues'));

--Associates
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Conail','Gallagher', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Khursand','Khan', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Tony','Thacker', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Imogen','Morpeth', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jamie','Peters', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jenny','Murray-Smith', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('John','French', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Karim','Derrick', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Muhammad','Siddiq', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Hugh','Mark', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joe','Bignel', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Ashleigh','Hall', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Amber','Short', (SELECT Id FROM Groups WHERE [Name]='Associates'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Donal','Roughneen', (SELECT Id FROM Groups WHERE [Name]='Associates'));

--World Leaders
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Donal','Trump', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Boris','Johnson', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Angela','Merkel', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Moon','Jae-in', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Xi','Jinping', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jair','Bolsonaro', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Narendra','Modi', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Shinzo','Abe', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Kim','Jong-un', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Imran','Khan', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Emmanuel','Macron', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Mette','Frederiksen', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Leo','Varadkar', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Mark','Rutte', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Vladimir','Putin', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Pedro','Sanchez', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Stefan','Lofven', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Andrés Manuel','López Obrador', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Scott','Morrison', (SELECT Id FROM Groups WHERE [Name]='World Leaders'));

--Guitar Heros
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jimi','Hendrix', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Michael','Schenker', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joe','Bonamassa', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Eric','Clapton', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Jimmy','Page', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Dave','Gilmour', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Steve','Morse', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Randy','Rhoads', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Uli Jon','Roth', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Mike','Oldfield', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Brian','May', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Stevie Ray','Vaughn', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Gary','Moore', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Ritchie','Blackmore', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Steve','Vai', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Rory','Gallagher', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Angus','Young', (SELECT Id FROM Groups WHERE [Name]='Guitar Heros'));

--Film Stars
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Sigourney','Weaver', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Arnold','Schwarzenegger', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Bruce','Willis', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Charlize','Theron', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Will','Smith', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Morgan','Freeman', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Keanu','Reeves', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Dwayne','Johnson', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Samuel L','Jackson', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Judy','Dench', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Helen','Mirren', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Tom','Cruise', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Tom','Holland', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Chris','Hemsworth', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Chris','Pratt', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Chris','Evans', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Scarlett','Johansson', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Josh','Brolin', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Don','Cheadle', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Johnny','Depp', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Idris','Elba', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Denzel','Washington', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Brad','Pitt', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Julia','Roberts', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Halle','Berry', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Joaquin','Phoenix', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Angelina','Jolie', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));
INSERT INTO [dbo].[Persons]([Forenames],[Surname],[GroupId]) VALUES ('Gerard','Butler', (SELECT Id FROM Groups WHERE [Name]='Film Stars'));

--Set created date on Groups
UPDATE Groups SET CreatedUtc = dateadd(day, -10, getutcdate());
SELECT * FROM Groups;

--Randomize the created date on Persons a bit
DECLARE @rdate DATETIME2
DECLARE @startId INT
DECLARE @endId INT

SELECT @startId = MIN(Id) FROM Persons;
SELECT @endId = MAX(Id) FROM Persons;

WHILE @startId <= @endId
BEGIN
	SET @rdate = dateadd(second, rand()*-86400, dateadd(day, rand()*-9, getutcdate()));
	UPDATE Persons SET CreatedUtc = @rdate WHERE Id = @startId;
	SET @startId = @startId + 1;
END
SELECT * FROM Persons;
