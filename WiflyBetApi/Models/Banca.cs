using WiflyBetApi.Enums;
using WiflyBetApi.Extensions;
using WiflyBetApi.Interfaces;

namespace WiflyBetApi.Models
{
    public class Banca
    {
        private IBanco _banco;

        public Banca(IBanco banco)
        {
            // Define o valor inicial da banca de 1000;
            decimal valorDeAbertura = 1000;

            //Instancia o banco, retira 1000 para iniciar a banca e adiciona na banca;
            _banco = banco;
            _banco.Remover(valorDeAbertura);
            ContaDeRetencao = valorDeAbertura / 2;
            ContaDePagamentoDisponivel = valorDeAbertura / 2;

            // Gera Id e inicializa a instância da lista de apostas que a banca vai gerenciar.
            BancaId = Guid.NewGuid();
            ListaDeApostas = new List<Aposta>();
        }

        public Guid BancaId { get; private set; }
        public decimal ContaDeRetencao { get; private set; }
        public decimal ContaDePagamentoDisponivel { get; private set; }
        public decimal ContaDePagamentoEfetuado { get; private set; }
        public List<Aposta> ListaDeApostas { get; private set; }

        public void Apostar(Aposta aposta)
        {
            ListaDeApostas.Add(aposta);
            ContaDeRetencao = ContaDeRetencao + aposta.Valor / 2;
            ContaDePagamentoDisponivel = ContaDePagamentoDisponivel + aposta.Valor / 2;
            Rodar(aposta);
        }

        public decimal ValorTotalDasApostas()
        {
            var total = ListaDeApostas.Sum(a => a.Valor);
            return total;
        }

        public int QtdeApostas()
        {
            return ListaDeApostas.Count;
        }

        public int QtdeApostasVencedoras()
        {
            return ListaDeApostas.Count(a => a.ApostaStatus == ApostaStatus.Vitoria);
        }

        public void Rodar(Aposta aposta)
        {
            var numeroSorteado = new Random().NextDouble();
            if (numeroSorteado < aposta.Chance)
            {
                aposta.AlterarStatus(ApostaStatus.Vitoria);
                Tesouro(aposta);

                MetodosDeExtensao.MensagemColorida("", "", MensagemTipo.Padrao);
                MetodosDeExtensao.MensagemColorida("Aposta Id", aposta.ApostaId.ToString(), "valor", aposta.Valor.ToString(), "Status", aposta.ApostaStatus.ToString(), MensagemTipo.Sucesso);
                MetodosDeExtensao.MensagemColorida("multiplicador", aposta.Premiacao.Multiplicador.ToString(), "valor disponível na banca", aposta.Premiacao.ValorLimiteDePagamento.ToString(), MensagemTipo.Sucesso);
                MetodosDeExtensao.MensagemColorida("conta de pagamento", ContaDePagamentoDisponivel.ToString(), MensagemTipo.Sucesso);
                MetodosDeExtensao.MensagemColorida("valor premiado", aposta.Premiacao.Valor.ToString(), MensagemTipo.Sucesso);
                MetodosDeExtensao.MensagemColorida("", "", MensagemTipo.Padrao);
            }
            else
            {
                aposta.AlterarStatus(ApostaStatus.Derrota);
                MetodosDeExtensao.MensagemColorida("Aposta Id", aposta.ApostaId.ToString(), "valor", aposta.Valor.ToString(), "Status", aposta.ApostaStatus.ToString(), MensagemTipo.Cinza);
            }
        }

        private void Tesouro(Aposta aposta)
        {
            // Cria uma lista de multiplicadores.
            var listaDeMultiplicacao = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 42, 44, 46, 48, 50, 53, 56, 59, 63, 67, 72, 77, 83, 89, 95, 100 };

            var listaDeChances = new List<PremiacaoInfo>();

            var valorDaAposta = aposta.Valor;

            // Define o valor máximo de pagamento 1000. se na banca contém menos que isso, então o valor máximo será este valor,
            // porém se a banca tiver com mais que 1000 não pagará mais que isso.
            decimal valorLimiteDePagamento = ContaDePagamentoDisponivel < 1000 ? ContaDePagamentoDisponivel : 1000;

            for (int i = listaDeMultiplicacao.Count - 1; i >= 0; i--)
            {
                var apostaMultiplicada = valorDaAposta * listaDeMultiplicacao[i];
                if (apostaMultiplicada <= valorLimiteDePagamento)
                {
                    var fatorDeChance = valorLimiteDePagamento / apostaMultiplicada;
                    for (int p = 0; p < (int)fatorDeChance; p++)
                    {
                        var premiacaoInfo = new PremiacaoInfo();
                        premiacaoInfo.Multiplicador = listaDeMultiplicacao[i];
                        premiacaoInfo.Valor = apostaMultiplicada;
                        premiacaoInfo.Fator = (int)fatorDeChance;
                        premiacaoInfo.ValorLimiteDePagamento = valorLimiteDePagamento;
                        listaDeChances.Add(premiacaoInfo);
                    }
                }
            }

            var premioIndex = new Random().NextInt64(0, listaDeChances.Count);
            var index = (int)premioIndex;
            var premio = listaDeChances[index];
            aposta.AtribuirPremiacao(premio);

            ContaDePagamentoDisponivel = ContaDePagamentoDisponivel - aposta.Premiacao.Valor;
            ContaDePagamentoEfetuado = ContaDePagamentoEfetuado + aposta.Premiacao.Valor;
        }

        public void Finalizar() 
        {
            // Se a conta de pagamento ainda resta algum valor, este valor é retornado para o cofre do banco.
            if (ContaDePagamentoDisponivel > 0) {
                _banco.Adicionar(ContaDePagamentoDisponivel);
            }
        }
    }
}
