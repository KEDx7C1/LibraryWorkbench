--4.2.	Получить всех должников, у которых более 3 просроченных книг
DECLARE @limit_period INT = 14;
SELECT  person.first_name AS 'FirstName', person.last_name AS 'LastName',
person.middle_name AS 'MiddleName', COUNT(library_card.book_id) AS 'Count'
FROM library_card
INNER JOIN person ON library_card.person_id = person.person_id
WHERE DATEDIFF(DAY, library_card.getting_time, SYSDATETIMEOFFSET()) > @limit_period
GROUP BY person.first_name, person.last_name, person.middle_name
HAVING COUNT(library_card.book_id) > 3
