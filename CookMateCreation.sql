drop database [CookMate]
go

create database [CookMate]
go

use [CookMate]

CREATE TABLE [CookMate]..[Utilizador] (
  id INT NOT NULL,
  nome VARCHAR(100) NOT NULL,
  email VARCHAR(100) NOT NULL,
  username VARCHAR(50) NOT NULL,
  password VARCHAR(50) NOT NULL,
  descricao VARCHAR(300) NULL,
  imagem VARCHAR(250) NULL,
  dataNascimento DATE NOT NULL,
  adicionaReceitas TINYINT NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Categoria] (
  id INT NOT NULL,
  nome VARCHAR(50) NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Receita] (
  id INT NOT NULL,
  titulo VARCHAR(150) NOT NULL,
  tempo TIME NOT NULL,
  idCategoria INT NOT NULL,
  PRIMARY KEY (id),
  INDEX idCategoria_idx (idCategoria ASC),
  CONSTRAINT idCategoria1
    FOREIGN KEY (idCategoria)
    REFERENCES [CookMate]..[Categoria] (id))


CREATE TABLE [CookMate]..[Ingrediente] (
  id INT NOT NULL,
  nome VARCHAR(50) NOT NULL,
  valor INT NULL,
  unidade VARCHAR(25) NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Operacao] (
  id INT NOT NULL,
  nome VARCHAR(50) NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Passo] (
  id INT NOT NULL,
  tempo INT NOT NULL,
  temporizador TINYINT NOT NULL,
  idReceita INT NOT NULL,
  ordem INT NOT NULL,
  idOperacao INT NOT NULL,
  PRIMARY KEY (id),
  INDEX fk_Passo_Receita1_idx (idReceita ASC),
  INDEX fk_Passo_Operacao1_idx (idOperacao ASC),
  CONSTRAINT fk_Passo_Receita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (id),
  CONSTRAINT fk_Passo_Operacao1
    FOREIGN KEY (idOperacao)
    REFERENCES [CookMate]..[Operacao] (id))


CREATE TABLE [CookMate]..[Ciclo] (
  id INT NOT NULL,
  primeiroPasso INT NOT NULL,
  ultimoPasso INT NOT NULL,
  idReceita INT NOT NULL,
  PRIMARY KEY (id),
  INDEX fk_Ciclo_Passo1_idx (primeiroPasso ASC),
  INDEX fk_Ciclo_Passo2_idx (ultimoPasso ASC),
  INDEX fk_Ciclo_Receita1_idx (idReceita ASC),
  CONSTRAINT primeiroPasso
    FOREIGN KEY (primeiroPasso)
    REFERENCES [CookMate]..[Passo] (id),
  CONSTRAINT ultimoPasso
    FOREIGN KEY (ultimoPasso)
    REFERENCES [CookMate]..[Passo] (id),
  CONSTRAINT fk_Ciclo_Receita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (id))


CREATE TABLE [CookMate]..[Classificacao] (
  pontuacao INT NOT NULL,
  comentario VARCHAR(300) NULL,
  idUtilizador INT UNIQUE,
  idReceita INT NOT NULL,
  INDEX idUtilizador_idx (idUtilizador ASC),
  INDEX idReceita_idx (idReceita ASC),
  PRIMARY KEY (idReceita, idUtilizador),
  CONSTRAINT idUtilizador1
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (id),
  CONSTRAINT idReceita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (id))


CREATE TABLE [CookMate]..[Avaliacao] (
  pontuacao INT NOT NULL,
  comentario VARCHAR(300) NULL,
  idUtilizador INT UNIQUE DEFAULT 0,
  INDEX fk_Avaliação_1_idx (idUtilizador ASC),
  PRIMARY KEY (idUtilizador),
  CONSTRAINT idUtilizador2
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (id))


