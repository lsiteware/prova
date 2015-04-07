using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Practices.Unity;
using SW.Core.Exceptions;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.Enumeradores;
using SW.Domain.Vendas.ViewModels;
using SW.Resources;
using SW.Service.Vendas;
using SW.Web.Extensions;

namespace SW.Web.Controllers.Vendas
{
    public class PromocaoController : Controller
    {
        [Dependency]
        public IServicoPromocao ServicoPromocao { get; set; }

        public ActionResult _PartialListagem()
        {
            return View(ServicoPromocao.FindListagem());
        }

        public JavaScriptResult ExcluirPromocao(int id)
        {
            StringBuilder scripts = new StringBuilder();
            scripts.AppendLine("VerificarMensagemTempData();");
            scripts.AppendLine("CarregarListagemProdutos();");
            scripts.AppendLine("CarregarListagemPromocoes();");
            try
            {
                ServicoPromocao.ExcluirPromocao(id);
                this.AddMenssagemSucesso(TITULO.SUCESSO, MENSAGEM.PROMOCAO_EXCLUIDO_SUCESSO, 3000);
            }
            catch (Exception ex)
            {
                this.AddMenssagemErro(TITULO.ERRO, ex.Message, 3000);
            }
            return new JavaScriptResult { Script = scripts.ToString() };
        }

        public ActionResult NovaPromocao()
        {
            CarregarListaTipoCobranca(PromocaoTipoCobranca.Media);
            return PartialView("_PartialEditar", new PromocaoViewModel());
        }

        public ActionResult EditarPromocao(int id)
        {
            var databasePromocao = ServicoPromocao.FindById(id);
            CarregarListaTipoCobranca(databasePromocao.TipoCobranca);
            return PartialView("_PartialEditar", Mapper.Map<Promocao, PromocaoViewModel>(databasePromocao));
        }

        #region Actions POST

        [HttpPost]
        public JavaScriptResult SalvarPromocao(PromocaoViewModel viewModel)
        {
            var scripts = new StringBuilder();
            scripts.AppendLine("VerificarMensagemTempData();");
            try
            {
                ServicoPromocao.SalvarPromocao(viewModel);
                scripts.AppendLine("CarregarListagemPromocoes();");
                scripts.AppendLine("FecharModalEdicao();");
                this.AddMenssagemSucesso(TITULO.SUCESSO, MENSAGEM.PROMOCAO_SALVA_SUCESSO, 3000);
            }
            catch (CwException ex)
            {
                this.AddMenssagensErro(TITULO.ERRO, ex.Erros, 3000);
            }
            return new JavaScriptResult { Script = scripts.ToString() };
        }

        #endregion

        #region Métodos

        private void CarregarListaTipoCobranca(PromocaoTipoCobranca tipoCobranca)
        {
            var listaItens = new List<SelectListItem>();
            listaItens.Add(new SelectListItem { Selected = tipoCobranca == PromocaoTipoCobranca.Media, Text = "Media", Value = "Media" });
            listaItens.Add(new SelectListItem { Selected = tipoCobranca == PromocaoTipoCobranca.ValorFixo, Text = "ValorFixo", Value = "ValorFixo" });
            ViewBag.ListaTipoCobranca = listaItens;
        }

        #endregion
    }
}
