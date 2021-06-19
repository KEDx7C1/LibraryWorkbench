--3.2. Получить список книг автора 
DECLARE @AuthorId INT = 1

select t1.first_name, t1.last_name, t1.middle_name, genres, names from
(
SELECT author_id AS id, first_name, last_name , middle_name 
from author where author_id=@AuthorId
) t1
left join 
(select author_id as id, STRING_AGG(genre, ',') AS genres from 
(select book.author_id as author_id, dim_genre.genre_name as genre from book
INNER JOIN book_genre_lnk ON book_genre_lnk.book_id = book.book_id
INNER JOIN dim_genre ON book_genre_lnk.genre_id = dim_genre.genre_id
WHERE book.author_id = @AuthorId
GROUP BY book.author_id, dim_genre.genre_name) t
Group by t.author_id) t2
ON t1.id=t2.id
left join
(select author_id as id, STRING_AGG(name, ',') AS names from 
(select book.author_id as author_id, book.name as name from book
WHERE book.author_id = @AuthorId
GROUP BY book.author_id, book.name) k
Group by k.author_id) k2
ON t1.id=k2.id