CREATE TABLE [CookMate]..[Termo] (
  id INT NOT NULL,
  designacao VARCHAR(50) NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Video] (
  id INT NOT NULL,
  ficheiro VARCHAR(250) NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Imagem] (
  id INT NOT NULL,
  ficheiro VARCHAR(250) NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Descricao] (
  id INT NOT NULL,
  texto VARCHAR(500) NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Hiperligacao] (
  id INT NOT NULL,
  url VARCHAR(250) NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[Recurso] (
  id INT NOT NULL,
  tipo INT NOT NULL,
  idVideo INT NULL,
  idImagem INT NULL,
  idDescricao INT NULL,
  idHiperligacao INT NULL,
  PRIMARY KEY (id),
  INDEX fk_Recurso_Video1_idx (idVideo ASC),
  INDEX fk_Recurso_Imagem1_idx (idImagem ASC),
  INDEX fk_Recurso_Descricao1_idx (idDescricao ASC),
  INDEX fk_Recurso_Hiperligacao1_idx (idHiperligacao ASC),
  CONSTRAINT fk_Recurso_Video1
    FOREIGN KEY (idVideo)
    REFERENCES [CookMate]..[Video] (id),
  CONSTRAINT fk_Recurso_Imagem1
    FOREIGN KEY (idImagem)
    REFERENCES [CookMate]..[Imagem] (id),
  CONSTRAINT fk_Recurso_Descricao1
    FOREIGN KEY (idDescricao)
    REFERENCES [CookMate]..[Descricao] (id),
  CONSTRAINT fk_Recurso_Hiperligacao1
    FOREIGN KEY (idHiperligacao)
    REFERENCES [CookMate]..[Hiperligacao] (id))


CREATE TABLE [CookMate]..[PreferenciaCategoria] (
  idUtilizador INT NOT NULL,
  idCategoria INT NOT NULL,
  INDEX idUtilizador_idx (idUtilizador ASC),
  INDEX idCategoria_idx (idCategoria ASC),
  PRIMARY KEY (idUtilizador, idCategoria),
  CONSTRAINT idUtilizador3
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (id),
  CONSTRAINT idCategoria2
    FOREIGN KEY (idCategoria)
    REFERENCES [CookMate]..[Categoria] (id))


CREATE TABLE [CookMate]..[PreferenciaIngrediente] (
  idUtilizador INT NOT NULL,
  idIngrediente INT NOT NULL,
  INDEX idUtilizador_idx (idUtilizador ASC),
  INDEX idIngrediente_idx (idIngrediente ASC),
  PRIMARY KEY (idUtilizador, idIngrediente),
  CONSTRAINT idUtilizador4
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (id),
  CONSTRAINT idIngrediente
    FOREIGN KEY (idIngrediente)
    REFERENCES [CookMate]..[Ingrediente] (id))


CREATE TABLE [CookMate]..[ReceitaFavorita] (
  idUtilizador INT NOT NULL,
  idReceita INT NOT NULL,
  INDEX idUtilizador_idx (idUtilizador ASC),
  INDEX idReceita_idx (idReceita ASC),
  PRIMARY KEY (idUtilizador, idReceita),
  CONSTRAINT idUtilizador5
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (id),
  CONSTRAINT idReceita2
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (id))


CREATE TABLE [CookMate]..[RecursoTermo] (
  idRecurso INT NOT NULL,
  idTermo INT NOT NULL,
  ordem INT NOT NULL,
  INDEX fk_RecursoTermo_Recurso1_idx (idRecurso ASC),
  INDEX fk_RecursoTermo_Termo1_idx (idTermo ASC),
  PRIMARY KEY (idRecurso, idTermo),
  CONSTRAINT fk_RecursoTermo_Recurso1
    FOREIGN KEY (idRecurso)
    REFERENCES [CookMate]..[Recurso] (id),
  CONSTRAINT fk_RecursoTermo_Termo1
    FOREIGN KEY (idTermo)
    REFERENCES [CookMate]..[Termo] (id))


CREATE TABLE [CookMate]..[RecursoPasso] (
  idRecurso INT NOT NULL,
  idPasso INT NOT NULL,
  ordem INT NOT NULL,
  INDEX fk_RecursoTermo_Recurso1_idx (idRecurso ASC),
  INDEX fk_RecursoPasso_Passo1_idx (idPasso ASC),
  PRIMARY KEY (idRecurso, idPasso),
  CONSTRAINT fk_RecursoTermo_Recurso10
    FOREIGN KEY (idRecurso)
    REFERENCES [CookMate]..[Recurso] (id),
  CONSTRAINT fk_RecursoPasso_Passo1
    FOREIGN KEY (idPasso)
    REFERENCES [CookMate]..[Passo] (id))


CREATE TABLE [CookMate]..[IngredienteReceita] (
  idIngrediente INT NOT NULL,
  idReceita INT NOT NULL,
  INDEX fk_IngredienteReceita_Ingrediente1_idx (idIngrediente ASC),
  INDEX fk_IngredienteReceita_Receita1_idx (idReceita ASC),
  PRIMARY KEY (idIngrediente, idReceita),
  CONSTRAINT fk_IngredienteReceita_Ingrediente1
    FOREIGN KEY (idIngrediente)
    REFERENCES [CookMate]..[Ingrediente] (id),
  CONSTRAINT fk_IngredienteReceita_Receita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (id))


CREATE TABLE [CookMate]..[Utensilio] (
  id INT NOT NULL,
  nome VARCHAR(50) NOT NULL,
  PRIMARY KEY (id))


CREATE TABLE [CookMate]..[UtensilioReceita] (
  idUtensilio INT NOT NULL,
  idReceita INT NOT NULL,
  INDEX fk_IngredienteReceita_Receita1_idx (idReceita ASC),
  INDEX fk_UtensilioReceita_Utensilio1_idx (idUtensilio ASC),
  PRIMARY KEY (idUtensilio, idReceita),
  CONSTRAINT fk_IngredienteReceita_Receita10
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (id),
  CONSTRAINT fk_UtensilioReceita_Utensilio1
    FOREIGN KEY (idUtensilio)
    REFERENCES [CookMate]..[Utensilio] (id))


CREATE TABLE [CookMate]..[RecursoReceita] (
  idRecurso INT NOT NULL,
  idReceita INT NOT NULL,
  ordem INT NOT NULL,
  INDEX fk_RecursoTermo_Recurso1_idx (idRecurso ASC),
  INDEX fk_RecursoReceita_Receita1_idx (idReceita ASC),
  PRIMARY KEY (idRecurso, idReceita),
  CONSTRAINT fk_RecursoTermo_Recurso11
    FOREIGN KEY (idRecurso)
    REFERENCES [CookMate]..[Recurso] (id),
  CONSTRAINT fk_RecursoReceita_Receita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (id))


CREATE TABLE [CookMate]..[IngredientePasso] (
  idIngrediente INT NOT NULL,
  idPasso INT NOT NULL,
  INDEX fk_Ingrediente_has_Passo_Passo1_idx (idPasso ASC),
  INDEX fk_Ingrediente_has_Passo_Ingrediente1_idx (idIngrediente ASC),
  PRIMARY KEY (idIngrediente, idPasso),
  CONSTRAINT fk_Ingrediente_has_Passo_Ingrediente1
    FOREIGN KEY (idIngrediente)
    REFERENCES [CookMate]..[Ingrediente] (id),
  CONSTRAINT fk_Ingrediente_has_Passo_Passo1
    FOREIGN KEY (idPasso)
    REFERENCES [CookMate]..[Passo] (id))
go
