using System.Timers;
using WiflyBetApi.Enums;
using WiflyBetApi.Extensions;
using WiflyBetApi.Interfaces;

namespace WiflyBetApi.Models
{
    public class DiretorDeBanca : IDiretorDeBanca
    {
        private Banca banca;
        private static System.Timers.Timer? _temporizador;
        private int contador = 60;
        private readonly object bancaLock = new();

        public DiretorDeBanca(IBanco banco)
        {
            banca = new Banca(banco);
            ContadorConfig();
        }

        public void Apostar(Aposta aposta)
        {
            lock (bancaLock)
            {
                banca.Apostar(aposta);
            }
        }

        public List<Aposta> ListaDeApostas()
        {
            return banca.ListaDeApostas;
        }

        public decimal ValorTotalDasApostas()
        {
            return banca.ValorTotalDasApostas();
        }

        public decimal QtdeApostas()
        {
            return banca.QtdeApostas();
        }

        void ContadorConfig()
        {
            _temporizador = new System.Timers.Timer(1000);
            _temporizador.Elapsed += Contador;
            _temporizador.AutoReset = true;
            _temporizador.Enabled = true;
            _temporizador.Start();
        }

        private void Contador(object sender, ElapsedEventArgs e)
        {
            lock (bancaLock)
            {
                if (contador == 0)
                {
                    banca.Finalizar();

                    banca = new Banca(new Banco());
                    MetodosDeExtensao.MensagemColorida("nova banca iniciada", banca.BancaId.ToString(), MensagemTipo.Magenta);

                    contador = 60;
                }
               
                contador--;
            }
        }
    }
}
