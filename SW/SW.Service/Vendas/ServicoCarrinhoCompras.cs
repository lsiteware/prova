using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using SW.Core.Exceptions;
using SW.Domain.Vendas.Enumeradores;
using SW.Domain.Vendas.ViewModels;
using SW.Resources;

namespace SW.Service.Vendas
{
    public class ServicoCarrinhoCompras : IServicoCarrinhoCompras
    {
        [Dependency]
        public IServicoProduto ServicoProduto { get; set; }

        [Dependency]
        public IServicoPromocao ServicoPromocao { get; set; }

        public void AdicionarProduto(CarrinhoComprasViewModel carrinhoCompras, int? produtoId, int? quantidade)
        {
            ValidarInclusaoProduto(produtoId, quantidade);
            var itemExistente = carrinhoCompras.Itens.FirstOrDefault(i => i.ProdutoId == produtoId);
            if (itemExistente == null)
            {
                var produto = ServicoProduto.FindById(produtoId.Value);
                itemExistente = new CarrinhoComprasItemViewModel
                {
                    Preco = produto.Preco,
                    ProdutoId = produto.Id,
                    ProdutoNome = produto.Nome,
                    PromocaoId = produto.PromocaoAtivaId,
                    PromocaoNome = produto.PromocaoAtiva == null ? "-" : produto.PromocaoAtiva.Nome,
                    Quantidade = quantidade.Value
                };
                carrinhoCompras.Itens.Add(itemExistente);
            }
            else
            {
                itemExistente.Quantidade += quantidade.Value;
            }
            CalcularPrecoTotalItem(itemExistente);
        }

        private void ValidarInclusaoProduto(int? produtoId, int? quantidade)
        {
            var erros = new List<string>();
            if (!produtoId.HasValue || (produtoId.HasValue && produtoId.Value == 0))
            {
                erros.Add(string.Format(MENSAGEM.ERRO_VALIDACAO_CAMPO_OBRIGATORIO, PROPRIEDADE.ITEM));
            }
            if (!quantidade.HasValue || (quantidade.HasValue && quantidade.Value == 0))
            {
                erros.Add(MENSAGEM.ERRO_CARRINHO_ADICIONAR_PRODUTO_QUANTIDADE_ZERADA);
            }
            if (erros.Any())
            {
                throw new CwException(erros);
            }
        }

        public void RemoverProduto(CarrinhoComprasViewModel carrinhoCompras, int produtoId)
        {
            carrinhoCompras.Itens.RemoveAll(i => i.ProdutoId == produtoId);
        }

        private void CalcularPrecoTotalItem(CarrinhoComprasItemViewModel item)
        {
            item.PrecoTotal = 0;
            if (item.PromocaoId.HasValue)
            {
                var promocao = ServicoPromocao.FindById(item.PromocaoId.Value);
                if (item.Quantidade >= promocao.QuantidadeProdutos)
                {
                    switch (promocao.TipoCobranca)
                    {
                        case PromocaoTipoCobranca.ValorUnico:
                        {
                            // Calcula e soma o "resto" da divisão (os que não entram no agrupamento)
                            int resto = item.Quantidade % promocao.QuantidadeProdutos;
                            // Soma os agrupamentos
                            item.PrecoTotal += (int)((item.Quantidade - resto) / promocao.QuantidadeProdutos) * item.Preco;
                            // Soma o "resto" da divisão (os que não entram no agrupamento)
                            item.PrecoTotal += (resto * item.Preco);
                            break;
                        }
                        case PromocaoTipoCobranca.ValorFixo:
                        {
                            // Calcula e soma o "resto" da divisão (os que não entram no agrupamento)
                            int resto = item.Quantidade % promocao.QuantidadeProdutos;
                            // Soma os agrupamentos
                            item.PrecoTotal += (int)((item.Quantidade - resto)/promocao.QuantidadeProdutos)*promocao.ValorFixo.Value;
                            // Soma o "resto" da divisão (os que não entram no agrupamento)
                            item.PrecoTotal += (resto*item.Preco);
                            break;
                        }
                    }
                }
                else
                {
                    item.PrecoTotal = item.Preco*item.Quantidade;
                }
            }
            else
            {
                item.PrecoTotal = item.Preco*item.Quantidade;
            }
        }
    }
}
