using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyToFind.Models;

namespace EasyToFind.Controllers
{
    public class ComidaController : Controller
    {
        [HttpGet]
        public IActionResult View1()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Bebidas()
        {
            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "agua.png", Descricao ="Água" });
            model.Add(new ModelBotoes { NomeImagem = "bagaço.png", Descricao = "Bagaço" });
            model.Add(new ModelBotoes { NomeImagem = "bebida-de-coco.png", Descricao = "Água de Coco" });
            model.Add(new ModelBotoes { NomeImagem = "cafe.png", Descricao = "Café" });
            model.Add(new ModelBotoes { NomeImagem = "champagne.png", Descricao = "Champagne" });
            model.Add(new ModelBotoes { NomeImagem = "leite.png", Descricao = "Leite" });
            model.Add(new ModelBotoes { NomeImagem = "licor.png", Descricao = "Licor" });
            model.Add(new ModelBotoes { NomeImagem = "Limonada.png", Descricao = "Limonada" });
            model.Add(new ModelBotoes { NomeImagem = "martini.png", Descricao = "Martini" });
            model.Add(new ModelBotoes { NomeImagem = "sumo.png", Descricao = "Sumo" });
            model.Add(new ModelBotoes { NomeImagem = "vinho.png", Descricao = "Vinho" });
            model.Add(new ModelBotoes { NomeImagem = "vodka.png", Descricao = "Vodka" });

            return View(model);            
        }


        [HttpGet]
        public IActionResult Frutas()
        {
            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "abacaxi.png", Descricao = "Abacaxi" });
            model.Add(new ModelBotoes { NomeImagem = "ameixa.png", Descricao = "Ameixa" });
            model.Add(new ModelBotoes { NomeImagem = "banana.png", Descricao = "Banana" });
            model.Add(new ModelBotoes { NomeImagem = "cerejas.png", Descricao = "Cerejas" });
            model.Add(new ModelBotoes { NomeImagem = "frutos-secos.png", Descricao = "Frutos Secos" });
            model.Add(new ModelBotoes { NomeImagem = "kiwi.png", Descricao = "Kiwi" });
            model.Add(new ModelBotoes { NomeImagem = "laranja.png", Descricao = "Laranja" });
            model.Add(new ModelBotoes { NomeImagem = "maca.png", Descricao = "Maçã" });
            model.Add(new ModelBotoes { NomeImagem = "morango.png", Descricao = "Morango" });
            model.Add(new ModelBotoes { NomeImagem = "pera.png", Descricao = "Pera" });
            model.Add(new ModelBotoes { NomeImagem = "pessego.png", Descricao = "Pessego" });
            model.Add(new ModelBotoes { NomeImagem = "uvas.png", Descricao = "Uvas" });

            return View(model);
        }

        [HttpGet]
        public IActionResult Outras()
        {
            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "bolo.png", Descricao = "Bolo" });
            model.Add(new ModelBotoes { NomeImagem = "comida-saudavel.png", Descricao = "Vegetais" });
            model.Add(new ModelBotoes { NomeImagem = "comida-vegana.png", Descricao = "Vegan" });
            model.Add(new ModelBotoes { NomeImagem = "doces.png", Descricao = "Doces" });
            model.Add(new ModelBotoes { NomeImagem = "donuts.png", Descricao = "Donuts" });
            model.Add(new ModelBotoes { NomeImagem = "especiaria.png", Descricao = "Especiarias" });
            model.Add(new ModelBotoes { NomeImagem = "gelado.png", Descricao = "Gelados" });
            model.Add(new ModelBotoes { NomeImagem = "massa.png", Descricao = "Massa" });
            model.Add(new ModelBotoes { NomeImagem = "melao.png", Descricao = "Melão" });
            model.Add(new ModelBotoes { NomeImagem = "panquecas.png", Descricao = "Panquecas" });
            model.Add(new ModelBotoes { NomeImagem = "pudim.png", Descricao = "Pudim" });
            model.Add(new ModelBotoes { NomeImagem = "sobremesa.png", Descricao = "Sobremesas" });

            return View(model);
        }

        [HttpGet]
        public IActionResult Pratos()
        {
            var model = new List<ModelBotoes>();

            model.Add(new ModelBotoes { NomeImagem = "assado.png", Descricao = "Assado" });
            model.Add(new ModelBotoes { NomeImagem = "comida-de-carne.png", Descricao = "Estufado" });
            model.Add(new ModelBotoes { NomeImagem = "comida-nao-saudavel.png", Descricao = "Fast Food" });
            model.Add(new ModelBotoes { NomeImagem = "fritos.png", Descricao = "Fritos" });
            model.Add(new ModelBotoes { NomeImagem = "grelhado.png", Descricao = "Grelhados" });
            model.Add(new ModelBotoes { NomeImagem = "guisado.png", Descricao = "Guisados" });
            model.Add(new ModelBotoes { NomeImagem = "leguminosas.png", Descricao = "Leguminosas" });
            model.Add(new ModelBotoes { NomeImagem = "massa.png", Descricao = "Massa" });
            model.Add(new ModelBotoes { NomeImagem = "ovo-cozido.png", Descricao = "Cozidos" });
            model.Add(new ModelBotoes { NomeImagem = "peixe.png", Descricao = "Saudáveis" });
            model.Add(new ModelBotoes { NomeImagem = "prato-vegetariano.png", Descricao = "Vegetariano" });
            model.Add(new ModelBotoes { NomeImagem = "tigela-de-arroz.png", Descricao = "Arroz" });

            return View(model);
        }
    }
}
