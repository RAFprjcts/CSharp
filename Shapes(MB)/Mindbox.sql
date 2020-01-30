--� ���� ������ MS SQL Server ���� �������� � ���������. 
--������ �������� ����� ��������������� ����� ���������, 
--� ����� ��������� ����� ���� ����� ���������. 
--�������� SQL ������ ��� ������ ���� ��� ���� �������� � ��� ���������. 
--���� � �������� ��� ���������, �� ��� ��� ��� ����� ������ ����������.

--�����: �� �� ����� ������, ��� ���� ��� �������� �������� � ��������� 
--��� ��������, ��� � �������� � ��������� ������ ���� �������� � ������ �������
--Categories {id, NameCategory}
--Products {id, NameProduct}
--��� �� �� �� �������, ��� ��������������� ����� ������ �� ������, ��� �������������� �������, 
--����������� ����� � �� ������� ���������� ����� �� ���������. (�������� � ��������)
--���������� ������:
--����� ������� Products �������� ��������� ������� {Id, NameProduct, CategoryId},
--� ������� Categories {id, NameCategory}: 1-������, 2-����. 3-�������� ����. ����� �������� ������� 
--Products:
--1|������|1
--2|����� |1
--3|������|NULL
--4|��������|2
--5|��������|3
--..........
--�� �� ������ ���������� �������� ������������� ��������, �� ��������� ��������, 
--��� �� �� �������������� �������� �� ������ �������� ���������, � ������� ����� ���������.
--����������, ��� ���� ����������� ������ �� ��������� �������� �� ������, 
--��� ��� ������ �������� �� ���������� �����, ������� ���������� 3��. 
--(�������� ��������)

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
--	VALUES ('������'), ('�����'), ('����'), ('�������� ����'), ('������������'), ('����'), ('����');
--INSERT INTO ProductsMB 
--	VALUES ('������'), ('�����'), ('��������'), ('���'), ('������'), ('��������'), ('�������'), ('������'), ('�����'), ('������');

-- INSERT INTO ProductsMB VALUES('������'); --������� ��� �������, � �������� �� ����� ���������

--select * from CategoriesMB;
--select * from ProductsMB;

--INSERT INTO GoodsMB 
--VALUES 
--	(1, 1), (2, 1),	(3, 1),	(4, 2),	(5, 2),	
--	(6, 3),	(7, 3),	(6, 4),	(7, 4),	(8, 4),	
--	(9, 4),	(10, 4), (8, 5), (9, 5), (10, 5),
--	(8, 6), (9, 6), (10, 6), (8, 7), (9, 7),
--	(10, 7)
	
----������� �
--SELECT NameProduct, NameCategory from GoodsMB AS G 
--JOIN CategoriesMB AS C ON G.CategoryId = C.Id
--RIGHT JOIN ProductsMB AS P ON G.ProductId = P.Id;

----������� �
----��� ���
--SELECT NameProduct, NameCategory from ProductsMB AS P 
--LEFT JOIN GoodsMB AS G ON G.ProductId = P.Id
--LEFT JOIN CategoriesMB AS C ON G.CategoryId = C.Id

----�� �� ��� ������� � ��������