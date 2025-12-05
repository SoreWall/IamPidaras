CREATE TABLE Manufacturers
(
	Id SERIAL PRIMARY KEY NOT NULL,
	Name CHARACTER(50) NOT NULL,
	Country CHARACTER(15) NOT NULL,
	Hotline_phone_number CHARACTER(18) NOT NULL,
	Website CHARACTER(20) NOT NULL
);

CREATE TABLE Car_models
(
	Id SERIAL PRIMARY KEY NOT NULL,
	Name CHARACTER(50) NOT NULL,
	Body_type CHARACTER(11) NOT NULL,
	Engine_type CHARACTER(13) NOT NULL,
	Manufacturer INT NOT NULL,
	FOREIGN KEY (Manufacturer) REFERENCES Manufacturers (Id) ON DELETE NO ACTION
);

CREATE TABLE Cars
(
	Id SERIAL PRIMARY KEY NOT NULL,
	VIN CHARACTER(17) NOT NULL,
	Year INT NOT NULL,
	Mileage INT NOT NULL,
	Quantity INT NOT NULL,
	Price INT NOT NULL,
	Image CHARACTER(100),
	Car_model INT NOT NULL,
	FOREIGN KEY (Car_model) REFERENCES Car_models (Id) ON DELETE NO ACTION
);

CREATE TABLE Customers
(
	Id SERIAL PRIMARY KEY NOT NULL,
	Surname CHARACTER(20) NOT NULL,
	First_name CHARACTER(20) NOT NULL,
	Middle_name CHARACTER(20) NOT NULL,
	Phone_number CHARACTER(18) NOT NULL,
	Login CHARACTER(20) NOT NULL,
	Password CHARACTER(100) NOT NULL,
	Email CHARACTER(50) NOT NULL,
	Address CHARACTER(100) NOT NULL
);

CREATE TABLE Employees
(
	Id SERIAL PRIMARY KEY NOT NULL,
	Surname CHARACTER(20) NOT NULL,
	First_name CHARACTER(20) NOT NULL,
	Middle_name CHARACTER(20) NOT NULL,
	Phone_number CHARACTER(18) NOT NULL,
	Email CHARACTER(50) NOT NULL,
	Address CHARACTER(100) NOT NULL,
	Position CHARACTER(20) NOT NULL,
	Salary INT NOT NULL
);


CREATE TABLE Sales
(
	Id SERIAL PRIMARY KEY NOT NULL,
	Sale_date DATE NOT NULL,
	Sale_price INT NOT NULL,
	Commission INT NOT NULL,
	Payment_method CHARACTER(9) NOT NULL,
	Car INT NOT NULL,
	Customer INT NOT NULL,
	Employee INT NOT NULL,
	FOREIGN KEY (Car) REFERENCES Cars (Id) ON DELETE NO ACTION,
	FOREIGN KEY (Customer) REFERENCES Customers (Id) ON DELETE NO ACTION,
	FOREIGN KEY (Employee) REFERENCES Employees (Id) ON DELETE NO ACTION
);

INSERT INTO Employees (Surname, First_name, Middle_name, Phone_number, Email, Address, Position, Salary) VALUES
('Жмышенко', 'Валерий', 'Альбертович', '+7 (926) 582-14-73', 'valeriy517@gmail.com', 'г. Москва, ул. Ленина, 15, кв. 24', 'Продавец', 50000),
('Паровозов', 'Аркадий', 'Сергеевич', '+7 (915) 739-26-48', 'arcadiy.parovozov123@mail.ru', 'г. Подольк, ул. Пушкина, 10, кв. 5', 'Менеджер', 75000),
('Щёголев', 'Дмитрий', 'Владимирович', '+7 (977) 864-05-91', 'shchegolev.d@yandex.ru', 'г. Домодедово, пр. Мира, 25, кв. 12', 'Старший продавец', 60000),
('Янтарская', 'Екатерина', 'Алексеевна', '+7 (977) 157-83-29', 'yantarskaya.ek@mail.com', 'г. Москва, ул. Гагарина, 8, кв. 33', 'Администратор', 65000),
('Фонвизин', 'Сергей', 'Николаевич', '+7 (915) 492-61-70', 'fonvizin.sergey228@gmail.com', 'г. Подольк, бульвар Роз, 17, кв. 9', 'Кассир', 45000),
('Трампов', 'Кирилл', 'Владимирович', '+7 (977) 205-74-36', 'soldat52@mail.ru', 'г. Саратов, ул. Садовая, 3, кв. 18', 'Маркетолог', 70000),
('Лупенко', 'Казимир', 'Казимирович', '+7 (926) 638-42-15', 'kazimir812@yandex.ru', 'г. Ступино, пр. Победы, 44, кв. 7', 'IT-специалист', 80000),
('Юпитерова', 'Мария', 'Олеговна', '+7 (915) 971-53-84', 'yupiterova3.m@mail.com', 'г. Кашира, ул. Центральная, 11, кв. 22', 'Бухгалтер', 68000),
('Сергеев', 'Сильвестор', 'Андреевич', '+7 (925) 346-89-27', 'seragga666@gmail.com', 'г. Москва, ул. Лесная, 6, кв. 15', 'Кладовщик', 40000),
('Щедрина', 'Наталья', 'Викторовна', '+7 (977) 780-12-65', 'shchedrina.nat@mail.ru', 'г. Омск, пр. Строителей, 30, кв. 11', 'HR-менеджер', 72000);

