﻿using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;
using SW.Service.Abstrato;

namespace SW.Service.Vendas
{
    public interface IServicoProduto : IServicoAbstrato<Produto, int>
    {
        ListagemProdutoViewModel FindListagem();

        void ExcluirProduto(int id);

        void SalvarProduto(ProdutoViewModel viewModel);
    }
}
