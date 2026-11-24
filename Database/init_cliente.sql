

CREATE TABLE cliente (
    id_cliente SERIAL PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    email VARCHAR(150) NOT NULL,
    telefone VARCHAR(20),
    data_nascimento DATE,
    ativo BOOLEAN NOT NULL DEFAULT TRUE
);

INSERT INTO cliente
(nome, cpf, email, telefone, data_nascimento, ativo)
VALUES
('Ana Silva', '111.111.111-11', 'ana@example.com', '(11) 99999-1111', '2000-05-10', TRUE),
('Bruno Santos', '222.222.222-22', 'bruno@example.com', '(11) 99999-2222', '1998-08-15', TRUE),
('Carla Oliveira', '333.333.333-33', 'carla@example.com', '(11) 99999-3333', '2002-03-20', TRUE),
('Daniel Costa', '444.444.444-44', 'daniel@example.com', '(11) 99999-4444', '1995-12-01', TRUE),
('Eduarda Lima', '555.555.555-55', 'eduarda@example.com', '(11) 99999-5555', '2001-07-25', FALSE);
