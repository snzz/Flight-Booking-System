--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 14.01.2022 14:39:20
-- Версия сервера: 8.0.26
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

--
-- Установка базы данных по умолчанию
--
USE air_booking;

--
-- Удалить представление `view_destinations_by_idcl`
--
DROP VIEW IF EXISTS view_destinations_by_idcl CASCADE;

--
-- Удалить представление `view_full_tickes_info`
--
DROP VIEW IF EXISTS view_full_tickes_info CASCADE;

--
-- Удалить представление `view_operations`
--
DROP VIEW IF EXISTS view_operations CASCADE;

--
-- Удалить представление `view_tickets`
--
DROP VIEW IF EXISTS view_tickets CASCADE;

--
-- Удалить таблицу `operations`
--
DROP TABLE IF EXISTS operations;

--
-- Удалить таблицу `tickets`
--
DROP TABLE IF EXISTS tickets;

--
-- Удалить представление `view_flights`
--
DROP VIEW IF EXISTS view_flights CASCADE;

--
-- Удалить таблицу `flights`
--
DROP TABLE IF EXISTS flights;

--
-- Удалить таблицу `routes`
--
DROP TABLE IF EXISTS routes;

--
-- Удалить таблицу `carriers`
--
DROP TABLE IF EXISTS carriers;

--
-- Удалить таблицу `airplanes`
--
DROP TABLE IF EXISTS airplanes;

--
-- Удалить таблицу `clients_list`
--
DROP TABLE IF EXISTS clients_list;

--
-- Удалить таблицу `ticket_type`
--
DROP TABLE IF EXISTS ticket_type;

--
-- Установка базы данных по умолчанию
--
USE air_booking;

--
-- Создать таблицу `ticket_type`
--
CREATE TABLE ticket_type (
  ID_type int NOT NULL AUTO_INCREMENT,
  type varchar(200) NOT NULL DEFAULT '',
  PRIMARY KEY (ID_type)
)
ENGINE = INNODB,
AUTO_INCREMENT = 5,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать индекс `UK_tickettype_type` для объекта типа таблица `ticket_type`
--
ALTER TABLE ticket_type
ADD UNIQUE INDEX UK_tickettype_type (type);

--
-- Создать таблицу `clients_list`
--
CREATE TABLE clients_list (
  ID_CL int UNSIGNED NOT NULL AUTO_INCREMENT,
  clFName varchar(20) NOT NULL DEFAULT '',
  clSName varchar(20) NOT NULL DEFAULT '',
  clPhone varchar(15) NOT NULL DEFAULT '',
  PRIMARY KEY (ID_CL)
)
ENGINE = INNODB,
AUTO_INCREMENT = 7,
AVG_ROW_LENGTH = 5461,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать индекс `clPhone` для объекта типа таблица `clients_list`
--
ALTER TABLE clients_list
ADD UNIQUE INDEX clPhone (clPhone);

--
-- Создать таблицу `airplanes`
--
CREATE TABLE airplanes (
  ID_ap int UNSIGNED NOT NULL AUTO_INCREMENT,
  model varchar(30) NOT NULL DEFAULT '',
  tailNum varchar(15) NOT NULL DEFAULT '',
  seatNum int UNSIGNED NOT NULL,
  PRIMARY KEY (ID_ap)
)
ENGINE = INNODB,
AUTO_INCREMENT = 7,
AVG_ROW_LENGTH = 2730,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать индекс `tailNum` для объекта типа таблица `airplanes`
--
ALTER TABLE airplanes
ADD UNIQUE INDEX tailNum (tailNum);

--
-- Создать таблицу `carriers`
--
CREATE TABLE carriers (
  ID_carr int UNSIGNED NOT NULL AUTO_INCREMENT,
  carrName varchar(255) NOT NULL DEFAULT '',
  carrPhone varchar(15) NOT NULL DEFAULT '',
  carrMail varchar(70) NOT NULL DEFAULT '',
  economy decimal(10, 2) UNSIGNED NOT NULL DEFAULT 0.00,
  comfort decimal(10, 2) UNSIGNED NOT NULL DEFAULT 0.00,
  business decimal(10, 2) UNSIGNED NOT NULL DEFAULT 0.00,
  first decimal(10, 2) UNSIGNED NOT NULL DEFAULT 0.00,
  baggagePrice decimal(10, 2) NOT NULL DEFAULT 0.00,
  childrenDiscount int UNSIGNED NOT NULL DEFAULT 0,
  babiesDiscount int UNSIGNED NOT NULL DEFAULT 0,
  PRIMARY KEY (ID_carr)
)
ENGINE = INNODB,
AUTO_INCREMENT = 4,
AVG_ROW_LENGTH = 5461,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `routes`
--
CREATE TABLE routes (
  ID_r int UNSIGNED NOT NULL AUTO_INCREMENT,
  departureP varchar(255) NOT NULL,
  destinationP varchar(255) NOT NULL,
  depAirport varchar(255) NOT NULL DEFAULT '',
  desAirport varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (ID_r)
)
ENGINE = INNODB,
AUTO_INCREMENT = 48,
AVG_ROW_LENGTH = 528,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `flights`
--
CREATE TABLE flights (
  ID_f int UNSIGNED NOT NULL AUTO_INCREMENT,
  fDepartureTime datetime NOT NULL,
  fArrivalTime datetime NOT NULL,
  ID_r int UNSIGNED NOT NULL,
  ID_ap int UNSIGNED NOT NULL,
  fPrice decimal(10, 2) NOT NULL DEFAULT 0.00,
  ID_carr int UNSIGNED NOT NULL,
  soldSeats int UNSIGNED NOT NULL DEFAULT 0,
  PRIMARY KEY (ID_f)
)
ENGINE = INNODB,
AUTO_INCREMENT = 134,
AVG_ROW_LENGTH = 8192,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE flights
ADD CONSTRAINT FK_flights_ID_ap FOREIGN KEY (ID_ap)
REFERENCES airplanes (ID_ap);

