CREATE TABLE [dbo].[workers] (
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