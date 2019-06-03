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
                    new Categoria{ nome = "Bolos" },
                    new Categoria{ nome = "Tartes" },
                    new Categoria{ nome = "Gelados" }
                };
                context.Categoria.AddRange(categorias);
                context.SaveChanges();

                // UtilizadorCategoria

                context.AddRange(
                    new UtilizadorCategoria { Utilizador = utilizadores[0], Categoria = categorias[0] },
                    new UtilizadorCategoria { Utilizador = utilizadores[1], Categoria = categorias[1] },
                    new UtilizadorCategoria { Utilizador = utilizadores[1], Categoria = categorias[2] }
                );
                //context.SaveChanges();

                // Até aqui dá

                // Add Receita
                var receitas = new List<Receita>
                {
                    new Receita { titulo = "Bolo de Bolacha", dificuldade = 3, valorEnergetico = 4000, imagem = "https://www.saborintenso.com/attachments/videos-doces/375d1252681021-bolo-bolacha-bolo-bolacha-1.jpg", tempo = new TimeSpan(2,30,0), idCategoria = categorias[0].id}
                };
                context.Receita.AddRange(receitas);
                context.SaveChanges();

                //Add Utensilios
                // nome < 50 chars
                var utensilios = new List<Utensilio> {
                    new Utensilio { nome = "Shape with loose base with smooth bottom with 20 cm of diameter" },
                    new Utensilio { nome = "Coffee maker" },
                    new Utensilio { nome = "Spoon" },
                    new Utensilio { nome = "Bowl" },
                    new Utensilio { nome = "Bowl" },
                    new Utensilio { nome = "Eletric Mixer" }
                };
                context.Utensilio.AddRange(utensilios);
                context.SaveChanges();

                // UtensilioReceita
                context.AddRange(
                    new UtensilioReceita { Utensilio = utensilios[0], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[1], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[2], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[3], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[4], Receita = receitas[0] },
                    new UtensilioReceita { Utensilio = utensilios[5], Receita = receitas[0] }
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
                        comentario = "OMG best recipe eva!!1!1"
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
                        nome = "Wafers",
                        valor = 2,
                        unidade = "package"
                    },
                    new Ingrediente
                    {
                        nome = "Butter",
                        valor = 250,
                        unidade = "gram"
                    },
                    new Ingrediente
                    {
                        nome = "RAR fine sugar",
                        valor = 200,
                        unidade = "gram"
                    },
                    new Ingrediente
                    {
                        nome = "Egg",
                        valor = 3,
                        unidade = "unit"
                    },
                    new Ingrediente
                    {
                        nome = "Soluble coffee",
                        valor = 0,
                        unidade = "as needed"
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
                        tempo = 2,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 3,titulo = "In a bowl, beat the butter until the cream is white.",
                        tempo = 2,
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
                        tempo = 2,
                        temporizador = false,
                        idOperacao = 0,
                    },
                    new Passo
                    {
                        idReceita = receitas[0].id,
                        ordem = 6,titulo = "Continue to beat everything until the cream is homogeneous.",
                        tempo = 3,
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
                        ordem = 13,titulo = "Unmount and serve.",
                        tempo = 2,
                        temporizador = false,
                        idOperacao = 0,
                    }
                };
                context.Passo.AddRange(passos);

                //Video
                var videos = new List<Video>
                {
                    new Video { ficheiro = "https://www.youtube.com/embed/wIuuTOl_ay8" }, // make coffee
                    new Video { ficheiro = "https://www.youtube.com/embed/yAGX-54iR30" } // separate egg yolkes
                };
                context.Video.AddRange(videos);

                //Imagem
                var imagens = new List<Imagem>
                {
                    new Imagem { ficheiro = "https://cdn.instructables.com/FNU/CF9N/IBL69CWA/FNUCF9NIBL69CWA.LARGE.jpg?auto=webp&width=900" }, // butter to white cream
                    new Imagem { ficheiro = "https://www.foodfromportugal.com/content/uploads/2012/11/bolo-de-bolachaxx2-575x901.jpg" }, // decorate
                    new Imagem { ficheiro = "https://i1.wp.com/receitasavolili.com/wp-content/uploads/2013/06/BoloBolachaMaria700.jpeg?resize=700%2C525&ssl=1" }, // wafer placement
                    new Imagem { ficheiro = "https://www.saborintenso.com/attachments/videos-doces/375d1252681021-bolo-bolacha-bolo-bolacha-1.jpg" } // bolo de bolacha (saborintenso)
                };
                context.Imagem.AddRange(imagens);

                //Descrição
                var descricoes = new List<Descricao>
                {
                    new Descricao { texto = "To prevent the cream from becoming grainy, make sure the butter is at room-temperature. You may also try adding some milk or vanilla essence (in small drops), while stirring." },
                    new Descricao { texto = "Going to have a party and want to prepare a different and special cake? This delicious creamy wafer cake flavored with coffee, has excellent presentation and is quite pleasant. Bon appetit!!!" },
                    new Descricao { texto = "Adapted and translated from:" }
                };
                context.Descricao.AddRange(descricoes);

                //Hiperligação
                var hiperligacoes = new List<Hiperligacao>
                {
                    new Hiperligacao { url = "https://www.teleculinaria.pt/receitas/doces-e-sobremesas//bolo-bolacha-cafe/" },
                    new Hiperligacao { url = "https://food52.com/blog/7720-a-better-way-to-get-cakes-out-of-their-pans" },
                    new Hiperligacao { url = "https://www.saborintenso.com/f23/bolo-bolacha-707/?fbclid=IwAR1ORb6ma1SP-w16svPh2gfLo_a_LddaLYB60rsKVs25lefQsH7vHTXbUBg" }
                };
                context.Hiperligacao.AddRange(hiperligacoes);
                context.SaveChanges();

                // Recurso
                var recursos = new List<Recurso>
                {
                    new Recurso {tipo = 0, idVideo = videos[0].id}, // make coffee
                    new Recurso {tipo = 0, idVideo = videos[1].id}, // separate egg yolkes
                    new Recurso {tipo = 1, idImagem = imagens[0].id}, // white cream
                    new Recurso {tipo = 2, idDescricao = descricoes[0].id}, // grainy cream
                    new Recurso {tipo = 1, idImagem = imagens[1].id}, // decorate
                    new Recurso {tipo = 1, idImagem = imagens[2].id}, // wafer placement
                    new Recurso {tipo = 3, idHiperligacao = hiperligacoes[1].id}, // unmount
                    new Recurso {tipo = 1, idImagem = imagens[3].id}, // bolo de bolacha (saborintenso)
                    new Recurso {tipo = 2, idDescricao = descricoes[1].id}, // wafer cake
                    new Recurso {tipo = 2, idDescricao = descricoes[2].id}, // adapted
                    new Recurso {tipo = 3, idHiperligacao = hiperligacoes[2].id} // article
                };
                context.Recurso.AddRange(recursos);

                // RecursoReceita
                context.AddRange(
                    new RecursoReceita { ordem = 1, idReceita = receitas[0].id, idRecurso = recursos[7].id},
                    new RecursoReceita { ordem = 2, idReceita = receitas[0].id, idRecurso = recursos[8].id},
                    new RecursoReceita { ordem = 3, idReceita = receitas[0].id, idRecurso = recursos[9].id},
                    new RecursoReceita { ordem = 4, idReceita = receitas[0].id, idRecurso = recursos[10].id}
                );

                // RecursoPasso
                context.AddRange(
                    new RecursoPasso { ordem = 1, idPasso = passos[0].id, idRecurso = recursos[0].id}, // make coffee
                    new RecursoPasso { ordem = 1, idPasso = passos[1].id, idRecurso = recursos[1].id}, // separate egg yolkes
                    new RecursoPasso { ordem = 1, idPasso = passos[2].id, idRecurso = recursos[2].id}, // white cream
                    new RecursoPasso { ordem = 1, idPasso = passos[3].id, idRecurso = recursos[3].id}, // grainy cream
                    new RecursoPasso { ordem = 1, idPasso = passos[10].id, idRecurso = recursos[4].id}, // decorate
                    new RecursoPasso { ordem = 1, idPasso = passos[7].id, idRecurso = recursos[5].id}, // wafer placement
                    new RecursoPasso { ordem = 1, idPasso = passos[12].id, idRecurso = recursos[6].id} // unmount
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
