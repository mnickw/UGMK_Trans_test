DECLARE @Colors TABLE(Name nvarchar(20))
INSERT INTO @Colors
VALUES ('green'),
('black'),
('yellow'),
('blue'),
('white'),
('red'),
('brown')

;with idWithNameTable as (
SELECT ROW_NUMBER() OVER(ORDER BY c1.name ASC) AS id, c1.name
From @Colors as c1
)
SELECT c1.name as name1, c2.name as name2, c3.name as name3, c4.name as name4
FROM idWithNameTable c1 
JOIN idWithNameTable c2 
ON c1.id < c2.id
JOIN idWithNameTable c3
ON c2.id < c3.id
JOIN idWithNameTable c4
ON c3.id < c4.id
