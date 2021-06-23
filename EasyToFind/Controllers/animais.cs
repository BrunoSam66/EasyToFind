using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyToFind.Models;
using Microsoft.AspNetCore.Http;

namespace EasyToFind.Controllers
{
    public class animais : Controller
    {

        [HttpGet]
        public IActionResult View1()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var animais = new List<ModelBotoes>();

            animais.Add(new ModelBotoes { NomeImagem = "abelhas.png", Descricao = "Abelha" });
            animais.Add(new ModelBotoes { NomeImagem = "alpaca.png", Descricao = "Alpaca" });
            animais.Add(new ModelBotoes { NomeImagem = "amêijoa.png", Descricao = "Amêijoa" });
            animais.Add(new ModelBotoes { NomeImagem = "aranha.png", Descricao = "Aranha" });
            animais.Add(new ModelBotoes { NomeImagem = "avestruz.png", Descricao = "Avestruz" });
            animais.Add(new ModelBotoes { NomeImagem = "Baleia.png", Descricao = "Baleia" });
            animais.Add(new ModelBotoes { NomeImagem = "canguru.png", Descricao = "Canguru" });
            animais.Add(new ModelBotoes { NomeImagem = "coala.png", Descricao = "Coala" });
            animais.Add(new ModelBotoes { NomeImagem = "cobra.png", Descricao = "Cobra" });
            animais.Add(new ModelBotoes { NomeImagem = "Colibri.png", Descricao = "Colibri" });
            animais.Add(new ModelBotoes { NomeImagem = "coral.png", Descricao = "Coral" });
            animais.Add(new ModelBotoes { NomeImagem = "outras.png", Descricao = "Outras1" });

            return View("Animais", animais);
        }

        [HttpGet]
        public IActionResult View2()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var animais = new List<ModelBotoes>();
            animais.Add(new ModelBotoes { NomeImagem = "coruja.png", Descricao = "Coruja" });
            animais.Add(new ModelBotoes { NomeImagem = "Doninha.png", Descricao = "Doninha" });
            animais.Add(new ModelBotoes { NomeImagem = "escorpião.png", Descricao = "Escorpião" });
            animais.Add(new ModelBotoes { NomeImagem = "flamingo.png", Descricao = "Flamengo" });
            animais.Add(new ModelBotoes { NomeImagem = "formiga.png", Descricao = "Formiga" });
            animais.Add(new ModelBotoes { NomeImagem = "girafa.png", Descricao = "Girafa" });
            animais.Add(new ModelBotoes { NomeImagem = "golfinho.png", Descricao = "Golfinho" });
            animais.Add(new ModelBotoes { NomeImagem = "hiena.png", Descricao = "Hiena" });
            animais.Add(new ModelBotoes { NomeImagem = "Leão.png", Descricao = "Leão" });
            animais.Add(new ModelBotoes { NomeImagem = "leopardo.png", Descricao = "Leopardo" });
            animais.Add(new ModelBotoes { NomeImagem = "lobo.png", Descricao = "Lobo" });
            animais.Add(new ModelBotoes { NomeImagem = "outras.png", Descricao = "Outras2" });
            return View("Animais", animais);
        }

        [HttpGet]
        public IActionResult View3()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var animais = new List<ModelBotoes>();
            animais.Add(new ModelBotoes { NomeImagem = "macaco.png", Descricao = "Macaco" });
            animais.Add(new ModelBotoes { NomeImagem = "Orca.png", Descricao = "Orca" });
            animais.Add(new ModelBotoes { NomeImagem = "panda.png", Descricao = "Panda" });
            animais.Add(new ModelBotoes { NomeImagem = "pantera.png", Descricao = "Pantera" });
            animais.Add(new ModelBotoes { NomeImagem = "papagaio.png", Descricao = "Papagaio" });
            animais.Add(new ModelBotoes { NomeImagem = "Pinguim.png", Descricao = "Pinguim" });
            animais.Add(new ModelBotoes { NomeImagem = "Polvo.png", Descricao = "Polvo" });
            animais.Add(new ModelBotoes { NomeImagem = "pomba.png", Descricao = "Pomba" });
            animais.Add(new ModelBotoes { NomeImagem = "raposa.png", Descricao = "Raposa" });
            animais.Add(new ModelBotoes { NomeImagem = "rato.png", Descricao = "Rato" });
            animais.Add(new ModelBotoes { NomeImagem = "rena.png", Descricao = "Rena" });
            animais.Add(new ModelBotoes { NomeImagem = "outras.png", Descricao = "Outras3" });
            return View("Animais", animais);
        }

        [HttpGet]
        public IActionResult View4()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var animais = new List<ModelBotoes>();
            animais.Add(new ModelBotoes { NomeImagem = "rinoceronte.png", Descricao = "Rinoceronte" });
            animais.Add(new ModelBotoes { NomeImagem = "salamandra.png", Descricao = "Salamandra" });
            animais.Add(new ModelBotoes { NomeImagem = "sapo.png", Descricao = "Sapo" });
            animais.Add(new ModelBotoes { NomeImagem = "tataruga.png", Descricao = "Tartaruga" });
            animais.Add(new ModelBotoes { NomeImagem = "tigre.png", Descricao = "Tigre" });
            animais.Add(new ModelBotoes { NomeImagem = "toupeira.png", Descricao = "Toupeira" });
            animais.Add(new ModelBotoes { NomeImagem = "tubarão.png", Descricao = "Tubarão" });
            animais.Add(new ModelBotoes { NomeImagem = "tucano.png", Descricao = "Tucano" });
            animais.Add(new ModelBotoes { NomeImagem = "Urso Pardo.png", Descricao = "Urso Pardo" });
            animais.Add(new ModelBotoes { NomeImagem = "Urso Polar.png", Descricao = "Urso Polar" });
            animais.Add(new ModelBotoes { NomeImagem = "veado.png", Descricao = "Veado" });
            animais.Add(new ModelBotoes { NomeImagem = "Zebra.png", Descricao = "Zebra" });
            return View("Animais", animais);
        }

        [HttpPost]
        public IActionResult View1(string botao, string pathUrl)
        {
            if (botao == "Outras1")
            {
                return RedirectToAction("View2");
            }
            else if (botao == "Outras2")
            {
                return RedirectToAction("View3");
            }
            else if (botao == "Outras3")
            {
                return RedirectToAction("View4");
            }
            else
            {
                string texto = HttpContext.Session.GetString("texto");

                HttpContext.Session.SetString("texto", texto + " " + botao);
            }

            return Redirect(Convert.ToString(pathUrl));
        }
    }
}
