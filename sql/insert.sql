/*Insert into [users]*/
INSERT INTO [users](firstName,lastName,emailAddress,phoneNumber,dOB,jobTitle,jobType,username ,password)
VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@dOB,@jobTitle,@jobType,@username ,@password)

/*Insert into [workers]*/
INSERT INTO [workers](firstName,lastName,emailAddress,phoneNumber,dOB,gender,jobTitle,jobType,startDate,addedBy)
                VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@dOB,@gender,@jobTitle,@jobType,@startDate,@addedBy)

/*Insert into [students]*/
INSERT INTO [students](firstName,lastName,emailAddress,phoneNumber,gender,dOB,nextOfKinFullName,nextOfKinPhone,studentNo,studentType,courseName,registrationStatus,addedBy)
            VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@gender,@dOB,@nextOfKinFullName,@nextOfKinPhone,@studentNo,@studentType,@courseName,@registrationStatus,@addedBy)

/*Insert into [rooms]*/
INSERT INTO [rooms](roomSymbolCode,roomFloor,roomType,roomAvailability,addedBy)
            VALUES(@roomSymbolCode,@roomFloor,@roomType,@roomAvailability,@addedBy)

/*Insert into [reservations]*/
INSERT INTO [reservations](studentId,roomId,reservedBy,bedAndChairUsage,recessStatus,dateReserved,MovedInDate)
                    VALUES(@StudentId,@roomId,@reservedBy,@BedAndChairUsage,@recessStatus,@dateReserved,@MovedInDate)


/*Insert into table [activityParticipation]*/
INSERT INTO [activityParticipation] (studentParticipant,semesterParticipating,totalPoints,allocatedDate, addedBy)
VALUES(@studentParticipant,@semesterParticipating,@totalPoints,@allocatedDate, @addedBy)

/*Insert into table [points]*/
INSERT INTO [points](studentId, totalPoint)
            VALUES(@studentId, @totalPoint)
