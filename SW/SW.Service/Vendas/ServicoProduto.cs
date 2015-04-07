using AutoMapper;
using SW.Core.Exceptions;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;
using SW.Service.Abstrato;

namespace SW.Service.Vendas
{
    public class ServicoProduto : ServicoAbstrato<Produto, int, IRepositorioProduto>, IServicoProduto
    {
        public ServicoProduto(IRepositorioProduto repositorio) : base(repositorio) { }

        public ListagemProdutoViewModel FindListagem()
        {
            return Repositorio.FindListagem();
        }

        public void ExcluirProduto(string idSerializado)
        {
            var viewModel = new ProdutoViewModel
            {
                IdSerializado = idSerializado
            };
            Repositorio.Delete(viewModel.Id)
                .Save();
        }

        public void SalvarProduto(ProdutoViewModel viewModel)
        {
            if (!viewModel.IsValid())
            {
                throw new CwException(viewModel.MensagensErro());
            }
            var produto = Mapper.Map<ProdutoViewModel, Produto>(viewModel);
            if (!produto.IsValid())
            {
                throw new CwException(produto.MensagensErro());
            }
            if (produto.Id > 0)
            {
                var produtoAlterado = DefinirDadosProduto(produto);
                Update(produtoAlterado);
            }
            else
            {
                Insert(produto);
            }
            Save();
        }

        private Produto DefinirDadosProduto(Produto produto)
        {
            var produtoAlterado = FindById(produto.Id);
            produtoAlterado.Nome = produto.Nome;
            produtoAlterado.Preco = produto.Preco;
            produtoAlterado.PromocaoAtivaId = produto.PromocaoAtivaId;
            return produtoAlterado;
        }
    }
}
