using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CookMate.Models;
using System.Text.RegularExpressions;

namespace CookMate.Controllers {

    public class AddRecursoController : Controller
    {
        private readonly UtilizadorContext _context;

        public AddRecursoController (UtilizadorContext context) {
            _context = context;
        }

        public IActionResult Confirm() {
            ViewData["idReceita"] = (int)HttpContext.Session.GetInt32("idReceita");
            return View("~/Views/Home/intermedio.cshtml");
        }

        [HttpPost]
        public IActionResult Initial(AddRecursoModel model) {

            var valid = true;
            if (model.tipo < 0 || model.tipo > 3) {
                valid = false;
                ModelState.AddModelError("TipoInvalido", "Type must be valid.");
            }
            if (model.path == null) {
                valid = false;
                ModelState.AddModelError("NoPath", "Path must be not empty.");
            }
            var recurso = new Recurso {
                tipo = 0,
                idVideo = 0,
                idImagem = 0,
                idDescricao = 0,
                idHiperligacao = 0
            };

            if (valid == true) {
                switch (model.tipo) {
                    case 0:
                        var video = new Video { 
                            ficheiro = model.path,        
                        };
                        _context.Video.Add(video);
                        _context.SaveChanges();
                        recurso = new Recurso {
                            tipo = model.tipo,
                            idVideo = video.id,
                            idImagem = 0,
                            idDescricao = 0,
                            idHiperligacao = 0
                        };
                        break;
                    case 1:
                        var imagem = new Imagem {
                            ficheiro = model.path,
                        };
                        _context.Imagem.Add(imagem);
                        _context.SaveChanges();
                        recurso = new Recurso {
                            tipo = model.tipo,
                            idVideo = 0,
                            idImagem = imagem.id,
                            idDescricao = 0,
                            idHiperligacao = 0
                        };
                        break;
                    case 2:
                        var descricao = new Descricao {
                            texto = model.path
                        };
                        _context.Descricao.Add(descricao);
                        _context.SaveChanges();
                        recurso = new Recurso {
                            tipo = model.tipo,
                            idVideo = 0,
                            idImagem = 0,
                            idDescricao = descricao.id,
                            idHiperligacao = 0
                        };
                        break;
                    case 3:
                        var hyper = new Hiperligacao {
                            url = model.path
                        };
                        _context.Hiperligacao.Add(hyper);
                        _context.SaveChanges();
                        recurso = new Recurso {
                            tipo = model.tipo,
                            idVideo = 0,
                            idImagem = 0,
                            idDescricao = 0,
                            idHiperligacao = hyper.id
                        };
                        break;
                }
                _context.Recurso.Add(recurso);
                _context.SaveChanges();
               
                int idPasso = (int)HttpContext.Session.GetInt32("idPasso");

                var rp = new RecursoPasso
                {
                    idRecurso = recurso.id,
                    idPasso = idPasso
                };
                _context.AddRange(rp);
                _context.SaveChanges();
                ViewData["idPasso"] = (int)HttpContext.Session.GetInt32("idPasso");
                return View("~/Views/Home/addPasso.cshtml");
            }
            return View("~/Views/Home/addRecurso.cshtml");
        }
    }

    public class AddRecursoModel {

        public int tipo { get; set; }

        public string path { get; set; }

    }
}
