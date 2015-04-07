using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SW.Core.Exceptions;
using SW.Domain.Vendas.ViewModels;
using SW.Resources;
using SW.Service.Vendas;
using SW.Web.Extensions;

namespace SW.Web.Controllers.Vendas
{
    public class CarrinhoComprasController : Controller
    {
        #region Propriedades

        [Dependency]
        public IServicoProduto ServicoProduto { get; set; }

        [Dependency]
        public IServicoCarrinhoCompras ServicoCarrinhoCompras { get; set; }

        private CarrinhoComprasViewModel CarrinhoCompras
        {
            get
            {
                if (Session["CARRINHO"] == null)
                {
                    Session["CARRINHO"] = new CarrinhoComprasViewModel();
                }
                return Session["CARRINHO"] as CarrinhoComprasViewModel;
            }
            set { Session["CARRINHO"] = value; }
        }

        #endregion

        #region Actions GET

        public ActionResult _PartialListagem()
        {
            return PartialView("_PartialListagem", CarrinhoCompras);
        }

        public ActionResult AdicionarProduto()
        {
            CarregarListaProdutos();
            return PartialView("_PartialEditar", new CarrinhoComprasItemViewModel());
        }

        public JavaScriptResult ExcluirProdutoCarrinho(int id)
        {
            StringBuilder scripts = new StringBuilder();
            scripts.AppendLine("VerificarMensagemTempData();");
            scripts.AppendLine("CarregarCarrinhoCompras();");
            try
            {
                ServicoCarrinhoCompras.RemoverProduto(CarrinhoCompras, id);
                this.AddMenssagemSucesso(TITULO.SUCESSO, MENSAGEM.PRODUTO_EXCLUIDO_SUCESSO, 3000);
            }
            catch (CwException ex)
            {
                this.AddMenssagensErro(TITULO.ERRO, ex.Erros, 3000);
            }
            return new JavaScriptResult { Script = scripts.ToString() };
        }

        #endregion

        #region Actions POST

        [HttpPost]
        public JavaScriptResult AdicionarProduto(CarrinhoComprasItemViewModel viewModel)
        {
            var scripts = new StringBuilder();
            scripts.AppendLine("VerificarMensagemTempData();");
            try
            {
                ServicoCarrinhoCompras.AdicionarProduto(CarrinhoCompras, viewModel.ProdutoId, viewModel.Quantidade);
                scripts.AppendLine("CarregarCarrinhoCompras();");
                scripts.AppendLine("FecharModalEdicao();");
                this.AddMenssagemSucesso(TITULO.SUCESSO, MENSAGEM.CARRINHO_COMPRAS_PRODUTO_ADICIONADO_SUCESSO, 3000);
            }
            catch (CwException ex)
            {
                this.AddMenssagensErro(TITULO.ERRO, ex.Erros, 3000);
            }
            return new JavaScriptResult { Script = scripts.ToString() };
        }

        #endregion

        #region Métodos

        private void CarregarListaProdutos()
        {
            ViewBag.ListaProdutos = from prod in ServicoProduto.FindAll()
                                    select new SelectListItem
                                    {
                                        Selected = false,
                                        Text = prod.Nome,
                                        Value = prod.Id.ToString()
                                    };
        }

        #endregion
    }
}