--
-- Создать внешний ключ
--
ALTER TABLE flights
ADD CONSTRAINT FK_flights_ID_carr FOREIGN KEY (ID_carr)
REFERENCES carriers (ID_carr);

--
-- Создать внешний ключ
--
ALTER TABLE flights
ADD CONSTRAINT FK_flights_ID_r FOREIGN KEY (ID_r)
REFERENCES routes (ID_r);

--
-- Создать представление `view_flights`
--
CREATE
DEFINER = 'root'@'localhost'
VIEW view_flights
AS
SELECT
  `flights`.`ID_f` AS `ID_f`,
  `flights`.`fDepartureTime` AS `fDepartureTime`,
  `flights`.`fArrivalTime` AS `fArrivalTime`,
  `flights`.`fPrice` AS `fPrice`,
  `routes`.`departureP` AS `departureP`,
  `routes`.`depAirport` AS `depAirport`,
  `routes`.`destinationP` AS `destinationP`,
  `routes`.`desAirport` AS `desAirport`,
  `airplanes`.`ID_ap` AS `ID_ap`,
  `airplanes`.`seatNum` AS `seatNum`,
  `flights`.`soldSeats` AS `soldSeats`,
  `carriers`.`carrName` AS `carrName`,
  `carriers`.`economy` AS `economy`,
  `carriers`.`comfort` AS `comfort`,
  `carriers`.`business` AS `business`,
  `carriers`.`first` AS `first`,
  `carriers`.`baggagePrice` AS `baggagePrice`,
  `carriers`.`childrenDiscount` AS `childrenDiscount`,
  `carriers`.`babiesDiscount` AS `babiesDiscount`
FROM (((`flights`
  JOIN `carriers`
    ON ((`flights`.`ID_carr` = `carriers`.`ID_carr`)))
  JOIN `routes`
    ON ((`flights`.`ID_r` = `routes`.`ID_r`)))
  JOIN `airplanes`
    ON ((`flights`.`ID_ap` = `airplanes`.`ID_ap`)));

--
-- Создать таблицу `tickets`
--
CREATE TABLE tickets (
  ID_ticket int UNSIGNED NOT NULL AUTO_INCREMENT,
  ID_f int UNSIGNED NOT NULL,
  seatTakerFirstName varchar(150) NOT NULL DEFAULT '',
  seatTakerLastName varchar(150) NOT NULL DEFAULT '',
  passportSeries char(4) DEFAULT '',
  passportNumber char(6) DEFAULT '',
  birthCertificate varchar(50) DEFAULT '',
  seatNum int UNSIGNED NOT NULL,
  ticketType varchar(200) NOT NULL DEFAULT '',
  baggageNum int UNSIGNED NOT NULL DEFAULT 0,
  seatType varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (ID_ticket)
)
ENGINE = INNODB,
AUTO_INCREMENT = 82,
AVG_ROW_LENGTH = 327,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE tickets
ADD CONSTRAINT FK_tickets_ID_f FOREIGN KEY (ID_f)
REFERENCES flights (ID_f);

--
-- Создать внешний ключ
--
ALTER TABLE tickets
ADD CONSTRAINT FK_tickets_ticketType FOREIGN KEY (ticketType)
REFERENCES ticket_type (type);

--
-- Создать таблицу `operations`
--
CREATE TABLE operations (
  IDoperation int UNSIGNED NOT NULL AUTO_INCREMENT,
  ID_cl int UNSIGNED NOT NULL,
  oDateTime datetime NOT NULL,
  ID_t int UNSIGNED NOT NULL,
  opPrice decimal(10, 2) UNSIGNED NOT NULL,
  PRIMARY KEY (IDoperation)
)
ENGINE = INNODB,
AUTO_INCREMENT = 78,
AVG_ROW_LENGTH = 334,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE operations
ADD CONSTRAINT FK_operations_ID_cl FOREIGN KEY (ID_cl)
REFERENCES clients_list (ID_CL);

--
-- Создать внешний ключ
--
ALTER TABLE operations
ADD CONSTRAINT FK_operations_ID_t FOREIGN KEY (ID_t)
REFERENCES tickets (ID_ticket);

--
-- Создать представление `view_tickets`
--
CREATE
DEFINER = 'root'@'localhost'
VIEW view_tickets
AS
SELECT
  `tickets`.`ID_ticket` AS `ID_ticket`,
  `tickets`.`seatTakerFirstName` AS `seatTakerFirstName`,
  `tickets`.`seatTakerLastName` AS `seatTakerLastName`,
  `tickets`.`seatNum` AS `seatNum`,
  `tickets`.`ticketType` AS `ticketType`,
  `routes`.`departureP` AS `departureP`,
  `routes`.`destinationP` AS `destinationP`,
  `flights`.`fDepartureTime` AS `fDepartureTime`,
  `flights`.`fArrivalTime` AS `fArrivalTime`,
  `carriers`.`carrName` AS `carrName`
