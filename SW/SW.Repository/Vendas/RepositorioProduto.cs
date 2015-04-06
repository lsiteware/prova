using AutoMapper;
using SW.Domain.Context;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;
using SW.Repository.Abstrato;

namespace SW.Repository.Vendas
{
    public class RepositorioProduto : RepositorioAbstrato<Produto, int>, IRepositorioProduto
    {
        public RepositorioProduto(SwDbContext context) : base(context) { }

        public ListagemProdutoViewModel FindListagem()
        {
            var listagem = new ListagemProdutoViewModel();
            foreach (var prod in FindAll())
            {
                listagem.Lista.Add(Mapper.Map<Produto, ProdutoViewModel>(prod));
            }
            return listagem;
        }
    }
}
