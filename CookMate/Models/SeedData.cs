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
                    new Receita { titulo = "Bolo de Bolacha", tempo = new TimeSpan(2,30,0), idCategoria = categorias[2].id, Categoria = categorias[2]}
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

                // TODO: Add UtilizadorReceita
                //context.AddRange(
                //    new UtilizadorReceita { Receita = receitas[0],  },    
                //);


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
                        unidade = "g"
                    },
                    new Ingrediente
                    {
                        nome = "Açúcar fino RAR",
                        valor = 200,
                        unidade = "g"
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

                // TODO: Passo 

                var passos = new List<Passo>
                {
                    new Passo
                    {
                        tempo = 10,
                        temporizador = true,
                        idReceita = receitas[0].id,
                        titulo = "test",
                        idOperacao = 0,
                        ordem = 1
                    }
                };
                context.Passo.AddRange(passos);


                //Video
                var videos = new List<Video>
                {
                    new Video { ficheiro = gitRepoAbsolutePath + "Recursos\\Video\\bolo_de_bolacha.mp4" }
                };
                context.Video.AddRange(videos);

                //Imagem
                var imagens = new List<Imagem>
                {
                    new Imagem { ficheiro = gitRepoAbsolutePath + "Recursos\\Imagem\\bolo_de_bolacha.jpg" }
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
                    new Recurso {tipo = 0, idVideo = videos[0].id, idImagem = imagens[0].id, idDescricao = descricoes[0].id, idHiperligacao = hiperligacoes[0].id}
                };
                context.Recurso.AddRange(recursos);

                // RecursoReceita
                context.AddRange(
                    new RecursoReceita { Receita = receitas[0], Recurso = recursos[0]}
                );

                // Avaliação
                var avaliacoes = new List<Avaliacao>
                {
                    new Avaliacao{Utilizador = utilizadores[3], pontuacao = 5, comentario = "Muito bom, está de parabéns!"},
                    new Avaliacao{Utilizador = utilizadores[0], pontuacao = 1, comentario = "Não cozinha por mim, só não dou menos pq não dá"}
                };
                context.AddRange(avaliacoes);


                context.SaveChanges();
                

            }
        }
    }
}