FROM ((((`tickets`
  JOIN `flights`
    ON ((`tickets`.`ID_f` = `flights`.`ID_f`)))
  JOIN `operations`
    ON ((`operations`.`ID_t` = `tickets`.`ID_ticket`)))
  JOIN `routes`
    ON ((`flights`.`ID_r` = `routes`.`ID_r`)))
  JOIN `carriers`
    ON ((`flights`.`ID_carr` = `carriers`.`ID_carr`)));

--
-- Создать представление `view_operations`
--
CREATE
DEFINER = 'root'@'localhost'
VIEW view_operations
AS
SELECT
  `operations`.`IDoperation` AS `IDoperation`,
  `operations`.`ID_cl` AS `ID_cl`,
  `operations`.`oDateTime` AS `oDateTime`,
  `tickets`.`ID_f` AS `ID_f`,
  `tickets`.`seatTakerFirstName` AS `seatTakerFirstName`,
  `tickets`.`seatTakerLastName` AS `seatTakerLastName`,
  `tickets`.`seatNum` AS `seatNum`,
  `routes`.`departureP` AS `departureP`,
  `routes`.`depAirport` AS `depAirport`,
  `routes`.`destinationP` AS `destinationP`,
  `routes`.`desAirport` AS `desAirport`,
  `flights`.`fDepartureTime` AS `fDepartureTime`,
  `flights`.`fArrivalTime` AS `fArrivalTime`,
  `tickets`.`ID_ticket` AS `ID_ticket`
FROM (((`operations`
  JOIN `tickets`
    ON ((`operations`.`ID_t` = `tickets`.`ID_ticket`)))
  JOIN `flights`
    ON ((`tickets`.`ID_f` = `flights`.`ID_f`)))
  JOIN `routes`
    ON ((`flights`.`ID_r` = `routes`.`ID_r`)));

--
-- Создать представление `view_full_tickes_info`
--
CREATE
DEFINER = 'root'@'localhost'
VIEW view_full_tickes_info
AS
SELECT
  `tickets`.`ID_ticket` AS `ID_ticket`,
  `operations`.`IDoperation` AS `IDoperation`,
  `operations`.`oDateTime` AS `oDateTime`,
  `tickets`.`seatTakerFirstName` AS `seatTakerFirstName`,
  `tickets`.`seatTakerLastName` AS `seatTakerLastName`,
  `tickets`.`passportSeries` AS `passportSeries`,
  `tickets`.`passportNumber` AS `passportNumber`,
  `tickets`.`birthCertificate` AS `birthCertificate`,
  `routes`.`departureP` AS `departureP`,
  `routes`.`depAirport` AS `depAirport`,
  `flights`.`fDepartureTime` AS `fDepartureTime`,
  `routes`.`destinationP` AS `destinationP`,
  `routes`.`desAirport` AS `desAirport`,
  `flights`.`fArrivalTime` AS `fArrivalTime`,
  `carriers`.`carrName` AS `carrName`,
  `airplanes`.`model` AS `model`,
  `airplanes`.`tailNum` AS `tailNum`,
  `tickets`.`seatType` AS `seatType`,
  `carriers`.`economy` AS `economy`,
  `carriers`.`comfort` AS `comfort`,
  `carriers`.`business` AS `business`,
  `carriers`.`first` AS `first`,
  `carriers`.`baggagePrice` AS `baggagePrice`,
  `carriers`.`childrenDiscount` AS `childrenDiscount`,
  `carriers`.`babiesDiscount` AS `babiesDiscount`,
  `tickets`.`baggageNum` AS `baggageNum`,
  `tickets`.`seatNum` AS `seatNum`,
  `flights`.`fPrice` AS `fPrice`,
  `operations`.`opPrice` AS `opPrice`,
  `tickets`.`ticketType` AS `ticketType`
FROM ((((((`tickets`
  JOIN `flights`
    ON ((`tickets`.`ID_f` = `flights`.`ID_f`)))
  JOIN `routes`
    ON ((`flights`.`ID_r` = `routes`.`ID_r`)))
  JOIN `operations`
    ON ((`operations`.`ID_t` = `tickets`.`ID_ticket`)))
  JOIN `clients_list`
    ON ((`operations`.`ID_cl` = `clients_list`.`ID_CL`)))
  JOIN `airplanes`
    ON ((`flights`.`ID_ap` = `airplanes`.`ID_ap`)))
  JOIN `carriers`
    ON ((`flights`.`ID_carr` = `carriers`.`ID_carr`)));

--
-- Создать представление `view_destinations_by_idcl`
--
CREATE
DEFINER = 'root'@'localhost'
VIEW view_destinations_by_idcl
AS
SELECT
  `operations`.`ID_cl` AS `ID_cl`,
  `routes`.`destinationP` AS `destinationP`
FROM (((`operations`
  JOIN `tickets`
    ON ((`operations`.`ID_t` = `tickets`.`ID_ticket`)))
  JOIN `flights`
    ON ((`tickets`.`ID_f` = `flights`.`ID_f`)))
  JOIN `routes`
    ON ((`flights`.`ID_r` = `routes`.`ID_r`)));

