namespace WiflyBetApi
{
    public class Banco : IBanco
    {
        public Banco()
        {
            Movimentacao = new List<BancoMovimentacao>();
            Cofre = 50000;
        }

        public decimal Cofre { get; private set; }
        public List<BancoMovimentacao> Movimentacao { get; private set; }

        public void Adicionar(decimal valor)
        {
            Cofre += valor;
            Movimentacao.Add(new BancoMovimentacao(valor: valor, tipo: BancoMovimentacaoTipo.Deposito));
        }

        public void Remover(decimal valor) 
        {
            if ((Cofre - valor) > 0 ) { 
                Cofre -= valor;
                Movimentacao.Add(new BancoMovimentacao(valor: valor, tipo: BancoMovimentacaoTipo.Saque));
            }
        }
    }
}
