--3.1.	Получить список всех взятых пользователем книг
-- STRING_AGG работает в версии SQL Server 2017 (14.x) и выше

DECLARE @PersonId INT = 4;

SELECT name, last_name, first_name,
middle_name, STRING_AGG(genre_name, ',') AS Genre FROM 
(SELECT book.name as name, author.last_name, author.first_name,
author.middle_name, dim_genre.genre_name
FROM library_card
INNER JOIN book ON library_card.book_id = book.book_id
INNER JOIN author ON author.author_id = book.author_id
INNER JOIN book_genre_lnk ON book_genre_lnk.book_id = book.book_id
INNER JOIN dim_genre ON dim_genre.genre_id = book_genre_lnk.genre_id
WHERE library_card.person_id = @PersonId 
GROUP BY book.name, author.last_name, author.first_name, author.middle_name, dim_genre.genre_name) AS a
GROUP BY name, last_name, first_name, middle_name