-- 
-- Вывод данных для таблицы routes
--
INSERT INTO routes VALUES
(16, 'г.Красноярск', 'г.Москва', 'Емельяново', 'Домодедово'),
(17, 'г.Москва', 'г.Красноярск', 'Домодедово', 'Емельяново'),
(19, 'г.Красноярск', 'г.Екатеринбург', 'Емельяново', 'Кольцово'),
(20, 'г.Красноярск', 'г.Санкт-Петербург', 'Емельяново', 'Пулково'),
(21, 'г.Красноярск', 'г.Севастополь', 'Емельяново', 'Бельбек'),
(22, 'г.Красноярск', 'г.Уфа', 'Емельяново', 'Международный аэропорт Уфа'),
(23, 'г.Красноярск', 'г.Новгород', 'Емельяново', 'Кречевицы'),
(24, 'г.Красноярск', 'г.Казань', 'Емельяново', 'Аэропорт Казань'),
(25, 'г.Москва', 'г.Екатеринбург', 'Домодедово', 'Кольцово'),
(26, 'г.Москва', 'г.Санкт-Петербург', 'Домодедово', 'Пулково'),
(27, 'г.Москва', 'г.Севастополь', 'Домодедово', 'Бельбек'),
(28, 'г.Москва', 'г.Уфа', 'Домодедово', 'Международный аэропорт Уфа'),
(29, 'г.Москва', 'г.Новгород', 'Домодедово', 'Кречевицы'),
(30, 'г.Москва', 'г.Казань', 'Домодедово', 'Аэропорт Казань'),
(31, 'г.Екатеринбург', 'г.Москва', 'Кольцово', 'Домодедово'),
(32, 'г.Екатеринбург', 'г.Красноярск', 'Кольцово', 'Емельяново'),
(33, 'г.Екатеринбург', 'г.Санкт-Петербург', 'Кольцово', 'Пулково'),
(34, 'г.Екатеринбург', 'г.Севастополь', 'Кольцово', 'Бельбек'),
(35, 'г.Екатеринбург', 'г.Уфа', 'Кольцово', 'Международный аэропорт Уфа'),
(36, 'г.Екатеринбург', 'г.Новгород', 'Кольцово', 'Кречевицы'),
(37, 'г.Екатеринбург', 'г.Казань', 'Кольцово', 'Аэропорт Казань'),
(38, 'г.Санкт-Петербург', 'г.Москва', 'Пулково', 'Домодедово'),
(39, 'г.Санкт-Петербург', 'г.Красноярск', 'Пулково', 'Емельяново'),
(40, 'г.Санкт-Петербург', 'г.Екатеринбург', 'Пулково', 'Кольцово'),
(41, 'г.Санкт-Петербург', 'г.Севастополь', 'Пулково', 'Бельбек'),
(42, 'г.Санкт-Петербург', 'г.Уфа', 'Пулково', 'Международный аэропорт Уфа'),
(43, 'г.Санкт-Петербург', 'г.Новгород', 'Пулково', 'Кречевицы'),
(44, 'г.Санкт-Петербург', 'г.Казань', 'Пулково', 'Аэропорт Казань'),
(45, 'г.Севастополь', 'г.Москва', 'Бельбек', 'Емельяново'),
(46, 'г.Севастополь', 'г.Красноярск', 'Бельбек', 'Емельяново'),
(47, 'г.Севастополь', 'г.Екатеринбург', 'Бельбек', 'Кольцово');

-- 
-- Вывод данных для таблицы carriers
--
INSERT INTO carriers VALUES
(1, 'Аэрофлот', '8005553535', 'aeroflot@af.com', 2000.00, 3000.00, 4500.00, 6000.00, 350.00, 80, 90),
(2, 'Аврора', '3912903322', 'aurora@aur.com', 1500.00, 2500.00, 3000.00, 5500.00, 300.00, 80, 100),
(3, 'КрасАвиа', '3913322554', 'krasavia@ka.com', 1500.00, 2500.00, 3500.00, 6000.00, 300.00, 85, 95);

-- 
-- Вывод данных для таблицы airplanes
--
INSERT INTO airplanes VALUES
(1, 'Airbus A320', 'RF777', 150),
(2, 'Airbus A321', 'RF435', 183),
(3, 'Airbus A320', 'RF253', 150),
(4, 'Airbus A320', 'RD876', 150),
(5, 'Airbus A320', 'RF567', 150),
(6, 'Airbus A320', 'RF221', 150);

-- 
-- Вывод данных для таблицы ticket_type
--
INSERT INTO ticket_type VALUES
(4, '-'),
(1, 'Взрослый'),
(3, 'Младенец'),
(2, 'Ребенок');

