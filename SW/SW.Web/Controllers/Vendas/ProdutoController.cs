using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Practices.Unity;
using SW.Core.Exceptions;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;
using SW.Resources;
using SW.Service.Vendas;
using SW.Web.Extensions;

namespace SW.Web.Controllers.Vendas
{
    public class ProdutoController : Controller
    {
        [Dependency]
        public IServicoProduto ServicoProduto { get; set; }

        [Dependency]
        public IServicoPromocao ServicoPromocao { get; set; }

        #region Actions GET

        public ActionResult _PartialListagem()
        {
            return View(ServicoProduto.FindListagem());
        }

        public JavaScriptResult ExcluirProduto(string id)
        {
            StringBuilder scripts = new StringBuilder();
            scripts.AppendLine("VerificarMensagemTempData();");
            scripts.AppendLine("CarregarListagemProdutos();");
            try
            {
                ServicoProduto.ExcluirProduto(id);
                this.AddMenssagemSucesso(TITULO.SUCESSO, MENSAGEM.PRODUTO_EXCLUIDO_SUCESSO, 3000);
            }
            catch (CwException ex)
            {
                this.AddMenssagensErro(TITULO.ERRO, ex.Erros, 3000);
            }
            return new JavaScriptResult { Script = scripts.ToString() };
        }

        public ActionResult NovoProduto()
        {
            CarregarListaPromocoes(null);
            return PartialView("_PartialEditar", new ProdutoViewModel());
        }

        public ActionResult EditarProduto(string id)
        {
            var viewModel = new ProdutoViewModel { IdSerializado = id };
            var databaseProduto = ServicoProduto.FindById(viewModel.Id);
            CarregarListaPromocoes(databaseProduto.PromocaoAtivaId);
            return PartialView("_PartialEditar", Mapper.Map<Produto, ProdutoViewModel>(databaseProduto));
        }

        #endregion

        #region Actions POST

        [HttpPost]
        public JavaScriptResult SalvarProduto(ProdutoViewModel viewModel)
        {
            var scripts = new StringBuilder();
            scripts.AppendLine("VerificarMensagemTempData();");
            try
            {
                ServicoProduto.SalvarProduto(viewModel);
                scripts.AppendLine("CarregarListagemProdutos();");
                scripts.AppendLine("FecharModalEdicao();");
                this.AddMenssagemSucesso(TITULO.SUCESSO, MENSAGEM.PRODUTO_INCLUIDO_SUCESSO, 3000);
            }
            catch (CwException ex)
            {
                this.AddMenssagensErro(TITULO.ERRO, ex.Erros, 3000);
            }
            return new JavaScriptResult{ Script = scripts.ToString() };
        }

        #endregion

        #region Métodos

        private void CarregarListaPromocoes(int? promocaoAtiva)
        {
            ViewBag.ListaPromocoes = from prom in ServicoPromocao.FindAll()
                select new SelectListItem
                {
                    Selected = prom.Id == promocaoAtiva,
                    Text = prom.Nome,
                    Value = prom.Id.ToString()
                };
        }

        #endregion
    }
}
