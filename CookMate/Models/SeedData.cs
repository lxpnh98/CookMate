using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CookMate.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UtilizadorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UtilizadorContext>>()))
            {
                // Look for any movies.
                //TODO: ver isto
                if (context.Utilizador.Any())
                {
                    return;   // DB has been seeded
                }

                context.Utilizador.AddRange(
                    new Utilizador
                    {
                        nome = "Miguel",
                        email = "miguel@gmail.com",
                        username = "mikl",
                        password = "password",
                        podeAdicionarReceita = false
                    },

                    new Utilizador
                    {
                        nome = "Joel",
                        email = "joel@gmail.com",
                        username = "joel",
                        password = "password",
                        podeAdicionarReceita = false
                    },

                    new Utilizador
                    {
                        nome = "Tiago",
                        email = "tiago@gmail.com",
                        username = "tiago",
                        password = "password",
                        podeAdicionarReceita = false
                    },

                    new Utilizador
                    {
                        nome = "Alexandre",
                        email = "alexandre@gmail.com",
                        username = "alex",
                        password = "password",
                        podeAdicionarReceita = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}