-- 
-- Вывод данных для таблицы flights
--
INSERT INTO flights VALUES
(3, '2021-12-27 00:00:00', '2021-12-27 23:52:26', 16, 1, 10000.00, 1, 1),
(4, '2021-12-28 08:00:00', '2021-12-28 14:00:00', 19, 2, 7000.00, 3, 1),
(5, '2022-01-17 00:00:00', '2021-12-17 06:00:00', 16, 1, 10000.00, 1, 14),
(6, '2022-01-17 14:00:00', '2022-12-17 20:00:00', 16, 3, 9000.00, 3, 18),
(7, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 16, 4, 12000.00, 2, 1),
(8, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 16, 5, 11000.00, 1, 0),
(9, '2022-01-17 20:00:00', '2022-01-18 02:00:00', 16, 6, 12000.00, 3, 0),
(10, '2022-01-17 18:00:00', '2022-01-18 00:00:00', 16, 1, 11000.00, 2, 0),
(11, '2022-01-17 10:30:01', '2022-01-17 16:30:00', 16, 4, 11500.00, 1, 0),
(12, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 16, 6, 11000.00, 3, 0),
(13, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 19, 1, 11000.00, 3, 1),
(14, '2022-01-17 00:00:00', '2021-12-17 06:00:00', 19, 2, 10000.00, 2, 0),
(15, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 19, 4, 12000.00, 3, 0),
(16, '2022-01-17 14:00:00', '2022-12-17 20:00:00', 16, 3, 9000.00, 3, 0),
(17, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 16, 4, 12000.00, 2, 0),
(18, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 16, 5, 11000.00, 1, 0),
(19, '2022-01-18 20:00:00', '2022-01-19 02:00:00', 16, 6, 12000.00, 3, 0),
(20, '2022-01-18 18:00:00', '2022-01-19 00:00:00', 16, 1, 11000.00, 2, 0),
(21, '2022-01-18 10:30:01', '2022-01-18 16:30:00', 16, 4, 11500.00, 1, 0),
(22, '2022-01-18 00:30:00', '2022-01-18 00:30:00', 16, 6, 11000.00, 3, 0),
(23, '2022-01-18 00:30:00', '2022-01-18 00:30:00', 19, 1, 11000.00, 3, 0),
(24, '2022-01-18 00:00:00', '2021-12-18 06:00:00', 19, 2, 10000.00, 2, 0),
(25, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 19, 4, 12000.00, 3, 0),
(26, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 16, 4, 12000.00, 2, 0),
(27, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 16, 5, 11000.00, 1, 0),
(28, '2022-01-17 20:00:00', '2022-01-18 02:00:00', 16, 6, 12000.00, 3, 0),
(29, '2022-01-17 18:00:00', '2022-01-18 00:00:00', 16, 1, 11000.00, 2, 0),
(30, '2022-01-17 10:30:01', '2022-01-17 16:30:00', 20, 4, 11500.00, 1, 1),
(31, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 20, 6, 11000.00, 3, 0),
(32, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 20, 1, 11000.00, 3, 2),
(33, '2022-01-17 00:00:00', '2021-12-17 06:00:00', 20, 2, 10000.00, 2, 0),
(34, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 20, 4, 12000.00, 3, 0),
(35, '2022-01-18 14:00:00', '2022-12-18 20:00:00', 20, 3, 9000.00, 3, 0),
(36, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 20, 4, 12000.00, 2, 0),
(37, '2022-01-19 08:00:00', '2022-01-19 14:00:00', 20, 5, 11000.00, 1, 0),
(38, '2022-01-19 20:00:00', '2022-01-20 02:00:00', 20, 6, 12000.00, 3, 0),
(39, '2022-01-19 08:00:00', '2022-01-19 14:00:00', 16, 5, 11000.00, 1, 0),
(40, '2022-01-19 20:00:00', '2022-01-20 02:00:00', 16, 6, 12000.00, 3, 0),
(41, '2022-01-19 18:00:00', '2022-01-20 00:00:00', 16, 1, 11000.00, 2, 0),
(42, '2022-01-19 10:30:01', '2022-01-19 16:30:00', 16, 4, 11500.00, 1, 0),
(43, '2022-01-19 00:30:00', '2022-01-19 00:30:00', 16, 6, 11000.00, 3, 0),
(44, '2022-01-19 00:30:00', '2022-01-19 00:30:00', 19, 1, 11000.00, 3, 0),
(45, '2022-01-19 00:00:00', '2021-12-19 06:00:00', 19, 2, 10000.00, 2, 0),
(46, '2022-01-19 08:00:00', '2022-01-19 14:00:00', 19, 4, 12000.00, 3, 0),
(47, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 16, 4, 12000.00, 2, 0),
(48, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 16, 5, 11000.00, 1, 0),
(49, '2022-01-18 20:00:00', '2022-01-19 02:00:00', 16, 6, 12000.00, 3, 0),
(50, '2022-01-18 18:00:00', '2022-01-19 00:00:00', 16, 1, 11000.00, 2, 0),
(51, '2022-01-18 10:30:01', '2022-01-18 16:30:00', 20, 4, 11500.00, 1, 0),
(52, '2022-01-18 00:30:00', '2022-01-18 00:30:00', 20, 6, 11000.00, 3, 0),
(53, '2022-01-18 00:30:00', '2022-01-18 00:30:00', 20, 1, 11000.00, 3, 0),
(54, '2022-01-18 00:00:00', '2021-12-18 06:00:00', 20, 2, 10000.00, 2, 0),
(55, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 20, 4, 12000.00, 3, 0),
(56, '2022-01-18 14:00:00', '2022-12-18 20:00:00', 20, 3, 9000.00, 3, 0),
(57, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 20, 4, 12000.00, 2, 0),
(58, '2022-01-19 08:00:00', '2022-01-19 14:00:00', 20, 5, 11000.00, 1, 0),
(59, '2022-01-19 20:00:00', '2022-01-20 02:00:00', 20, 6, 12000.00, 3, 0),
(60, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 21, 6, 11000.00, 3, 4),
(61, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 21, 1, 11000.00, 3, 0),
(62, '2022-01-17 00:00:00', '2021-12-17 06:00:00', 21, 2, 10000.00, 2, 0),
(63, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 21, 4, 12000.00, 3, 0),
(64, '2022-01-17 14:00:00', '2022-12-17 20:00:00', 21, 3, 9000.00, 3, 0),
(65, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 21, 4, 12000.00, 2, 0),
(66, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 21, 5, 11000.00, 1, 0),
(67, '2022-01-18 20:00:00', '2022-01-19 02:00:00', 21, 6, 12000.00, 3, 0),
(68, '2022-01-18 18:00:00', '2022-01-19 00:00:00', 21, 1, 11000.00, 2, 0),
(69, '2022-01-18 10:30:01', '2022-01-18 16:30:00', 21, 4, 11500.00, 1, 0),
(70, '2022-01-18 00:30:00', '2022-01-18 00:30:00', 21, 6, 11000.00, 3, 0),
(71, '2022-01-18 00:30:00', '2022-01-18 00:30:00', 21, 1, 11000.00, 3, 0),
(72, '2022-01-18 00:00:00', '2021-12-18 06:00:00', 21, 2, 10000.00, 2, 0),
(73, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 21, 4, 12000.00, 3, 0),
(74, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 21, 4, 12000.00, 2, 0),
(75, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 21, 5, 11000.00, 1, 0),
(76, '2022-01-17 20:00:00', '2022-01-18 02:00:00', 20, 6, 12000.00, 3, 0),
(77, '2022-01-17 18:00:00', '2022-01-18 00:00:00', 21, 1, 11000.00, 2, 0),
(78, '2022-01-17 10:30:01', '2022-01-17 16:30:00', 21, 4, 11500.00, 1, 0),
(79, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 21, 6, 11000.00, 3, 0),
(80, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 21, 1, 11000.00, 3, 0),
(81, '2022-01-17 00:00:00', '2021-12-17 06:00:00', 21, 2, 10000.00, 2, 0),
(82, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 21, 4, 12000.00, 3, 0),
(83, '2022-01-18 14:00:00', '2022-12-18 20:00:00', 21, 3, 9000.00, 3, 0),
(84, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 21, 4, 12000.00, 2, 0),
(85, '2022-01-19 08:00:00', '2022-01-19 14:00:00', 21, 5, 11000.00, 1, 0),
(86, '2022-01-19 20:00:00', '2022-01-20 02:00:00', 21, 6, 12000.00, 3, 0),
(87, '2022-01-19 08:00:00', '2022-01-19 14:00:00', 21, 5, 11000.00, 1, 0),
(88, '2022-01-19 20:00:00', '2022-01-20 02:00:00', 21, 6, 12000.00, 3, 0),
(89, '2022-01-19 18:00:00', '2022-01-20 00:00:00', 21, 1, 11000.00, 2, 0),
(90, '2022-01-19 10:30:01', '2022-01-19 16:30:00', 21, 4, 11500.00, 1, 0),
(91, '2022-01-19 00:30:00', '2022-01-19 00:30:00', 21, 6, 11000.00, 3, 0),
(92, '2022-01-19 00:30:00', '2022-01-19 00:30:00', 21, 1, 11000.00, 3, 0),
(93, '2022-01-19 00:00:00', '2021-12-19 06:00:00', 21, 2, 10000.00, 2, 0),
(94, '2022-01-19 08:00:00', '2022-01-19 14:00:00', 21, 4, 12000.00, 3, 0),
(95, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 21, 4, 12000.00, 2, 0),
(96, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 21, 5, 11000.00, 1, 0),
(97, '2022-01-18 20:00:00', '2022-01-19 02:00:00', 21, 6, 12000.00, 3, 0),
(98, '2022-01-18 18:00:00', '2022-01-19 00:00:00', 21, 1, 11000.00, 2, 0),
(99, '2022-01-18 10:30:01', '2022-01-18 16:30:00', 21, 4, 11500.00, 1, 0),
(100, '2022-01-18 00:30:00', '2022-01-18 00:30:00', 22, 6, 11000.00, 3, 0),
(101, '2022-01-18 00:30:00', '2022-01-18 00:30:00', 22, 1, 11000.00, 3, 0),
(102, '2022-01-18 00:00:00', '2021-12-18 06:00:00', 22, 2, 10000.00, 2, 0),
(103, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 22, 4, 12000.00, 3, 0),
(104, '2022-01-18 14:00:00', '2022-12-18 20:00:00', 23, 3, 9000.00, 3, 0),
(105, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 23, 4, 12000.00, 2, 0),
(106, '2022-01-19 08:00:00', '2022-01-19 14:00:00', 23, 5, 11000.00, 1, 4),
(107, '2022-01-19 20:00:00', '2022-01-20 02:00:00', 24, 6, 12000.00, 3, 1),
(108, '2022-01-17 00:30:00', '2022-01-17 00:30:00', 24, 1, 11000.00, 3, 0),
(109, '2022-01-17 00:00:00', '2021-12-17 06:00:00', 21, 2, 10000.00, 2, 0),
(110, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 21, 4, 12000.00, 3, 0),
(111, '2022-01-17 14:00:00', '2022-12-17 20:00:00', 25, 3, 9000.00, 3, 1),
(112, '2022-01-17 08:00:00', '2022-01-17 14:00:00', 25, 4, 12000.00, 2, 0),
(113, '2022-01-18 08:00:00', '2022-01-18 14:00:00', 25, 5, 11000.00, 1, 0),
(114, '2022-01-18 20:00:00', '2022-01-19 02:00:00', 26, 6, 12000.00, 3, 0),
(115, '2022-01-18 18:00:00', '2022-01-19 00:00:00', 27, 1, 11000.00, 2, 0),
(116, '2022-01-18 10:30:01', '2022-01-18 16:30:00', 27, 4, 11500.00, 1, 0);

