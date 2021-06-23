using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using EasyToFind.Models;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Speech.AudioFormat;
using System.IO;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.Media;

namespace EasyToFind.Controllers
{
    public class easytofind : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            string teste = HttpContext.Session.GetString("Email");
            if (HttpContext.Session.GetString("Email") != null)
            {
                return RedirectToAction("ViewPrincipal");
            }

            return View();
        }

        [HttpGet]
        public IActionResult ViewPrincipal(string email)
        {
            if (email != null)
            {
                HttpContext.Session.SetString("Email", email);
            }

            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "animais.png", Descricao = "Animais" });
            model.Add(new ModelBotoes { NomeImagem = "comida.png", Descricao = "Comida" });
            model.Add(new ModelBotoes { NomeImagem = "educacao.png", Descricao = "Educação" });
            model.Add(new ModelBotoes { NomeImagem = "entretenimento.png", Descricao = "Entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "interligadores.png", Descricao = "Interligadores" });
            model.Add(new ModelBotoes { NomeImagem = "lugares.png", Descricao = "Lugares" });
            model.Add(new ModelBotoes { NomeImagem = "numeros.png", Descricao = "Números" });
            model.Add(new ModelBotoes { NomeImagem = "questoes.png", Descricao = "Questões" });
            model.Add(new ModelBotoes { NomeImagem = "saude.png", Descricao = "Saúde" });
            model.Add(new ModelBotoes { NomeImagem = "redes_sociais.png", Descricao = "Redes Socias" });
            model.Add(new ModelBotoes { NomeImagem = "verbos.png", Descricao = "Verbos" });
            model.Add(new ModelBotoes { NomeImagem = "outras.png", Descricao = "Outras" });

            ViewBag.Trocar = "add_categoria.png";

            return View(model);
        }

        public IActionResult ViewPrincipal2()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "desporto.png", Descricao = "Desporto" });
            model.Add(new ModelBotoes { NomeImagem = "edifícios.png", Descricao = "Edifícios" });
            model.Add(new ModelBotoes { NomeImagem = "formas.png", Descricao = "Formas" });
            model.Add(new ModelBotoes { NomeImagem = "marcas.png", Descricao = "Marcas" });
            model.Add(new ModelBotoes { NomeImagem = "metereologia.png", Descricao = "Metereologia" });
            model.Add(new ModelBotoes { NomeImagem = "mobiliario.png", Descricao = "Mobiliário" });
            model.Add(new ModelBotoes { NomeImagem = "musica.png", Descricao = "Música" });
            model.Add(new ModelBotoes { NomeImagem = "natureza.png", Descricao = "Natureza" });
            model.Add(new ModelBotoes { NomeImagem = "paises.png", Descricao = "Países" });
            model.Add(new ModelBotoes { NomeImagem = "posicoes.png", Descricao = "Posições" });
            model.Add(new ModelBotoes { NomeImagem = "profissoes.png", Descricao = "Profissões" });
            model.Add(new ModelBotoes { NomeImagem = "outras.png", Descricao = "Outras2" });

            ViewBag.Trocar = "retroceder.png";

            return View("ViewPrincipal", model);
        }

        public IActionResult ViewPrincipal3()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "religiao.png", Descricao = "Religião" });
            model.Add(new ModelBotoes { NomeImagem = "roupa.png", Descricao = "Roupa" });
            model.Add(new ModelBotoes { NomeImagem = "símbolos.png", Descricao = "Símbolos" });
            model.Add(new ModelBotoes { NomeImagem = "veiculos.png", Descricao = "Veículos" });
            model.Add(new ModelBotoes { NomeImagem = "viagens.png", Descricao = "Viagens" });

            ViewBag.Trocar = "retroceder.png";

            return View("ViewPrincipal", model);
        }

        [HttpPost]
        public IActionResult ViewPrincipal(string botao, string pathUrl)
        {
            if (botao == "Outras")
            {
                return RedirectToAction("ViewPrincipal2");
            }
            else if (botao == "Outras2")
            {
                return RedirectToAction("ViewPrincipal3");
            }
            else if (botao == "Animais")
            {
                return RedirectToAction("View1", "animais");
            }
            else if (botao == "Comida")
            {
                return RedirectToAction("view1", "comida");
            }
            else if (botao == "Educação")
            {
                return RedirectToAction("educacao");
            }
            else if (botao == "Entretenimento")
            {
                return RedirectToAction("entretenimento");
            }
            else if (botao == "Desporto")
            {
                return RedirectToAction("desporto");
            }
            else if (botao == "Lugares")
            {
                return RedirectToAction("lugares");
            }
            else if (botao == "Edifícios")
            {
                return RedirectToAction("edificios");
            }
            else if (botao == "Formas")
            {
                return RedirectToAction("formas");
            }
            else if (botao == "Mobiliário")
            {
                return RedirectToAction("mobiliario");
            }
            else if (botao == "Posições")
            {
                return RedirectToAction("posicoes");
            }
            else if (botao == "Profissões")
            {
                return RedirectToAction("profissoes");
            }
            else if (botao == "Questões")
            {
                return RedirectToAction("questoes");
            }
            else if (botao == "Roupa")
            {
                return RedirectToAction("roupa");
            }
            else if (botao == "Saúde")
            {
                return RedirectToAction("saude");
            }
            else if (botao == "Redes Socias")
            {
                return RedirectToAction("social");
            }
            else if (botao == "Veículos")
            {
                return RedirectToAction("veiculos");
            }
            else if (botao == "Viagens")
            {
                return RedirectToAction("viagens");
            }
            else if (botao == "Verbos")
            {
                return RedirectToAction("verbos");
            }
            else if (botao == "Símbolos")
            {
                return RedirectToAction("simbolos");
            }
            else if (botao == "Números")
            {
                return RedirectToAction("numeros");
            }
            else if (botao == "Religião")
            {
                return RedirectToAction("religiao");
            }
            else if (botao == "Marcas")
            {
                return RedirectToAction("marcas");
            }
            else if (botao == "Metereologia")
            {
                return RedirectToAction("metereologia");
            }
            else if (botao == "Música")
            {
                return RedirectToAction("musica");
            }
            else if (botao == "Natureza")
            {
                return RedirectToAction("natureza");
            }
            else if (botao == "Interligadores")
            {
                return RedirectToAction("interligadores");
            }
            else if (botao == "Países")
            {
                return RedirectToAction("paises");
            }
            else
            {
                string texto = HttpContext.Session.GetString("texto");

                HttpContext.Session.SetString("texto", texto + " " + botao);
            }

            return Redirect(Convert.ToString(pathUrl));
        }

        [HttpGet]
        public IActionResult desporto()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "badminton.png", Descricao = "Badminton", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "basebol.png", Descricao = "Basebol", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "basquete.png", Descricao = "Basquete", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "boxe.png", Descricao = "Boxe", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "ciclismo.png", Descricao = "Ciclismo", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "corrida.png", Descricao = "Atletismo", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "equitação.png", Descricao = "Equitação", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "futbol.png", Descricao = "Futbol", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "golfe.png", Descricao = "Golf", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "hockey.png", Descricao = "Hockey", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "natacao.png", Descricao = "Natação", Categoria = "img_desporto" });
            model.Add(new ModelBotoes { NomeImagem = "voleibol.png", Descricao = "Voleibol", Categoria = "img_desporto" });

            return View("geral", model);
        }




        [HttpGet]
        public IActionResult edificios()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "aeroporto.png", Descricao = "Aeroporto", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "bar.png", Descricao = "Bar", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "company.png", Descricao = "Empresas", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "escola.png", Descricao = "Escola", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "farmacia.png", Descricao = "Farmácia", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "fazenda.png", Descricao = "Fazenda", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "gym.png", Descricao = "Ginásio", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "hospital.png", Descricao = "Hospital", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "police-station.png", Descricao = "Polícia", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "supermercados.png", Descricao = "Supermercado", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "tribunal-de-justica.png", Descricao = "Tribunal", Categoria = "img_edificios" });
            model.Add(new ModelBotoes { NomeImagem = "veterinary.png", Descricao = "Veterinário", Categoria = "img_edificios" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult educacao()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "biologia.png", Descricao = "Biologia", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "ciencias.png", Descricao = "Ciências", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "educacao-fisica.png", Descricao = "Educação Física", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "educacao-sexual.png", Descricao = "Educação Sexual", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "engenharia.png", Descricao = "Engenharia", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "fisica.png", Descricao = "Física", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "Formacao-musical.png", Descricao = "Música", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "linguas.png", Descricao = "Línguas", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "matematica.png", Descricao = "Matemática", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "psicologia.png", Descricao = "Psicologia", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "quimica.png", Descricao = "Química", Categoria = "img_educacao" });
            model.Add(new ModelBotoes { NomeImagem = "Tic.png", Descricao = "TIC", Categoria = "img_educacao" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Entretenimento()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "agricultura.png", Descricao = "Agricultura", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "cinema.png", Descricao = "Cinema", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "cultura.png", Descricao = "Cultura", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "experiencia.png", Descricao = "Experiência", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "festividadespng.png", Descricao = "Festiais", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "fotografia.png", Descricao = "Fotografia", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "historia.png", Descricao = "História", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "jogos.png", Descricao = "Jogos", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "musica.png", Descricao = "Música", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "pinturas.png", Descricao = "Pintura", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "politica.png", Descricao = "Política", Categoria = "img_entretenimento" });
            model.Add(new ModelBotoes { NomeImagem = "recordes.png", Descricao = "Recordes", Categoria = "img_entretenimento" });

            return View("geral", model);
        }


        [HttpGet]
        public IActionResult Formas()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "circular.png", Descricao = "Circular", Categoria = "img_formas" });
            model.Add(new ModelBotoes { NomeImagem = "elipse.png", Descricao = "Elipse", Categoria = "img_formas" });
            model.Add(new ModelBotoes { NomeImagem = "hexagono.png", Descricao = "Hexágono", Categoria = "img_formas" });
            model.Add(new ModelBotoes { NomeImagem = "linha.png", Descricao = "Linha", Categoria = "img_formas" });
            model.Add(new ModelBotoes { NomeImagem = "pentagono.png", Descricao = "Pentágono", Categoria = "img_formas" });
            model.Add(new ModelBotoes { NomeImagem = "pontos.png", Descricao = "Pontos", Categoria = "img_formas" });
            model.Add(new ModelBotoes { NomeImagem = "quadrado.png", Descricao = "Quadrado", Categoria = "img_formas" });
            model.Add(new ModelBotoes { NomeImagem = "triangular.png", Descricao = "Triangular", Categoria = "img_formas" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Lugares()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "cidades.png", Descricao = "Cidades", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "Continentes.png", Descricao = "Continentes", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "desertos.png", Descricao = "Desertos", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "ilhas.png", Descricao = "Ilhas", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "lagos.png", Descricao = "Lagos", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "marco-historicos.png", Descricao = "Marcos Históricos", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "montanhas.png", Descricao = "Montanhas", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "oceanos.png", Descricao = "Oceanos", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "paises.png", Descricao = "Países", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "polos.png", Descricao = "Polos", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "rios.png", Descricao = "Rios", Categoria = "img_lugares" });
            model.Add(new ModelBotoes { NomeImagem = "vulcoes.png", Descricao = "Vulcões", Categoria = "img_lugares" });

            return View("geral", model);
        }



        [HttpGet]
        public IActionResult Mobiliario()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "armário-casa-de-banho.png", Descricao = "Armário", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "armarios.png", Descricao = "Cacifo", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "balcao.png", Descricao = "Balcão", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "cadeira.png", Descricao = "Cadeira", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "cama.png", Descricao = "Cama", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "closet.png", Descricao = "Guarda Vestidos", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "comoda.png", Descricao = "Cómoda", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "espelho.png", Descricao = "Espelho", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "estante.png", Descricao = "Estante", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "mesa.png", Descricao = "Mesa", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "mesinha.png", Descricao = "Mesinha", Categoria = "img_mobiliario" });
            model.Add(new ModelBotoes { NomeImagem = "sofa.png", Descricao = "Sofá", Categoria = "img_mobiliario" });

            return View("geral", model);
        }


        [HttpGet]
        public IActionResult Posicoes()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "ali.png", Descricao = "Ali", Categoria = "img_posicoes" });
            model.Add(new ModelBotoes { NomeImagem = "aqui.png", Descricao = "Aqui", Categoria = "img_posicoes" });
            model.Add(new ModelBotoes { NomeImagem = "direita.png", Descricao = "Direita", Categoria = "img_posicoes" });
            model.Add(new ModelBotoes { NomeImagem = "em-baixo.png", Descricao = "Debaixo", Categoria = "img_posicoes" });
            model.Add(new ModelBotoes { NomeImagem = "em-cima.png", Descricao = "Em Cima", Categoria = "img_posicoes" });
            model.Add(new ModelBotoes { NomeImagem = "em-volta.png", Descricao = "Em Volta", Categoria = "img_posicoes" });
            model.Add(new ModelBotoes { NomeImagem = "esquerda.png", Descricao = "Esquerda", Categoria = "img_posicoes" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Profissoes()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "arquiteto.png", Descricao = "Arquiteto", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "Bombeiro.png", Descricao = "Bombeiro", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "carpinteiro.png", Descricao = "Carpinteiro", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "carteiro.png", Descricao = "Carteiro", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "cientista.png", Descricao = "Cientista", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "Comerciante.png", Descricao = "Comerciante", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "cozinheiro.png", Descricao = "Cozinheiro", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "eletricista.png", Descricao = "Eletricista", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "médico.png", Descricao = "Médico", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "pintor.png", Descricao = "Pintor", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "policia.png", Descricao = "Polícia", Categoria = "img_profissões" });
            model.Add(new ModelBotoes { NomeImagem = "Professor.png", Descricao = "Professor", Categoria = "img_profissões" });

            return View("geral", model);
        }


        [HttpGet]
        public IActionResult Questoes()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "Como.png", Descricao = "Como", Categoria = "img_questoes" });
            model.Add(new ModelBotoes { NomeImagem = "onde.png", Descricao = "Onde", Categoria = "img_questoes" });
            model.Add(new ModelBotoes { NomeImagem = "Porque.png", Descricao = "Porque", Categoria = "img_questoes" });
            model.Add(new ModelBotoes { NomeImagem = "Qual.png", Descricao = "Qual", Categoria = "img_questoes" });
            model.Add(new ModelBotoes { NomeImagem = "quando.png", Descricao = "Quando", Categoria = "img_questoes" });
            model.Add(new ModelBotoes { NomeImagem = "Quanto.png", Descricao = "Quanto", Categoria = "img_questoes" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Roupa()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "acessorio.png", Descricao = "Acessórios", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "bikini.png", Descricao = "Bikini", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "calcas.png", Descricao = "Calças", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "shorts.png", Descricao = "Calções", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "camisa.png", Descricao = "Camisa", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "casaco.png", Descricao = "Casaco", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "chapeu.png", Descricao = "Chapéu", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "fato.png", Descricao = "Fatos", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "gorro.png", Descricao = "Gorro", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "gravata.png", Descricao = "Gravata", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "sapatos.png", Descricao = "Sapatos", Categoria = "img_roupa" });
            model.Add(new ModelBotoes { NomeImagem = "t-shirt.png", Descricao = "T-shirt", Categoria = "img_roupa" });

            return View("geral", model);
        }


        [HttpGet]
        public IActionResult Saude()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "analises.png", Descricao = "Análises", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "doente.png", Descricao = "Gripado", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "dor.png", Descricao = "Desorientado", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "fadiga.png", Descricao = "Fadiga", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "febre.png", Descricao = "Febre", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "fraturas.png", Descricao = "Fraturas", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "inchaco.png", Descricao = "Inchaço", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "indisposto.png", Descricao = "Indisposto", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "mal-estar.png", Descricao = "Mal-estar", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "operacao.png", Descricao = "Operação", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "vacinado.png", Descricao = "Vacinado", Categoria = "img_saude" });
            model.Add(new ModelBotoes { NomeImagem = "visão.png", Descricao = "Visão", Categoria = "img_saude" });


            return View("geral", model);
        }


        [HttpGet]
        public IActionResult Social()
        {

            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "facebook.png", Descricao = "Facebook", Categoria = "img_social" });
            model.Add(new ModelBotoes { NomeImagem = "instagram.png", Descricao = "Instagram", Categoria = "img_social" });
            model.Add(new ModelBotoes { NomeImagem = "linkedin.png", Descricao = "Linkedin", Categoria = "img_social" });
            model.Add(new ModelBotoes { NomeImagem = "snapchat.png", Descricao = "Snapchat", Categoria = "img_social" });
            model.Add(new ModelBotoes { NomeImagem = "tik-tok.png", Descricao = "Tik Tok", Categoria = "img_social" });
            model.Add(new ModelBotoes { NomeImagem = "twitter.png", Descricao = "Twitter", Categoria = "img_social" });
            model.Add(new ModelBotoes { NomeImagem = "whatsapp.png", Descricao = "Whatsapp", Categoria = "img_social" });
            model.Add(new ModelBotoes { NomeImagem = "youtube.png", Descricao = "Youtube", Categoria = "img_social" });

            return View("geral", model);
        }



        [HttpGet]
        public IActionResult Veiculos()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "autocarro.png", Descricao = "Autocarro", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "bicicletas.png", Descricao = "Bicicleta", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "camiao.png", Descricao = "Camião", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "carro.png", Descricao = "Carro", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "escavador.png", Descricao = "Escavadora", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "grua-de-camiao.png", Descricao = "Grua", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "jipe.png", Descricao = "Jipe", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "limousine.png", Descricao = "Limousine", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "moto.png", Descricao = "Mota", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "quadriciclo.png", Descricao = "Quadriciclo", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "trator.png", Descricao = "Trator", Categoria = "img_veiculos" });
            model.Add(new ModelBotoes { NomeImagem = "triciclo.png", Descricao = "Tricíclo", Categoria = "img_veiculos" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Viagens()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "Açores.png", Descricao = "Açores", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Algarve.png", Descricao = "Algarve", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Bagan.png", Descricao = "Bagan", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Guam.png", Descricao = "Guam", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Indonésia.png", Descricao = "Indonésia", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Marrocos.png", Descricao = "Marrocos", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "México.png", Descricao = "México", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Paris.png", Descricao = "Paris", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Perú.png", Descricao = "Perú", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Sintra.png", Descricao = "Sintra", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Suzhou.png", Descricao = "Suzhou", Categoria = "img_viagens" });
            model.Add(new ModelBotoes { NomeImagem = "Turquia.png", Descricao = "Turquia", Categoria = "img_viagens" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Verbos()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "Comprar.png", Descricao = "Comprar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Cozinhar.png", Descricao = "Cozinhar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Fazer.png", Descricao = "Fazer", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Filtrar.png", Descricao = "Filtrar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Gostar.png", Descricao = "Gostar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Inscrever.png", Descricao = "Inscrever", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "instalar.png", Descricao = "Instalar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Jogar.png", Descricao = "Jogar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Lavar.png", Descricao = "Lavar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Procurar.png", Descricao = "Procurar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Reparar.png", Descricao = "Reparar", Categoria = "img_verbos" });
            model.Add(new ModelBotoes { NomeImagem = "Ter.png", Descricao = "Ter", Categoria = "img_verbos" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Simbolos()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "Comunismo.png", Descricao = "Comunismo", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Estacionamento.png", Descricao = "Estacionamento", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Feminino.png", Descricao = "Feminino", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Informação.png", Descricao = "Informação", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "lixo.png", Descricao = "Lixo", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Masculino.png", Descricao = "Masculino", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Multibanco.png", Descricao = "Multibanco", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Parquimetro.png", Descricao = "Parquimetro", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Perigo.png", Descricao = "Perigo", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Proibido.png", Descricao = "Proibido", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "Recycling.png", Descricao = "Reciclagem", Categoria = "img_simbolos" });
            model.Add(new ModelBotoes { NomeImagem = "WC.png", Descricao = "Casa de Banho", Categoria = "img_simbolos" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Numeros()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "zero.png", Descricao = "Zero", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Um.png", Descricao = "Um", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Dois.png", Descricao = "Dois", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Três.png", Descricao = "Três", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Quatro.png", Descricao = "Quatro", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Cinco.png", Descricao = "Cinco", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "seis.png", Descricao = "Seis", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Sete.png", Descricao = "Sete", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Oito.png", Descricao = "Oito", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Nove.png", Descricao = "Nove", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "PI.png", Descricao = "Pi", Categoria = "img_números" });
            model.Add(new ModelBotoes { NomeImagem = "Complexos.png", Descricao = "Complexos", Categoria = "img_números" });

            return View("geral", model);
        }


        [HttpGet]
        public IActionResult Religiao()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "Africana.png", Descricao = "Africana", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Ateísmopng.png", Descricao = "Ateísmo", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Budismo.png", Descricao = "Budismo", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Cristianismo.png", Descricao = "Cristianismo", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Espiritismo.png", Descricao = "Espiritismo", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Hinduísmo.png", Descricao = "Hinduísmo", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Indígena.png", Descricao = "Indígena", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Islamismo.png", Descricao = "Islamismo", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Juche.png", Descricao = "Juche", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Judaísmo.png", Descricao = "Judaísmo", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "Sikhism.png", Descricao = "Sikhism", Categoria = "img_religião" });
            model.Add(new ModelBotoes { NomeImagem = "ying-yang.png", Descricao = "Ying e Yang", Categoria = "img_religião" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Natureza()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "animais.png", Descricao = "Animais", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "arvore.png", Descricao = "Árvore", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "aves.png", Descricao = "Aves", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "deserto.png", Descricao = "Deserto", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "floresta.png", Descricao = "Floresta", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "oceano.png", Descricao = "Oceano", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "planta.png", Descricao = "Planta", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "praia.png", Descricao = "Praia", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "rio.png", Descricao = "Rio", Categoria = "img_natureza" });
            model.Add(new ModelBotoes { NomeImagem = "selva.png", Descricao = "Selva", Categoria = "img_natureza" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Marcas()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "adidas.png", Descricao = "Adidas", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "asus.png", Descricao = "Asus", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "audi.png", Descricao = "Audi", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "bmw.png", Descricao = "BMW", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "champion.png", Descricao = "Champion", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "honda.png", Descricao = "Honda", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "hp.png", Descricao = "HP", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "huawei.png", Descricao = "Huawei", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "iphone.png", Descricao = "Iphone", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "lenovo.png", Descricao = "Lenovo", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "nike.png", Descricao = "Nike", Categoria = "img_marcas" });
            model.Add(new ModelBotoes { NomeImagem = "samsung.png", Descricao = "Samsung", Categoria = "img_marcas" });


            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Musica()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "baixo.png", Descricao = "Baixo", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "bateria.png", Descricao = "Bateria", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "cd.png", Descricao = "CD", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "coluna.png", Descricao = "Coluna", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "guitarra.png", Descricao = "Guitarra", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "guitarra_eletrica.png", Descricao = "Guitarra Elétrica", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "palco.png", Descricao = "Palco", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "spotify.png", Descricao = "Spotify", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "teclado.png", Descricao = "Teclado", Categoria = "img_musica" });
            model.Add(new ModelBotoes { NomeImagem = "youtube music.png", Descricao = "Youtube Music", Categoria = "img_musica" });

            return View("geral", model);
        }

        [HttpGet]
        public IActionResult Metereologia()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "chuva.png", Descricao = "Chuva", Categoria = "img_metereologia" });
            model.Add(new ModelBotoes { NomeImagem = "neve.png", Descricao = "Neve", Categoria = "img_metereologia" });
            model.Add(new ModelBotoes { NomeImagem = "nevoeiro.png", Descricao = "Nevoeiro", Categoria = "img_metereologia" });
            model.Add(new ModelBotoes { NomeImagem = "sol com nuvens.png", Descricao = "Sol com núvens", Categoria = "img_metereologia" });
            model.Add(new ModelBotoes { NomeImagem = "sol.png", Descricao = "Sol", Categoria = "img_metereologia" });
            model.Add(new ModelBotoes { NomeImagem = "tempo.png", Descricao = "Tempo", Categoria = "img_metereologia" });
            model.Add(new ModelBotoes { NomeImagem = "trevoada.png", Descricao = "Trevoada", Categoria = "img_metereologia" });

            return View("geral", model);
        }

        public IActionResult Paises()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "alemanha.png", Descricao = "Alemanha" });
            model.Add(new ModelBotoes { NomeImagem = "austria.png", Descricao = "Áustria" });
            model.Add(new ModelBotoes { NomeImagem = "belgica.png", Descricao = "Bélgica" });
            model.Add(new ModelBotoes { NomeImagem = "bulgaria.png", Descricao = "Bulgária" });
            model.Add(new ModelBotoes { NomeImagem = "chipre.png", Descricao = "Chipre" });
            model.Add(new ModelBotoes { NomeImagem = "croacia.png", Descricao = "Crócia" });
            model.Add(new ModelBotoes { NomeImagem = "dinamarca.png", Descricao = "Dinamarca" });
            model.Add(new ModelBotoes { NomeImagem = "eslováquia.png", Descricao = "Eslováquia" });
            model.Add(new ModelBotoes { NomeImagem = "espanha.png", Descricao = "Espanha" });
            model.Add(new ModelBotoes { NomeImagem = "estónia.png", Descricao = "Estónia" });
            model.Add(new ModelBotoes { NomeImagem = "finlandia.png", Descricao = "Finlandia" });
            model.Add(new ModelBotoes { NomeImagem = "outras.png", Descricao = "Outras" });




            return View(model);
        }

        public IActionResult Paises2()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "frança.png", Descricao = "França" });
            model.Add(new ModelBotoes { NomeImagem = "grecia.png", Descricao = "Grécia" });
            model.Add(new ModelBotoes { NomeImagem = "hungria.png", Descricao = "Hungria" });
            model.Add(new ModelBotoes { NomeImagem = "irlanda.png", Descricao = "Irlanda" });
            model.Add(new ModelBotoes { NomeImagem = "italia.png", Descricao = "Itália" });
            model.Add(new ModelBotoes { NomeImagem = "letônia.png", Descricao = "Letônia" });
            model.Add(new ModelBotoes { NomeImagem = "luxemburgo.png", Descricao = "Luxemburgo" });
            model.Add(new ModelBotoes { NomeImagem = "malta.png", Descricao = "Malta" });
            model.Add(new ModelBotoes { NomeImagem = "paises_baixos.png", Descricao = "Países Baixos" });
            model.Add(new ModelBotoes { NomeImagem = "polonia.png", Descricao = "Polónia" });
            model.Add(new ModelBotoes { NomeImagem = "portugal.png", Descricao = "Portugal" });
            model.Add(new ModelBotoes { NomeImagem = "outras.png", Descricao = "Outras2" });

            return View("Paises", model);
        }

        public IActionResult Paises3()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "republica checa.png", Descricao = "Republica Checa" });
            model.Add(new ModelBotoes { NomeImagem = "romenia.png", Descricao = "Roménia" });
            model.Add(new ModelBotoes { NomeImagem = "suecia.png", Descricao = "Suécia" });

            return View("Paises", model);
        }

        [HttpPost]
        public IActionResult Paises(string botao, string pathUrl)
        {
            if (botao == "Outras")
            {
                return RedirectToAction("Paises2");
            }
            else if (botao == "Outras2")
            {
                return RedirectToAction("Paises3");
            }
            else
            {
                string texto = HttpContext.Session.GetString("texto");

                HttpContext.Session.SetString("texto", texto + " " + botao);
            }

            return Redirect(Convert.ToString(pathUrl));
        }

        [HttpPost]
        public IActionResult Geral(string botao, string pathUrl)
        {
            string texto = HttpContext.Session.GetString("texto");

            HttpContext.Session.SetString("texto", texto + " " + botao);

            return Redirect(Convert.ToString(pathUrl));
        }

        [HttpGet]
        public IActionResult Interligadores()
        {

            var Interligadores = new List<ModelBotoes>();

            Interligadores.Add(new ModelBotoes { Descricao = "A" });
            Interligadores.Add(new ModelBotoes { Descricao = "O" });
            Interligadores.Add(new ModelBotoes { Descricao = "Ao" });
            Interligadores.Add(new ModelBotoes { Descricao = "As" });
            Interligadores.Add(new ModelBotoes { Descricao = "Bem" });
            Interligadores.Add(new ModelBotoes { Descricao = "Os" });
            Interligadores.Add(new ModelBotoes { Descricao = "Com" });
            Interligadores.Add(new ModelBotoes { Descricao = "Do" });
            Interligadores.Add(new ModelBotoes { Descricao = "Das" });
            Interligadores.Add(new ModelBotoes { Descricao = "Em" });
            Interligadores.Add(new ModelBotoes { Descricao = "Lhe" });
            Interligadores.Add(new ModelBotoes { NomeImagem = "outras.png", Descricao = "Outras", Categoria = "Img_Categorias" });

            return View(Interligadores);
        }

        [HttpGet]
        public IActionResult Interligadores2()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var Interligadores = new List<ModelBotoes>();

            Interligadores.Add(new ModelBotoes { Descricao = "Lhes" });
            Interligadores.Add(new ModelBotoes { Descricao = "Nas" });
            Interligadores.Add(new ModelBotoes { Descricao = "Não" });
            Interligadores.Add(new ModelBotoes { Descricao = "Nos" });
            Interligadores.Add(new ModelBotoes { Descricao = "Mal" });
            Interligadores.Add(new ModelBotoes { Descricao = "Melhor" });
            Interligadores.Add(new ModelBotoes { Descricao = "Para" });
            Interligadores.Add(new ModelBotoes { Descricao = "Pior" });
            Interligadores.Add(new ModelBotoes { Descricao = "Por" });
            Interligadores.Add(new ModelBotoes { Descricao = "Que" });
            Interligadores.Add(new ModelBotoes { Descricao = "Sim" });
            Interligadores.Add(new ModelBotoes { Descricao = "Sem" });

            return View("Interligadores", Interligadores);
        }

        [HttpPost]
        public IActionResult Interligadores(string botao, string pathUrl)
        {
            string texto = HttpContext.Session.GetString("texto");

            HttpContext.Session.SetString("texto", texto + " " + botao);

            if (botao == "Outras")
            {
                return RedirectToAction("interligadores2");
            }


            return Redirect(Convert.ToString(pathUrl));
        }

        [HttpPost]
        public IActionResult Apagar(string pathUrl)
        {
            if (HttpContext.Session.GetString("texto") != null)
            {
                string str = HttpContext.Session.GetString("texto");

                string newString = str.Substring(0, str.LastIndexOf(" ") + 1).Trim();
                HttpContext.Session.SetString("texto", newString);
            }

            if (pathUrl == null)
            {
                return RedirectToAction("ViewPrincipal", "easytofind");
            }
            else
            {
                return Redirect(Convert.ToString(pathUrl));
            }
        }

        [HttpPost]
        public ActionResult Falar(string pathUrl)
        {
            string texto = HttpContext.Session.GetString("texto");

            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

            speechSynthesizer.SetOutputToDefaultAudioDevice();

            speechSynthesizer.SelectVoice("Microsoft Maria Desktop");

            speechSynthesizer.Speak(texto);

            return Redirect(Convert.ToString(pathUrl));
        }

        [HttpPost]
        public ActionResult Pesquisar()
        {
            return Redirect("http://www.google.com/search?q=" + HttpContext.Session.GetString("texto").ToString() + "");
        }

        [HttpPost]
        public ActionResult VerificarLogin(string email)
        {
            HttpContext.Session.SetString("Email", Convert.ToString(email));

            string teste = HttpContext.Session.GetString("Email");

            return View();
        }


        [HttpPost]
        public ActionResult Errei(string pathUrl)
        {
            string texto = "Cometi um Erro";

            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

            speechSynthesizer.Volume = 100;

            speechSynthesizer.SetOutputToDefaultAudioDevice();

            speechSynthesizer.SelectVoice("Microsoft Maria Desktop");

            speechSynthesizer.Speak(texto);

            return Redirect(Convert.ToString(pathUrl));
        }

        [HttpPost]
        public ActionResult Alerta(string pathUrl)
        {

            var basePath = Convert.ToString("C:/campainha.wav");
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = basePath;
            player.Load();
            player.Play();

            return Redirect(Convert.ToString(pathUrl));
        }

        [HttpGet]
        public async Task<IActionResult> Guardar()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            Guardar guardar = new Guardar();

            guardar.Email = HttpContext.Session.GetString("Email");
            guardar.Texto = HttpContext.Session.GetString("texto");

            string projectId;
            FirestoreDb fireStoreDb;

            string filepath = Path.GetFullPath("cloudfirebase.json").ToString();
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "easytofind-b0a20";
            fireStoreDb = FirestoreDb.Create(projectId);
            var frases = new List<Guardar>();
            try
            {
                Query capitalQuery = fireStoreDb.Collection("Guardar");
                QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
                foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
                {
                    if (documentSnapshot.GetValue<string>("Email") == HttpContext.Session.GetString("Email"))
                    {
                        string value = documentSnapshot.GetValue<string>("Texto");
                        frases.Add(new Guardar { Email = HttpContext.Session.GetString("Email"), Texto = Convert.ToString(value) });
                    }
                }
            }
            catch
            {
                throw;
            }

            return View(frases);
        }


        [HttpPost]
        public async Task<ActionResult> Guardar(string pathUrl)
        {
            if (HttpContext.Session.GetString("texto") != null)
            {
                Guardar guardar = new Guardar();

                guardar.Email = HttpContext.Session.GetString("Email");
                guardar.Texto = HttpContext.Session.GetString("texto");

                string projectId;
                FirestoreDb fireStoreDb;

                string filepath = Path.GetFullPath("cloudfirebase.json").ToString();
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
                projectId = "easytofind-b0a20";
                fireStoreDb = FirestoreDb.Create(projectId);

                try
                {

                    CollectionReference colRef = fireStoreDb.Collection("Guardar");
                    Dictionary<string, object> varGuardar = new Dictionary<string, object>();
                    varGuardar.Add("Email", guardar.Email);
                    varGuardar.Add("Texto", guardar.Texto);

                    await colRef.AddAsync(varGuardar);
                }
                catch
                {
                    throw;
                }

            }

            return Redirect(Convert.ToString(pathUrl));
        }

        [HttpPost]
        public ActionResult UtilizarFrase(string frase)
        {
            HttpContext.Session.SetString("texto",Convert.ToString(frase));
            return RedirectToAction("ViewPrincipal");
        }

        [HttpPost]
        public async Task<ActionResult> EliminarFrase(string frase,string pathUrl)
        {
            string projectId;
            FirestoreDb fireStoreDb;

            string filepath = Path.GetFullPath("cloudfirebase.json").ToString();
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "easytofind-b0a20";
            fireStoreDb = FirestoreDb.Create(projectId);
            var frases = new List<Guardar>();
            try
            {
                Query capitalQuery = fireStoreDb.Collection("Guardar");
                QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
                foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
                {
                    if (documentSnapshot.GetValue<string>("Email") == HttpContext.Session.GetString("Email") && documentSnapshot.GetValue<string>("Texto") == Convert.ToString(frase))
                    {
                        await documentSnapshot.Reference.DeleteAsync();
                    }
                }
            }
            catch
            {
                throw;
            }

            return Redirect(Convert.ToString(pathUrl));
        }


    }
}
