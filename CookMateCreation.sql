drop database [CookMate]
go

create database [CookMate]
go

use [CookMate]

CREATE TABLE [CookMate]..[Utilizador] (
  idUtilizador INT NOT NULL,
  nomeUtilizador VARCHAR(100) NOT NULL,
  emailUtilizador VARCHAR(100) NOT NULL,
  usernameUtilizador VARCHAR(50) NOT NULL,
  passwordUtilizador VARCHAR(50) NOT NULL,
  descricaoUtilizador VARCHAR(300) NULL,
  imagemUtilizador VARCHAR(250) NULL,
  dataNascimentoUtilizador DATE NOT NULL,
  adicionaReceitasUtilizador TINYINT NOT NULL,
  PRIMARY KEY (idUtilizador))


CREATE TABLE [CookMate]..[Categoria] (
  idCategoria INT NOT NULL,
  nomeCategoria VARCHAR(50) NOT NULL,
  PRIMARY KEY (idCategoria))


CREATE TABLE [CookMate]..[Receita] (
  idReceita INT NOT NULL,
  tituloReceita VARCHAR(150) NOT NULL,
  tempoReceita TIME NOT NULL,
  idCategoria INT NOT NULL,
  PRIMARY KEY (idReceita),
  INDEX idCategoria_idx (idCategoria ASC),
  CONSTRAINT idCategoria1
    FOREIGN KEY (idCategoria)
    REFERENCES [CookMate]..[Categoria] (idCategoria))


CREATE TABLE [CookMate]..[Ingrediente] (
  idIngrediente INT NOT NULL,
  nomeIngrediente VARCHAR(50) NOT NULL,
  valorIngrediente INT NULL,
  unidadeIngrediente VARCHAR(25) NULL,
  PRIMARY KEY (idIngrediente))


CREATE TABLE [CookMate]..[Operacao] (
  idOperacao INT NOT NULL,
  nomeOperacao VARCHAR(50) NOT NULL,
  PRIMARY KEY (idOperacao))


CREATE TABLE [CookMate]..[Passo] (
  idPasso INT NOT NULL,
  tempoPasso INT NOT NULL,
  temporizadorPasso TINYINT NOT NULL,
  idReceita INT NOT NULL,
  ordemPasso INT NOT NULL,
  idOperacao INT NOT NULL,
  PRIMARY KEY (idPasso),
  INDEX fk_Passo_Receita1_idx (idReceita ASC),
  INDEX fk_Passo_Operacao1_idx (idOperacao ASC),
  CONSTRAINT fk_Passo_Receita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (idReceita),
  CONSTRAINT fk_Passo_Operacao1
    FOREIGN KEY (idOperacao)
    REFERENCES [CookMate]..[Operacao] (idOperacao))


CREATE TABLE [CookMate]..[Ciclo] (
  idCiclo INT NOT NULL,
  primeiroPasso INT NOT NULL,
  ultimoPasso INT NOT NULL,
  idReceita INT NOT NULL,
  PRIMARY KEY (idCiclo),
  INDEX fk_Ciclo_Passo1_idx (primeiroPasso ASC),
  INDEX fk_Ciclo_Passo2_idx (ultimoPasso ASC),
  INDEX fk_Ciclo_Receita1_idx (idReceita ASC),
  CONSTRAINT primeiroPasso
    FOREIGN KEY (primeiroPasso)
    REFERENCES [CookMate]..[Passo] (idPasso),
  CONSTRAINT ultimoPasso
    FOREIGN KEY (ultimoPasso)
    REFERENCES [CookMate]..[Passo] (idPasso),
  CONSTRAINT fk_Ciclo_Receita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (idReceita))


CREATE TABLE [CookMate]..[Classificação] (
  pontuacaoClassificacao INT NOT NULL,
  comentarioClassificacao VARCHAR(300) NULL,
  idUtilizador INT UNIQUE,
  idReceita INT NOT NULL,
  INDEX idUtilizador_idx (idUtilizador ASC),
  INDEX idReceita_idx (idReceita ASC),
  PRIMARY KEY (idReceita, idUtilizador),
  CONSTRAINT idUtilizador1
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (idUtilizador),
  CONSTRAINT idReceita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (idReceita))


CREATE TABLE [CookMate]..[Avaliação] (
  pontuacaoAvaliacao INT NOT NULL,
  comentarioAvaliacao VARCHAR(300) NULL,
  idUtilizador INT UNIQUE DEFAULT 0,
  INDEX fk_Avaliação_1_idx (idUtilizador ASC),
  PRIMARY KEY (idUtilizador),
  CONSTRAINT idUtilizador2
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (idUtilizador))