INSERT INTO Customers (Surname, First_name, Middle_name, Phone_number, Login, Password, Email, Address) VALUES
('Златопольский', 'Арсений', 'Витальевич', '+7 (916) 483-72-19', '1', '11111', 'zlatopolsky45.a@mail.ru', 'г. Уфа, ул. Солнечная, 22, кв. 8'),
('Хрусталёва', 'Вероника', 'Игоревна', '+7 (925) 691-34-87', '2', '22222', 'khrustaleva.veronika@gmail.com', 'г. Москва, пр. Космонавтов, 13, кв. 41'),
('Янковский', 'Станислав', 'Романович', '+7 (903) 274-65-98', '3', '33333', 'yankovsky.s@yandex.ru', 'г. Подольк, ул. Берёзовая, 7, кв. 16'),
('Зубенько', 'Михаил', 'Петрович', '+7 (977) 815-42-76', '4', '44444', 'petrovichhh812@mail.com', 'г. Подольк, бульвар Весенний, 19, кв. 29'),
('Тесакова', 'Алиса', 'Фёдоровна', '+7 (916) 362-89-14', '5', '55555', 'tesak163@gmail.com', 'г. Уфа, ул. Парковая, 4, кв. 33'),
('Князев', 'Всеволод', 'Денисович', '+7 (926) 728-53-06', '6', '66666', 'knyazev.vsevolod@mail.ru', 'г. Йошкар-Ола, пр. Юбилейный, 28, кв. 12'),
('Бриллиантова', 'Элеонора', 'Степановна', '+7 (915) 194-67-25', '7', '77777', 'brilliantova.eleonora8756@yandex.ru', 'г. Домодедово, ул. Садовая, 11, кв. 9'),
('Головач', 'Виктор', 'Анатольевич', '+7 (977) 546-31-89', '8', '88888', 'golovachtv@gmail.com', 'г. Москва, ул. Лесная, 15, кв. 24'),
('Яшвили', 'Тамара', 'Георгиевна', '+7 (903) 872-45-63', '9', '99999', 'yashvili.tamara74@mail.ru', 'г. Москва, пр. Мира, 33, кв. 18'),
('Акушеров', 'Владимир', 'Вадимович', '+7 (925) 419-78-32', '10', '10101', 'lilpeep15@yandex.ru', 'г. Москва, ул. Центральная, 9, кв. 7');

INSERT INTO Manufacturers (Name, Country, Hotline_phone_number, Website) VALUES
('Toyota', 'Japan', '+7 (800) 200-55-55', 'www.toyota.ru'),
('BMW', 'Germany', '+7 (800) 555-35-35', 'www.bmw.ru'),
('Ford', 'USA', '+7 (800) 700-01-01', 'www.ford.ru'),
('Hyundai', 'South Korea', '+7 (800) 300-30-03', 'www.hyundai.ru'),
('Renault', 'France', '+7 (800) 200-40-40', 'www.renault.ru'),
('Fiat', 'Italy', '+7 (800) 250-50-50', 'www.fiat.ru'),
('Volvo', 'Sweden', '+7 (800) 333-33-33', 'www.volvo.ru'),
('Kia', 'South Korea', '+7 (800) 301-50-50', 'www.kia.ru'),
('Mercedes-Benz', 'Germany', '+7 (800) 250-25-25', 'www.mercedes-benz.ru'),
('Honda', 'Japan', '+7 (800) 200-22-02', 'www.honda.ru');

