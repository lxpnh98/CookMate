using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookMate.Models
{
    public static class SeedData
    {
        // Mudar o path do repositório para ter acesso aos recursos
        static private String gitRepoAbsolutePath = "D:\\Desktop\\LI4\\CookMate\\";

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UtilizadorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UtilizadorContext>>()))
            {
                
                //TODO: ver isto
                if (context.Utilizador.Any())
                {
                    return;   // DB has been seeded
                }

                // Add utilizadores
                var utilizadores = new List<Utilizador>
                {
                    new Utilizador
                    {
                        nome = "Miguel",
                        email = "miguel@gmail.com",
                        username = "mikl",
                        password = "password",
                        podeAdicionarReceita = false,
                        imagePath = "",
                        descricao = "",
                        admin = false
                    },
                    new Utilizador
                    {
                        nome = "Joel",
                        email = "joel@gmail.com",
                        username = "joel",
                        password = "password",
                        podeAdicionarReceita = false,
                        imagePath = "",
                        descricao = "",
                        admin = false
                    },
                    new Utilizador
                    {
                        nome = "Tiago",
                        email = "tiago@gmail.com",
                        username = "tiago",
                        password = "password",
                        podeAdicionarReceita = false,
                        imagePath = "",
                        descricao = "",
                        admin = false
                    },
                    new Utilizador
                    {
                        nome = "Alexandre",
                        email = "alexandre@gmail.com",
                        username = "alex",
                        password = "password",
                        podeAdicionarReceita = false,
                        imagePath = "",
                        descricao = "",
                        admin = false
                    },
                    new Utilizador
                    {
                        nome = "Admin",
                        email = "iamadmin@email.com",
                        username = "admin1",
                        password = "admin1",
                        podeAdicionarReceita = true,
                        imagePath = "",
                        descricao = "i am admin",
                        admin = true
                    }
                };
                context.Utilizador.AddRange(utilizadores);
                //context.SaveChanges();

                // Add categoria
                var categorias = new List<Categoria>
                {
                    new Categoria{ nome = "Categoria 1" },
                    new Categoria{ nome = "Categoria 2" },
                    new Categoria{ nome = "Bolos" }
                };
                context.Categoria.AddRange(categorias);
                context.SaveChanges();

                // UtilizadorCategoria

                context.AddRange(
                    new UtilizadorCategoria { Utilizador = utilizadores[0], Categoria = categorias[0] },
                    new UtilizadorCategoria { Utilizador = utilizadores[1], Categoria = categorias[0] },
                    new UtilizadorCategoria { Utilizador = utilizadores[1], Categoria = categorias[1] }
                );
                //context.SaveChanges();

                // Até aqui dá

                // Add Receita
                var receitas = new List<Receita>
                {
                    new Receita { titulo = "Bolo de Bolacha", dificuldade = 3, valorEnergetico = 4000, imagem = "https://www.saborintenso.com/attachments/videos-doces/375d1252681021-bolo-bolacha-bolo-bolacha-1.jpg", tempo = new TimeSpan(2,30,0), idCategoria = categorias[2].id, Categoria = categorias[2]}
                };
                context.Receita.AddRange(receitas);
                //context.SaveChanges();

                //Add Utensilios
                // nome < 50 chars
                var utensilios = new List<Utensilio> {
                    new Utensilio { nome = "Forma de 20cm com base lisa e solta" },
                    new Utensilio { nome = "Colher para molhar as bolachas" },
                    new Utensilio { nome = "Taça para bater a manteiga" },
                    new Utensilio { nome = "Taça para o café" },
                    new Utensilio { nome = "Batedeira elétrica" }
                };
                context.Utensilio.AddRange(utensilios);
                context.SaveChanges();

                // UtensilioReceita
                context.AddRange(
                    new UtensilioReceita { Utensilio = utensilios[0], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[1], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[2], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[3], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[4], Receita = receitas[0] }
                );
                //context.SaveChanges();

                //Add Classificação
                context.Classificao.AddRange(
                    new Classificacao {
                        idUtilizador = utilizadores[1].id,
                        Utilizador = utilizadores[1],
                        idReceita = receitas[0].id,
                        Receita = receitas[0],
                        pontuacao = 5,
                        comentario = "OMG best receita eva!!1!1"
                    },
                    new Classificacao
                    {
                        idUtilizador = utilizadores[3].id,
                        Utilizador = utilizadores[3],
                        idReceita = receitas[0].id,
                        Receita = receitas[0],
                        pontuacao = 3,
                        comentario = "Meh"
                    }
                );

                // TODO: Add ciclo

                // Add UtilizadorReceita (receitas favoritas)
                context.AddRange(
                    new UtilizadorReceita { idReceita = receitas[0].id, idUtilizador = utilizadores[0].id },
                    new UtilizadorReceita { idReceita = receitas[0].id, idUtilizador = utilizadores[3].id }
                );


                //Add Ingredientes
                var ingredientes = new List<Ingrediente>
                {
                    new Ingrediente
                    {
                        nome = "Bolacha Maria",
                        valor = 2,
                        unidade = "pacote"
                    },
                    new Ingrediente
                    {
                        nome = "Manteiga",
                        valor = 250,
                        unidade = "grama"
                    },
                    new Ingrediente
                    {
                        nome = "Açúcar fino RAR",
                        valor = 200,
                        unidade = "grama"
                    },
                    new Ingrediente
                    {
                        nome = "Ovo",
                        valor = 3,
                        unidade = "unidade"
                    },
                    new Ingrediente
                    {
                        nome = "Café solúvel",
                        valor = 0,
                        unidade = "q.b."
                    }
                };
                context.Ingrediente.AddRange(ingredientes);

                // IngredienteReceita

                context.AddRange(
                    new IngredienteReceita { Receita = receitas[0], Ingrediente = ingredientes[0] },
                    new IngredienteReceita { Receita = receitas[0], Ingrediente = ingredientes[1] },
                    new IngredienteReceita { Receita = receitas[0], Ingrediente = ingredientes[2] },
                    new IngredienteReceita { Receita = receitas[0], Ingrediente = ingredientes[3] },
                    new IngredienteReceita { Receita = receitas[0], Ingrediente = ingredientes[4] }
                );

                // TODO: UtilizadorIngrediente

                var passos = new List<Passo>
                {
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 1,titulo = "Make coffee and set aside.",
                        tempo = 2,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 2,titulo = "Separate the yolks from the egg whites and reserve the egg yolks.",
                        tempo = 1,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 3,titulo = "In a bowl, beat the butter until the cream is white.",
                        tempo = 1,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 4,titulo = "Add sugar slowly, while beating until completely dissolved.",
                        tempo = 2,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 5,titulo = "Add one gem at a time, also while beating.",
                        tempo = 1,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 6,titulo = "Continue to beat everything until the cream is homogeneous.",
                        tempo = 2,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 7,titulo = "Make sure the coffee is cold and put the biscuits over the coffee, one at a time.",
                        tempo = 1,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 8,titulo = "Place a wafer in the center of the shape and 6 wafers around it, sweep them with the cream.",
                        tempo = 1,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 9,titulo = "Make another layer of cookies and sweep the cookies again.",
                        tempo = 2,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 10,titulo = "Repeat the process until the wafers are gone.",
                        tempo = 10,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 11,titulo = "Decorate with grated wafer.",
                        tempo = 1,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 12,titulo = "Take to the refrigerator for 2 hours.",
                        tempo = 120,
                        temporizador = true,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 13,titulo = "Unmold and serve.",
                        tempo = 1,
                        temporizador = false,
                        idOperacao = 0,
                    }
                };
                context.Passo.AddRange(passos);

                //Video
                var videos = new List<Video>
                {
                    new Video { ficheiro = "https://www.youtube.com/embed/dQw4w9WgXcQ" }
                };
                context.Video.AddRange(videos);

                //Imagem
                var imagens = new List<Imagem>
                {
                    new Imagem { ficheiro = "https://i.kym-cdn.com/entries/icons/original/000/016/212/manning.png" }
                };
                context.Imagem.AddRange(imagens);

                //Descrição
                var descricoes = new List<Descricao>
                {
                    new Descricao { texto = "Um bolo de bolacha de café delicioso" }
                };
                context.Descricao.AddRange(descricoes);

                //Hiperligação
                var hiperligacoes = new List<Hiperligacao>
                {
                    new Hiperligacao { url = "https://www.teleculinaria.pt/receitas/doces-e-sobremesas//bolo-bolacha-cafe/" }
                };
                context.Hiperligacao.AddRange(hiperligacoes);
                context.SaveChanges();

                // Recurso
                var recursos = new List<Recurso>
                {
                    new Recurso {tipo = 0, idVideo = videos[0].id},
                    new Recurso {tipo = 1, idImagem = imagens[0].id},
                    new Recurso {tipo = 2, idDescricao = descricoes[0].id},
                    new Recurso {tipo = 3, idHiperligacao = hiperligacoes[0].id}
                };
                context.Recurso.AddRange(recursos);

                // RecursoReceita
                context.AddRange(
                    new RecursoReceita { ordem = 2, idReceita = receitas[0].id, idRecurso = recursos[0].id},
                    new RecursoReceita { ordem = 3, idReceita = receitas[0].id, idRecurso = recursos[1].id},
                    new RecursoReceita { ordem = 1, idReceita = receitas[0].id, idRecurso = recursos[2].id},
                    new RecursoReceita { ordem = 4, idReceita = receitas[0].id, idRecurso = recursos[3].id}
                );

                // RecursoReceita
                context.AddRange(
                    new RecursoPasso { ordem = 1, idPasso = passos[0].id, idRecurso = recursos[0].id},
                    new RecursoPasso { ordem = 2, idPasso = passos[0].id, idRecurso = recursos[1].id},
                    new RecursoPasso { ordem = 1, idPasso = passos[1].id, idRecurso = recursos[2].id},
                    new RecursoPasso { ordem = 1, idPasso = passos[2].id, idRecurso = recursos[3].id}
                );

                // Avaliação
                var avaliacoes = new List<Avaliacao>
                {
                    new Avaliacao{idUtilizador = utilizadores[3].id, pontuacao = 5, comentario = "Muito bom, está de parabéns!"},
                    new Avaliacao{idUtilizador = utilizadores[0].id, pontuacao = 1, comentario = "Não cozinha por mim, só não dou menos pq não dá"}
                };
                context.AddRange(avaliacoes);


                context.SaveChanges();
                

            }
        }
    }
}
