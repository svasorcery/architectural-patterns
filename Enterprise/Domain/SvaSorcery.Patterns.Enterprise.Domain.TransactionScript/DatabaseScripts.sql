CREATE TABLE Products(Id int primary key, Name varchar, Type varchar)
CREATE TABLE Contracts(Id int primary key, ProductId int, Revenue decimal, DateSigned date)
CREATE TABLE RevenueRecognitions(ContractId int, Amount decimal, RecognizedAt date, PRIMARY KEY(ContractId, RecognizedAt))
