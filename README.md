Практическое задание для Mindbox.

Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.

Требования:
1) Библиотека предназначается для поставки внешним клиентам
2) Площадь круга по радиусу
3) Площадь треугольника по сторонам
4) Юнит-тесты
5) Легкость добавления других фигур
6) Вычисление площади фигуры без знания типа фигуры в compile-time
7) Проверку на то, является ли треугольник прямоугольным 


Чек-лист по решению:
1) Постарался реализовать прозрачную иерархию. Комментарии писал на английском, т.к. не указано кто будет пользоваться нашей библиотекой.
2) Реализовано: создаем экземпляр класса Circle с помощью конструктора Circle(double radius), методом GetArea() получаем площадь.
3) Реализовано: создаем экземпляр класса Triangle с помощью конструктора Rectangle(double firstSideLength, double secondSideLength, double thirdSideLength), методом GetArea() получаем площадь.
4) Юнит-тесты пристуствуют (в основном сделанные по калькулятору).
5) Разработанное решение позволяет быстро создавать новые типы фигур (несамопересекающихся многоугольников и производных эллипса).
Для многоугольников достаточно наследоваться от Polygon, добавлять точки в конструкторе AddPoint'om.
Вычисление площади для дочерних классов Polygon будет работать из коробки (считает по точкам по формуле площади Гауса).
4) Кастим к IShape экземпляр любого типа фигуры в Runtime'e, методом GetArea() получаем площадь.
5) Реализована экстеншн методом, проверку проводит по обратной теореме Пифагора. Погрешность 1e-12.
