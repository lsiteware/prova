﻿using SW.Domain.Vendas.Entidades;
using SW.Domain.Vendas.ViewModels;
using SW.Service.Abstrato;

namespace SW.Service.Vendas
{
    public interface IServicoPromocao : IServicoAbstrato<Promocao, int>
    {
        ListagemPromocaoViewModel FindListagem();

        void ExcluirPromocao(int id);

        void SalvarPromocao(PromocaoViewModel viewModel);
    }
}
