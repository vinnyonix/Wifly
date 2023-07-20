namespace WiflyBetApi
{
    public class DiretorDeBanca : IDiretorDeBanca
    {
        private Banca banca;
        public DiretorDeBanca(IBanco banco)
        {
            banca = new Banca(banco);
        }

        public void Apostar(Aposta aposta)
        {
            banca.Apostar(aposta);
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
    }
}