-- 
-- Вывод данных для таблицы tickets
--
INSERT INTO tickets VALUES
(32, 6, 'Илья', 'Кулаков', '1234', '123456', '- ', 31, 'Взрослый', 1, 'Economy'),
(33, 6, 'Петр', 'Петров', '-', '-', 'XX-КК 123456', 32, 'Ребенок', 1, 'Economy'),
(34, 6, 'Иван', 'Иванов', '-', '-', 'II-ФФ 123456', 0, 'Младенец', 0, '-'),
(35, 6, 'Илья', 'Кулаков', '1231', '312323', '- ', 3, 'Взрослый', 1, 'Premier'),
(36, 6, 'Данил', 'Данилов', '-', '-', 'C-УУ 123456', 4, 'Ребенок', 1, 'Premier'),
(37, 6, 'Влад', 'Владов', '-', '-', 'III-ФФ 123467', 0, 'Младенец', 0, '-'),
(38, 6, 'Семен', 'Семенов', '1234', '123456', '- ', 79, 'Взрослый', 1, 'Economy'),
(39, 6, 'Игорь', 'Игорев', '-', '-', 'XX-ЦЦ 123456', 80, 'Ребенок', 1, 'Economy'),
(40, 6, 'Светлана', 'Светлая', '-', '-', 'III-ЫЫ 123567', 0, 'Младенец', 0, '-'),
(41, 6, 'марий', 'кудряшкин', '3423', '444444', '- ', 11, 'Взрослый', 1, 'Premier'),
(42, 6, 'Фаик', 'Фаикович', '1234', '123213', '- ', 119, 'Взрослый', 1, 'Economy'),
(43, 7, 'Василий', 'Васильев', '1234', '123456', '- ', 1, 'Взрослый', 1, 'Premier'),
(44, 5, 'Илья', 'Кулаков', '4123', '412412', '- ', 3, 'Взрослый', 1, 'Premier'),
(45, 5, 'test', 'test', '1234', '123456', '- ', 34, 'Взрослый', 1, 'Economy'),
(46, 5, 'Кулаков', 'Илья', '1232', '323132', '- ', 4, 'Взрослый', 1, 'Premier'),
(47, 5, 'Илья', 'Кулаков', '1234', '123456', '- ', 31, 'Взрослый', 1, 'Economy'),
(48, 5, 'Петр', 'Петров', '4321', '765432', '- ', 1, 'Взрослый', 1, 'Premier'),
(49, 5, 'Петр', 'Петров', '1234', '123456', '- ', 15, 'Взрослый', 1, 'Premier'),
(50, 5, 'Иван', 'Иванов', '1231', '423423', '- ', 16, 'Взрослый', 1, 'Premier'),
(51, 5, 'Владимир', 'Владимиров', '4234', '423424', '- ', 19, 'Взрослый', 1, 'Premier'),
(52, 5, 'Павел', 'Павлов', '4234', '423423', '- ', 20, 'Взрослый', 1, 'Premier'),
(53, 5, 'Влад', 'Владов', '1234', '123456', '- ', 91, 'Взрослый', 1, 'Economy'),
(54, 5, 'Мария', 'Марьевна', '1234', '123456', '- ', 99, 'Взрослый', 1, 'Economy'),
(55, 6, 'Федор', 'Федоров', '1234', '123455', '- ', 71, 'Взрослый', 1, 'Economy'),
(56, 6, 'Геннадий', 'Федоров', '-', '-', 'XC-ЕЕ 123456', 72, 'Ребенок', 1, 'Economy'),
(57, 13, 'Валерий', 'Валерьев', '1234', '123456', '- ', 3, 'Взрослый', 1, 'Premier'),
(58, 30, 'Николай', 'Николаев', '1234', '123456', '- ', 9, 'Взрослый', 1, 'Premier'),
(59, 32, 'Илья', 'Кулаков', '1234', '123456', '- ', 31, 'Взрослый', 1, 'Economy'),
(60, 32, 'Филипп', 'Филипенко', '1234', '123456', '- ', 3, 'Взрослый', 1, 'Premier'),
(61, 60, 'Илья', 'Кулаков', '1234', '123456', '- ', 1, 'Взрослый', 1, 'Premier'),
(62, 60, 'Павел', 'Павлов', '4321', '654321', '- ', 2, 'Взрослый', 1, 'Premier'),
(63, 60, 'Мария', 'Марева', '6789', '876543', '- ', 3, 'Взрослый', 1, 'Premier'),
(64, 60, 'Александр', 'Александров', '6789', '456789', '- ', 4, 'Взрослый', 1, 'Premier'),
(65, 106, 'Илья', 'Кулаков', '1234', '123456', '- ', 31, 'Взрослый', 1, 'Economy'),
(66, 106, 'Павел', 'Павлов', '1234', '123456', '- ', 32, 'Взрослый', 1, 'Economy'),
(67, 106, 'Иван', 'Иванов', '1234', '123456', '- ', 33, 'Взрослый', 0, 'Economy'),
(68, 106, 'Дмитрий', 'Дмитров', '1234', '123567', '- ', 34, 'Взрослый', 0, 'Economy'),
(69, 111, 'Илья', 'Кулаков', '1234', '123456', '- ', 3, 'Взрослый', 1, 'Premier'),
(70, 107, 'Илья', 'Кулаков', '1234', '234567', '- ', 31, 'Взрослый', 1, 'Economy'),
(71, 5, 'Илья', 'Кулаков', '1234', '234567', '- ', 89, 'Взрослый', 1, 'Economy'),
(72, 6, 'Илья', 'Кулаков', '1234', '345678', '- ', 1, 'Взрослый', 1, 'Premier'),
(73, 6, 'Иван', 'Иванов', '-', '-', 'XX-КК 123456', 2, 'Ребенок', 1, 'Premier'),
(74, 6, 'Павел', 'Павлов', '-', '-', 'II-ФФ 124567', 0, 'Младенец', 0, '-'),
(75, 6, 'Илья', 'Кулаков', '1234', '123456', '- ', 7, 'Взрослый', 1, 'Premier'),
(76, 6, 'Кулаков', 'Илья', '1234', '123456', '- ', 5, 'Взрослый', 1, 'Premier'),
(77, 6, 'Петр', 'Петров', '-', '-', 'II-ЦЦ 123456', 6, 'Ребенок', 1, 'Premier'),
(78, 6, 'Иван', 'Иванов', '-', '-', 'CC-ФФ 123567', 0, 'Младенец', 0, '-'),
(79, 5, 'Николай', 'Николаев', '2345', '234234', '- ', 70, 'Взрослый', 1, 'Economy'),
(80, 5, 'Иван', 'Иванов', '-', '-', 'XX-ВВ 232342', 71, 'Ребенок', 1, 'Economy'),
(81, 5, 'Анастасья', 'Настасьева', '-', '-', 'III-ФФ 123123', 0, 'Младенец', 0, '-');

