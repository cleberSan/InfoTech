using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
    public class CadastroController : Controller
    {

        #region :: GrupoProduto ::

        // GET: Cadastro
        private static List<GrupoProdutoModel> _listaGrupoProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel() { Id=1, Nome="Teclados", Ativo=true },
            new GrupoProdutoModel() { Id=2, Nome="Mouses", Ativo=true },
            new GrupoProdutoModel() { Id=3, Nome="Monitores", Ativo=false }
        };

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(_listaGrupoProduto);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(_listaGrupoProduto.Find(x => x.Id == id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            var ret = false;
            var registroBD = _listaGrupoProduto.Find(x => x.Id == id);
            if (registroBD != null)
            {
                _listaGrupoProduto.Remove(registroBD);
                ret = true;
            }
            return Json(ret);
        }
        [HttpPost]
        [Authorize]
        public ActionResult SalvarGrupoProduto(GrupoProdutoModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;
            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var registroBD = _listaGrupoProduto.Find(x => x.Id == model.Id);
                    if (registroBD == null)
                    {
                        registroBD = model;
                        registroBD.Id = _listaGrupoProduto.Max(x => x.Id) + 1;
                        _listaGrupoProduto.Add(registroBD);
                    }
                    else
                    {
                        registroBD.Nome = model.Nome;
                        registroBD.Ativo = model.Ativo;
                    }

                    idSalvo = registroBD.Id.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";

                }
            }
            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        #endregion

        #region :: MarcaProduto ::

        // GET: Cadastro
        private static List<MarcaProduto> _listaMarcaProduto = new List<MarcaProduto>()
        {
            new MarcaProduto() { Id=1, Nome="Hyper-X"},
            new MarcaProduto() { Id=2, Nome="Razer"},
            new MarcaProduto() { Id=3, Nome="Corsair"}
        };
        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View(_listaMarcaProduto);
        }
        [HttpPost]
        [Authorize]
        public ActionResult RecuperarMarcaProduto(int id)
        {
            return Json(_listaMarcaProduto.Find(x => x.Id == id));
        }
        [HttpPost]
        [Authorize]
        public ActionResult ExcluirMarcaProduto(int id)
        {
            var ret = false;
            var registroBD = _listaMarcaProduto.Find(x => x.Id == id);
            if (registroBD != null)
            {
                _listaMarcaProduto.Remove(registroBD);
                ret = true;
            }
            return Json(ret);
        }
        [HttpPost]
        [Authorize]
        public ActionResult SalvarMarcaProduto(MarcaProduto model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;
            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var registroBD = _listaMarcaProduto.Find(x => x.Id == model.Id);
                    if (registroBD == null)
                    {
                        registroBD = model;
                        registroBD.Id = _listaMarcaProduto.Max(x => x.Id) + 1;
                        _listaMarcaProduto.Add(registroBD);
                    }
                    else
                    {
                        registroBD.Nome = model.Nome;
                    }

                    idSalvo = registroBD.Id.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";

                }
            }
            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        #endregion

        #region :: LocalProduto ::

        [Authorize]
        public ActionResult LocalProduto()
        {
            return View();
        }

        #endregion

        #region :: UnidadeMedida :: 

        [Authorize]
        public ActionResult UnidadeMedida()
        {
            return View();
        }

        #endregion

        #region :: Produto ::

        private static List<Produto> _listaProduto = new List<Produto>()
        {
            new Produto() { Id=1, Nome="Notebook Dell"},
            new Produto() { Id=2, Nome="Mouse Gamer Logitech G402"},
            new Produto() { Id=3, Nome="Mouse Dell"},
            new Produto() { Id=4, Nome="Teclado Dell"},
            new Produto() { Id=5, Nome="Monitor Dell"},
            new Produto() { Id=6, Nome="Computador Dell"},
            new Produto() { Id=7, Nome="Computador Positivo"},
            new Produto() { Id=8, Nome="Notebook Acer Aspire 4740"},
            new Produto() { Id=9, Nome="Computador Acer"},
        };

        [HttpPost]
        [Authorize]
        public ActionResult SalvarProduto(Produto model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;
            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var registroBD = _listaProduto.Find(x => x.Id == model.Id);
                    if (registroBD == null)
                    {
                        registroBD = model;
                        registroBD.Id = _listaProduto.Max(x => x.Id) + 1;
                        _listaProduto.Add(registroBD);
                    }
                    else
                    {
                        registroBD.Nome = model.Nome;
                        registroBD.Ativo = model.Ativo;
                    }

                    idSalvo = registroBD.Id.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";

                }
            }
            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirProduto(int id)
        {
            var ret = false;
            var registroBD = _listaProduto.Find(x => x.Id == id);
            if (registroBD != null)
            {
                _listaProduto.Remove(registroBD);
                ret = true;
            }
            return Json(ret);
        }

        [Authorize]
        public ActionResult Produto()
        {
            return View(_listaProduto);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarProduto(int id)
        {
            return Json(_listaProduto.Find(x => x.Id == id));
        }

        #endregion

        #region :: Fornecedor ::

        private static List<FornecedorModel> _listaFornecedor = new List<FornecedorModel>()
        {
            // Fornecedor Nome
            new FornecedorModel() { Id=1, Nome="Dell Inc.", Ativo=true },
            new FornecedorModel() { Id=2, Nome="CodeDice tecnology", Ativo=true },
            new FornecedorModel() { Id=3, Nome="Forte Tech", Ativo=true },

            // Fornecedor Contrato
            new FornecedorModel() { Id=1, Contrato="00039110", Ativo=true },
            new FornecedorModel() { Id=1, Contrato="00039120", Ativo=true },
            new FornecedorModel() { Id=1, Contrato="00039130", Ativo=true },

            // Fornecedor Estado
            new FornecedorModel() { Id=1, Estado="Texas", Ativo=true },
            new FornecedorModel() { Id=1, Estado="Rio de Janeiro", Ativo=true },
            new FornecedorModel() { Id=1, Estado="São Paulo", Ativo=true },

            // Fornecedor Pais 
            new FornecedorModel() { Id=1, Pais="Estados Unidos", Ativo=true },
            new FornecedorModel() { Id=1, Pais="Brasil", Ativo=true },
            new FornecedorModel() { Id=1, Pais="Brasil", Ativo=true },
        };

        [Authorize]
        public ActionResult Fornecedor()
        {
            return View(_listaFornecedor);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarFornecedor(int id)
        {
            return Json(_listaFornecedor.Find(f => f.Id == id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirFornecedor(int id)
        {
            var retor = false;
            var registroBD = _listaFornecedor.Find(f => f.Id == id);
            
            if (registroBD != null)
            {
                _listaFornecedor.Remove(registroBD);
                retor = true;
            }

            return Json(retor);
        }

        [HttpPost]
        [Authorize]
        public ActionResult SalvarFornecedor(FornecedorModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(f => f.Errors).Select(f => f.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var registroBD = _listaFornecedor.Find(f => f.Id == model.Id);
                    if (registroBD == null)
                    {
                        registroBD = model;
                        registroBD.Id = _listaFornecedor.Max(f => f.Id) + 1;
                        _listaFornecedor.Add(registroBD);
                    }
                    else
                    {
                        registroBD.Nome = model.Nome;
                        registroBD.Contrato = model.Contrato;
                        registroBD.Estado = model.Estado;
                        registroBD.Pais = model.Pais;
                        registroBD.Ativo = model.Ativo;
                    }

                    idSalvo = registroBD.Id.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }
            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        #endregion
    }
}