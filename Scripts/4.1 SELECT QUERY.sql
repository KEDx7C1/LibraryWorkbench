--4.1.	Получить всех должников
DECLARE @limit_period INT = 14;
SELECT person.first_name AS 'FirstName', person.last_name AS 'LastName',
person.middle_name AS 'MiddleName',
book.name AS 'Title',
DATEDIFF(DAY, library_card.getting_time, SYSDATETIMEOFFSET()) - @limit_period AS [Delay]
FROM library_card
INNER JOIN person ON library_card.person_id = person.person_id
INNER JOIN book ON library_card.book_id = book.book_id
WHERE DATEDIFF(DAY, library_card.getting_time, SYSDATETIMEOFFSET()) > @limit_period
ORDER BY [delay]