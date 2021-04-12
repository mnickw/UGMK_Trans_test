# УГМК-Транс тестовое задание
## 1. MS SQL Server
Пусть объявлена табличная переменная `@Colors` содержащая следующие значения:
```
DECLARE @Colors TABLE(Name nvarchar(20))
INSERT INTO @Colors
VALUES ('green'),
('black'),
('yellow'),
('blue'),
('white'),
('red'),
('brown')
```
Необходимо написать SQL запрос, который выведет все возможные сочетания для значений переменной, где n = 7 и k = 4.
Пример:
Табличная переменная @Colors:

| Name   |
|--------|
| green  |
| black  |
| yellow |
| blue   |

Результат запроса для n = 4 и k = 3:

| Name1 | Name2 | Name3  |
|-------|-------|--------|
| green | black | yellow |
| blue  | black | green  |
| blue  | black | yellow |
| green | blue  | yellow |

### Решение
Решение находится в файле MS_SQL_Server.sql. Решение использует не-эквисоединение, отсекающее не уникальные строки.

## 2. .NET Core C#
Пусть дано следующее определение интерфейса:
```
public interface ICircularList<T> : IList<T>
{
 void MoveNext();
 void MoveBack();
 T Current { get; }
 T Previous { get; }
 T Next { get; }
}
```
Интерфейс описывает замкнутую коллекцию объектов, по которой можно бесконечно перемещаться в прямом и обратном направлении с помощью методов MoveNext и
MoveBack.
Для получения текущего, предыдущего и следующего элемента коллекции интерфейс определяет соответствующие свойства Current, Previous и Next.
Напишите класс, реализующий интерфейс ICircularList<T>, удовлетворяющую указанным условиям.
### Решение
Решение находится в папке CircularList. Для решения используется класс Collection<T>. Были написаны юнит тесты