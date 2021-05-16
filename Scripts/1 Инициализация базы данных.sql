--Инициализация базы данных
CREATE DATABASE library_database
GO
USE [library_database]
GO

CREATE TABLE dim_genre
(genre_id int PRIMARY KEY IDENTITY(1,1),
genre_name NVARCHAR(75) NOT NULL);

CREATE TABLE author
(author_id  INT PRIMARY KEY IDENTITY(1,1),
first_name NVARCHAR(75) NOT NULL,
last_name NVARCHAR(75) NOT NULL,
middle_name NVARCHAR(75));

CREATE TABLE book
(book_id INT PRIMARY KEY IDENTITY(1,1),
name NVARCHAR(75) NOT NULL,
author_id INT NOT NULL,
FOREIGN KEY (author_id) REFERENCES author (author_id));

CREATE TABLE book_genre_lnk
(book_id INT,
genre_id INT,
FOREIGN KEY (book_id) REFERENCES book (book_id),
FOREIGN KEY (genre_id) REFERENCES dim_genre (genre_id));

CREATE TABLE person
(person_id INT PRIMARY KEY IDENTITY(1,1),
first_name NVARCHAR(75) NOT NULL,
last_name NVARCHAR(75) NOT NULL,
middle_name NVARCHAR(75),
birth_date DATE);

CREATE TABLE library_card
(book_id INT,
person_id INT,
FOREIGN KEY (book_id) REFERENCES book (book_id),
FOREIGN KEY (person_id) REFERENCES person (person_id));
