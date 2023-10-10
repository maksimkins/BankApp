Use Bank

insert into Clients values
('alex', 'mypassword', 45.25),
('maks', '123654', 785),
('myaccount', 'password', 72),
('durakonline', 'durakonline', 0),
('mrmiyagi', 'monarch', 12)

DECLARE @date date = '2023-10-09';

insert into LoanClients values
(800, 0, 0, 12, 12, @date, 1),
(800, 0, 0, 25, 25, @date, 2),
(800, 0, 0, 12, 24, @date, 3)

insert into DebtorClients values
(50000, 5)