CREATE TABLE [CookMate]..[Termo] (
  idTermo INT NOT NULL,
  designacaoTermo VARCHAR(50) NOT NULL,
  PRIMARY KEY (idTermo))


CREATE TABLE [CookMate]..[Video] (
  idVideo INT NOT NULL,
  ficheiroVideo VARCHAR(250) NOT NULL,
  PRIMARY KEY (idVideo))


CREATE TABLE [CookMate]..[Imagem] (
  idImagem INT NOT NULL,
  ficheiroImagem VARCHAR(250) NOT NULL,
  PRIMARY KEY (idImagem))


CREATE TABLE [CookMate]..[Descricao] (
  idDescricao INT NOT NULL,
  textoDescricao VARCHAR(500) NOT NULL,
  PRIMARY KEY (idDescricao))


CREATE TABLE [CookMate]..[Hiperligacao] (
  idHiperligacao INT NOT NULL,
  urlHiperligacao VARCHAR(250) NOT NULL,
  PRIMARY KEY (idHiperligacao))


CREATE TABLE [CookMate]..[Recurso] (
  idRecurso INT NOT NULL,
  tipoRecurso INT NOT NULL,
  idVideo INT NULL,
  idImagem INT NULL,
  idDescricao INT NULL,
  idHiperligacao INT NULL,
  PRIMARY KEY (idRecurso),
  INDEX fk_Recurso_Video1_idx (idVideo ASC),
  INDEX fk_Recurso_Imagem1_idx (idImagem ASC),
  INDEX fk_Recurso_Descricao1_idx (idDescricao ASC),
  INDEX fk_Recurso_Hiperligacao1_idx (idHiperligacao ASC),
  CONSTRAINT fk_Recurso_Video1
    FOREIGN KEY (idVideo)
    REFERENCES [CookMate]..[Video] (idVideo),
  CONSTRAINT fk_Recurso_Imagem1
    FOREIGN KEY (idImagem)
    REFERENCES [CookMate]..[Imagem] (idImagem),
  CONSTRAINT fk_Recurso_Descricao1
    FOREIGN KEY (idDescricao)
    REFERENCES [CookMate]..[Descricao] (idDescricao),
  CONSTRAINT fk_Recurso_Hiperligacao1
    FOREIGN KEY (idHiperligacao)
    REFERENCES [CookMate]..[Hiperligacao] (idHiperligacao))


CREATE TABLE [CookMate]..[PreferenciaCategoria] (
  idUtilizador INT NOT NULL,
  idCategoria INT NOT NULL,
  INDEX idUtilizador_idx (idUtilizador ASC),
  INDEX idCategoria_idx (idCategoria ASC),
  PRIMARY KEY (idUtilizador, idCategoria),
  CONSTRAINT idUtilizador3
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (idUtilizador),
  CONSTRAINT idCategoria2
    FOREIGN KEY (idCategoria)
    REFERENCES [CookMate]..[Categoria] (idCategoria))


CREATE TABLE [CookMate]..[PreferenciaIngrediente] (
  idUtilizador INT NOT NULL,
  idIngrediente INT NOT NULL,
  INDEX idUtilizador_idx (idUtilizador ASC),
  INDEX idIngrediente_idx (idIngrediente ASC),
  PRIMARY KEY (idUtilizador, idIngrediente),
  CONSTRAINT idUtilizador4
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (idUtilizador),
  CONSTRAINT idIngrediente
    FOREIGN KEY (idIngrediente)
    REFERENCES [CookMate]..[Ingrediente] (idIngrediente))


CREATE TABLE [CookMate]..[ReceitaFavorita] (
  idUtilizador INT NOT NULL,
  idReceita INT NOT NULL,
  INDEX idUtilizador_idx (idUtilizador ASC),
  INDEX idReceita_idx (idReceita ASC),
  PRIMARY KEY (idUtilizador, idReceita),
  CONSTRAINT idUtilizador5
    FOREIGN KEY (idUtilizador)
    REFERENCES [CookMate]..[Utilizador] (idUtilizador),
  CONSTRAINT idReceita2
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (idReceita))