-- 
-- Вывод данных для таблицы clients_list
--
INSERT INTO clients_list VALUES
(1, 'Илья', 'Кулаков', '1231231231'),
(4, 'павел', 'арбузов', '5645656363'),
(5, 'testing', 'testing', '2222222222'),
(6, 'Петр', 'Петров', '3333333333');

-- 
-- Вывод данных для таблицы operations
--
INSERT INTO operations VALUES
(29, 1, '2022-01-07 04:29:13', 32, 10500.00),
(30, 1, '2022-01-07 04:29:13', 33, 2850.00),
(31, 1, '2022-01-07 04:29:13', 34, 0.00),
(32, 1, '2022-01-07 04:35:46', 35, 12500.00),
(33, 1, '2022-01-07 04:35:46', 36, 4850.00),
(34, 1, '2022-01-07 04:35:46', 37, 0.00),
(35, 1, '2022-01-07 04:45:20', 38, 10500.00),
(36, 1, '2022-01-07 04:45:20', 39, 2850.00),
(37, 1, '2022-01-07 04:45:20', 40, 0.00),
(38, 1, '2022-01-07 05:14:48', 41, 12800.00),
(39, 1, '2022-01-07 19:34:51', 43, 15300.00),
(40, 1, '2022-01-08 21:28:24', 44, 14850.00),
(41, 5, '2022-01-08 22:00:43', 45, 12350.00),
(42, 5, '2022-01-08 23:01:12', 46, 14850.00),
(43, 1, '2022-01-09 00:01:40', 47, 12350.00),
(44, 1, '2022-01-09 00:30:11', 48, 14850.00),
(45, 1, '2022-01-09 00:58:25', 49, 14850.00),
(46, 1, '2022-01-09 00:58:25', 50, 14850.00),
(47, 1, '2022-01-09 00:58:25', 51, 14850.00),
(48, 1, '2022-01-09 00:58:25', 52, 14850.00),
(49, 1, '2022-01-09 01:10:21', 53, 12350.00),
(50, 1, '2022-01-09 01:10:21', 54, 12350.00),
(51, 1, '2022-01-09 01:14:44', 55, 10800.00),
(52, 1, '2022-01-09 01:14:44', 56, 3150.00),
(53, 1, '2022-01-09 16:46:17', 57, 14800.00),
(54, 1, '2022-01-09 16:49:58', 58, 16350.00),
(55, 1, '2022-01-09 17:03:25', 59, 12800.00),
(56, 1, '2022-01-09 19:24:01', 60, 14800.00),
(57, 1, '2022-01-09 19:26:46', 61, 14800.00),
(58, 1, '2022-01-09 19:26:46', 62, 14800.00),
(59, 1, '2022-01-09 19:26:46', 63, 14800.00),
(60, 1, '2022-01-09 19:26:46', 64, 14800.00),
(61, 1, '2022-01-09 19:59:18', 65, 13350.00),
(62, 1, '2022-01-09 19:59:18', 66, 13350.00),
(63, 1, '2022-01-09 19:59:18', 67, 13000.00),
(64, 1, '2022-01-09 19:59:18', 68, 13000.00),
(65, 1, '2022-01-09 20:07:56', 69, 12800.00),
(66, 1, '2022-01-09 20:10:00', 70, 13800.00),
(67, 1, '2022-01-10 09:41:01', 71, 12350.00),
(68, 1, '2022-01-11 11:03:57', 72, 12800.00),
(69, 1, '2022-01-11 11:03:57', 73, 5150.00),
(70, 1, '2022-01-11 11:03:57', 74, 0.00),
(71, 1, '2022-01-11 17:38:02', 75, 12800.00),
(72, 1, '2022-01-13 20:51:14', 76, 12800.00),
(73, 1, '2022-01-13 20:51:15', 77, 5150.00),
(74, 1, '2022-01-13 20:51:15', 78, 0.00),
(75, 1, '2022-01-13 21:35:23', 79, 12350.00),
(76, 1, '2022-01-13 21:35:23', 80, 4350.00),
(77, 1, '2022-01-13 21:35:23', 81, 0.00);

--
-- Установка базы данных по умолчанию
--
USE air_booking;

--
-- Удалить триггер `trigger_airplane_unical_model`
--
DROP TRIGGER IF EXISTS trigger_airplane_unical_model;

--
-- Установка базы данных по умолчанию
--
USE air_booking;

DELIMITER $$

--
-- Создать триггер `trigger_airplane_unical_model`
--
CREATE
DEFINER = 'root'@'localhost'
TRIGGER trigger_airplane_unical_model
BEFORE INSERT
ON airplanes
FOR EACH ROW
BEGIN
END
$$

DELIMITER ;

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;