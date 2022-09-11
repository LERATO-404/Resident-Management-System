/*Update table [users]*/

/*Update table [workers]*/
UPDATE [workers] SET firstName=@firstName,
			lastName=@lastName,
			emailAddress=@emailAddress,
			phoneNumber=@phoneNumber,
			dOB=@dOB,
			gender=@gender,
			jobTitle=@jobTitle,
			jobType=@jobType,
			startDate=@startDate 
			WHERE workerId=@workerId

/*Update table [students]*/
UPDATE [students] SET firstName=@firstName,
		lastName=@lastName,
		emailAddress=@emailAddress,
		phoneNumber=@phoneNumber,
		gender=@gender,dOB=@dOB,
		nextOfKinFullName=@nextOfKinFullName,
		nextOfKinPhone=@nextOfKinPhone,
		studentNo=@studentNo,
		studentType=@studentType,
		courseName=@courseName,
		registrationStatus=@registrationStatus 
		WHERE studentId=@studentId

/*Update table [rooms]*/
UPDATE [rooms] SET roomSymbolCode=@roomSymbolCode,
	roomFloor=@roomFloor,
	roomType=@roomType,
	roomAvailability=@roomAvailability 
	WHERE roomId=@roomId

/*Update table [reservations]*/
UPDATE [reservations] SET studentId=@studentId,
		roomId=@roomId,
		bedAndChairUsage=@bedAndChairUsage,
		recessStatus=@recessStatus,
		dateReserved=@dateReserved,
		MovedInDate=@MovedInDate 
		WHERE reservationId=@reservationId



