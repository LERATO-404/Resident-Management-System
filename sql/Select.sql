

/*Counting the number of users*/
SELECT COUNT(userId) FROM [users]

/*Counting the number of workers*/
SELECT COUNT(workerId) FROM [workers]

/*Counting the number of students*/
SELECT COUNT(studentId) FROM [students]


/*Select student full name and the points the student has*/
SELECT a.activityId, a.totalPoints AS Points, s.firstName, s.lastName
         FROM activityParticipation a
         INNER JOIN students s
         ON  a.studentParticipant = s.studentId
         ORDER BY a.activityId

/*Selecting student id and full name and the room code the student is in*/
SELECT r.roomId, r.roomSymbolCode, r.roomType, rs.studentId AS OccupantId, s.firstName, s.lastName
         FROM Rooms r
         INNER JOIN Reservations rs
            ON r.roomId = rs.roomId
         INNER JOIN Students s
            ON  rs.studentId = s.studentId
         ORDER BY r.roomId