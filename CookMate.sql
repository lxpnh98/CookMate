Use Cookmate;

INSERT INTO CookMate..Utilizador (nome, email, username,  password, podeAdicionarReceita)
    VALUES('Ola'   , 'abc1@email.com' , 'abc1' , 'abc1' , 0 ),
          ('Ola 1' , 'abc2@email.com' , 'abc2' , 'abc2' , 0 ),
          ('Ola 2' , 'abc3@email.com' , 'abc3' , 'abc3' , 0 ),
          ('Ola 3' , 'abc4@email.com' , 'abc4' , 'abc4' , 0 ),
          ('Ola 4' , 'abc5@email.com' , 'abc5' , 'abc5' , 0 );

SELECT * FROM CookMate..Utilizador;


Use Cookmate;

INSERT INTO CookMate..Utilizador (nome, email, username,  password, podeAdicionarReceita, descricao, imagePath, admin)
    VALUES('Ola 5'   , 'iamadmin@email.com' , 'admin1' , 'admin1' , 1, 'i am admin', , 1);

SELECT * FROM CookMate..Utilizador;


Use Cookmate;

INSERT INTO CookMate..Receita (titulo, tempo, idCategoria)
    VALUES('Receita1', '15:30' , 1);

SELECT * FROM CookMate..Receita;