CREATE TABLE [CookMate]..[RecursoTermo] (
  idRecurso INT NOT NULL,
  idTermo INT NOT NULL,
  ordem INT NOT NULL,
  INDEX fk_RecursoTermo_Recurso1_idx (idRecurso ASC),
  INDEX fk_RecursoTermo_Termo1_idx (idTermo ASC),
  PRIMARY KEY (idRecurso, idTermo),
  CONSTRAINT fk_RecursoTermo_Recurso1
    FOREIGN KEY (idRecurso)
    REFERENCES [CookMate]..[Recurso] (idRecurso),
  CONSTRAINT fk_RecursoTermo_Termo1
    FOREIGN KEY (idTermo)
    REFERENCES [CookMate]..[Termo] (idTermo))


CREATE TABLE [CookMate]..[RecursoPasso] (
  idRecurso INT NOT NULL,
  idPasso INT NOT NULL,
  ordem INT NOT NULL,
  INDEX fk_RecursoTermo_Recurso1_idx (idRecurso ASC),
  INDEX fk_RecursoPasso_Passo1_idx (idPasso ASC),
  PRIMARY KEY (idRecurso, idPasso),
  CONSTRAINT fk_RecursoTermo_Recurso10
    FOREIGN KEY (idRecurso)
    REFERENCES [CookMate]..[Recurso] (idRecurso),
  CONSTRAINT fk_RecursoPasso_Passo1
    FOREIGN KEY (idPasso)
    REFERENCES [CookMate]..[Passo] (idPasso))


CREATE TABLE [CookMate]..[IngredienteReceita] (
  idIngrediente INT NOT NULL,
  idReceita INT NOT NULL,
  INDEX fk_IngredienteReceita_Ingrediente1_idx (idIngrediente ASC),
  INDEX fk_IngredienteReceita_Receita1_idx (idReceita ASC),
  PRIMARY KEY (idIngrediente, idReceita),
  CONSTRAINT fk_IngredienteReceita_Ingrediente1
    FOREIGN KEY (idIngrediente)
    REFERENCES [CookMate]..[Ingrediente] (idIngrediente),
  CONSTRAINT fk_IngredienteReceita_Receita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (idReceita))


CREATE TABLE [CookMate]..[Utensilio] (
  idUtensilio INT NOT NULL,
  nomeUtensilio VARCHAR(50) NOT NULL,
  PRIMARY KEY (idUtensilio))


CREATE TABLE [CookMate]..[UtensilioReceita] (
  idUtensilio INT NOT NULL,
  idReceita INT NOT NULL,
  INDEX fk_IngredienteReceita_Receita1_idx (idReceita ASC),
  INDEX fk_UtensilioReceita_Utensilio1_idx (idUtensilio ASC),
  PRIMARY KEY (idUtensilio, idReceita),
  CONSTRAINT fk_IngredienteReceita_Receita10
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (idReceita),
  CONSTRAINT fk_UtensilioReceita_Utensilio1
    FOREIGN KEY (idUtensilio)
    REFERENCES [CookMate]..[Utensilio] (idUtensilio))


CREATE TABLE [CookMate]..[RecursoReceita] (
  idRecurso INT NOT NULL,
  idReceita INT NOT NULL,
  ordem INT NOT NULL,
  INDEX fk_RecursoTermo_Recurso1_idx (idRecurso ASC),
  INDEX fk_RecursoReceita_Receita1_idx (idReceita ASC),
  PRIMARY KEY (idRecurso, idReceita),
  CONSTRAINT fk_RecursoTermo_Recurso11
    FOREIGN KEY (idRecurso)
    REFERENCES [CookMate]..[Recurso] (idRecurso),
  CONSTRAINT fk_RecursoReceita_Receita1
    FOREIGN KEY (idReceita)
    REFERENCES [CookMate]..[Receita] (idReceita))


CREATE TABLE [CookMate]..[IngredientePasso] (
  idIngrediente INT NOT NULL,
  idPasso INT NOT NULL,
  INDEX fk_Ingrediente_has_Passo_Passo1_idx (idPasso ASC),
  INDEX fk_Ingrediente_has_Passo_Ingrediente1_idx (idIngrediente ASC),
  PRIMARY KEY (idIngrediente, idPasso),
  CONSTRAINT fk_Ingrediente_has_Passo_Ingrediente1
    FOREIGN KEY (idIngrediente)
    REFERENCES [CookMate]..[Ingrediente] (idIngrediente),
  CONSTRAINT fk_Ingrediente_has_Passo_Passo1
    FOREIGN KEY (idPasso)
    REFERENCES [CookMate]..[Passo] (idPasso))
go
