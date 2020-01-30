--В базе данных MS SQL Server есть продукты и категории. 
--Одному продукту может соответствовать много категорий, 
--в одной категории может быть много продуктов. 
--Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
--Если у продукта нет категорий, то его имя все равно должно выводиться.

--Мысли: По ТЗ можно понять, что есть две сущности Продукты и Категории 
--это означает, что и продукты и категории должны быть вынесены в разные таблицы
--Categories {id, NameCategory}
--Products {id, NameProduct}
--Так же по тз понятно, что рассматривается связь многие ко многим, без дополнительной таблицы, 
--реализовать такое и не нарушив нормальную форму не получится. (Возможно я ошибаюсь)
--Рассмотрим пример:
--Пусть таблица Products выглядит следующим образом {Id, NameProduct, CategoryId},
--а таблица Categories {id, NameCategory}: 1-фрукты, 2-Мясо. 3-Белковая пища. тогда заполнив таблицу 
--Products:
--1|Яблоко|1
--2|Груша |1
--3|Ананас|NULL
--4|Говядина|2
--5|Говядина|3
--..........
--Мы не сможем однозначно получить идентификатор продукта, по известной катеории, 
--так же по идентификатору продукта не сможем получить категории, в которых товар находится.
--Получается, что есть зависимость одного не ключевого атрибута со вторым, 
--они все должны зависить от первичного ключе, поэтому нарушается 3нф. 
--(Возможно ошибаюсь)

--CREATE DATABASE Mindbox;
--go
--use Mindbox;

--CREATE TABLE CategoriesMB
--(
--	Id INT IDENTITY PRIMARY KEY,
--	NameCategory NVARCHAR(20) NOT NULL
--);

--CREATE TABLE ProductsMB
--(
--	Id INT IDENTITY PRIMARY KEY,
--	NameProduct NVARCHAR(20) NOT NULL
--);

--CREATE TABLE GoodsMB
--(
--	ProductId INT REFERENCES ProductsMB(Id) ON DELETE CASCADE,
--	CategoryId INT REFERENCES CategoriesMB(Id) ON DELETE CASCADE
--);

--INSERT INTO CategoriesMB 
--	VALUES ('Фрукты'), ('Овощи'), ('Мясо'), ('Белковая пища'), ('Морепродукты'), ('Рыба'), ('Жиры');
--INSERT INTO ProductsMB 
--	VALUES ('Яблоко'), ('Груша'), ('Апельсин'), ('Лук'), ('Огурец'), ('Говядина'), ('Свинина'), ('Треска'), ('Пикша'), ('Палтус');

-- INSERT INTO ProductsMB VALUES('Ананас'); --добавим еще продукт, у которого не будет категории

--select * from CategoriesMB;
--select * from ProductsMB;

--INSERT INTO GoodsMB 
--VALUES 
--	(1, 1), (2, 1),	(3, 1),	(4, 2),	(5, 2),	
--	(6, 3),	(7, 3),	(6, 4),	(7, 4),	(8, 4),	
--	(9, 4),	(10, 4), (8, 5), (9, 5), (10, 5),
--	(8, 6), (9, 6), (10, 6), (8, 7), (9, 7),
--	(10, 7)
	
----Вариант А
--SELECT NameProduct, NameCategory from GoodsMB AS G 
--JOIN CategoriesMB AS C ON G.CategoryId = C.Id
--RIGHT JOIN ProductsMB AS P ON G.ProductId = P.Id;

----Вариант Б
----или так
--SELECT NameProduct, NameCategory from ProductsMB AS P 
--LEFT JOIN GoodsMB AS G ON G.ProductId = P.Id
--LEFT JOIN CategoriesMB AS C ON G.CategoryId = C.Id

----Но по мне вариант А понятнее