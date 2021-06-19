--4.3.	Получить статистику (кол-во книг,сколько дней просрочки)
DECLARE @limit_period INT = 14
SELECT COUNT(library_card.book_id) AS 'Count',
SUM(DATEDIFF(DAY, library_card.getting_time, SYSDATETIMEOFFSET()) - @limit_period) AS 'SumDelay'
FROM library_card
WHERE DATEDIFF(DAY, library_card.getting_time, SYSDATETIMEOFFSET()) > @limit_period