INSERT INTO Car_models (Name, Body_type, Engine_type, Manufacturer) VALUES
('Camry', 'sedan', 'бензиновый', 1),
('Corolla', 'sedan', 'бензиновый', 1),
('RAV4', 'crossover', 'гибридный', 1),
('Land Cruiser', 'SUV', 'дизельный', 1),
('Hilux', 'pickup', 'дизельный', 1),

('X5', 'SUV', 'бензиновый', 2),
('3 Series', 'sedan', 'бензиновый', 2),
('5 Series', 'sedan', 'гибридный', 2),
('X3', 'crossover', 'дизельный', 2),
('7 Series', 'sedan', 'бензиновый', 2),

('Focus', 'sedan', 'бензиновый', 3),
('Mondeo', 'sedan', 'дизельный', 3),
('Kuga', 'crossover', 'гибридный', 3),
('Explorer', 'SUV', 'бензиновый', 3),
('F-150', 'pickup', 'дизельный', 3),

('Solaris', 'sedan', 'бензиновый', 4),
('Creta', 'crossover', 'бензиновый', 4),
('Tucson', 'crossover', 'дизельный', 4),
('Santa Fe', 'SUV', 'гибридный', 4),
('Elantra', 'sedan', 'бензиновый', 4),

('Logan', 'sedan', 'бензиновый', 5),
('Duster', 'crossover', 'дизельный', 5),
('Sandero', 'hatchback', 'бензиновый', 5),
('Kaptur', 'crossover', 'бензиновый', 5),
('Arkana', 'crossover', 'гибридный', 5),

('Doblo', 'minivan', 'бензиновый', 6),
('Panda', 'hatchback', 'бензиновый', 6),
('Tipo', 'sedan', 'дизельный', 6),
('500', 'hatchback', 'электрический', 6),
('Fullback', 'pickup', 'дизельный', 6),

('XC90', 'SUV', 'гибридный', 7),
('S90', 'sedan', 'бензиновый', 7),
('XC60', 'crossover', 'дизельный', 7),
('V90', 'wagon', 'бензиновый', 7),
('XC40', 'crossover', 'электрический', 7),

('Rio', 'sedan', 'бензиновый', 8),
('Sportage', 'crossover', 'дизельный', 8),
('Sorento', 'SUV', 'гибридный', 8),
('Ceed', 'hatchback', 'бензиновый', 8),
('Carnival', 'minivan', 'дизельный', 8),

('E-Class', 'sedan', 'бензиновый', 9),
('GLE', 'SUV', 'дизельный', 9),
('S-Class', 'sedan', 'гибридный', 9),
('C-Class', 'sedan', 'бензиновый', 9),
('GLC', 'crossover', 'электрический', 9),

('Civic', 'sedan', 'бензиновый', 10),
('CR-V', 'crossover', 'гибридный', 10),
('Accord', 'sedan', 'бензиновый', 10),
('Pilot', 'SUV', 'дизельный', 10),
('HR-V', 'crossover', 'электрический', 10);

INSERT INTO Cars (VIN, Year, Mileage, Quantity, Price, Image, Car_model) VALUES
('Z94CB41BAER123001', 2024, 0, 32, 2890000, 'padna.jpg', 27),
('Z94CB41BAER123002', 2025, 0, 16, 1650000, 's-class.jpg', 43),
('Z94CB41BAER123003', 2025, 0, 23, 3450000, 'f150.jpg', 15),
('Z94CB41BAER123004', 2022, 0, 112, 5890000, 'sorento.jpeg', 38),
('Z94CB41BAER123005', 2024, 0, 45, 2450000, 'x3.jpg', 9),

('WBA56EY0XG5E12345', 2020, 0, 26, 6890000, 'duster.jpg', 22),
('WBA56EY0XG5E12346', 2025, 0, 12, 4250000, 'hr-v.jpg', 50),
('WBA56EY0XG5E12347', 2025, 35000, 33, 5890000, 'x5.jpg', 6),
('WBA56EY0XG5E12348', 2025, 0, 21, 5120000, 'xc90.png', 31),
('WBA56EY0XG5E12349', 2025, 0, 12, 8450000, 'creta.jpg', 17),

