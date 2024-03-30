-- Tabela Clientes
CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100),
    CPF VARCHAR(11) UNIQUE,
    UF CHAR(2),
    Celular VARCHAR(20)
);

-- Tabela Financiamentos
CREATE TABLE Financiamentos (
    IdFinanciamento INT PRIMARY KEY IDENTITY,
    IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente),
    TipoFinanciamento NVARCHAR(50),
    ValorTotal DECIMAL(18, 2),
    DataUltimoVencimento DATE
);

-- Tabela Parcelas
CREATE TABLE Parcelas (
    IdParcela INT PRIMARY KEY IDENTITY,
    IdFinanciamento INT FOREIGN KEY REFERENCES Financiamentos(IdFinanciamento),
    NumeroParcela INT,
    ValorParcela DECIMAL(18, 2),
    DataVencimento DATE,
    DataPagamento DATE
);


-- Inserir dados na tabela Clientes
INSERT INTO Clientes (Nome, CPF, UF, Celular)
VALUES
    ('João Silva', '12345678901', 'SP', '(11) 98765-4321'),
    ('Maria Santos', '98765432109', 'RJ', '(21) 12345-6789'),
    ('Carlos Oliveira', '23456789012', 'SP', '(11) 54321-6789');

-- Inserir dados na tabela Financiamentos
INSERT INTO Financiamentos (IdCliente, TipoFinanciamento, ValorTotal, DataUltimoVencimento)
VALUES
    (1, 'Imobiliário', 1000000.00, '2024-12-31'),
    (2, 'Pessoal', 5000.00, '2024-06-30'),
    (3, 'Empresarial', 20000.00, '2024-09-30');
	
-- Inserir dados na tabela Parcelas
INSERT INTO Parcelas (IdFinanciamento, NumeroParcela, ValorParcela, DataVencimento, DataPagamento)
VALUES
    (1, 1, 20000.00, '2023-01-15', '2023-01-10'),
    (1, 2, 20000.00, '2023-02-15', '2023-02-10'),
    (1, 3, 20000.00, '2023-03-15', '2023-03-10'),
    (2, 1, 1000.00, '2023-01-10', '2023-01-10'),
    (2, 2, 1000.00, '2023-02-10', '2023-02-10'),
    (3, 1, 5000.00, '2023-01-05', '2023-01-01'),
	(1, 4, 20000.00, '2022-12-15', NULL),
    (1, 5, 20000.00, '2022-11-15', NULL),
    (2, 3, 1000.00, '2022-12-10', NULL),
    (3, 2, 5000.00, '2023-01-05', NULL);



SELECT c.*
FROM Clientes c
WHERE c.UF = 'SP'
AND EXISTS (
    SELECT 1
    FROM Financiamentos f
    INNER JOIN Parcelas p ON f.IdFinanciamento = p.IdFinanciamento
    WHERE f.IdCliente = c.IdCliente
    GROUP BY f.IdCliente
    HAVING SUM(CASE WHEN p.DataPagamento IS NOT NULL THEN 1 ELSE 0 END) / COUNT(*) > 0.6
);


SELECT TOP 4 c.*
FROM Clientes c
WHERE EXISTS (
    SELECT 1
    FROM Financiamentos f
    INNER JOIN Parcelas p ON f.IdFinanciamento = p.IdFinanciamento
    WHERE f.IdCliente = c.IdCliente
    AND p.DataVencimento < GETDATE()
    AND p.DataPagamento IS NULL
);
