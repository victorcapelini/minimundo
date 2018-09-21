INSERT INTO Empresa (CNPJ, DataDeCadastro, Nome, RazaoSocial)
VALUES ('83.768.287/0001-21', '2017-06-01 11:53:48.3814412', 'Empresa Teste 1', 'Razao Social Teste 1');
INSERT INTO Empresa (CNPJ, DataDeCadastro, Nome, RazaoSocial)
VALUES ('83.768.287/0001-21', '2018-06-11 05:37:48.3814412', 'Empresa Teste 2', 'Razao Social Teste 2');
INSERT INTO Empresa (CNPJ, DataDeCadastro, Nome, RazaoSocial)
VALUES ('83.768.287/0001-21', '2018-09-05 01:53:44.3814412', 'Empresa Teste 3', 'Razao Social Teste 3');

INSERT INTO Colaborador (Cargo, DataDeContratacao, DataDeDemissao, EmpresaId, PessoaId, Salario, Status)
VALUES ('ProPlayer', '2018-09-05 01:53:44.3814412', '2018-09-05 01:53:44.3814412', 1, 1, 5000, 'Contratado');

    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Cargo]             NVARCHAR (MAX) NOT NULL,
    [DataDeContratacao] DATETIME2 (7)  NOT NULL,
    [DataDeDemissao]    DATETIME2 (7)  NOT NULL,
    [EmpresaId]         INT            NOT NULL,
    [PessoaId]          INT            NOT NULL,
    [Salario]           FLOAT (53)     NOT NULL,
    [Status] 