('1FMCU0GD1GUA12345', 2025, 0, 22, 1890000, 'c-class.jpg', 44),
('1FMCU0GD1GUA12346', 2025, 25000, 19, 2150000, 'rav4.jpg', 3),
('1FMCU0GD1GUA12347', 2025, 0, 37, 2780000, 'tipo.jpg', 28),
('1FMCU0GD1GUA12348', 2020, 0, 28, 3850000, 'mondeo.jpg', 12),
('1FMCU0GD1GUA12349', 2025, 35000, 12, 4250000, 'pilot.jpg', 49),

('KMHDH4AE2FU123456', 2020, 20000, 44, 1250000, '3series.jpg', 7),
('KMHDH4AE2FU123457', 2025, 30000, 29, 1680000, 'xc40.jpg', 35),
('KMHDH4AE2FU123458', 2023, 15000, 34, 2150000, 'santafe.jpg', 19),
('KMHDH4AE2FU123459', 2025, 25000, 12, 2890000, 'e-class.jpg', 41),
('KMHDH4AE2FU123460', 2022, 10000, 25, 1450000, 'corolla.jpg', 2),

('VF1RFA00E12345678', 2025, 35000, 36, 1150000, 'civic.jpg', 46),
('VF1RFA00E12345679', 2025, 0, 22, 1350000, 'Explorer.png', 14),
('VF1RFA00E12345680', 2018, 40000, 13, 980000, 'xc60.jpg', 33),
('VF1RFA00E12345681', 2022, 0, 46, 1420000, '5series.jpg', 8),
('VF1RFA00E12345682', 2024, 30000, 21, 1560000, 'captur.jpg', 24),

('ZFA25000001234567', 2025, 25000, 1, 890000, 'ceed.jpg', 39),
('ZFA25000001234568',2012, 0, 34, 750000, 'focus.jpg', 11),
('ZFA25000001234569', 2025, 0, 27, 950000, 'cr-v.jpg', 47),
('ZFA25000001234570', 2023, 10000, 14, 1250000, 'hilux.jpg', 5),
('ZFA25000001234571', 2019, 40000, 26, 680000, 'fullback.jpg', 30),

('YV1LFA2A0C1234567', 2024, 15000, 23, 4850000, 'solaris.png', 16),
('YV1LFA2A0C1234568', 2025, 0, 16, 4250000, 'gle.jpg', 42),
('YV1LFA2A0C1234569', 2024, 10000, 31, 5250000, 'camry.jpg', 1),
('YV1LFA2A0C1234570', 2023, 0, 23, 3850000, 'arkana.jpg', 25),
('YV1LFA2A0C1234571', 2022, 0, 12, 5890000, 'rio.jpg', 36),

('KNAGN5DB3G5123456', 2019, 0, 4, 1280000, 'elantra.jpg', 20),
('KNAGN5DB3G5123457', 2025, 0, 2, 1850000, 'glc.jpg', 45),
('KNAGN5DB3G5123458', 2025, 0, 3, 2450000, '7series.jpg', 10),
('KNAGN5DB3G5123459', 2022, 25000, 1, 1680000, 's90.jpg', 32),
('KNAGN5DB3G5123460', 2025, 10000, 2, 1950000, 'accord.jpg', 48),

('WDD2130031A123456', 2020, 5000, 14, 6250000, 'kugo.jpg', 13),
('WDD2130031A123457', 2021, 0, 25, 5450000, '500.jpg', 29),
('WDD2130031A123458', 2025, 0, 12, 8950000, 'landcruser.jpg', 4),
('WDD2130031A123459', 2024, 0, 31, 4850000, 'sandero.jpg', 23),
('WDD2130031A123460', 2025, 0, 27, 6850000, 'sportage.jpg', 37),

('JHMCV6650YC123456', 2024, 0, 23, 2250000, 'tucson.jpg', 18),
('JHMCV6650YC123457', 2024, 0, 18, 2850000, 'v90.jpg', 34),
('JHMCV6650YC123458', 2021, 0, 33, 1950000, 'logan.jpg', 21),
('JHMCV6650YC123459', 2025, 20000, 25, 3850000, 'doblo.jpg', 26),
('JHMCV6650YC123460', 2023, 10000, 13, 3150000, 'carnival.jpg', 40);

