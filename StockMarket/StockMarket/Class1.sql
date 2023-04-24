using System.Collections.Generic;

CREATE TABLE stocks (
  StockId CHAR(36) NOT NULL,
  StockName VARCHAR(20) NOT NULL,
  StockSymbol VARCHAR(15) NOT NULL,
  Price DECIMAL(10, 2) NOT NULL,
  CreationDate DATE NOT NULL,
PRIMARY KEY (StockId)
);

INSERT INTO stocks (StockId, StockName, StockSymbol, Price, CreationDate)
VALUES
('1', 'Reliance Industries Ltd', 'RELIANCE', '2,102.65', '2023-04-24'),
('2', 'Tata Consultancy Services Ltd', 'TCS', '3,124.05', '2023-04-24'),
('3', 'HDFC Bank Ltd', 'HDFCBANK', '1,454.95', '2023-04-24'),
('4', 'Hindustan Unilever Ltd', 'HINDUNILVR', '2,580.55', '2023-04-24'),
('5', 'Infosys Ltd', 'INFY', '1,440.75', '2023-04-24'),
('6', 'ICICI Bank Ltd', 'ICICIBANK', '758.15', '2023-04-24'),
('7', 'Kotak Mahindra Bank Ltd', 'KOTAKBANK', '1,988.55', '2023-04-24'),
('8', 'Bajaj Finance Ltd', 'BAJFINANCE', '7,327.25', '2023-04-24'),
('9', 'Axis Bank Ltd', 'AXISBANK', '780.75', '2023-04-24'),
('10', 'State Bank of India', 'SBIN', '461.95', '2023-04-24');
