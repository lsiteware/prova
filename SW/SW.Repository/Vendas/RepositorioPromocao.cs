using AutoMapper;
using SW.Domain.Context;
using SW.Domain.Interfaces.Repositorio.Vendas;
using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;
using SW.Repository.Abstrato;

namespace SW.Repository.Vendas
{
    public class RepositorioPromocao : RepositorioAbstrato<Promocao, int>, IRepositorioPromocao
    {
        public RepositorioPromocao(SwDbContext context) : base(context) { }

        public ListagemPromocaoViewModel FindListagem()
        {
            var listagem = new ListagemPromocaoViewModel();
            foreach (var prom in FindAll())
            {
                listagem.Lista.Add(Mapper.Map<Promocao, PromocaoViewModel>(prom));
            }
            return listagem;
        }
    }
}
