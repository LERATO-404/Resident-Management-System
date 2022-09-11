DROP TABLE [dbo].[users]
DROP TABLE [dbo].[students]
DROP TABLE [dbo].[workers]
DROP TABLE [dbo].[rooms]
DROP TABLE [dbo].[reservations]
DROP TABLE [dbo].[activityParticipation]
DROP DATABASE [ResidenceManagemenSystemDB]

USE [master]
GO
CREATE DATABASE [ResidenceManagemenSystemDB]
    CONTAINMENT = NONE
    ON  PRIMARY 
    ( NAME = N'ResidenceManagemenSystemDB', FILENAME = N'C:\Users\LAVAS\Desktop\Test DB\ResidenceManagemenSystemDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
     LOG ON 
    ( NAME = N'ResidenceManagemenSystemDB_Log', FILENAME = N'C:\Users\LAVAS\Desktop\Test DB\ResidenceManagemenSystemDB_Log.Idf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
USE [ResidenceManagemenSystemDB]
GO

CREATE TABLE [dbo].[users] (
    [userId]       INT           IDENTITY (1, 1) NOT NULL,
    [firstName]    NVARCHAR (50) NOT NULL,
    [lastName]     NVARCHAR (50) NOT NULL,
    [emailAddress] NVARCHAR (50) NOT NULL,
    [phoneNumber]  NVARCHAR (50) NOT NULL,
    [dOB]          DATE          NULL,
    [jobTitle]     NVARCHAR (40) NULL,
    [jobType]      NVARCHAR (40) NULL,
    [username]     NVARCHAR (50) NOT NULL,
    [password]     NVARCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([userId] ASC),
    UNIQUE NONCLUSTERED ([username] ASC),
    CHECK ([jobTitle]='Full-Time' OR [jobTitle]='Part-Time' OR [jobTitle]='Temporary' OR [jobTitle]='Volunteer' OR [jobTitle]='Guest'),
    CHECK ([jobType]='Residence-Manager' OR [jobType]='Room-Controller' OR [jobType]='Activity-Controller' OR [jobType]='Administrator' OR [jobType ]='Guest')
);


CREATE TABLE [dbo].[students] (
    [studentId]          INT           IDENTITY (1, 1) NOT NULL,
    [firstName]          NVARCHAR (50) NOT NULL,
    [lastName]           NVARCHAR (50) NOT NULL,
    [emailAddress]       NVARCHAR (50) NOT NULL,
    [phoneNumber]        NVARCHAR (50) NOT NULL,
    [gender]             NVARCHAR (10) NOT NULL,
    [dOB]                DATE          NOT NULL,
    [nextOfKinFullName]  NVARCHAR (30) NULL,
    [nextOfKinPhone]     NVARCHAR (30) NULL,
    [studentNo]          NVARCHAR (8)  NOT NULL,
    [studentType]        NVARCHAR (30) NULL,
    [courseName]         NVARCHAR (30) NULL,
    [registrationStatus] NVARCHAR (30) NULL,
    [addedBy]            INT           NULL,
    PRIMARY KEY CLUSTERED ([studentId] ASC),
    FOREIGN KEY ([addedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([registrationStatus]='Active' OR [registrationStatus]='Not-Active'),
    CHECK ([gender]='Male' OR [gender]='Female'),
    CHECK ([studentType]='Freshmen' OR [studentType]='Sophomore' OR [studentType]='Junior' OR [studentType]='Senior')
);


CREATE TABLE [dbo].[workers] (
    [workerId]     INT           IDENTITY (1, 1) NOT NULL,
    [firstName]    NVARCHAR (50) NOT NULL,
    [lastName]     NVARCHAR (50) NOT NULL,
    [emailAddress] NVARCHAR (50) NOT NULL,
    [phoneNumber]  NVARCHAR (50) NOT NULL,
    [dOB]          DATE          NULL,
    [gender]       NVARCHAR (10) NULL,
    [jobTitle]     NVARCHAR (30) NULL,
    [jobType]      NVARCHAR (30) NULL,
    [startDate]    DATE          NULL,
    [addedBy]      INT           NULL,
    PRIMARY KEY CLUSTERED ([workerId] ASC),
    FOREIGN KEY ([addedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([jobType]='Security' OR [jobType]='Residence-Receptionist' OR [jobType]='Garden-Manager' OR [jobType]='Gardener' OR [jobType]='Cleaning-Manager' OR [jobType]='Residence-housekeeper' OR [jobType]='Parking-attendant'),
    CHECK ([jobTitle]='Full-Time' OR [jobTitle]='Part-Time' OR [jobTitle]='Temporary' OR [jobTitle]='Volunteer'),
    CHECK ([gender]='Male' OR [gender]='Female')
);


CREATE TABLE [dbo].[rooms] (
    [roomId]           INT           IDENTITY (1, 1) NOT NULL,
    [roomSymbolCode]   NVARCHAR (10) NOT NULL,
    [roomFloor]        NVARCHAR (15) NOT NULL,
    [roomType]         NVARCHAR (15) NOT NULL,
    [roomAvailability] NVARCHAR (30) NOT NULL,
    [addedBy]          INT           NULL,
    PRIMARY KEY CLUSTERED ([roomId] ASC),
    UNIQUE NONCLUSTERED ([roomSymbolCode] ASC),
    FOREIGN KEY ([addedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([roomAvailability]='Available' OR [roomAvailability]='Not-Available'),
    CHECK ([roomType]='Single' OR [roomType]='Shared'),
    CHECK ([roomFloor]='Floor-1' OR [roomFloor]='Floor-2' OR [roomFloor]='Floor-3' OR [roomFloor]='Floor-4')
);


CREATE TABLE [dbo].[reservations] (
    [reservationId]    INT           IDENTITY (1, 1) NOT NULL,
    [studentId]        INT           NOT NULL,
    [roomId]           INT           NOT NULL,
    [reservedBy]       INT           NULL,
    [bedAndChairUsage] NVARCHAR (15) NOT NULL,
    [recessStatus]     NVARCHAR (50) NOT NULL,
    [dateReserved]     DATE          NOT NULL,
    [MovedInDate]      DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([reservationId] ASC),
    FOREIGN KEY ([roomId]) REFERENCES [dbo].[rooms] ([roomId]),
    FOREIGN KEY ([reservedBy]) REFERENCES [dbo].[users] ([userId]),
    FOREIGN KEY ([studentId]) REFERENCES [dbo].[students] ([studentId]),
    CHECK ([recessStatus]='staying' OR [recessStatus]='leaving' OR [recessStatus]='not-sure'),
    CHECK ([bedAndChairUsage]='R:Bed-Chair' OR [bedAndChairUsage]='S:Bed-Chair' OR [bedAndChairUsage]='R:Bed-S:Chair' OR [bedAndChairUsage]='R:Chair-S:Bed')
);


CREATE TABLE [dbo].[activityParticipation] (
    [activityId]            INT           IDENTITY (1, 1) NOT NULL,
    [studentParticipant]    INT           NOT NULL,
    [semesterParticipating] NVARCHAR (20) NOT NULL,
    [totalPoints]           INT           NOT NULL,
    [allocatedDate]         DATE          NOT NULL,
    [addedBy]               INT           NULL,
    PRIMARY KEY CLUSTERED ([activityId] ASC),
    FOREIGN KEY ([studentParticipant]) REFERENCES [dbo].[students] ([studentId]),
    FOREIGN KEY ([addedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([semesterParticipating]='First-Semester' OR [semesterParticipating]='Second-Semester' OR [semesterParticipating]='Both-Semesters')
);




CREATE TABLE [dbo].[points] (
    [pointsId]    INT IDENTITY (1, 1) NOT NULL,
    [studentId]   INT NOT NULL,
    [totalPoints] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([pointsId] ASC),
    FOREIGN KEY ([studentId]) REFERENCES [dbo].[students] ([studentId])
);



