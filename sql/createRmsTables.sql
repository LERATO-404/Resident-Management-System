DROP TABLE [dbo].[users]
DROP TABLE [dbo].[students]
DROP TABLE [8D5901062469E8288D7A18734F03CAA8_SYSTEMS DESIGN\PROJECT\RMS\RESIDENCE-MANAGEMENT-SYSTEM\APP_DATA\RESIDENCEMANAGEMENTSYSTEMDB.MDF].[dbo].[workers]
DROP TABLE [dbo].[rooms]
DROP TABLE [dbo].[reservations]
DROP TABLE [dbo].[activityParticipation]
DROP TABLE [dbo].[points]

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
    CHECK ([jobType]='Residence-Manager' OR [jobType]='Room-Controller' OR [jobType]='Activity-Controller' OR [jobType]='Administrator' OR [jobType ]='Guest'),
    CHECK ([jobTitle]='Full-Time' OR [jobTitle]='Part-Time' OR [jobTitle]='Temporary' OR [jobTitle]='Volunteer' OR [jobTitle]='Guest')
);


CREATE TABLE [dbo].[students] (
    [studentId]         INT           IDENTITY (1, 1) NOT NULL,
    [firstName]         NVARCHAR (50) NOT NULL,
    [lastName]          NVARCHAR (50) NOT NULL,
    [emailAddress]      NVARCHAR (50) NOT NULL,
    [phoneNumber]       NVARCHAR (50) NOT NULL,
    [gender]            NVARCHAR (10) NOT NULL,
    [dOB]               DATE          NOT NULL,
    [nationality]       NVARCHAR (30) NULL,
    [studentType]       NVARCHAR (30) NULL,
    [courseName]        NVARCHAR (30) NULL,
    [nextOfKinFullName] NVARCHAR (30) NULL,
    [nextOfKinPhone]    NVARCHAR (30) NULL,
    [addedBy]           INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([studentId] ASC),
    FOREIGN KEY ([addedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([studentType]='Freshman' OR [studentType]='Sophomore' OR [studentType]='Junior' OR [studentType]='Senior'),
    CHECK ([gender]='Male' OR [gender]='Female')
);

CREATE TABLE [8D5901062469E8288D7A18734F03CAA8_SYSTEMS DESIGN\PROJECT\RMS\RESIDENCE-MANAGEMENT-SYSTEM\APP_DATA\RESIDENCEMANAGEMENTSYSTEMDB.MDF].[dbo].[workers] (
    [workerId]     INT           IDENTITY (1, 1) NOT NULL,
    [firstName]    NVARCHAR (50) NOT NULL,
    [lastName]     NVARCHAR (50) NOT NULL,
    [emailAddress] NVARCHAR (50) NOT NULL,
    [phoneNumber]  NVARCHAR (50) NOT NULL,
    [dOB]          DATE          NULL,
    [gender]       NVARCHAR (10) NULL,
    [jobTitle]     NVARCHAR (10) NULL,
    [jobType]      NVARCHAR (10) NULL,
    [startDate]    DATE          NULL,
    [addedBy]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([workerId] ASC),
    FOREIGN KEY ([addedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([gender]='Male' OR [gender]='Female'),
    CHECK ([jobType]='Security' OR [jobType]='Cleaner' OR [jobType]='Gardener' OR [jobType]='Constructor' OR [jobType]='other'),
    CHECK ([jobTitle]='Full-Time' OR [jobTitle]='Part-Time' OR [jobTitle]='Temporary' OR [jobTitle]='Volunteer' OR [jobTitle]='Guest')
);


CREATE TABLE [dbo].[rooms] (
    [roomID]     INT           IDENTITY (1, 1) NOT NULL,
    [roomFloor]  NVARCHAR (50) NOT NULL,
    [roomType]   NVARCHAR (50) NOT NULL,
    [bedUsed]    NVARCHAR (50) NOT NULL,
    [chairUsed]  NVARCHAR (50) NOT NULL,
    [roomStatus] NVARCHAR (50) NOT NULL,
    [addedBy]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([roomID] ASC),
    FOREIGN KEY ([addedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([RoomFloor]='Floor-1' OR [RoomFloor]='Floor-2' OR [RoomFloor]='Floor-3' OR [RoomFloor]='Floor-4'),
    CHECK ([roomType]='Single' OR [roomType]='Shared'),
    CHECK ([bedUsed]='Residence-Bed' OR [bedUsed ]='Student-Bed'),
    CHECK ([chairUsed]='Residence-Chair' OR [chairUsed]='Student-Chair'),
    CHECK ([roomStatus]='Occupied' OR [roomStatus]='Not-fully-occupied' OR [roomStatus]='Fully-Occupied')
);

CREATE TABLE [dbo].[reservations] (
    [reservationId] INT           IDENTITY (1, 1) NOT NULL,
    [studentId]     INT           NOT NULL,
    [roomId]        INT           NOT NULL,
    [reservedBy]    INT           NOT NULL,
    [recessStatus]  NVARCHAR (50) NOT NULL,
    [gender]        NVARCHAR (50) NOT NULL,
    [dateReserved]  DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([reservationId] ASC),
    FOREIGN KEY ([studentId]) REFERENCES [dbo].[students] ([studentId]),
    FOREIGN KEY ([roomId]) REFERENCES [dbo].[rooms] ([roomID]),
    FOREIGN KEY ([reservedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([recessStatus]='staying' OR [recessStatus]='leaving'),
    CHECK ([gender]='Male' OR [gender]='Female')
);


CREATE TABLE [dbo].[activityParticipation] (
    [activityId]          INT            IDENTITY (1, 1) NOT NULL,
    [activityName]        NVARCHAR (50)  NOT NULL,
    [activityDescription] NVARCHAR (100) NOT NULL,
    [participatingGender] NVARCHAR (10)  NOT NULL,
    [allocatedDate]       DATE           NOT NULL,
    [studentParticipant]  INT            NOT NULL,
    [addedBy]             INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([activityId] ASC),
    FOREIGN KEY ([studentParticipant]) REFERENCES [dbo].[students] ([studentId]),
    FOREIGN KEY ([addedBy]) REFERENCES [dbo].[users] ([userId]),
    CHECK ([participatingGender]='Male' OR [participatingGender]='Female' OR [participatingGender]='Both')
);


CREATE TABLE [dbo].[points] (
    [pointsId]    INT IDENTITY (1, 1) NOT NULL,
    [studentId]   INT NOT NULL,
    [totalPoints] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([pointsId] ASC),
    FOREIGN KEY ([studentId]) REFERENCES [dbo].[students] ([studentId])
);



