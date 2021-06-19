--3.3.	Вывод статистики Жанр - количество книг
SELECT dim_genre.genre_name AS 'Genre', COUNT(dim_genre.genre_name) AS 'Count' FROM book
INNER JOIN book_genre_lnk ON book_genre_lnk.book_id=book.book_id
INNER JOIN dim_genre ON dim_genre.genre_id = book_genre_lnk.genre_id
GROUP BY dim_genre.genre_name