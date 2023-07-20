using WiflyBetApi.Enums;

namespace WiflyBetApi.Models
{
    public class Aposta
    {
        public Aposta(string apostador, decimal valor)
        {
            ApostaId = Guid.NewGuid();
            Apostador = apostador == string.Empty ? DateTime.Now.ToString() : apostador;
            Valor = valor;
            ApostaStatus = ApostaStatus.Aguardando;
            Chance = 0.1f;
        }
        public Guid ApostaId { get; set; }
        public float Chance { get; set; }
        public string Apostador { get; set; }
        public decimal Valor { get; private set; }
        public PremiacaoInfo Premiacao { get; private set; }
        int Percentual { get; set; }
        public ApostaStatus ApostaStatus { get; set; }

        public void AlterarStatus(ApostaStatus novoStatus)
        {
            ApostaStatus = novoStatus;
        }

        public void AtribuirPremiacao(PremiacaoInfo premiacao)
        {
            Premiacao = premiacao;
        }
    }
}
