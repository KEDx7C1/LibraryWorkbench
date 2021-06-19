--4. Добавление столбца времени получения в таблицу library_card
ALTER TABLE library_card ADD getting_time DATETIME
GO
UPDATE library_card SET getting_time = '2021-10-04' WHERE getting_time IS NULL
ALTER TABLE library_card ALTER COLUMN getting_time DATETIMEOFFSET NOT NULL