INSERT INTO Sales (Sale_date, Sale_price, Commission, Payment_method, Car, Customer, Employee) VALUES
('2024-01-15', 2890000, 144500, 'карта', 1, 3, 2),
('2024-01-18', 1650000, 82500, 'наличные', 2, 7, 1),
('2024-01-22', 3450000, 172500, 'карта', 3, 5, 3),
('2024-02-05', 5890000, 294500, 'карта', 4, 2, 4),
('2024-02-12', 2450000, 122500, 'наличные', 5, 8, 1),

('2024-02-18', 6890000, 344500, 'карта', 6, 6, 5),
('2024-02-25', 4250000, 212500, 'карта', 7, 4, 2),
('2024-03-03', 5890000, 294500, 'наличные', 8, 9, 3),
('2024-03-10', 5120000, 256000, 'карта', 9, 1, 4),
('2024-03-15', 8450000, 422500, 'карта', 10, 10, 5),

('2024-03-22', 1890000, 94500, 'наличные', 11, 2, 1),
('2024-04-02', 2150000, 107500, 'карта', 12, 3, 2),
('2024-04-08', 2780000, 139000, 'карта', 13, 7, 3),
('2024-04-14', 3850000, 192500, 'наличные', 14, 5, 4),
('2024-04-20', 4250000, 212500, 'карта', 15, 8, 5),

('2024-05-05', 1250000, 62500, 'наличные', 16, 4, 1),
('2024-05-11', 1680000, 84000, 'карта', 17, 6, 2),
('2024-05-17', 2150000, 107500, 'карта', 18, 9, 3),
('2024-05-24', 2890000, 144500, 'наличные', 19, 1, 4),
('2024-05-30', 1450000, 72500, 'карта', 20, 10, 5),

('2024-06-07', 1150000, 57500, 'наличные', 21, 3, 1),
('2024-06-12', 1350000, 67500, 'карта', 22, 7, 2),
('2024-06-18', 980000, 49000, 'наличные', 23, 2, 3),
('2024-06-25', 1420000, 71000, 'карта', 24, 5, 4),
('2024-07-02', 1560000, 78000, 'карта', 25, 8, 5),

('2024-07-09', 890000, 44500, 'наличные', 26, 4, 1),
('2024-07-15', 750000, 37500, 'карта', 27, 6, 2),
('2024-07-21', 950000, 47500, 'наличные', 28, 9, 3),
('2024-07-28', 1250000, 62500, 'карта', 29, 1, 4),
('2024-08-04', 680000, 34000, 'наличные', 30, 10, 5),

('2024-08-11', 4850000, 242500, 'карта', 31, 3, 1),
('2024-08-18', 4250000, 212500, 'карта', 32, 7, 2),
('2024-08-25', 5250000, 262500, 'карта', 33, 2, 3),
('2024-09-01', 3850000, 192500, 'наличные', 34, 5, 4),
('2024-09-08', 5890000, 294500, 'карта', 35, 8, 5),

('2024-09-15', 1280000, 64000, 'наличные', 36, 4, 1),
('2024-09-22', 1850000, 92500, 'карта', 37, 6, 2),
('2024-09-29', 2450000, 122500, 'карта', 38, 9, 3),
('2024-10-06', 1680000, 84000, 'наличные', 39, 1, 4),
('2024-10-13', 1950000, 97500, 'карта', 40, 10, 5),

('2024-10-20', 6250000, 312500, 'карта', 41, 3, 1),
('2024-10-27', 5450000, 272500, 'карта', 42, 7, 2),
('2024-11-03', 8950000, 447500, 'карта', 43, 2, 3),
('2024-11-10', 4850000, 242500, 'наличные', 44, 5, 4),
('2024-11-17', 6850000, 342500, 'карта', 45, 8, 5);

SELECT * FROM Car_models;
SELECT * FROM Cars;
SELECT * FROM Customers;
SELECT * FROM Employees;
SELECT * FROM Manufacturers;
SELECT * FROM Sales;

DROP TABLE Car_models;
DROP TABLE Cars;
DROP TABLE Customers;
DROP TABLE Employees;
DROP TABLE Manufacturers;
DROP TABLE Sales;