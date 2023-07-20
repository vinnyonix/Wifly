using Microsoft.AspNetCore.Mvc;
using WiflyBetApi.Interfaces;
using WiflyBetApi.Models;

namespace WiflyBetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ManagerController : ControllerBase
    {
        private IDiretorDeBanca _diretorDeBanca;
        public ManagerController(IDiretorDeBanca diretorDeBanca)
        {
            _diretorDeBanca = diretorDeBanca;
        }

        [HttpGet("apostar")]
        public void Apostar(decimal valor) 
        {
            _diretorDeBanca.Apostar(new(apostador: "", valor: valor));
        }

        [HttpGet("listadeapostas")]
        public List<Aposta> Apostas()
        {
            return _diretorDeBanca.ListaDeApostas();
        }

        [HttpGet("valortotaldasapostas")]
        public decimal ValorTotalDasApostas()
        {
            return _diretorDeBanca.ValorTotalDasApostas();
        }
    }
}
