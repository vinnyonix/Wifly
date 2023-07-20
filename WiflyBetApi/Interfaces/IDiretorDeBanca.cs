using WiflyBetApi.Models;

namespace WiflyBetApi.Interfaces
{
    public interface IDiretorDeBanca
    {
        //public void NovaBanca(Banca novaBanca);
        public decimal ValorTotalDasApostas();
        public List<Aposta> ListaDeApostas();
        public void Apostar(Aposta aposta);
        public decimal QtdeApostas();
    }
}
