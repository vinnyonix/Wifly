
using WiflyBetApi.Enums;

namespace WiflyBetApi.Models
{
    public class BancoMovimentacao
    {
        public BancoMovimentacao(decimal valor, BancoMovimentacaoTipo tipo)
        {
            DataHora = DateTime.Now;
            Valor = valor;
            BancoMovimentacaoTipo = tipo;
        }
        public DateTime DataHora { get; private set; }
        public decimal Valor { get; private set; }
        public BancoMovimentacaoTipo BancoMovimentacaoTipo { get; private set; }
    }
}
