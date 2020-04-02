create database MusicoDB
Go

use MusicoDB
Go

SET DATEFORMAT dmy
Go

IF OBJECT_ID('UserDetails')  IS NOT NULL
DROP TABLE UserDetails
GO
IF OBJECT_ID('UserRating')  IS NOT NULL
DROP TABLE UserRating
GO
IF OBJECT_ID('Songs')  IS NOT NULL
DROP TABLE Songs
GO
IF OBJECT_ID('Artists')  IS NOT NULL
DROP TABLE Artists
GO
IF OBJECT_ID('SongArtistRelation')  IS NOT NULL
DROP TABLE SongArtistRelation
GO

IF OBJECT_ID('ufn_TopTenSongDetails')  IS NOT NULL
DROP FUNCTION ufn_TopTenSongDetails
GO

IF OBJECT_ID('ufn_TopTenArtistDetails')  IS NOT NULL
DROP FUNCTION ufn_TopTenArtistDetails
GO

IF OBJECT_ID('ufn_GetArtistsOfSong')  IS NOT NULL
DROP FUNCTION ufn_GetArtistsOfSong
GO

IF OBJECT_ID('usp_UpdateRating')  IS NOT NULL
DROP PROCEDURE usp_UpdateRating
GO


IF OBJECT_ID('usp_AddSong')  IS NOT NULL
DROP PROCEDURE usp_AddSong
GO

IF OBJECT_ID('usp_SongArtistRelation')  IS NOT NULL
DROP PROCEDURE usp_SongArtistRelation
GO

create table UserDetails(
userid numeric identity(1000,1) primary key,
email varchar(200) unique,
[name] varchar(200),
[password] varchar(100)
);
Go

create table Songs(
SongId numeric identity(10002,1) primary key,
SongName varchar(200),
DateOfRelease date,
AverageRating float,
ImageCoverLocation varchar(500)
);
Go

create table Artists (
ArtistId numeric identity(100,1) primary key,
ArtistName varchar(200),
DateOfBirth date,
Bio Varchar(1000)
);
Go

create table UserRating(
sno numeric primary key identity(1,1),
userid numeric references UserDetails(userid),
SongId numeric references Songs(SongId)
);
Go

create table SongArtistRelation(
SongId numeric references Songs(SongId),
ArtistId numeric references Artists(ArtistId),
primary key(SongId,ArtistId)
);
Go


insert into UserDetails values ('abc@abc.com','abc_xyz','abc123')
Go


insert into Songs values ('shape of you','6-01-2017',4.7,'later')
insert into Songs values ('rockstar','15-07-2017',4.4,'later')
insert into Songs values ('one dance','5-04-2016',4.4,'later')
insert into Songs values ('closer','29-07-2016',4.8,'later')
insert into Songs values ('thinking out loud','20-06-2014',4.1,'later')
insert into Songs values ('sunflower','18-10-2018',4.2,'later')
insert into Songs values ('havana','3-08-2017',4.6,'later')
insert into Songs values ('perfect','3-03-2017',4.2,'later')
insert into Songs values ('love yourself','9-11-2015',4.1,'later')
insert into Songs values ('lean on','2-03-2015',4.5,'later')
Go


insert into Artists values ('ed sheeran','2/01/1983','later')
insert into Artists values ('post malone','2/01/1983','later')
insert into Artists values ('21 savage','2/01/1983','later')
insert into Artists values ('drake','2/01/1983','later')
insert into Artists values ('wizkid','2/01/1983','later')
insert into Artists values ('kyla','2/01/1983','later')
insert into Artists values ('the chainsmokers','2/01/1983','later')
insert into Artists values ('halsey','2/01/1983','later')
insert into Artists values ('swae lee','2/01/1983','later')
insert into Artists values ('camila cabello','2/01/1983','later')
insert into Artists values ('young thug','2/01/1983','later')
insert into Artists values ('justin bieber','2/01/1983','later')
insert into Artists values ('major lazor','2/01/1983','later')
insert into Artists values ('dj snake','2/01/1983','later')
Go

insert into SongArtistRelation values (10002,100)
insert into SongArtistRelation values (10003,101)
insert into SongArtistRelation values (10003,102)
insert into SongArtistRelation values (10004,103)
insert into SongArtistRelation values (10004,104)
insert into SongArtistRelation values (10004,105)
insert into SongArtistRelation values (10005,106)
insert into SongArtistRelation values (10005,107)
insert into SongArtistRelation values (10006,100)
insert into SongArtistRelation values (10007,101)
insert into SongArtistRelation values (10007,108)
insert into SongArtistRelation values (10008,109)
insert into SongArtistRelation values (10009,100)
insert into SongArtistRelation values (10010,111)
insert into SongArtistRelation values (10011,112)
insert into SongArtistRelation values (10011,113)
Go

CREATE FUNCTION ufn_TopTenSongDetails()
RETURNS TABLE 
AS
	 RETURN (SELECT Top 10 * FROM Songs order by AverageRating desc)
GO 


CREATE FUNCTION ufn_TopTenArtistDetails()
RETURNS TABLE 
AS
	 RETURN (SELECT Top 10 a.ArtistId,a.ArtistName,a.DateOfBirth,AverageRating FROM Artists a join 
	 SongArtistRelation sa on a.ArtistId = sa.ArtistId join Songs s on sa.SongId = s.SongId order by s.AverageRating desc)
GO 

CREATE FUNCTION ufn_GetArtistsOfSong
(
@SongId numeric 
)
RETURNS TABLE 
AS
	 RETURN (SELECT a.ArtistId,a.ArtistName FROM Artists a join 
	 SongArtistRelation sa on a.ArtistId = sa.ArtistId where SongId = @SongId)
GO 


CREATE PROCEDURE usp_UpdateRating
(
	@email VARCHAR(200),
    @SongId numeric,
	@rating float
)
AS
BEGIN
	DECLARE @userid numeric
	BEGIN TRY
		Select @userid = userid from UserDetails where email = @email
		INSERT INTO UserRating VALUES (@userid,@SongId)
		UPDATE Songs set AverageRating = (AverageRating+@rating)/2 where SongId = @SongId 
		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN -99
	END CATCH
END
GO

CREATE PROCEDURE usp_AddSong
(
	@SongName VARCHAR(200),
    @DateOfRelease date,
	@AverageRating float,
	@ImagecoverLocation varchar(500)
)
AS
BEGIN
		DECLARE @id numeric			
		BEGIN TRY
		INSERT INTO Songs VALUES (@SongName,@DateOfRelease,@AverageRating,@ImagecoverLocation)
		select @id = SongId from Songs where SongName = @SongName AND DateOfRelease = @DateOfRelease
		RETURN @id
	END TRY
	BEGIN CATCH
		RETURN -99
	END CATCH
END
GO

CREATE PROCEDURE usp_SongArtistRelation
(
	@SongId numeric,
    @ArtistId numeric
	
)
AS
BEGIN
	BEGIN TRY
		INSERT INTO SongArtistRelation values (@SongId,@ArtistId)	
		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN -99
	END CATCH
END
GO

