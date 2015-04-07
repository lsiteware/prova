using System.Collections.Generic;
using AutoMapper;
using Microsoft.Practices.Unity;
using SW.Core.Exceptions;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;
using SW.Service.Abstrato;

namespace SW.Service.Vendas
{
    public class ServicoPromocao : ServicoAbstrato<Promocao, int, IRepositorioPromocao>, IServicoPromocao
    {
        [Dependency]
        public IServicoProduto ServicoProduto { get; set; }

        public ServicoPromocao(IRepositorioPromocao repositorio) : base(repositorio) { }

        public ListagemPromocaoViewModel FindListagem()
        {
            return Repositorio.FindListagem();
        }

        public void ExcluirPromocao(int id)
        {
            RemoverAssociacaoPromocao(id);
            Repositorio.Delete(id)
                .Save();
        }

        private void RemoverAssociacaoPromocao(int id)
        {
            IEnumerable<Produto> listaProdutosAlterar = ServicoProduto.FindAll(p => p.PromocaoAtivaId == id);
            listaProdutosAlterar.Each(p => p.PromocaoAtivaId = null);
            ServicoProduto.Save();
        }

        public void SalvarPromocao(PromocaoViewModel viewModel)
        {
            if (!viewModel.IsValid())
            {
                throw new CwException(viewModel.MensagensErro());
            }
            var promocao = Mapper.Map<PromocaoViewModel, Promocao>(viewModel);
            if (!promocao.IsValid())
            {
                throw new CwException(promocao.MensagensErro());
            }
            if (promocao.Id > 0)
            {
                var promocaoAlterada = DefinirDadosPromocao(promocao);
                Update(promocaoAlterada);
            }
            else
            {
                Insert(promocao);
            }
            Save();
        }

        private Promocao DefinirDadosPromocao(Promocao promocao)
        {
            var promocaoAlterada = FindById(promocao.Id);
            promocaoAlterada.Nome = promocao.Nome;
            promocaoAlterada.QuantidadeProdutos = promocao.QuantidadeProdutos;
            promocaoAlterada.TipoCobranca = promocao.TipoCobranca;
            promocaoAlterada.ValorFixo = promocao.ValorFixo;
            return promocaoAlterada;
        }
    }
}
